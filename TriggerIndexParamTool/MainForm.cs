/*
 * Copyright 2019-2022 by Starkku
 * This file is part of TriggerIndexParamTool, which is free software. It is made
 * available to you under the terms of the GNU General Public License
 * as published by the Free Software Foundation, either version 3 of
 * the License, or (at your option) any later version. For more
 * information, see LICENSE.txt.
 */

using System;
using System.IO;
using System.Windows.Forms;
using System.ComponentModel;
using System.Linq;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using Starkku.Utilities;

namespace TriggerIndexParamTool
{
    public partial class MainForm : Form
    {
        public BindingList<string> mapFilenames = new BindingList<string>();
        private string[] allowedMapExtensions = new string[] { ".map", ".yrm", ".mpr" };
        private OpenFileDialog openFileDialog = new OpenFileDialog();
        private SaveFileDialog saveFileDialog = new SaveFileDialog();

        private bool addRuleButtonState;
        private bool removeRuleButtonState;
        private bool removeMapsButtonState;
        private bool processMapButtonState;

        private string baseLogFilename = Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().Location);
        private string lastLogFilename = "";

        public MainForm()
        {
            InitializeComponent();

            foreach (RuleCategoryTabPage page in tabControl.TabPages)
            {
                page.SelectionChangeAction = ToggleRemoveRuleButton;
                page.InputValidationAction = ToggleAddRuleButton;
                RuleCategory ruleCategory = RuleCategory.Invalid;
                Enum.TryParse(page.Text, out ruleCategory);
                page.RuleCategory = ruleCategory;
            }

            listBoxMaps.DataSource = mapFilenames;
            mapFilenames.ListChanged += MapFilenames_ListChanged;

            openFileDialog.Multiselect = true;
            openFileDialog.Title = "Browse Map Files";
            string extensionString = string.Join(", ", allowedMapExtensions).Replace(".", "*.");
            openFileDialog.Filter = "Map files (" + extensionString + ")|" + extensionString.Replace(", ", ";") + "|All files (*.*)|*.*";

            saveFileDialog.Title = "Save Log File";
            saveFileDialog.Filter = "Log file (*.log)|*.log|All files (*.*)|*.*";

            Version v = Assembly.GetExecutingAssembly().GetName().Version;
            Text += " v." + v.ToString();
        }

        private void Log(string logmessage)
        {
            Color color = rtbLog.ForeColor;

            if (logmessage.Contains("[Warn]"))
                color = Color.Orange;
            else if (logmessage.Contains("[Error]"))
                color = Color.Red;

            rtbLog.AppendText(logmessage + Environment.NewLine, color);
        }

        private void ToggleAddRuleButton(RuleCategoryTabPage page, bool enable)
        {
            if (page == tabControl.SelectedTab)
                buttonAddRule.Enabled = enable;
        }

        private void ToggleRemoveRuleButton(TabPage page, bool enable)
        {
            if (page == tabControl.SelectedTab)
                buttonRemoveRule.Enabled = enable;
        }

        private void ToggleProcessMapButton()
        {
            buttonProcessMaps.Enabled = mapFilenames.Count > 0 && GetRulesCount() > 0;
        }

        private void AddMapFilename(string filename)
        {
            if (!File.Exists(filename) || mapFilenames.Contains(filename) || !allowedMapExtensions.Contains(Path.GetExtension(filename)))
                return;
            mapFilenames.Add(filename);
        }

        private int GetRulesCount()
        {
            int ruleCount = 0;
            foreach (RuleCategoryTabPage page in tabControl.TabPages)
            {
                ruleCount += page.RuleCount;
            }
            return ruleCount;
        }

        private void ToggleUI(bool enable)
        {
            if (!enable)
            {
                addRuleButtonState = buttonAddRule.Enabled;
                removeRuleButtonState = buttonRemoveRule.Enabled;
                removeMapsButtonState = buttonRemoveMaps.Enabled;
                processMapButtonState = buttonProcessMaps.Enabled;

                buttonAddRule.Enabled = false;
                buttonRemoveRule.Enabled = false;
                buttonRemoveMaps.Enabled = false;
                buttonProcessMaps.Enabled = false;
                tabControl.Enabled = false;
                buttonAddMaps.Enabled = false;
                buttonCopyToClipboard.Enabled = false;
                buttonSaveLog.Enabled = false;
            }
            else
            {
                buttonAddRule.Enabled = addRuleButtonState;
                buttonRemoveRule.Enabled = removeRuleButtonState;
                buttonRemoveMaps.Enabled = removeMapsButtonState;
                buttonProcessMaps.Enabled = processMapButtonState;
                tabControl.Enabled = true;
                buttonAddMaps.Enabled = true;
                buttonCopyToClipboard.Enabled = true;
                buttonSaveLog.Enabled = true;
            }
        }

        private void ButtonAddRule_Click(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab is RuleCategoryTabPage)
                (tabControl.SelectedTab as RuleCategoryTabPage).AddListItem();
            ToggleProcessMapButton();
        }

        private void ButtonRemoveRule_Click(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab is RuleCategoryTabPage)
                (tabControl.SelectedTab as RuleCategoryTabPage).RemoveListItems();
            ToggleProcessMapButton();
        }

        private void ButtonAddMaps_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (openFileDialog.FileNames != null && openFileDialog.FileNames.Length > 0)
                {
                    foreach (string filename in openFileDialog.FileNames)
                    {
                        AddMapFilename(filename);
                    }
                }
            }
        }

        private void ButtonRemoveMaps_Click(object sender, EventArgs e)
        {
            string[] selectedItems = new string[listBoxMaps.SelectedItems.Count];
            listBoxMaps.SelectedItems.CopyTo(selectedItems, 0);

            foreach (string filename in selectedItems)
            {
                mapFilenames.Remove(filename);
            }
        }

        private void MapFilenames_ListChanged(object sender, ListChangedEventArgs e)
        {
            ToggleProcessMapButton();
        }

        private void TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab is RuleCategoryTabPage)
            {
                (tabControl.SelectedTab as RuleCategoryTabPage).ResetInputState();
            }
        }

        private void ButtonProcessMaps_Click(object sender, EventArgs e)
        {
            List<Rule> rules = new List<Rule>();

            foreach (RuleCategoryTabPage page in tabControl.TabPages)
            {
                rules.AddRange(page.GetRules());
            }

            ToggleUI(false);
            rtbLog.Clear();
            Logger.Initialize(Log);
            MapHandler.ProcessMaps(mapFilenames, rules);
            lastLogFilename = baseLogFilename + "-" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".log";
            ToggleUI(true);
        }

        private void ButtonSaveLog_Click(object sender, EventArgs e)
        {
            saveFileDialog.FileName = lastLogFilename;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filename = saveFileDialog.FileName;
                try
                {
                    File.WriteAllLines(filename, rtbLog.Lines);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "Could not save log file to location " + filename + "." + Environment.NewLine + Environment.NewLine +
                        "Error message: " + ex.Message, "Error Saving Log File", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ButtonCopyToClipboard_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(string.Join(Environment.NewLine, rtbLog.Lines));
        }

        private void ListBoxMaps_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonRemoveMaps.Enabled = listBoxMaps.SelectedIndex != -1;
        }

        private void MainForm_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void MainForm_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            foreach (string filename in files)
            {
                AddMapFilename(filename);
            }
        }
    }

    public static class RichTextBoxExtensions
    {
        public static void AppendText(this RichTextBox box, string text, Color color)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;

            box.SelectionColor = color;
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;
        }
    }
}
