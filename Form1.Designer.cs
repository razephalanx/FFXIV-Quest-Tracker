﻿namespace FFXIV_Quest_Tracker
{
    partial class FFXIVQuestTrackerForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabMain = new System.Windows.Forms.TabPage();
            this.dataGridViewMainQuests = new System.Windows.Forms.DataGridView();
            this.QuestComplete = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.QuestNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QuestTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QuestLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QuestArea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QuestGarlandToolsLink = new System.Windows.Forms.DataGridViewLinkColumn();
            this.comboBoxMainCategory = new System.Windows.Forms.ComboBox();
            this.labelMainCategory = new System.Windows.Forms.Label();
            this.labelMainExpac = new System.Windows.Forms.Label();
            this.comboBoxMainExpac = new System.Windows.Forms.ComboBox();
            this.tabPreferences = new System.Windows.Forms.TabPage();
            this.buttonCancelPref = new System.Windows.Forms.Button();
            this.buttonResetQuestListPref = new System.Windows.Forms.Button();
            this.buttonResetSavePref = new System.Windows.Forms.Button();
            this.buttonSavePref = new System.Windows.Forms.Button();
            this.buttonPrefQuestListLocation = new System.Windows.Forms.Button();
            this.textBoxPrefQuestListLocation = new System.Windows.Forms.TextBox();
            this.labelPrefQuestListLocation = new System.Windows.Forms.Label();
            this.buttonPrefSaveLocation = new System.Windows.Forms.Button();
            this.textBoxPrefSaveLocation = new System.Windows.Forms.TextBox();
            this.labelPrefSaveLocation = new System.Windows.Forms.Label();
            this.comboBoxPrefTheme = new System.Windows.Forms.ComboBox();
            this.labelPrefTheme = new System.Windows.Forms.Label();
            this.comboBoxPrefExpac = new System.Windows.Forms.ComboBox();
            this.labelPrefExpac = new System.Windows.Forms.Label();
            this.tabControl.SuspendLayout();
            this.tabMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMainQuests)).BeginInit();
            this.tabPreferences.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabMain);
            this.tabControl.Controls.Add(this.tabPreferences);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(884, 561);
            this.tabControl.TabIndex = 0;
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.dataGridViewMainQuests);
            this.tabMain.Controls.Add(this.comboBoxMainCategory);
            this.tabMain.Controls.Add(this.labelMainCategory);
            this.tabMain.Controls.Add(this.labelMainExpac);
            this.tabMain.Controls.Add(this.comboBoxMainExpac);
            this.tabMain.Location = new System.Drawing.Point(4, 24);
            this.tabMain.Name = "tabMain";
            this.tabMain.Padding = new System.Windows.Forms.Padding(3);
            this.tabMain.Size = new System.Drawing.Size(876, 533);
            this.tabMain.TabIndex = 0;
            this.tabMain.Text = "Main";
            this.tabMain.UseVisualStyleBackColor = true;
            // 
            // dataGridViewMainQuests
            // 
            this.dataGridViewMainQuests.AllowUserToAddRows = false;
            this.dataGridViewMainQuests.AllowUserToDeleteRows = false;
            this.dataGridViewMainQuests.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewMainQuests.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewMainQuests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMainQuests.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.QuestComplete,
            this.QuestNumber,
            this.QuestTitle,
            this.QuestLevel,
            this.QuestArea,
            this.QuestGarlandToolsLink});
            this.dataGridViewMainQuests.Location = new System.Drawing.Point(185, 3);
            this.dataGridViewMainQuests.Name = "dataGridViewMainQuests";
            this.dataGridViewMainQuests.RowHeadersVisible = false;
            this.dataGridViewMainQuests.RowTemplate.Height = 25;
            this.dataGridViewMainQuests.ShowCellToolTips = false;
            this.dataGridViewMainQuests.Size = new System.Drawing.Size(688, 527);
            this.dataGridViewMainQuests.TabIndex = 4;
            this.dataGridViewMainQuests.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewMainQuests_CellContentClick);
            // 
            // QuestComplete
            // 
            this.QuestComplete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.QuestComplete.HeaderText = "√";
            this.QuestComplete.MinimumWidth = 40;
            this.QuestComplete.Name = "QuestComplete";
            this.QuestComplete.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.QuestComplete.Width = 40;
            // 
            // QuestNumber
            // 
            this.QuestNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.QuestNumber.DefaultCellStyle = dataGridViewCellStyle2;
            this.QuestNumber.HeaderText = "#";
            this.QuestNumber.MinimumWidth = 40;
            this.QuestNumber.Name = "QuestNumber";
            this.QuestNumber.ReadOnly = true;
            this.QuestNumber.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.QuestNumber.Width = 40;
            // 
            // QuestTitle
            // 
            this.QuestTitle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.QuestTitle.HeaderText = "Title";
            this.QuestTitle.MinimumWidth = 100;
            this.QuestTitle.Name = "QuestTitle";
            this.QuestTitle.ReadOnly = true;
            this.QuestTitle.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // QuestLevel
            // 
            this.QuestLevel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.QuestLevel.FillWeight = 20F;
            this.QuestLevel.HeaderText = "Level";
            this.QuestLevel.Name = "QuestLevel";
            this.QuestLevel.ReadOnly = true;
            this.QuestLevel.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // QuestArea
            // 
            this.QuestArea.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.QuestArea.FillWeight = 80F;
            this.QuestArea.HeaderText = "Area";
            this.QuestArea.Name = "QuestArea";
            this.QuestArea.ReadOnly = true;
            this.QuestArea.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // QuestGarlandToolsLink
            // 
            this.QuestGarlandToolsLink.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.QuestGarlandToolsLink.HeaderText = "GTD";
            this.QuestGarlandToolsLink.MinimumWidth = 40;
            this.QuestGarlandToolsLink.Name = "QuestGarlandToolsLink";
            this.QuestGarlandToolsLink.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.QuestGarlandToolsLink.Width = 40;
            // 
            // comboBoxMainCategory
            // 
            this.comboBoxMainCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMainCategory.FormattingEnabled = true;
            this.comboBoxMainCategory.Location = new System.Drawing.Point(6, 80);
            this.comboBoxMainCategory.Name = "comboBoxMainCategory";
            this.comboBoxMainCategory.Size = new System.Drawing.Size(170, 23);
            this.comboBoxMainCategory.TabIndex = 3;
            this.comboBoxMainCategory.SelectionChangeCommitted += new System.EventHandler(this.comboBoxMainCategory_SelectionChangeCommitted);
            // 
            // labelMainCategory
            // 
            this.labelMainCategory.AutoSize = true;
            this.labelMainCategory.Location = new System.Drawing.Point(6, 62);
            this.labelMainCategory.Name = "labelMainCategory";
            this.labelMainCategory.Size = new System.Drawing.Size(55, 15);
            this.labelMainCategory.TabIndex = 2;
            this.labelMainCategory.Text = "Category";
            // 
            // labelMainExpac
            // 
            this.labelMainExpac.AutoSize = true;
            this.labelMainExpac.Location = new System.Drawing.Point(8, 3);
            this.labelMainExpac.Name = "labelMainExpac";
            this.labelMainExpac.Size = new System.Drawing.Size(61, 15);
            this.labelMainExpac.TabIndex = 1;
            this.labelMainExpac.Text = "Expansion";
            // 
            // comboBoxMainExpac
            // 
            this.comboBoxMainExpac.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMainExpac.FormattingEnabled = true;
            this.comboBoxMainExpac.Location = new System.Drawing.Point(6, 21);
            this.comboBoxMainExpac.Name = "comboBoxMainExpac";
            this.comboBoxMainExpac.Size = new System.Drawing.Size(170, 23);
            this.comboBoxMainExpac.TabIndex = 0;
            this.comboBoxMainExpac.SelectedIndexChanged += new System.EventHandler(this.comboBoxMainExpac_SelectedIndexChanged);
            // 
            // tabPreferences
            // 
            this.tabPreferences.Controls.Add(this.buttonCancelPref);
            this.tabPreferences.Controls.Add(this.buttonResetQuestListPref);
            this.tabPreferences.Controls.Add(this.buttonResetSavePref);
            this.tabPreferences.Controls.Add(this.buttonSavePref);
            this.tabPreferences.Controls.Add(this.buttonPrefQuestListLocation);
            this.tabPreferences.Controls.Add(this.textBoxPrefQuestListLocation);
            this.tabPreferences.Controls.Add(this.labelPrefQuestListLocation);
            this.tabPreferences.Controls.Add(this.buttonPrefSaveLocation);
            this.tabPreferences.Controls.Add(this.textBoxPrefSaveLocation);
            this.tabPreferences.Controls.Add(this.labelPrefSaveLocation);
            this.tabPreferences.Controls.Add(this.comboBoxPrefTheme);
            this.tabPreferences.Controls.Add(this.labelPrefTheme);
            this.tabPreferences.Controls.Add(this.comboBoxPrefExpac);
            this.tabPreferences.Controls.Add(this.labelPrefExpac);
            this.tabPreferences.Location = new System.Drawing.Point(4, 24);
            this.tabPreferences.Name = "tabPreferences";
            this.tabPreferences.Padding = new System.Windows.Forms.Padding(3);
            this.tabPreferences.Size = new System.Drawing.Size(876, 533);
            this.tabPreferences.TabIndex = 1;
            this.tabPreferences.Text = "Preferences";
            this.tabPreferences.UseVisualStyleBackColor = true;
            // 
            // buttonCancelPref
            // 
            this.buttonCancelPref.Location = new System.Drawing.Point(768, 504);
            this.buttonCancelPref.Name = "buttonCancelPref";
            this.buttonCancelPref.Size = new System.Drawing.Size(102, 23);
            this.buttonCancelPref.TabIndex = 20;
            this.buttonCancelPref.Text = "Cancel Changes";
            this.buttonCancelPref.UseVisualStyleBackColor = true;
            this.buttonCancelPref.Click += new System.EventHandler(this.buttonCancelPref_Click);
            // 
            // buttonResetQuestListPref
            // 
            this.buttonResetQuestListPref.Location = new System.Drawing.Point(778, 92);
            this.buttonResetQuestListPref.Name = "buttonResetQuestListPref";
            this.buttonResetQuestListPref.Size = new System.Drawing.Size(75, 23);
            this.buttonResetQuestListPref.TabIndex = 19;
            this.buttonResetQuestListPref.Text = "Reset";
            this.buttonResetQuestListPref.UseVisualStyleBackColor = true;
            this.buttonResetQuestListPref.Click += new System.EventHandler(this.buttonResetQuestListPref_Click);
            // 
            // buttonResetSavePref
            // 
            this.buttonResetSavePref.Location = new System.Drawing.Point(778, 49);
            this.buttonResetSavePref.Name = "buttonResetSavePref";
            this.buttonResetSavePref.Size = new System.Drawing.Size(75, 23);
            this.buttonResetSavePref.TabIndex = 16;
            this.buttonResetSavePref.Text = "Reset";
            this.buttonResetSavePref.UseVisualStyleBackColor = true;
            this.buttonResetSavePref.Click += new System.EventHandler(this.buttonResetSavePref_Click);
            // 
            // buttonSavePref
            // 
            this.buttonSavePref.Location = new System.Drawing.Point(660, 504);
            this.buttonSavePref.Name = "buttonSavePref";
            this.buttonSavePref.Size = new System.Drawing.Size(102, 23);
            this.buttonSavePref.TabIndex = 15;
            this.buttonSavePref.Text = "Save Changes";
            this.buttonSavePref.UseVisualStyleBackColor = true;
            this.buttonSavePref.Click += new System.EventHandler(this.buttonSavePref_Click);
            // 
            // buttonPrefQuestListLocation
            // 
            this.buttonPrefQuestListLocation.Location = new System.Drawing.Point(747, 93);
            this.buttonPrefQuestListLocation.Name = "buttonPrefQuestListLocation";
            this.buttonPrefQuestListLocation.Size = new System.Drawing.Size(25, 23);
            this.buttonPrefQuestListLocation.TabIndex = 14;
            this.buttonPrefQuestListLocation.Text = "...";
            this.buttonPrefQuestListLocation.UseVisualStyleBackColor = true;
            this.buttonPrefQuestListLocation.Click += new System.EventHandler(this.buttonPrefQuestListLocation_Click);
            // 
            // textBoxPrefQuestListLocation
            // 
            this.textBoxPrefQuestListLocation.Location = new System.Drawing.Point(166, 93);
            this.textBoxPrefQuestListLocation.Name = "textBoxPrefQuestListLocation";
            this.textBoxPrefQuestListLocation.ReadOnly = true;
            this.textBoxPrefQuestListLocation.Size = new System.Drawing.Size(575, 23);
            this.textBoxPrefQuestListLocation.TabIndex = 13;
            // 
            // labelPrefQuestListLocation
            // 
            this.labelPrefQuestListLocation.AutoEllipsis = true;
            this.labelPrefQuestListLocation.AutoSize = true;
            this.labelPrefQuestListLocation.Location = new System.Drawing.Point(8, 96);
            this.labelPrefQuestListLocation.Name = "labelPrefQuestListLocation";
            this.labelPrefQuestListLocation.Size = new System.Drawing.Size(111, 15);
            this.labelPrefQuestListLocation.TabIndex = 12;
            this.labelPrefQuestListLocation.Text = "Quest List Location:";
            // 
            // buttonPrefSaveLocation
            // 
            this.buttonPrefSaveLocation.Location = new System.Drawing.Point(747, 49);
            this.buttonPrefSaveLocation.Name = "buttonPrefSaveLocation";
            this.buttonPrefSaveLocation.Size = new System.Drawing.Size(25, 23);
            this.buttonPrefSaveLocation.TabIndex = 9;
            this.buttonPrefSaveLocation.Text = "...";
            this.buttonPrefSaveLocation.UseVisualStyleBackColor = true;
            this.buttonPrefSaveLocation.Click += new System.EventHandler(this.buttonPrefSaveLocation_Click);
            // 
            // textBoxPrefSaveLocation
            // 
            this.textBoxPrefSaveLocation.Location = new System.Drawing.Point(166, 49);
            this.textBoxPrefSaveLocation.Name = "textBoxPrefSaveLocation";
            this.textBoxPrefSaveLocation.ReadOnly = true;
            this.textBoxPrefSaveLocation.Size = new System.Drawing.Size(575, 23);
            this.textBoxPrefSaveLocation.TabIndex = 8;
            // 
            // labelPrefSaveLocation
            // 
            this.labelPrefSaveLocation.AutoEllipsis = true;
            this.labelPrefSaveLocation.AutoSize = true;
            this.labelPrefSaveLocation.Location = new System.Drawing.Point(8, 52);
            this.labelPrefSaveLocation.Name = "labelPrefSaveLocation";
            this.labelPrefSaveLocation.Size = new System.Drawing.Size(124, 15);
            this.labelPrefSaveLocation.TabIndex = 4;
            this.labelPrefSaveLocation.Text = "Default Save Location:";
            // 
            // comboBoxPrefTheme
            // 
            this.comboBoxPrefTheme.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPrefTheme.FormattingEnabled = true;
            this.comboBoxPrefTheme.Items.AddRange(new object[] {
            "Light",
            "Dark"});
            this.comboBoxPrefTheme.Location = new System.Drawing.Point(600, 6);
            this.comboBoxPrefTheme.Name = "comboBoxPrefTheme";
            this.comboBoxPrefTheme.Size = new System.Drawing.Size(253, 23);
            this.comboBoxPrefTheme.TabIndex = 3;
            this.comboBoxPrefTheme.SelectionChangeCommitted += new System.EventHandler(this.comboBoxPrefTheme_SelectionChangeCommitted);
            // 
            // labelPrefTheme
            // 
            this.labelPrefTheme.AutoEllipsis = true;
            this.labelPrefTheme.AutoSize = true;
            this.labelPrefTheme.Location = new System.Drawing.Point(548, 9);
            this.labelPrefTheme.Name = "labelPrefTheme";
            this.labelPrefTheme.Size = new System.Drawing.Size(46, 15);
            this.labelPrefTheme.TabIndex = 2;
            this.labelPrefTheme.Text = "Theme:";
            // 
            // comboBoxPrefExpac
            // 
            this.comboBoxPrefExpac.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPrefExpac.FormattingEnabled = true;
            this.comboBoxPrefExpac.Location = new System.Drawing.Point(166, 6);
            this.comboBoxPrefExpac.Name = "comboBoxPrefExpac";
            this.comboBoxPrefExpac.Size = new System.Drawing.Size(253, 23);
            this.comboBoxPrefExpac.TabIndex = 1;
            this.comboBoxPrefExpac.SelectionChangeCommitted += new System.EventHandler(this.comboBoxPrefExpac_SelectionChangeCommitted);
            // 
            // labelPrefExpac
            // 
            this.labelPrefExpac.AutoEllipsis = true;
            this.labelPrefExpac.AutoSize = true;
            this.labelPrefExpac.Location = new System.Drawing.Point(8, 9);
            this.labelPrefExpac.Name = "labelPrefExpac";
            this.labelPrefExpac.Size = new System.Drawing.Size(152, 15);
            this.labelPrefExpac.TabIndex = 0;
            this.labelPrefExpac.Text = "Default Selected Expansion:";
            // 
            // FFXIVQuestTrackerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.tabControl);
            this.Name = "FFXIVQuestTrackerForm";
            this.Text = "FFXIV Quest Tracker";
            this.tabControl.ResumeLayout(false);
            this.tabMain.ResumeLayout(false);
            this.tabMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMainQuests)).EndInit();
            this.tabPreferences.ResumeLayout(false);
            this.tabPreferences.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TabControl tabControl;
        private TabPage tabMain;
        private TabPage tabPreferences;
        private Label labelPrefExpac;
        private ComboBox comboBoxPrefExpac;
        private ComboBox comboBoxPrefTheme;
        private Label labelPrefTheme;
        private Label labelPrefSaveLocation;
        private TextBox textBoxPrefSaveLocation;
        private Button buttonPrefSaveLocation;
        private Button buttonPrefQuestListLocation;
        private TextBox textBoxPrefQuestListLocation;
        private Label labelPrefQuestListLocation;
        private Button buttonResetSavePref;
        private Button buttonSavePref;
        private Button buttonResetQuestListPref;
        private Button buttonCancelPref;
        private Label labelMainExpac;
        private ComboBox comboBoxMainExpac;
        private ComboBox comboBoxMainCategory;
        private Label labelMainCategory;
        private DataGridView dataGridViewMainQuests;
        private DataGridViewCheckBoxColumn QuestComplete;
        private DataGridViewTextBoxColumn QuestNumber;
        private DataGridViewTextBoxColumn QuestTitle;
        private DataGridViewTextBoxColumn QuestLevel;
        private DataGridViewTextBoxColumn QuestArea;
        private DataGridViewLinkColumn QuestGarlandToolsLink;
    }
}