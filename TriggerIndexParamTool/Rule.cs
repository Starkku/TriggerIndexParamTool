/*
 * Copyright 2019-2022 by Starkku
 * This file is part of TriggerIndexParamTool, which is free software. It is made
 * available to you under the terms of the GNU General Public License
 * as published by the Free Software Foundation, either version 3 of
 * the License, or (at your option) any later version. For more
 * information, see LICENSE.txt.
 */

namespace TriggerIndexParamTool
{
    public enum RuleCategory { Invalid, Houses, Buildings, Aircraft, Infantry, Vehicles, Superweapons, Animations }

    class Rule
    {
        public int StartIndex { get; set; } = -1;
        public int EndIndex { get; set; } = -1;
        public int Increment { get; set; } = 0;
        public RuleCategory RuleCategory { get; set; } = RuleCategory.Invalid;

        public Rule(int startIndex, int endIndex, int increment, RuleCategory ruleCategory)
        {
            StartIndex = startIndex;
            EndIndex = endIndex;
            Increment = increment;
            RuleCategory = ruleCategory;

        }

        public override string ToString()
        {
            return "Start:" + StartIndex + ", End:" + EndIndex + ", Inc:" + Increment; 
        }
    }
}
