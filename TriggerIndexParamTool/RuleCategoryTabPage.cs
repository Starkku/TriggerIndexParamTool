/*
 * Copyright 2019-2022 by Starkku
 * This file is part of TriggerIndexParamTool, which is free software. It is made
 * available to you under the terms of the GNU General Public License
 * as published by the Free Software Foundation, either version 3 of
 * the License, or (at your option) any later version. For more
 * information, see LICENSE.txt.
 */

using System.Windows.Forms;
using System.Drawing;
using System;

namespace TriggerIndexParamTool
{
    class RuleCategoryTabPage : TabPage
    {
        public Action<RuleCategoryTabPage, bool> SelectionChangeAction { get; set; }
        public Action<RuleCategoryTabPage, bool> InputValidationAction { get; set; }
        public RuleCategory RuleCategory { get; set; }
        public int RuleCount { get { return listBoxRules.Items.Count; } }

        private NumericUpDown numStartIndex;
        private Label labelStartIndex;
        private Label labelEndIndex;
        private NumericUpDown numEndIndex;
        private Label labelIncrement;
        private NumericUpDown numIncrement;
        private Label labelScan;
        private NumericUpDown numScan;
        private ListBox listBoxRules;
        private int startIndex = 0;
        private int endIndex = 0;
        private int increment = 0;
        private int scan = 0;

        public RuleCategoryTabPage()
        {
            InitializeComponents();
            listBoxRules.SelectedIndexChanged += ListBoxRules_SelectedIndexChanged;
            numStartIndex.TextChanged += NumStartIndex_TextChanged;
            numEndIndex.TextChanged += NumEndIndex_TextChanged;
            numIncrement.TextChanged += NumIncrement_TextChanged;
            numScan.TextChanged += NumScan_TextChanged;
        }

        public void AddListItem()
        {
            Rule rule = new Rule(startIndex, endIndex, increment, RuleCategory);
            listBoxRules.Items.Add(rule);
            ValidateValues();
        }

        public void RemoveListItems()
        {
            if (listBoxRules.SelectedItems.Count != 0)
            {
                while (listBoxRules.SelectedIndex != -1)
                {
                    listBoxRules.Items.RemoveAt(listBoxRules.SelectedIndex);
                }
            }
            ValidateValues();
        }

        public Rule[] GetRules()
        {
            Rule[] rules = new Rule[listBoxRules.Items.Count];
            listBoxRules.Items.CopyTo(rules, 0);
            return rules;
        }

        public void ResetInputState()
        {
            listBoxRules.SelectedIndex = -1;
            ValidateValues();
        }

        public int GetScanId()
        {
            return scan;
        }

        private void ValidateValues()
        {
            bool valid = true;

            if (increment == 0)
                valid = false;
            else
            {
                foreach (Rule rule in listBoxRules.Items)
                {
                    if (rule.StartIndex == startIndex && rule.EndIndex == endIndex && rule.Increment == increment)
                    {
                        valid = false;
                        break;
                    }
                }
            }

            InputValidationAction(this, valid);
        }

        private void NumScan_TextChanged(object sender, EventArgs e)
        {
            scan = (int)numScan.Value;
        }
        
        private void NumIncrement_TextChanged(object sender, EventArgs e)
        {
            increment = (int)numIncrement.Value;
            ValidateValues();
        }

        private void NumEndIndex_TextChanged(object sender, EventArgs e)
        {
            endIndex = (int)numEndIndex.Value;
            ValidateValues();
        }

        private void NumStartIndex_TextChanged(object sender, EventArgs e)
        {
            startIndex = (int)numStartIndex.Value;
            ValidateValues();
        }

        private void ListBoxRules_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectionChangeAction(this, listBoxRules.SelectedIndex >= 0);
        }

        private void InitializeComponents()
        {
            listBoxRules = new ListBox
            {
                FormattingEnabled = true,
                Location = new Point(183, 16),
                Name = "listBoxRules",
                Size = new Size(197, 120),
                TabIndex = 4,
                SelectionMode = SelectionMode.MultiExtended
            };

            labelScan = new Label
            {
                Location = new Point(13, 112),
                Name = "labelScan",
                RightToLeft = RightToLeft.No,
                Size = new Size(61, 18),
                Text = "Scan:",
                TextAlign = ContentAlignment.MiddleRight
            };

            numScan = new NumericUpDown
            {
                Location = new Point(80, 112),
                Name = "tbScan",
                Size = new Size(81, 20),
                Maximum = short.MaxValue,
                TabIndex = 3
            };

            labelIncrement = new Label
            {
                Location = new Point(13, 80),
                Name = "labelIncrement",
                RightToLeft = RightToLeft.No,
                Size = new Size(61, 18),
                Text = "Increment:",
                TextAlign = ContentAlignment.MiddleRight
            };

            numIncrement = new NumericUpDown
            {
                Location = new Point(80, 80),
                Name = "tbIncrement",
                Size = new Size(81, 20),
                Maximum = short.MaxValue,
                Minimum = short.MinValue,
                TabIndex = 2
            };

            labelEndIndex = new Label
            {
                Location = new Point(13, 48),
                Name = "labelEndIndex",
                RightToLeft = RightToLeft.No,
                Size = new Size(61, 18),
                Text = "End Index:",
                TextAlign = ContentAlignment.MiddleRight
            };

            numEndIndex = new NumericUpDown
            {
                Location = new Point(80, 48),
                Name = "tbEndIndex",
                Size = new Size(81, 20),
                Maximum = ushort.MaxValue,
                TabIndex = 1
            };

            numStartIndex = new NumericUpDown
            {
                Location = new Point(80, 16),
                Name = "tbStartIndex",
                Size = new Size(81, 20),
                Maximum = ushort.MaxValue,
                TabIndex = 0
            };

            labelStartIndex = new Label
            {
                Location = new Point(13, 16),
                Name = "labelStartIndex",
                RightToLeft = RightToLeft.No,
                Size = new Size(61, 18),
                Text = "Start Index:",
                TextAlign = ContentAlignment.MiddleRight
            };

            Controls.Add(listBoxRules);
            Controls.Add(labelScan);
            Controls.Add(numScan);
            Controls.Add(labelIncrement);
            Controls.Add(numIncrement);
            Controls.Add(labelEndIndex);
            Controls.Add(numEndIndex);
            Controls.Add(numStartIndex);
            Controls.Add(labelStartIndex);
        }
    }
}
