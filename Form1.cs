using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFXIV_Quest_Tracker
{
    public partial class FFXIVQuestTrackerForm : Form
    {
        private string[] rawPreferencesData = null;
        private Dictionary<string, string> preferencesDictionary;
        private string currentExpac, currentyCategory, currentTheme, currentSave, currentQuestList;
        private string defaultExpac = "A Realm Reborn";
        private string defaultTheme = "Light";
        private string defaultSaveFileName = "FFXIVQT_data.txt";
        private string defaultQuestListFileName = "FFXIVQT_questlist.txt";
        private string selectedExpac, expacToSave, selectedTheme, selectedSave, selectedQuestList;

        // Reset textBoxPrefSaveLocation to default value
        private void buttonResetSavePref_Click(object sender, EventArgs e)
        {
            string _basePath = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory);
            string defaultSaveLocation = _basePath + @"\" + defaultSaveFileName;
            textBoxPrefSaveLocation.Text = defaultSaveLocation;
            selectedSave = defaultSaveLocation;
        }

        // Undo selections when preference saving is cancelled
        private void buttonCancelPref_Click(object sender, EventArgs e)
        {
            comboBoxPrefExpac.SelectedIndex = comboBoxPrefExpac.FindStringExact(expacToSave);
            selectedExpac = expacToSave;
            comboBoxPrefTheme.SelectedIndex = comboBoxPrefTheme.FindStringExact(currentTheme);
            selectedTheme = currentTheme;
            textBoxPrefSaveLocation.Text = currentSave;
            selectedSave = currentSave;
            textBoxPrefQuestListLocation.Text = currentQuestList;
            selectedQuestList = currentQuestList;
        }


        // Save preferences to file
        private void buttonSavePref_Click(object sender, EventArgs e)
        {
            // Get path to preferences file
            string _filePath = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory)  + @"\preferences.txt";
            // Store values to be written to file
            expacToSave = selectedExpac;
            currentTheme = selectedTheme;
            currentSave = selectedSave;
            currentQuestList = selectedQuestList;
            string[] lines = {  "defaultExpac=" + expacToSave,
                                "theme=" + currentTheme,
                                "saveLocation=" + currentSave,
                                "questListLocation=" + currentQuestList};
            
            // Write values to file
            File.WriteAllLines(_filePath, lines);
            // Show message on completion
            System.Windows.Forms.MessageBox.Show("Preferences saved.", "NOTICE", MessageBoxButtons.OK);
        }
        
        // Change theme
        private void changeTheme()
        {
            // TODO
        }

        // Reset textBoxPrefQuestListLocation to default value
        private void buttonResetQuestListPref_Click(object sender, EventArgs e)
        {
            string _basePath = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory);
            string defaultQuestListLocation = _basePath + @"\" + defaultQuestListFileName;
            textBoxPrefQuestListLocation.Text = defaultQuestListLocation;
            selectedQuestList = defaultQuestListLocation;
        }

        public FFXIVQuestTrackerForm()
        {
            InitializeComponent();

            // Load preferences from file, create new preferences file if none exists
            loadPrefs();
        }

        // Store selected theme
        private void comboBoxPrefTheme_SelectionChangeCommitted(object sender, EventArgs e)
        {
            selectedTheme = comboBoxPrefTheme.Text;
        }

        // Store selected expac
        private void comboBoxPrefExpac_SelectionChangeCommitted(object sender, EventArgs e)
        {
            selectedExpac = comboBoxPrefExpac.Text;
        }

        // Select file path for quest list location in preferences
        private void buttonPrefQuestListLocation_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                textBoxPrefQuestListLocation.Text = Path.GetFullPath(dlg.FileName);
                selectedQuestList = textBoxPrefQuestListLocation.Text;
            }
        }

        // Select file path for save location in preferences
        private void buttonPrefSaveLocation_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                textBoxPrefSaveLocation.Text = Path.GetFullPath(dlg.FileName);
                selectedSave = textBoxPrefSaveLocation.Text;
            }
        }
    }
}