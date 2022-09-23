/*
 * Copyright 2019-2022 by Starkku
 * This file is part of TriggerIndexParamTool, which is free software. It is made
 * available to you under the terms of the GNU General Public License
 * as published by the Free Software Foundation, either version 3 of
 * the License, or (at your option) any later version. For more
 * information, see LICENSE.txt.
 */

using System.Collections.Generic;

namespace TriggerIndexParamTool
{
    /// <summary>
    /// Collection of event parameters.
    /// </summary>
    static class EventParameterCollection
    {
        public static Dictionary<RuleCategory, ParameterType[]> Parameters = new Dictionary<RuleCategory, ParameterType[]>()
        {
            {
                RuleCategory.Houses,
                new ParameterType[] {
                    new ParameterType(1, 0),
                    new ParameterType(3, 0),
                    new ParameterType(5, 0),
                    new ParameterType(5, 0),
                    new ParameterType(9, 0),
                    new ParameterType(10, 0),
                    new ParameterType(11, 0),
                    new ParameterType(24, 0),
                    new ParameterType(25, 0),
                    new ParameterType(26, 0),
                    new ParameterType(30, 0),
                    new ParameterType(44, 0),
                    new ParameterType(53, 0),
                    new ParameterType(55, 0),
                    new ParameterType(56, 0),
                    new ParameterType(58, 0),
                    new ParameterType(59, 0),
                    new ParameterType(63, 0),
                    new ParameterType(65, 0),
                    new ParameterType(68, 0),
                    new ParameterType(70, 0),
                    new ParameterType(72, 0),
                    new ParameterType(74, 0),
                    new ParameterType(84, 0),
                    new ParameterType(85, 0),
                    new ParameterType(87, 0),
                    new ParameterType(88, 0),
                }
            },
            {
                RuleCategory.Buildings,
                new ParameterType[] {
                    new ParameterType(19, 0),
                    new ParameterType(32, 0),
                    new ParameterType(57, 0),
                }
            },
            {
                RuleCategory.Aircraft,
                new ParameterType[] {
                    new ParameterType(22, 0),
                }
            },
            {
                RuleCategory.Infantry,
                new ParameterType[] {
                    new ParameterType(21, 0),
                    new ParameterType(54, 0),
                }
            },
            {
                RuleCategory.Vehicles,
                new ParameterType[] {
                    new ParameterType(20, 0),
                }
            },
            {
                RuleCategory.Superweapons,
                new ParameterType[] {
                    new ParameterType(75, 0),
                    new ParameterType(76, 0),
                }
            },
            {
                RuleCategory.Animations,
                new ParameterType[] {
                }
            },
        };
    }

    /// <summary>
    /// Collection of action parameters.
    /// </summary>
    static class ActionParameterCollection
    {
        public static Dictionary<RuleCategory, ParameterType[]> Parameters = new Dictionary<RuleCategory, ParameterType[]>()
        {
            {
                RuleCategory.Houses,
                new ParameterType[] {
                    new ParameterType(1, 0),
                    new ParameterType(2, 0),
                    new ParameterType(3, 0),
                    new ParameterType(6, 0),
                    new ParameterType(9, 0),
                    new ParameterType(13, 0),
                    new ParameterType(14, 0),
                    new ParameterType(36, 0),
                    new ParameterType(37, 0),
                    new ParameterType(38, 0),
                    new ParameterType(74, 0),
                    new ParameterType(75, 0),
                    new ParameterType(113, 0),
                    new ParameterType(119, 0),
                    new ParameterType(120, 0),
                    new ParameterType(121, 0),
                    new ParameterType(122, 0),
                    new ParameterType(123, 0),
                    new ParameterType(124, 0),
                    new ParameterType(126, 0),
                    new ParameterType(130, 0),
                    new ParameterType(146, 0),
                    new ParameterType(147, 0),
                }
            },
            {
                RuleCategory.Buildings,
                new ParameterType[] {
                }
            },
            {
                RuleCategory.Aircraft,
                new ParameterType[] {
                }
            },
            {
                RuleCategory.Infantry,
                new ParameterType[] {
                }
            },
            {
                RuleCategory.Vehicles,
                new ParameterType[] {
                }
            },
            {
                RuleCategory.Superweapons,
                new ParameterType[] {
                    new ParameterType(33, 0),
                    new ParameterType(34, 0),
                    new ParameterType(129, 0),
                    new ParameterType(132, 0),
                    new ParameterType(133, 0),
                    new ParameterType(134, 0),
                }
            },
            {
                RuleCategory.Animations,
                new ParameterType[] {
                    new ParameterType(41, 0),
                }
            },
        };
    }

    /// <summary>
    /// Event / action parameter type.
    /// </summary>
    class ParameterType
    {
        /// <summary>
        /// Event / action ID.
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// Position of the parameter in event / action.
        /// </summary>
        public int ParamPosition { get; set; }

        public ParameterType(int id, int paramPosition)
        {
            ID = id;
            ParamPosition = paramPosition;
        }
    }
}
