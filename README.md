# FFXIV Quest Tracker
FFXIV Quest Tracker is a simple program that lets the user see a full list of quests in FFXIV,
mark quests as complete(and mark them incomplete again), and save the list of completed quests to a local .txt file.

The full list of quests is read from another .txt file stored in the same directory as the executable
and can be modified to include new quests or custom quests/categories for quests.

By default, the program reads and writes files to and from the same folder the executable is in,
but the user can specify where to read the main quest list from and where to save the checklist data.
The user can also specify what quests should be displayed by the program on startup. Currently the
"Theme" option is non-functional, but is intended to be properly added soon.

## Using the Program
### Starting Up
Simply place the executable and the main quest list in the same directory and run the executable.
If you want to use an existing data file that already has a list of completed quests in it, you
can accomplish this in one of two ways:  
* **Option 1**: Use the Preferences tab
	1) Go to the "Preferences" tab
 	2) Change the "Default Save Location"
	3) Click "Save Preferences"
	4) Restart the Program
* **Option 2**: Rename the file you wish to use to the name used by the default data file (*FFXIVQT_data.txt*)

### Reading the Table
The program displays a table of quests with 5 columns:
* **✓** - Displays whether or not the quest is marked as "complete"
* **#** - Displays the number of the quest as listed in the main quest list file
* **Title** - Displays the title of the quest
* **Level** - Displays the level of the quest
* **Area** - Displays the area the quest start is located in
* **GTD** - Displays a clickable link to the Garland Tools Data page for the quest

### Completing Quests
The program displays all quests available from the main quest list file. To mark a quest as completed,
simply click the check box on the row of the quest you want to mark complete.  
* Clicking "Save" will save the current list of completed quests to the default save file.
* Clicking "Save As..." will give the user a save file dialog window to select where to save the current list of completed quests.

If the user makes a change to the list of completed quests and tries to exit the program without saving,
the program will prompt the user to save their changes to the default save location.