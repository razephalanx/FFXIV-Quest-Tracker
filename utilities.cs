using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFXIV_Quest_Tracker
{
    public partial class FFXIVQuestTrackerForm : Form
    {
        /// <summary>
        /// Load preferences from text file located in same directory as executable
        /// </summary>
        private void loadPrefs()
        {
            #region Set up variables for loading preferences
            // Get file path to preferences.txt
            string _basePath = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory);
            string _filePath = _basePath + @"\preferences.txt";
            // Set up variables
            string defaultSaveLocation = _basePath + @"\" + defaultSaveFileName;
            string defaultQuestListLocation = _basePath + @"\" + defaultQuestListFileName;
            int numOfPreferences = 4;
            #endregion

            #region Check if preferences.txt exists
            // Check if preferences.txt exists, create new preferences.txt if false
            if (!File.Exists(_filePath))
            {
                string[] defaultLines = {   "defaultExpac="         + defaultExpac,
                                            "theme="                + defaultTheme,
                                            "saveLocation="         + defaultSaveLocation,
                                            "questListLocation="    + defaultQuestListLocation};
                File.WriteAllLines(_filePath, defaultLines);
                System.Windows.Forms.MessageBox.Show("A preferences text file has been created at " + _filePath, "NOTICE", MessageBoxButtons.OK);
            }
            #endregion

            #region Load text file information
            // Store text lines in rawPreferencesData
            rawPreferencesData = System.IO.File.ReadAllLines(_filePath);
            // Store preferences data in preferencesDictionary
            preferencesDictionary = new Dictionary<string, string>();
            char[] delimiterchars = { '=' };
            foreach (string str in rawPreferencesData)
            {
                string[] split = str.Split(delimiterchars);
                switch(split[0].ToLower())
                {
                    case "defaultexpac":
                        preferencesDictionary.Add("defaultExpac", split[1]);
                        break;
                    case "theme":
                        preferencesDictionary.Add("theme", split[1]);
                        break;
                    case "savelocation":
                        preferencesDictionary.Add("saveLocation", split[1]);
                        break;
                    case "questlistlocation":
                        preferencesDictionary.Add("questListLocation", split[1]);
                        break;
                    default:
                        // Do nothing
                        break;
                }
            }
            #endregion

            #region Check if preferences are missing from file and use defaults for missing ones
            // Check if any preferences are missing, use default values for any missing ones
            if (preferencesDictionary.Count != numOfPreferences)
            {
                System.Windows.Forms.MessageBox.Show("One or more preferences are missing from the preferences text file, using default values for missing preferences.", "NOTICE", MessageBoxButtons.OK);
                // Create dictionary using default values
                Dictionary<string, string> allPrefsDict = new Dictionary<string, string>();
                allPrefsDict.Add("defaultExpac", defaultExpac);
                allPrefsDict.Add("theme", defaultTheme);
                allPrefsDict.Add("saveLocation", defaultSaveLocation);
                allPrefsDict.Add("questListLocation", defaultQuestListLocation);

                // Perform union of preferencesDictionary and allPrefsDict
                preferencesDictionary = preferencesDictionary.Union(allPrefsDict)
                                                             .GroupBy(g => g.Key)
                                                             .ToDictionary(pair => pair.Key, pair => pair.First().Value);
            }
            #endregion

            #region Finish setting up preferences
            // Setup values in preferences tab
            currentExpac = selectedExpac = expacToSave = preferencesDictionary["defaultExpac"];
            currentSave = selectedSave = preferencesDictionary["saveLocation"];
            currentQuestList = selectedQuestList = preferencesDictionary["questListLocation"];
            // Load data from save and quest list files
            loadQuestData();
            loadQuestList();
            // Fill out combobox options
            loadExpansions();
            comboBoxMainExpac.SelectedIndex = comboBoxMainExpac.FindStringExact(currentExpac);
            loadCategories(currentExpac);

            // Default Expansion
            if (comboBoxPrefExpac.FindString(preferencesDictionary["defaultExpac"]) != -1)
            {
                comboBoxPrefExpac.SelectedIndex = comboBoxPrefExpac.FindStringExact(preferencesDictionary["defaultExpac"]);
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Expansion " + preferencesDictionary["defaultExpac"] + " not found, defaulting to \"A Realm Reborn\".", "ERROR");
                comboBoxPrefExpac.SelectedIndex = comboBoxPrefExpac.FindStringExact("A Realm Reborn");
            }
            // Theme
            if (comboBoxPrefTheme.FindString(preferencesDictionary["theme"]) != -1)
            {
                comboBoxPrefTheme.SelectedIndex = comboBoxPrefTheme.FindStringExact(preferencesDictionary["theme"]);
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Theme " + preferencesDictionary["theme"] + " not found, defaulting to \"Light\".", "ERROR");
                comboBoxPrefTheme.SelectedIndex = comboBoxPrefTheme.FindStringExact("Light");
            }
            currentTheme = selectedTheme = comboBoxPrefTheme.Text;
            // Default Save Location
            textBoxPrefSaveLocation.Text = preferencesDictionary["saveLocation"];
            // Quest List Location
            textBoxPrefQuestListLocation.Text = preferencesDictionary["questListLocation"];
            #endregion
        }

        /// <summary>
        /// Load quest list into Main tab
        /// </summary>
        private void mainStartup()
        {
            loadPrefs();
            loadMainData(currentExpac, currentCategory);
        }

        /// <summary>
        /// Add items to Expansion drop down list
        /// </summary>
        private void loadExpansions()
        {
            foreach(KeyValuePair<string, Dictionary<string, List<QuestStruct>>> pair in questDictionary)
            {
                comboBoxMainExpac.Items.Add(pair.Key);
                comboBoxPrefExpac.Items.Add(pair.Key);
            }
        }

        /// <summary>
        /// Add items to Category drop down list according to input expansion name
        /// </summary>
        /// <param name="expac"></param>
        private void loadCategories(string expac)
        {
            comboBoxMainCategory.Items.Clear();
            foreach(KeyValuePair<string, Dictionary<string, List<QuestStruct>>> pair in questDictionary)
            {
                foreach(KeyValuePair<string, List<QuestStruct>> subpair in pair.Value) {
                    if (pair.Key == currentExpac)
                    {
                        comboBoxMainCategory.Items.Add(subpair.Key);
                    }
                }
            }
            comboBoxMainCategory.SelectedIndex = 0;
            currentCategory = comboBoxMainCategory.Text;
        }

        /// <summary>
        /// Load quest list into vars
        /// </summary>
        private void loadQuestList()
        {
            // Set up vars
            string expac = "";
            string category = "";
            List<QuestStruct> questList = null;
            Dictionary<string, List<QuestStruct>> questCategories = null;
            questDictionary = new Dictionary<string, Dictionary<string, List<QuestStruct>>>();
            char[] delimiterChars = { '\t' };

            // Read each line and create separate list of QuestStruct for each category within each expansion
            try
            {
                foreach (var line in File.ReadAllLines(currentQuestList))
                {
                    // Skip line if empty or null
                    if (line != "" && line != null)
                    {
                        // Determine what subsection is being read
                        if (line.StartsWith("### ") && line.EndsWith(" ###") && questCategories == null)
                        {
                            expac = line.Substring(4, line.IndexOf(" #", 5) - 4);
                            questCategories = new Dictionary<string, List<QuestStruct>>();
                        }
                        else if (line.StartsWith("=== ") && line.EndsWith(" ===") && questList == null)
                        {
                            category = line.Substring(4, line.IndexOf(" =", 5) - 4);
                            questList = new List<QuestStruct>();
                        }
                        else if (line.StartsWith("=== ") && line.EndsWith(" ===") && questList != null)
                        {
                            questCategories.Add(category, questList);
                            category = line.Substring(4, line.IndexOf(" =", 5) - 4);
                            questList = new List<QuestStruct>();
                        }
                        else if (line.StartsWith("### ") && line.EndsWith(" ###") && questCategories != null)
                        {
                            questCategories.Add(category, questList);
                            questDictionary.Add(expac, questCategories);
                            questCategories = null;
                            questList = null;
                            questCategories = new Dictionary<string, List<QuestStruct>>();
                            expac = line.Substring(4, line.IndexOf(" #", 5) - 4);
                        }

                        // Add new QuestStruct object to questList
                        if (!(line.StartsWith("### ") && line.EndsWith(" ###")) && !(line.StartsWith("=== ") && line.EndsWith(" ===")) && questList != null)
                        {
                            string[] split = line.Split(delimiterChars);
                            QuestStruct quest = new QuestStruct();
                            if (!Int32.TryParse(split[0], out quest.number))
                            {
                                throw new Exception("Bad quest number: " + split[0]);
                            }
                            quest.title = split[1];
                            if (!Int32.TryParse(split[2], out quest.level))
                            {
                                throw new Exception("Bad quest level: " + split[2]);
                            }
                            quest.area = split[3];
                            //bool uriSuccess = Uri.TryCreate(@"https://garlandtools.org/db/#quest/" + split[4], , quest.url);
                            quest.url = new Uri(@"https://garlandtools.org/db/#quest/" + split[4]);
                            //quest.url = @"https://garlandtools.org/db/#quest/" + split[4];
                            questList.Add(quest);
                        }
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                System.Windows.Forms.MessageBox.Show("Quest list file not found. Please place a file called \"FFXIVQT_questlist.txt\"" +
                                                     "in the same directory as this program's executable. and try again",
                                                     "ERROR",
                                                     MessageBoxButtons.OK,
                                                     MessageBoxIcon.Error);
                Application.Exit();
                Environment.Exit(-1);
            }
        }

        /// <summary>
        /// Load completed quest data
        /// </summary>
        private void loadQuestData()
        {
            // Set up vars
            string expac = "";
            string category = "";
            List<QuestStruct> questList = null;
            Dictionary<string, List<QuestStruct>> questCategories = null;
            completedQuests = new Dictionary<string, Dictionary<string, List<QuestStruct>>>();
            char[] delimiterChars = { '\t' };

            // Read each line and create separate list of QuestStruct for each category within each expansion
            try
            {
                foreach (var line in File.ReadAllLines(currentSave))
                {
                    // Skip line if empty or null
                    if (line != "" && line != null)
                    {
                        // Determine what subsection is being read
                        if (line.StartsWith("### ") && line.EndsWith(" ###") && questCategories == null)
                        {
                            expac = line.Substring(4, line.IndexOf(" #", 5) - 4);
                            questCategories = new Dictionary<string, List<QuestStruct>>();
                        }
                        else if (line.StartsWith("=== ") && line.EndsWith(" ===") && questList == null)
                        {
                            category = line.Substring(4, line.IndexOf(" =", 5) - 4);
                            questList = new List<QuestStruct>();
                        }
                        else if (line.StartsWith("=== ") && line.EndsWith(" ===") && questList != null)
                        {
                            questCategories.Add(category, questList);
                            category = line.Substring(4, line.IndexOf(" =", 5) - 4);
                            questList = new List<QuestStruct>();
                        }
                        else if (line.StartsWith("### ") && line.EndsWith(" ###") && questCategories != null)
                        {
                            questCategories.Add(category, questList);
                            completedQuests.Add(expac, questCategories);
                            questCategories = null;
                            questList = null;
                            questCategories = new Dictionary<string, List<QuestStruct>>();
                            expac = line.Substring(4, line.IndexOf(" #", 5) - 4);
                        }

                        // Add new QuestStruct object to questList
                        if (!(line.StartsWith("### ") && line.EndsWith(" ###")) && !(line.StartsWith("=== ") && line.EndsWith(" ===")) && questList != null)
                        {
                            string[] split = line.Split(delimiterChars);
                            QuestStruct quest = new QuestStruct();
                            if (!Int32.TryParse(split[0], out quest.number))
                            {
                                throw new Exception("Bad quest number: " + split[0]);
                            }
                            quest.title = split[1];
                            if (!Int32.TryParse(split[2], out quest.level))
                            {
                                throw new Exception("Bad quest level: " + split[2]);
                            }
                            quest.area = split[3];
                            quest.url = new Uri(@"https://garlandtools.org/db/#quest/" + split[4]);
                            //quest.url = @"https://garlandtools.org/db/#quest/" + split[4];
                            questList.Add(quest);
                        }
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                System.Windows.Forms.MessageBox.Show("Quest data file not found. Please place a file called \"FFXIVQT_data.txt\"" +
                                                     "in the same directory as this program's executable. and try again",
                                                     "ERROR",
                                                     MessageBoxButtons.OK,
                                                     MessageBoxIcon.Error);
                Application.Exit();
                Environment.Exit(-1);
            }
        }

        /// <summary>
        /// Load information into Main tab's DataGridView
        /// </summary>
        private void loadMainData(string expac, string category)
        {
            dataGridViewMainQuests.Rows.Clear();
            bool completedContainsExpacCategory = (completedQuests.ContainsKey(expac) && completedQuests[expac].ContainsKey(category));
            foreach (QuestStruct quest in questDictionary[expac][category])
            {
                if (completedContainsExpacCategory && completedQuests[expac][category].Contains(quest))
                {
                    //System.Diagnostics.Debug.WriteLine("Found in completed: " + quest.title);
                    dataGridViewMainQuests.Rows.Add(true, quest.number, quest.title, quest.level, quest.area, quest.url);
                }
                else
                {
                    //System.Diagnostics.Debug.WriteLine("Not Found: " + quest.title);
                    dataGridViewMainQuests.Rows.Add(false, quest.number, quest.title, quest.level, quest.area, quest.url);
                }
            }
        }
    }
}
