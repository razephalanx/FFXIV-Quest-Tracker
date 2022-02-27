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
            public int number;
            public string title;
            public int level;
            public string area;
            public string urlCode;
            public Uri url;

            public override string ToString()
            {
                return number + "\t" + title + "\t" + level + "\t" + area + "\t" + urlCode;
            }
        }

        #region Vars
        // Vars for preference storage
        private string[] rawPreferencesData = null;
        /// <summary>
        /// Dictionary of preferences data
        /// </summary>
        private Dictionary<string, string> preferencesDictionary;
        // Vars for expac, category, save file, theme, and quest list
        /// <summary>
        /// Currently selected expansion/main category
        /// </summary>
        private string currentExpac;
        /// <summary>
        /// Currently selected subcategory
        /// </summary>
        private string currentCategory;
        /// <summary>
        /// Currently selected theme (NOT YET IMPLEMENTED)
        /// </summary>
        private string currentTheme;
        /// <summary>
        /// Current quest data save file location
        /// </summary>
        private string currentSave;
        /// <summary>
        /// Current main quest list file location
        /// </summary>
        private string currentQuestList;
        /// <summary>
        /// One of a set of vars for temporarily storing changes to preferences without overwriting current values
        /// </summary>
        private string selectedExpac, expacToSave, selectedTheme, selectedSave, selectedQuestList;
        // Default vars for expac, theme, save file, and quest list file
        private readonly string defaultExpac = "A Realm Reborn";
        private readonly string defaultTheme = "Light";
        private readonly string defaultSaveFileName = "FFXIVQT_data.txt";
        private readonly string defaultQuestListFileName = "FFXIVQT_questlist.txt";
        // Var to store quests and data being displayed
        /// <summary>
        /// Main Dictionary of quests (both complete and incomplete)
        /// </summary>
        private Dictionary<string, Dictionary<string, List<QuestStruct>>> questDictionary;
        /// <summary>
        /// Dictionary of completed quests
        /// </summary>
        private Dictionary<string, Dictionary<string, List<QuestStruct>>> completedQuests;
        /// <summary>
        /// Dictionary of quests that is only updated after saving quest data.
        /// Same as completedQuests on startup.
        /// </summary>
        private Dictionary<string, Dictionary<string, List<QuestStruct>>> rollbackQuests;
        // Vars to detect if completed list or quest list has changed since program has opened or since last save
        /// <summary>
        /// Boolean to keep track of if completedQuests has changed
        /// </summary>
        private bool dataChanged;
        /// <summary>
        /// Boolean to keep track of if questDictionary has changed.
        /// </summary>
        // Adding/removing quests to the quest list is currently not implemented.
        private bool questListChanged;
        #endregion

        public FFXIVQuestTrackerForm()
        {
            InitializeComponent();

            // Set up Application.Exit event handler
            Application.ApplicationExit += new EventHandler(this.OnApplicationExit);

            // Prepare program
            dataChanged = false;
            questListChanged = false;
            MainStartup();

            // Sort quest table by ascending quest number by default
            dataGridViewMainQuests.Sort(dataGridViewMainQuests.Columns[1], System.ComponentModel.ListSortDirection.Ascending);
        }

        #region Main tab
        // Change checklist in Main tab to match the selected expansion
        /// <summary>
        /// Store new selected expac/main category, select the first subcategory for that expac/main category, and reload table
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxMainExpac_SelectionChangeCommitted(object sender, EventArgs e)
        {
            currentExpac = comboBoxMainExpac.Text;
            LoadCategories(currentExpac);
            LoadMainData(currentExpac, currentCategory);
        }

        /// <summary>
        /// Store new selected subcategory and reload table
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxMainCategory_SelectionChangeCommitted(object sender, EventArgs e)
        {
            currentCategory = comboBoxMainCategory.Text;
            LoadMainData(currentExpac, currentCategory);
        }

        /// <summary>
        /// Action taken when user clicked on column header.
        /// Used to fix sorting issues.
        /// Could use improvements as sorting is still weird, only consistent now.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewMainQuests_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Check the column name the user is sorting by
            DataGridViewColumn col = dataGridViewMainQuests.SortedColumn;
            // Return if the column is QuestNumber
            if (col.Name == "QuestNumber")
            {
                return;
            }
            // Get sorting order
            SortOrder order = dataGridViewMainQuests.SortOrder;
            // Sort by ascending QuestNumber before anything else
            dataGridViewMainQuests.Sort(dataGridViewMainQuests.Columns[1], System.ComponentModel.ListSortDirection.Ascending);
            // Sort by user's decision
            if (order == SortOrder.Ascending)
            {
                dataGridViewMainQuests.Sort(col, System.ComponentModel.ListSortDirection.Ascending);
            }
            else
            {
                dataGridViewMainQuests.Sort(col, System.ComponentModel.ListSortDirection.Descending);
            }
        }

        /// <summary>
        /// Display information about the program
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonAbout_Click(object sender, EventArgs e)
        {
            using (AboutBoxFFXIVQT box = new AboutBoxFFXIVQT())
            {
                box.ShowDialog();
            }
        }

        /// <summary>
        /// Add/remove quest(s) from completedQuests when a row's checkbox value changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewMainQuests_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Make sure cell is in checkbox column
            if (!(e.RowIndex != -1 && e.ColumnIndex == 0 && dataGridViewMainQuests.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn))
            {
                return;
            }

            // Create temporary QuestStruct to add/remove a quest from completedQuests
            QuestStruct temp = new QuestStruct();
            temp.number = (int)dataGridViewMainQuests[1, e.RowIndex].Value;
            temp.title = dataGridViewMainQuests[2, e.RowIndex].Value.ToString();
            temp.level = (int)dataGridViewMainQuests[3, e.RowIndex].Value;
            temp.area = dataGridViewMainQuests[4, e.RowIndex].Value.ToString();
            temp.url = (Uri)dataGridViewMainQuests[5, e.RowIndex].Value;
            temp.urlCode = dataGridViewMainQuests[5, e.RowIndex].Value.ToString().Substring(dataGridViewMainQuests[5, e.RowIndex].Value.ToString().LastIndexOf("/") + 1);

            // Check if completedQuests has the currently selected expansion and category already added
            // Kinda messy, but quest data .txt should already have all expansions and categories in order
            // and the order in completedQuests doesn't really matter anyways (except for saving to a file)
            if (!completedQuests.ContainsKey(currentExpac))
            {
                Dictionary<string, List<QuestStruct>> dic = new Dictionary<string, List<QuestStruct>>();
                completedQuests.Add(currentExpac, dic);
            }
            if (!completedQuests[currentExpac].ContainsKey(currentCategory))
            {
                List<QuestStruct> list = new List<QuestStruct>();
                completedQuests[currentExpac].Add(currentCategory, list);
            }

            // Add newly completed quest to completedQuests
            if ((bool)dataGridViewMainQuests[e.ColumnIndex, e.RowIndex].Value == true && !completedQuests[currentExpac][currentCategory].Contains(temp))
            {
                completedQuests[currentExpac][currentCategory].Add(temp);
                dataChanged = true;
                // Re-sort the List<QuestStruct> at completedQuests[currentExpac][currentCategory] by quest number
                completedQuests[currentExpac][currentCategory].Sort((quest1, quest2) => quest1.number.CompareTo(quest2.number));
            }
            // Remove quest marked incompleted from completedQuests
            else if ((bool)dataGridViewMainQuests[e.ColumnIndex, e.RowIndex].Value == false && completedQuests[currentExpac][currentCategory].Contains(temp))
            {
                completedQuests[currentExpac][currentCategory].Remove(temp);
                dataChanged = true;
                // Re-sort the List<QuestStruct> at completedQuests[currentExpac][currentCategory] by quest number
                completedQuests[currentExpac][currentCategory].Sort((quest1, quest2) => quest1.number.CompareTo(quest2.number));
            }
        }

        /// <summary>
        /// Save quest data to default location on button press
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonMainSaveDefault_Click(object sender, EventArgs e)
        {
            SaveQuestData(currentSave);
            // Update rollbackQuests
            CopyQuestDictionary(completedQuests, rollbackQuests);
        }

        /// <summary>
        /// Save quest data to specified file on button press
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonMainSaveAs_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Text files (*.txt)|*.txt|All file (*.*)|*.*";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                SaveQuestData(dlg.FileName);
                // Update rollbackQuests
                CopyQuestDictionary(completedQuests, rollbackQuests);
            }
        }

        /// <summary>
        /// Cancel saving changes of quest data, undo changes on table
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCancelDataChanges_Click(object sender, EventArgs e)
        {
            // Check if any changes have been made to quest data
            if (!dataChanged)
            {
                MessageBox.Show("No changes to revert.", "", MessageBoxButtons.OK, MessageBoxIcon.None);
                return;
            }

            // Prompt user to cancel changes
            DialogResult dialogResult = MessageBox.Show("Undo changes to checklist and revert to last save?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                // Deep copy rollbackQuests into completedQuests
                CopyQuestDictionary(rollbackQuests, completedQuests);
                // Reload quest table
                LoadMainData(currentExpac, currentCategory);
                // Reset dataChanged to false
                dataChanged = false;
            }
        }
        #endregion

        #region Preferences
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
            System.Windows.Forms.MessageBox.Show("Preferences saved.", "NOTICE", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        #region Miscellaneous Functions
        /// <summary>
        /// Action(s) to perform when Application.Exit is called
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnApplicationExit(object sender, EventArgs e)
        {
            // Prompt user to save changes to quest list if they were not saved
            if (questListChanged)
            {
                DialogResult dgResult = MessageBox.Show("Changes to quest list have not been saved.\nSave now?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dgResult == DialogResult.Yes)
                {
                    SaveQuestList(currentQuestList);
                }
            }

            // Prompt user to save completed quest data to file if completed quest data was changed
            if (dataChanged)
            {
                DialogResult dialogResult = MessageBox.Show("Quest data has not been saved.\nSave data now?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    SaveQuestData(currentSave);
                }
            }
        }
        #endregion
    }
}