namespace TriggerIndexParamTool
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonAddRule = new System.Windows.Forms.Button();
            this.buttonRemoveRule = new System.Windows.Forms.Button();
            this.listBoxMaps = new System.Windows.Forms.ListBox();
            this.buttonProcessMaps = new System.Windows.Forms.Button();
            this.buttonRemoveMaps = new System.Windows.Forms.Button();
            this.buttonAddMaps = new System.Windows.Forms.Button();
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageHouses = new TriggerIndexParamTool.RuleCategoryTabPage();
            this.tabPageBuildings = new TriggerIndexParamTool.RuleCategoryTabPage();
            this.tabPageAircraft = new TriggerIndexParamTool.RuleCategoryTabPage();
            this.tabPageInfantry = new TriggerIndexParamTool.RuleCategoryTabPage();
            this.tabPageVehicles = new TriggerIndexParamTool.RuleCategoryTabPage();
            this.tabPageSW = new TriggerIndexParamTool.RuleCategoryTabPage();
            this.tabPageAnims = new TriggerIndexParamTool.RuleCategoryTabPage();
            this.buttonSaveLog = new System.Windows.Forms.Button();
            this.buttonCopyToClipboard = new System.Windows.Forms.Button();
            this.buttonScanMaps = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonAddRule
            // 
            this.buttonAddRule.Enabled = false;
            this.buttonAddRule.Location = new System.Drawing.Point(12, 194);
            this.buttonAddRule.Name = "buttonAddRule";
            this.buttonAddRule.Size = new System.Drawing.Size(84, 23);
            this.buttonAddRule.TabIndex = 1;
            this.buttonAddRule.Text = "Add Rule";
            this.buttonAddRule.UseVisualStyleBackColor = true;
            this.buttonAddRule.Click += new System.EventHandler(this.ButtonAddRule_Click);
            // 
            // buttonRemoveRule
            // 
            this.buttonRemoveRule.Enabled = false;
            this.buttonRemoveRule.Location = new System.Drawing.Point(102, 194);
            this.buttonRemoveRule.Name = "buttonRemoveRule";
            this.buttonRemoveRule.Size = new System.Drawing.Size(86, 23);
            this.buttonRemoveRule.TabIndex = 2;
            this.buttonRemoveRule.Text = "Remove Rules";
            this.buttonRemoveRule.UseVisualStyleBackColor = true;
            this.buttonRemoveRule.Click += new System.EventHandler(this.ButtonRemoveRule_Click);
            // 
            // listBoxMaps
            // 
            this.listBoxMaps.FormattingEnabled = true;
            this.listBoxMaps.Location = new System.Drawing.Point(12, 231);
            this.listBoxMaps.Name = "listBoxMaps";
            this.listBoxMaps.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxMaps.Size = new System.Drawing.Size(403, 199);
            this.listBoxMaps.TabIndex = 3;
            this.listBoxMaps.SelectedIndexChanged += new System.EventHandler(this.ListBoxMaps_SelectedIndexChanged);
            // 
            // buttonProcessMaps
            // 
            this.buttonProcessMaps.Enabled = false;
            this.buttonProcessMaps.Location = new System.Drawing.Point(331, 445);
            this.buttonProcessMaps.Name = "buttonProcessMaps";
            this.buttonProcessMaps.Size = new System.Drawing.Size(84, 23);
            this.buttonProcessMaps.TabIndex = 6;
            this.buttonProcessMaps.Text = "Process Maps";
            this.buttonProcessMaps.UseVisualStyleBackColor = true;
            this.buttonProcessMaps.Click += new System.EventHandler(this.ButtonProcessMaps_Click);
            // 
            // buttonScanMaps
            // 
            this.buttonScanMaps.Enabled = false;
            this.buttonScanMaps.Location = new System.Drawing.Point(241, 445);
            this.buttonScanMaps.Name = "buttonScanMaps";
            this.buttonScanMaps.Size = new System.Drawing.Size(84, 23);
            this.buttonScanMaps.TabIndex = 6;
            this.buttonScanMaps.Text = "Scan Maps";
            this.buttonScanMaps.UseVisualStyleBackColor = true;
            this.buttonScanMaps.Click += new System.EventHandler(this.ButtonScanMaps_Click);
            // 
            // buttonRemoveMaps
            // 
            this.buttonRemoveMaps.Enabled = false;
            this.buttonRemoveMaps.Location = new System.Drawing.Point(102, 445);
            this.buttonRemoveMaps.Name = "buttonRemoveMaps";
            this.buttonRemoveMaps.Size = new System.Drawing.Size(86, 23);
            this.buttonRemoveMaps.TabIndex = 5;
            this.buttonRemoveMaps.Text = "Remove Maps";
            this.buttonRemoveMaps.UseVisualStyleBackColor = true;
            this.buttonRemoveMaps.Click += new System.EventHandler(this.ButtonRemoveMaps_Click);
            // 
            // buttonAddMaps
            // 
            this.buttonAddMaps.Location = new System.Drawing.Point(12, 445);
            this.buttonAddMaps.Name = "buttonAddMaps";
            this.buttonAddMaps.Size = new System.Drawing.Size(84, 23);
            this.buttonAddMaps.TabIndex = 4;
            this.buttonAddMaps.Text = "Add Maps";
            this.buttonAddMaps.UseVisualStyleBackColor = true;
            this.buttonAddMaps.Click += new System.EventHandler(this.ButtonAddMaps_Click);
            // 
            // rtbLog
            // 
            this.rtbLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtbLog.Location = new System.Drawing.Point(430, 12);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.ReadOnly = true;
            this.rtbLog.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtbLog.Size = new System.Drawing.Size(342, 418);
            this.rtbLog.TabIndex = 7;
            this.rtbLog.Text = "";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageHouses);
            this.tabControl.Controls.Add(this.tabPageBuildings);
            this.tabControl.Controls.Add(this.tabPageAircraft);
            this.tabControl.Controls.Add(this.tabPageInfantry);
            this.tabControl.Controls.Add(this.tabPageVehicles);
            this.tabControl.Controls.Add(this.tabPageSW);
            this.tabControl.Controls.Add(this.tabPageAnims);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.Padding = new System.Drawing.Point(0, 0);
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(403, 170);
            this.tabControl.TabIndex = 0;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.TabControl_SelectedIndexChanged);
            // 
            // tabPageHouses
            // 
            this.tabPageHouses.InputValidationAction = null;
            this.tabPageHouses.Location = new System.Drawing.Point(4, 22);
            this.tabPageHouses.Name = "tabPageHouses";
            this.tabPageHouses.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageHouses.RuleCategory = TriggerIndexParamTool.RuleCategory.Invalid;
            this.tabPageHouses.SelectionChangeAction = null;
            this.tabPageHouses.Size = new System.Drawing.Size(395, 144);
            this.tabPageHouses.TabIndex = 0;
            this.tabPageHouses.Text = "Houses";
            this.tabPageHouses.UseVisualStyleBackColor = true;
            // 
            // tabPageBuildings
            // 
            this.tabPageBuildings.InputValidationAction = null;
            this.tabPageBuildings.Location = new System.Drawing.Point(4, 22);
            this.tabPageBuildings.Name = "tabPageBuildings";
            this.tabPageBuildings.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageBuildings.RuleCategory = TriggerIndexParamTool.RuleCategory.Invalid;
            this.tabPageBuildings.SelectionChangeAction = null;
            this.tabPageBuildings.Size = new System.Drawing.Size(395, 144);
            this.tabPageBuildings.TabIndex = 1;
            this.tabPageBuildings.Text = "Buildings";
            this.tabPageBuildings.UseVisualStyleBackColor = true;
            // 
            // tabPageAircraft
            // 
            this.tabPageAircraft.InputValidationAction = null;
            this.tabPageAircraft.Location = new System.Drawing.Point(4, 22);
            this.tabPageAircraft.Name = "tabPageAircraft";
            this.tabPageAircraft.RuleCategory = TriggerIndexParamTool.RuleCategory.Invalid;
            this.tabPageAircraft.SelectionChangeAction = null;
            this.tabPageAircraft.Size = new System.Drawing.Size(395, 144);
            this.tabPageAircraft.TabIndex = 2;
            this.tabPageAircraft.Text = "Aircraft";
            this.tabPageAircraft.UseVisualStyleBackColor = true;
            // 
            // tabPageInfantry
            // 
            this.tabPageInfantry.InputValidationAction = null;
            this.tabPageInfantry.Location = new System.Drawing.Point(4, 22);
            this.tabPageInfantry.Name = "tabPageInfantry";
            this.tabPageInfantry.RuleCategory = TriggerIndexParamTool.RuleCategory.Invalid;
            this.tabPageInfantry.SelectionChangeAction = null;
            this.tabPageInfantry.Size = new System.Drawing.Size(395, 144);
            this.tabPageInfantry.TabIndex = 3;
            this.tabPageInfantry.Text = "Infantry";
            this.tabPageInfantry.UseVisualStyleBackColor = true;
            // 
            // tabPageVehicles
            // 
            this.tabPageVehicles.InputValidationAction = null;
            this.tabPageVehicles.Location = new System.Drawing.Point(4, 22);
            this.tabPageVehicles.Name = "tabPageVehicles";
            this.tabPageVehicles.RuleCategory = TriggerIndexParamTool.RuleCategory.Invalid;
            this.tabPageVehicles.SelectionChangeAction = null;
            this.tabPageVehicles.Size = new System.Drawing.Size(395, 144);
            this.tabPageVehicles.TabIndex = 4;
            this.tabPageVehicles.Text = "Vehicles";
            this.tabPageVehicles.UseVisualStyleBackColor = true;
            // 
            // tabPageSW
            // 
            this.tabPageSW.InputValidationAction = null;
            this.tabPageSW.Location = new System.Drawing.Point(4, 22);
            this.tabPageSW.Name = "tabPageSW";
            this.tabPageSW.RuleCategory = TriggerIndexParamTool.RuleCategory.Invalid;
            this.tabPageSW.SelectionChangeAction = null;
            this.tabPageSW.Size = new System.Drawing.Size(395, 144);
            this.tabPageSW.TabIndex = 5;
            this.tabPageSW.Text = "Superweapons";
            this.tabPageSW.UseVisualStyleBackColor = true;
            // 
            // tabPageAnims
            // 
            this.tabPageAnims.InputValidationAction = null;
            this.tabPageAnims.Location = new System.Drawing.Point(4, 22);
            this.tabPageAnims.Name = "tabPageAnims";
            this.tabPageAnims.RuleCategory = TriggerIndexParamTool.RuleCategory.Invalid;
            this.tabPageAnims.SelectionChangeAction = null;
            this.tabPageAnims.Size = new System.Drawing.Size(395, 144);
            this.tabPageAnims.TabIndex = 6;
            this.tabPageAnims.Text = "Animations";
            this.tabPageAnims.UseVisualStyleBackColor = true;
            // 
            // buttonSaveLog
            // 
            this.buttonSaveLog.Enabled = false;
            this.buttonSaveLog.Location = new System.Drawing.Point(676, 445);
            this.buttonSaveLog.Name = "buttonSaveLog";
            this.buttonSaveLog.Size = new System.Drawing.Size(96, 23);
            this.buttonSaveLog.TabIndex = 9;
            this.buttonSaveLog.Text = "Save To File";
            this.buttonSaveLog.UseVisualStyleBackColor = true;
            this.buttonSaveLog.Click += new System.EventHandler(this.ButtonSaveLog_Click);
            // 
            // buttonCopyToClipboard
            // 
            this.buttonCopyToClipboard.Enabled = false;
            this.buttonCopyToClipboard.Location = new System.Drawing.Point(566, 445);
            this.buttonCopyToClipboard.Name = "buttonCopyToClipboard";
            this.buttonCopyToClipboard.Size = new System.Drawing.Size(104, 23);
            this.buttonCopyToClipboard.TabIndex = 8;
            this.buttonCopyToClipboard.Text = "Copy To Clipboard";
            this.buttonCopyToClipboard.UseVisualStyleBackColor = true;
            this.buttonCopyToClipboard.Click += new System.EventHandler(this.ButtonCopyToClipboard_Click);
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 482);
            this.Controls.Add(this.buttonCopyToClipboard);
            this.Controls.Add(this.buttonSaveLog);
            this.Controls.Add(this.rtbLog);
            this.Controls.Add(this.buttonAddMaps);
            this.Controls.Add(this.buttonRemoveMaps);
            this.Controls.Add(this.buttonScanMaps);
            this.Controls.Add(this.buttonProcessMaps);
            this.Controls.Add(this.listBoxMaps);
            this.Controls.Add(this.buttonRemoveRule);
            this.Controls.Add(this.buttonAddRule);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "TS / RA2 Map Trigger Index Parameter Changer Tool";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainForm_DragEnter);
            this.tabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private RuleCategoryTabPage tabPageHouses;
        private RuleCategoryTabPage tabPageBuildings;
        private RuleCategoryTabPage tabPageAircraft;
        private RuleCategoryTabPage tabPageInfantry;
        private RuleCategoryTabPage tabPageVehicles;
        private RuleCategoryTabPage tabPageSW;
        private RuleCategoryTabPage tabPageAnims;
        private System.Windows.Forms.Button buttonAddRule;
        private System.Windows.Forms.Button buttonRemoveRule;
        private System.Windows.Forms.ListBox listBoxMaps;
        private System.Windows.Forms.Button buttonProcessMaps;
        private System.Windows.Forms.Button buttonRemoveMaps;
        private System.Windows.Forms.Button buttonAddMaps;
        private System.Windows.Forms.RichTextBox rtbLog;
        private System.Windows.Forms.Button buttonSaveLog;
        private System.Windows.Forms.Button buttonCopyToClipboard;
        private System.Windows.Forms.Button buttonScanMaps;
    }
}

