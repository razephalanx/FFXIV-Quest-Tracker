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
        public void loadPrefs()
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
            currentExpac = selectedExpac = expacToSave = comboBoxPrefExpac.Text;
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
            currentSave = selectedSave = textBoxPrefSaveLocation.Text;
            // Quest List Location
            textBoxPrefQuestListLocation.Text = preferencesDictionary["questListLocation"];
            currentQuestList = selectedQuestList = textBoxPrefQuestListLocation.Text;
            #endregion
        }
    }
}
