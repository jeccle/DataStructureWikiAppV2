using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataStructureWikiAppV2
{
    public partial class WikiForm : Form
    {
        public WikiForm()
        {
            InitializeComponent();
        }
        // [PC:2] Create a global List<T> of type information called wiki.
        private List<Information> wiki = new List<Information>();
        private string fileName = "information.dat";
        private int ptr = 0;
        private int currentItem;

        // Trace.Listeners.Add(new TextWriterTraceListener(Console.out));  
        
        #region Util
        // [PC:4] Data structure matrix contains six categories.
        private void PopulateComboBox()
        {
            string[] categories = new string[6] { "Array", "List", "Tree", "Graph", "Abstract", "Hash" };
            Trace.TraceInformation("Populating combo box.");
            foreach (string category in categories)
            {
                Trace.WriteLine("Inserting: " + category);
                catBox.Items.Add(category);
            }
        }

        // [PC:6] Create two methods to highlight and return values from radio.
        // First returns string.
        private string CheckRadioBoxValue()
        {
            if (linRB.Checked)
                return "Linear";
            else if (nonLinRB.Checked)
                return "Non-Linear";
            else
                return "";
        }

        // Second returns int.
        private int RadioBoxIndex()
        {
            if (linRB.Checked)
                return 1;
            else if (nonLinRB.Checked)
                return 0;
            else
                return -1;
        }

        // Will return bool checking if all text boxes are appropriately filled.
        private bool CheckTextBoxes()
        {
            // Checks all text boxes and measures if contents are empty or not.
            if (!(RadioBoxIndex() == -1) && !string.IsNullOrEmpty(nameBox.Text) && !string.IsNullOrEmpty(catBox.Text) && !string.IsNullOrEmpty(descBox.Text))
                return true;
            else
            {
                ClearColors();
                // Check each text box, identify field needed to be filled with a red visual marker.
                // Check if nameBox is empty.
                if (string.IsNullOrEmpty(nameBox.Text))
                {
                    Trace.TraceInformation("NameBox identified as empty.");
                    nameBox.BackColor = Color.LightPink;
                    stripLabel.Text = "Please specify Name.";
                }
                // Check if category box is empty.
                if (string.IsNullOrEmpty(catBox.Text))
                {
                    Trace.TraceInformation("catBox identified as empty.");
                    catBox.BackColor = Color.LightPink;
                    stripLabel.Text = "Please specify Category";
                }
                // Check if structure radio box is ticked.
                if (CheckRadioBoxValue() == "")
                {
                    Trace.TraceInformation("radioBox identified as empty.");
                    linRB.ForeColor = Color.Red;
                    nonLinRB.ForeColor = Color.Red;
                    stripLabel.Text = "Please specify Linear/Non-Linear.";
                }
                // Check if description is empty.
                if (string.IsNullOrEmpty(descBox.Text))
                {
                    Trace.TraceInformation("descBox identified as empty.");
                    descBox.BackColor = Color.LightPink;
                    stripLabel.Text = "Please specify Description";
                }
                Trace.TraceInformation("Fields incorrectly filled.");
                stripLabel.Text = "Fields inappropriately filled. Correct them and try again.";
                return false;
            }
        }

        // [PC:5] ValidName method takes string input and returns bool after checking for duplicates.
        private bool ValidName(string name)
        {
            // Add other text box checks here potentially.
            Trace.TraceInformation("Checking " + name + " for validity.");
            if (wiki.Exists(info => info.getName().ToLower() == name.ToLower()))
            {
                stripLabel.Text = name + " already exists.";
                Trace.TraceInformation(name + " already exists.");
                ClearColors();
                return false;
            }
            else
            {
                Trace.TraceInformation(name + " is valid");
                return true;
            }
        }

        // [PC:9] Create a custom method that will sort and display the name and category of the list.
        private void DisplayListView()
        {
            ptr = 0;
            listViewDisplay.Items.Clear();
            wiki.Sort();
            Trace.TraceInformation("Displaying elements of list.");
            foreach (var structure in wiki)
            {
                ListViewItem structureDisplay = new ListViewItem(structure.getName());
                structureDisplay.SubItems.Add(structure.getCategory());
                listViewDisplay.Items.Add(structureDisplay);
                Trace.WriteLine(structure.getName());
                ptr++;
            }
            Trace.TraceInformation("Finished displaying all elements.");
        }

        private void ClearColors()
        {
            linRB.ForeColor = Color.Black;
            nonLinRB.ForeColor = Color.Black;
            nameBox.BackColor = Color.White;
            catBox.BackColor = Color.White;
            descBox.BackColor = Color.White;
            Trace.TraceInformation("Clearing form highlights.");
        }

        // Clears all text boxes and resets radio buttons.
        private void ClearBoxes()
        {
            nameBox.Clear();
            catBox.Text = "";
            linRB.ForeColor = Color.Black;
            linRB.Checked = false;
            nonLinRB.ForeColor = Color.Black;
            nonLinRB.Checked = false;
            descBox.Clear();
            stripLabel.Text = "";
            currentItem = -1;
            Trace.TraceInformation("Clearing text boxes.");
        }

        // [PC:11] Populates text boxes with specified item information.
        private void PopBoxes(int index)
        {
            nameBox.Text = wiki[index].getName();
            catBox.Text = wiki[index].getCategory();
            // Radio box check
            if (wiki[index].getStructure().ToLower() == "linear")
            {
                linRB.Checked = true;
                nonLinRB.Checked = false;
            }
            else if (wiki[index].getStructure().ToLower() == "non-linear")
            {
                nonLinRB.Checked = true;
                linRB.Checked = false;
            }
            descBox.Text = wiki[index].getDescription();
        }

        // [PC:7] Delete currently selected item in listview.
        private void RemoveStructure(List<Information> list, int index)
        {
            try
            {
                Trace.TraceInformation("Removing item: " + list.ElementAt(index).DisplayInformation());
                stripLabel.Text = "Removing at index " + list.ElementAt(index);
                list.RemoveAt(index);
                DisplayListView();
            }
            catch
            {
                Trace.TraceError("Error removing at index: " + index);
                stripLabel.Text = "Error removing at index: " + index;
            }
        }

        // [PC:3] Add new item to list.
        private void AddStructure(List<Information> list, string name, string cat, string structure, string desc)
        {
            Information information = new Information();
            information.setStructure(structure);
            information.setName(name);
            information.setCategory(cat);
            information.setDescription(desc);
            list.Add(information);
            Trace.TraceInformation("Adding item: " + information.DisplayInformation());
        }

        // [PC:8] Edit currently selected item from list.
        private void EditStructure(List<Information> list, int index, string name, string cat, string structure, string desc)
        {
            try
            {
                Trace.TraceInformation("Editing item: " + list.ElementAt(index).getName());
                list.ElementAt(index).setName(name);
                list.ElementAt(index).setCategory(cat);
                list.ElementAt(index).setStructure(structure);
                list.ElementAt(index).setDescription(desc);
                Trace.TraceInformation(list.ElementAt(index).DisplayInformation());
                stripLabel.Text = "Edited record...";
            }
            catch
            {
                Trace.TraceError("Error editing record: " + index);
                stripLabel.Text = "Error editing record: " + index;
            }
        }

        #endregion

        #region File I/O
        // Loads information objects from specified file.
        private void LoadFromFile(string selectedFile)
        {
            try
            {
                wiki.Clear();
                using (var bin = new BinaryReader(File.Open(selectedFile, FileMode.OpenOrCreate), Encoding.UTF8, false))
                {
                    Trace.TraceInformation("Loading from " + TrimFileName(selectedFile));
                    // Until stream is complete.
                    while (bin.BaseStream.Position < bin.BaseStream.Length)
                    {
                        Information line = new Information();
                        line.setName(bin.ReadString());
                        line.setCategory(bin.ReadString());
                        line.setStructure(bin.ReadString());
                        line.setDescription(bin.ReadString());
                        wiki.Add(line);
                    }
                    Trace.TraceInformation("Loading from " + TrimFileName(selectedFile) + " complete.");
                }
            }
            catch (IOException ex)
            {
                Trace.TraceError("Error occurred reading from file " + selectedFile + ".\nError: " + ex);
                stripLabel.Text = "Error loading from file " + selectedFile + ".";
            }
        }

        // Saves information objects to binary file.
        private void SaveToFile(string selectedFile)
        {
            try
            {
                Trace.TraceInformation("Saving to " + TrimFileName(selectedFile));
                using (BinaryWriter bin = new BinaryWriter(File.Open(selectedFile, FileMode.OpenOrCreate), Encoding.UTF8, false))
                {
                    foreach (var structure in wiki)
                    {
                        bin.Write(structure.getName());
                        bin.Write(structure.getCategory());
                        bin.Write(structure.getStructure());
                        bin.Write(structure.getDescription());
                    }
                }
                Trace.TraceInformation(TrimFileName(selectedFile) + " saved.");
            }
            catch (IOException ex)
            {
                Trace.TraceError("Error occurred saving to file " + selectedFile + ".\nError: " + ex);
                stripLabel.Text = "Error saving to file " + selectedFile + ".";
            }
        }

        // Caption = Opening/Closing
        private string SelectFile(string caption, FileDialog dialog)
        {
            string currentFileName = fileName;
            FileDialog OpenText = dialog;
            //OpenText.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            OpenText.InitialDirectory = Application.StartupPath; // Initial Dir Set. Top is ROAMING. Bot is app folder.
            OpenText.Filter = "Binary Files|*.bin;*.dat";
            OpenText.DefaultExt = "bin";
            DialogResult sr = OpenText.ShowDialog(); // Open dialog box.
            if (sr == DialogResult.OK) // If ok is selected.
            {
                if (OpenText.FileName.EndsWith(".bin") | OpenText.FileName.EndsWith(".dat"))
                {
                    currentFileName = OpenText.FileName;
                    stripLabel.Text = caption + " " + TrimFileName(currentFileName);
                    //Trace.TraceInformation(caption + " " + TrimFileName(currentFileName));
                }
                else
                {
                    MessageBox.Show("Incorrect file type\nPlease select a .dat || .bin file.");
                    return null;
                }
            }
            return currentFileName;
        }

        private string TrimFileName(string fileName)
        {
            return Path.GetFileName(fileName);
        }
        #endregion

        #region Buttons
        // Add button functionality, adds structure, displays all items.
        private void addButton_Click(object sender, EventArgs e)
        {
            if (CheckTextBoxes() && ValidName(nameBox.Text))
            {
                AddStructure(wiki, nameBox.Text, catBox.SelectedItem.ToString(), CheckRadioBoxValue(), descBox.Text);
                DisplayListView();
                ClearColors();
                ClearBoxes();
                nameBox.Focus();
            }
                      

        }

        // Edit button functionality, Edits selected item, list is redisplayed.
        private void editButton_Click(object sender, EventArgs e)
        {
            if (CheckTextBoxes() && currentItem != -1)
            {
                EditStructure(wiki, currentItem, nameBox.Text, catBox.SelectedItem.ToString(), CheckRadioBoxValue(), descBox.Text);
                DisplayListView();
                ClearBoxes();
            }
        }

        // [PC:7] Remove items from listView giving user the option to back out of the action using dialogbox.
        private void delButton_Click(object sender, EventArgs e)
        {
            if (CheckTextBoxes())
            {
                Information tempInfo = new Information();
                tempInfo.setName(nameBox.Text);
                DialogResult sr = MessageBox.Show("Delete " + wiki[wiki.BinarySearch(tempInfo)].getName() + "?", "Data Structure Wiki App", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (sr == DialogResult.OK)
                {
                    RemoveStructure(wiki, wiki.BinarySearch(tempInfo));
                    ClearBoxes();
                    ClearColors();
                    stripLabel.Text = "Structure removed...";
                }
            }
            else
            {
                stripLabel.Text = "Please select a structure for deletion";
            }
        }

        // [PC:12] Create a method that will clear and reset text boxes, comboBox, etc
        private void clearButton_Click(object sender, EventArgs e)
        {
            ClearColors();
            ClearBoxes();
            listViewDisplay.Items.Clear();
            wiki.Clear();
            stripLabel.Text = "Clearing wiki...";
        }

        // [PC:14] Create two buttons for the manual open function.
        // Files are stored in binary format.
        private void loadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            LoadFromFile(SelectFile("Loading from ", openDialog));
            DisplayListView();
            ClearBoxes();
            ClearColors();
            //stripLabel.Text = "Loading from file...";
        }

        // [PC:14] Create two buttons for the manual save function.
        private void saveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            SaveToFile(SelectFile("Saving to ", saveDialog));
            ClearBoxes();
            ClearColors();
            //stripLabel.Text = "Writing to file...";
        }

        // [PC:10] Uses binary search to find data structure name. If found boxes are populated
        private void searchButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(searchBox.Text))
                {
                    Information tempInfo = new Information();
                    tempInfo.setName(searchBox.Text);
                    wiki.Sort();
                    int foundIndex = wiki.BinarySearch(tempInfo);
                    stripLabel.Text = "Searching for: " + searchBox.Text;
                    Trace.TraceInformation("Index: " + foundIndex);
                    if (foundIndex >= 0)
                    {
                        PopBoxes(foundIndex);
                        stripLabel.Text = wiki[foundIndex].getName() + " found.";
                        Trace.TraceInformation("Item: " + wiki[foundIndex].getName() + " found at: " + foundIndex);
                        listViewDisplay.Focus();
                        listViewDisplay.Items[foundIndex].Selected = true;
                        searchBox.Clear();
                        searchBox.Focus();
                    }
                    else
                    {
                        Trace.TraceInformation(searchBox.Text + " binary search failed at index: " + foundIndex);
                        stripLabel.Text = searchBox.Text + " not found.";
                    }

                }
                else
                {
                    searchBox.Focus();
                    stripLabel.Text = "Please specify what to search for.";
                }
            }
            catch (Exception ex)
            {
                Trace.TraceError("Error occurred searching for " + searchBox.Text + ".\nError: " + ex);
            }
        }
        #endregion

        #region Form Events
        private void WikiForm_Load(object sender, EventArgs e)
        {
            // Outputs Trace Information to log file which is recorded in the file dir.
            // Use Trace.Flush() or Trace.Close() to empty the output buffer.
            Trace.Listeners.Add(new TextWriterTraceListener("TraceOutput.log", "myListener"));
            PopulateComboBox();
        }

        //[PC:11] user can select a Data Structure Name from the list of Names and information will be displayed in text boxes.
        private void listViewDisplay_MouseClick(object sender, MouseEventArgs e)
        {
            currentItem = listViewDisplay.SelectedIndices[0];
            PopBoxes(currentItem);
            ClearColors();
        }

        //[PC:13] Create a double click event 
        private void listViewDisplay_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                int currentItem = listViewDisplay.SelectedIndices[0];
                DialogResult sr = MessageBox.Show("Delete " + wiki[currentItem].getName() + "?", "Data Structure Wiki App", MessageBoxButtons.OKCancel);
                if (sr == DialogResult.OK)
                {
                    RemoveStructure(wiki, currentItem);
                }
            }
            catch (Exception ex)
            {
                stripLabel.Text = "Error attempting to delete record using double click.";
            }
        }

        // [PC:15] The wiki application will save data when form closes.
        // if no is selected default filename is selected.
        private void WikiForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                DialogResult sr = MessageBox.Show("Save to new file before closing?", "Exit", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (sr == DialogResult.Yes)
                {
                    Trace.TraceInformation("Saving to file on exit");
                    SaveFileDialog saveDialog = new SaveFileDialog();
                    SaveToFile(SelectFile("Saving to ", saveDialog));
                }
                else if (sr == DialogResult.No)
                    SaveToFile(fileName);
            }
            catch(Exception ex)
            {
                Trace.TraceError("Error: " + ex);
            }
            Trace.Flush();
        }


        //[PC:13] Double click event on nameBox to clear all textBoxes.
        private void nameBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ClearBoxes();
            ClearColors();
        }


        #endregion


    }
}
