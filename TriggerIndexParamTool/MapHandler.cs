/*
 * Copyright 2019-2022 by Starkku
 * This file is part of TriggerIndexParamTool, which is free software. It is made
 * available to you under the terms of the GNU General Public License
 * as published by the Free Software Foundation, either version 3 of
 * the License, or (at your option) any later version. For more
 * information, see LICENSE.txt.
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Starkku.Utilities;
using Starkku.Utilities.FileTypes;

namespace TriggerIndexParamTool
{
    static class MapHandler
    {
        private static readonly int[] STRUCTURE_SCRIPT_ACTIONS = new int[] { 46, 47, 56, 57, 58 };
        private static readonly int[] HOUSE_SCRIPT_ACTIONS = new int[] { 20 };

        public static void ProcessMaps(IEnumerable<string> mapFilenames, IEnumerable<Rule> rules)
        {
            foreach (string filename in mapFilenames)
            {
                if (!File.Exists(filename))
                {
                    Logger.Error("File '" + filename + "' does not exist.");
                    continue;
                }

                INIFile map = new INIFile(filename);

                Logger.Info("Processing file '" + filename + "'.");

                bool altered_events = HandleEvents(map, rules);
                bool altered_actions = HandleActions(map, rules);
                bool altered_scripts = HandleScripts(map, rules);

                if (altered_events || altered_actions || altered_scripts)
                {
                    string error = map.Save();

                    if (error != null)
                        Logger.Error("Error encountered when saving map file " + map.Filename + ". Message: " + error);
                    else
                        Logger.Info("Map file " + map.Filename + " saved successfully.");
                }
                else
                {
                    Logger.Info("No changes were made to map file " + map.Filename + ".");
                }
            }
        }

        private static bool HandleEvents(INIFile map, IEnumerable<Rule> rules)
        {
            List<EventActionItem> events = GetEventActionItems(map, "Events");

            if (events == null)
                return false;

            HandleItems(events, rules, EventParameterCollection.Parameters, "Event");
            return ApplyChanges(map, events, "Events");
        }

        private static bool HandleActions(INIFile map, IEnumerable<Rule> rules)
        {
            List<EventActionItem> actions = GetEventActionItems(map, "Actions");

            if (actions == null)
                return false;

            HandleItems(actions, rules, ActionParameterCollection.Parameters, "Action");

            return ApplyChanges(map, actions, "Actions");
        }

        private static List<EventActionItem> GetEventActionItems(INIFile map, string section)
        {
            List<EventActionItem> events = new List<EventActionItem>();
            string[] keys = map.GetKeys(section);

            if (keys == null)
                return events;

            bool parseActions = section == "Actions";

            foreach (string key in keys)
            {
                try
                {
                    EventActionItem eventKey = new EventActionItem(key);
                    string[] values = map.GetKey(section, key, "").Split(',');

                    if (values.Length < 1)
                        continue;

                    int count = Conversion.GetIntFromString(values[0], 0);
                    int valueCounter = 1;

                    for (int i = 0; i < count; i++)
                    {
                        string id = values[valueCounter++];
                        int flag = Conversion.GetIntFromString(values[valueCounter++], 0);
                        EventAction member = new EventAction(id, flag.ToString());

                        if (!parseActions)
                        {
                            member.Parameters.Add(new EventActionParameter(values[valueCounter++]));

                            if (flag > 1)
                                member.Parameters.Add(new EventActionParameter(values[valueCounter++]));
                        }
                        else
                        {
                            for (int j = 0; j < 6; j++)
                            {
                                member.Parameters.Add(new EventActionParameter(values[valueCounter++]));
                            }
                        }

                        eventKey.Members.Add(member);
                    }

                    events.Add(eventKey);
                }
                catch (Exception e)
                {
                    Logger.Error("Error encountered when parsing [" + section + "] key " + key + ". Message: " + e.Message);
                    return null;
                }
            }

            return events;
        }

        private static void HandleItems(List<EventActionItem> items, IEnumerable<Rule> rules, Dictionary<RuleCategory, ParameterType[]> parameterCollection, string label)
        {
            foreach (Rule rule in rules)
            {
                if (rule.RuleCategory == RuleCategory.Invalid)
                    return;

                ParameterType[] parameterTypes = parameterCollection[rule.RuleCategory];

                foreach (ParameterType parameterType in parameterTypes)
                {
                    var itemsMatch = items.Where(x => x.Members.Find(y => Conversion.GetIntFromString(y.ID, -1) == parameterType.ID) != null);

                    foreach (EventActionItem item in itemsMatch)
                    {
                        int memberCounter = 1;

                        foreach (EventAction itemMember in item.Members)
                        {
                            if (Conversion.GetIntFromString(itemMember.ID, -1) != parameterType.ID)
                                continue;

                            EventActionParameter parameter = itemMember.Parameters[parameterType.ParamPosition];
                            int tmp = Conversion.GetIntFromString(parameter.ParameterValue, -1);

                            if (tmp >= rule.StartIndex && tmp <= rule.EndIndex)
                            {
                                parameter.NewParameterValue = tmp + rule.Increment + "";
                                Logger.Info("Trigger " + item.Key + ": " + label + " #" + memberCounter + " " +
                                    "(ID " + parameterType.ID + ") parameter #" + (parameterType.ParamPosition + 1) +
                                    " value changed from " + parameter.ParameterValue + " to " + parameter.NewParameterValue + ".");
                            }

                            memberCounter++;
                        }
                    }
                }
            }
        }

        private static bool ApplyChanges(INIFile map, List<EventActionItem> items, string section)
        {
            bool altered = false;
            foreach (EventActionItem item in items)
            {
                string value = item.Members.Count + "";

                foreach (EventAction itemMember in item.Members)
                {
                    value += "," + itemMember.ID + "," + itemMember.Flag;

                    foreach (EventActionParameter parameter in itemMember.Parameters)
                    {
                        string parameterValue = parameter.ParameterValue;

                        if (parameter.NewParameterValue != null)
                        {
                            altered = true;
                            parameterValue = parameter.NewParameterValue;
                        }

                        value += "," + parameterValue;
                    }
                }

                map.SetKey(section, item.Key, value);
            }

            return altered;
        }

        private static bool HandleScripts(INIFile map, IEnumerable<Rule> rules)
        {
            string[] scriptTypeKeys = map.GetValues("ScriptTypes");

            if (scriptTypeKeys == null)
                return false;

            bool scriptsChanged = false;

            foreach (string scriptTypeKey in scriptTypeKeys)
            {
                scriptsChanged = HandleScript(scriptTypeKey, map, rules) | scriptsChanged;
            }

            return scriptsChanged;
        }

        private static bool HandleScript(string scriptTypeKey, INIFile map, IEnumerable<Rule> rules)
        {
            bool scriptChanged = false;

            for (int i = 0; i < 50; i++)
            {
                string key = i + "";
                string action = map.GetKey(scriptTypeKey, key, null);

                if (action == null)
                    break;

                string[] split = action.Split(',');

                if (split.Length < 2)
                {
                    Logger.Warn("ScriptType [" + scriptTypeKey + "] key " + key + " contains less than two comma-separated values.");
                    continue;
                }

                int actionID = Conversion.GetIntFromString(split[0], -1);
                int actionParameter = Conversion.GetIntFromString(split[1], -1);

                if (actionID == -1 || actionParameter == -1)
                {
                    Logger.Warn("ScriptType [" + scriptTypeKey + "] key " + key + " contains invalid action ID or parameter.");
                    continue;
                }

                scriptChanged = HandleScriptAction(scriptTypeKey, key, actionID, actionParameter, map, rules) | scriptChanged;
            }

            return scriptChanged;
        }

        private static bool HandleScriptAction(string scriptTypeKey, string key, int actionID, int actionParameter, INIFile map, IEnumerable<Rule> rules)
        {
            bool actionChanged = false;

            int currentActionParameter = actionParameter;

            if (HOUSE_SCRIPT_ACTIONS.Contains(actionID))
            {
                var rulesMatch = rules.Where(x => x.RuleCategory == RuleCategory.Houses);

                foreach (Rule rule in rulesMatch)
                {
                    if (currentActionParameter >= rule.StartIndex || currentActionParameter <= rule.EndIndex)
                    {
                        currentActionParameter += rule.Increment;
                        map.SetKey(scriptTypeKey, key, actionID + "," + currentActionParameter);
                        actionChanged = true;
                    }
                }
            }
            else if (STRUCTURE_SCRIPT_ACTIONS.Contains(actionID))
            {
                var rulesMatch = rules.Where(x => x.RuleCategory == RuleCategory.Buildings);

                currentActionParameter = GetActualBuildingTypeIndex(currentActionParameter, out int flag);

                foreach (Rule rule in rulesMatch)
                {
                    if (currentActionParameter >= rule.StartIndex || currentActionParameter <= rule.EndIndex)
                    {
                        currentActionParameter += rule.Increment;
                        map.SetKey(scriptTypeKey, key, actionID + "," + GetBuildingTypeIndex(currentActionParameter, flag));
                        actionChanged = true;
                    }
                }
            }

            return actionChanged;
        }

        private static int GetActualBuildingTypeIndex(int index, out int flag)
        {
            int actualIndex = index % 65536;
            flag = (index - actualIndex) / 65536;
            return actualIndex;
        }

        private static int GetBuildingTypeIndex(int index, int flag) => index + (flag * 65536);

    }


    class EventActionItem
    {
        public string Key { get; set; }
        public List<EventAction> Members = new List<EventAction>();

        public EventActionItem(string key)
        {
            Key = key;
        }
    }

    class EventAction
    {
        public string ID { get; set; }
        public string Flag { get; set; }
        public List<EventActionParameter> Parameters = new List<EventActionParameter>();

        public EventAction(string id, string flag)
        {
            ID = id;
            Flag = flag;
        }
    }

    class EventActionParameter
    {
        public string ParameterValue { get; set; }
        public string NewParameterValue { get; set; } = null;

        public EventActionParameter(string paramValue)
        {
            ParameterValue = paramValue;
        }
    }


}
