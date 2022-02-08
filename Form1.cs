using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFXIV_Quest_Tracker
{
    public partial class FFXIVQuestTrackerForm : Form
    {
        // Struct to store quest information
        private struct QuestStruct
        {
            //public bool complete;
            public int number;
            public string title;
            public int level;
            public string area;
            //public string url;
            public Uri url;

            public override string ToString()
            {
                return number + "\t" + title + "\t" + level + "\t" + area + "\t" + url;
            }
        }

        #region Vars
        // Vars for preference storage
        private string[] rawPreferencesData = null;
        private Dictionary<string, string> preferencesDictionary;
        // Vars for expac, category, save file, theme, and quest list
        private string currentExpac, currentCategory, currentTheme, currentSave, currentQuestList;
        private string selectedExpac, expacToSave, selectedTheme, selectedSave, selectedQuestList;
        // Default vars for expac, theme, save file, and quest list file
        private string defaultExpac = "A Realm Reborn";
        private string defaultTheme = "Light";
        private string defaultSaveFileName = "FFXIVQT_data.txt";
        private string defaultQuestListFileName = "FFXIVQT_questlist.txt";
        // Var to store quests being displayed
        private Dictionary<string, Dictionary<string, List<QuestStruct>>> questDictionary;
        private Dictionary<string, Dictionary<string, List<QuestStruct>>> completedQuests;
        #endregion

        public FFXIVQuestTrackerForm()
        {
            InitializeComponent();
            
            // Prepare program
            mainStartup();
        }

        #region Main tab
        // Change checklist in Main tab to match the selected expansion
        private void comboBoxMainExpac_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentExpac = comboBoxMainExpac.Text;
            loadCategories(currentExpac);
            loadMainData(currentExpac, currentCategory);
        }

        // Store new selected category
        private void comboBoxMainCategory_SelectionChangeCommitted(object sender, EventArgs e)
        {
            currentCategory = comboBoxMainCategory.Text;
            loadMainData(currentExpac, currentCategory);
        }
        #endregion

        #region Preferences
        // Store selected theme
        private void comboBoxPrefTheme_SelectionChangeCommitted(object sender, EventArgs e)
        {
            selectedTheme = comboBoxPrefTheme.Text;
        }

        // Open Garland Tools Data link in browser on URL click
        private void dataGridViewMainQuests_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex == 5 && dataGridViewMainQuests.Columns[e.ColumnIndex] is DataGridViewLinkColumn)
            {
                //System.Diagnostics.Process.Start("cmd", "c/ start " + dataGridViewMainQuests[e.ColumnIndex, e.RowIndex].Value.ToString());
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(dataGridViewMainQuests[e.ColumnIndex, e.RowIndex].Value.ToString())
                                                                                        { UseShellExecute = true });
            }
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

        // Reset save location text box to default value
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
            string _filePath = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory) + @"\preferences.txt";
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

        // Reset quest list location text box to default value
        private void buttonResetQuestListPref_Click(object sender, EventArgs e)
        {
            string _basePath = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory);
            string defaultQuestListLocation = _basePath + @"\" + defaultQuestListFileName;
            textBoxPrefQuestListLocation.Text = defaultQuestListLocation;
            selectedQuestList = defaultQuestListLocation;
        }
        #endregion

        // Change theme
        private void changeTheme()
        {
            // TODO
        }
    }
}