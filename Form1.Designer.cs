namespace FFXIV_Quest_Tracker
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabMain = new System.Windows.Forms.TabPage();
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
            this.tabMain.Location = new System.Drawing.Point(4, 24);
            this.tabMain.Name = "tabMain";
            this.tabMain.Padding = new System.Windows.Forms.Padding(3);
            this.tabMain.Size = new System.Drawing.Size(876, 533);
            this.tabMain.TabIndex = 0;
            this.tabMain.Text = "Main";
            this.tabMain.UseVisualStyleBackColor = true;
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
            this.buttonResetQuestListPref.Location = new System.Drawing.Point(795, 92);
            this.buttonResetQuestListPref.Name = "buttonResetQuestListPref";
            this.buttonResetQuestListPref.Size = new System.Drawing.Size(75, 23);
            this.buttonResetQuestListPref.TabIndex = 19;
            this.buttonResetQuestListPref.Text = "Reset";
            this.buttonResetQuestListPref.UseVisualStyleBackColor = true;
            this.buttonResetQuestListPref.Click += new System.EventHandler(this.buttonResetQuestListPref_Click);
            // 
            // buttonResetSavePref
            // 
            this.buttonResetSavePref.Location = new System.Drawing.Point(795, 49);
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
            this.buttonPrefQuestListLocation.Location = new System.Drawing.Point(764, 93);
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
            this.textBoxPrefQuestListLocation.Size = new System.Drawing.Size(592, 23);
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
            this.buttonPrefSaveLocation.Location = new System.Drawing.Point(764, 49);
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
            this.textBoxPrefSaveLocation.Size = new System.Drawing.Size(592, 23);
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
            this.comboBoxPrefExpac.Items.AddRange(new object[] {
            "A Realm Reborn",
            "Heavensward",
            "Stormblood",
            "Shadowbringers",
            "Endwalker"});
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
    }
}