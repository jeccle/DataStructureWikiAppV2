﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        private List<Information> wiki = new List<Information>();
        private string fileName = "information.dat";
        private int ptr = 0;
        private int currentItem;

        #region Util
        private void PopulateComboBox()
        {
            string[] categories = new string[6] { "Array", "List", "Tree", "Graph", "Abstract", "Hash" };
            foreach (string category in categories)
            {
                catBox.Items.Add(category);
            }
        }

        private string CheckRadioBoxValue()
        {
            if (linRB.Checked)
                return "Linear";
            else if (nonLinRB.Checked)
                return "Non-Linear";
            else
                return "null";
        }

        private void SetRadioBoxValue()
        {

        }

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
            if (!(RadioBoxIndex() == -1) && !string.IsNullOrEmpty(nameBox.Text) && !string.IsNullOrEmpty(catBox.Text) && !string.IsNullOrEmpty(descBox.Text))
                return true;
            else
            {
                ClearColors();
                // Check each text box, identify if they need to be filled with a red visual marker.
                if (string.IsNullOrEmpty(nameBox.Text))
                {
                    nameBox.BackColor = Color.LightPink;
                    stripLabel.Text = "Please specify Name.";
                }
                if (string.IsNullOrEmpty(catBox.Text))
                {
                    catBox.BackColor = Color.LightPink;
                    stripLabel.Text = "Please specify Category";
                }
                if (CheckRadioBoxValue() == "null")
                {
                    linRB.ForeColor = Color.Red;
                    nonLinRB.ForeColor = Color.Red;
                    stripLabel.Text = "Please specify Linear/Non-Linear.";
                }
                if (string.IsNullOrEmpty(descBox.Text)) 
                { 
                    descBox.BackColor = Color.LightPink;
                    stripLabel.Text = "Please specify Description";
                }
                stripLabel.Text = "Fields inappropriately filled. Correct them and try again.";
                return false;
            }
        }

        private bool ValidName(string name)
        {
            if (wiki.Exists(info => info.getName().ToLower() == name.ToLower()))
                return false;
            else
                return true;
        }

        private void DisplayListView()
        {
            ptr = 0;
            listViewDisplay.Items.Clear();
            foreach (var structure in wiki)
            {
                ListViewItem structureDisplay = new ListViewItem(structure.getName());
                structureDisplay.SubItems.Add(structure.getCategory());
                listViewDisplay.Items.Add(structureDisplay);
                ptr++;
            }
        }

        private void ClearColors()
        {
            linRB.ForeColor = Color.Black;
            nonLinRB.ForeColor = Color.Black;
            nameBox.BackColor = Color.White;
            catBox.BackColor = Color.White;
            descBox.BackColor = Color.White;
        }

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
        }

        private void PopBoxes(int index)
        {
            nameBox.Text = wiki[index].getName();
            catBox.Text = wiki[index].getCategory();
            // Change to reaadio box structureBox.Text = wiki[index].getStructure();
            if (wiki[index].getStructure().ToLower() == "linear")
            {
                linRB.Checked = true;
                nonLinRB.Checked = true;
            }
            else if (wiki[index].getStructure().ToLower() == "non-linear")
            {
                nonLinRB.Checked = true;
                linRB.Checked = false;
            }

            descBox.Text = wiki[index].getDescription();
        }

        private void RemoveStructure(List<Information> list, int index)
        {
            try
            {
                list.RemoveAt(index);
                DisplayListView();
                stripLabel.Text = "Removing at index " + index;
            }
            catch
            {
                // Error msgs
            }
        }

        private void AddStructure(List<Information> list, string name, string cat, string structure, string desc)
        {
            Information information = new Information();
            information.setStructure(structure);
            information.setName(name);
            information.setCategory(cat);
            information.setDescription(desc);
            list.Add(information);
        }

        private void EditStructure(List<Information> list, int index, string name, string cat, string structure, string desc)
        {
            try
            {
                list.ElementAt(index).setName(name);
                list.ElementAt(index).setCategory(cat);
                list.ElementAt(index).setStructure(structure);
                list.ElementAt(index).setDescription(desc);
                stripLabel.Text = "Edited record...";
            }
            catch
            {
                // Error msgs
            }
        }

        #endregion

        #region File I/O
        private void LoadFromFile(string selectedFile)
        {
            try
            {
                wiki.Clear();
                using (var bin = new BinaryReader(File.Open(selectedFile, FileMode.OpenOrCreate), Encoding.UTF8, false))
                {
                    // May be incorrect.
                    while (bin.BaseStream.CanRead)
                    {
                        Information line = new Information();
                        line.setName(bin.ReadString());
                        line.setCategory(bin.ReadString());
                        line.setStructure(bin.ReadString());
                        line.setDescription(bin.ReadString());
                        wiki.Add(line);
                    }
                }
            }
            catch (IOException ex)
            {
                // Error msgs
            }
        }

        private void SaveToFile(string selectedFile)
        {
            try
            {
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
            }
            catch (IOException ex)
            {
                // error msgs
            }
        }
        #endregion

        #region Buttons
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
            else
            {
                //MessageBox.Show("testing");
            }

        }

        private void editButton_Click(object sender, EventArgs e)
        {
            if (CheckTextBoxes() && currentItem != -1)
            {

                EditStructure(wiki, currentItem, nameBox.Text, catBox.SelectedItem.ToString(), CheckRadioBoxValue(), descBox.Text);
            }
        }

        private void delButton_Click(object sender, EventArgs e)
        {
            if (CheckTextBoxes())
            {
                DialogResult sr = MessageBox.Show("Delete " + wiki[currentItem].getName() + "?", "Data Structure Wiki App", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (sr == DialogResult.OK)
                {
                    RemoveStructure(wiki, currentItem);
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

        private void clearButton_Click(object sender, EventArgs e)
        {
            ClearColors();
            ClearBoxes();
            stripLabel.Text = "Clearing wiki...";
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            LoadFromFile(fileName);
            DisplayListView();
            stripLabel.Text = "Loading from file...";
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            SaveToFile(fileName);
            stripLabel.Text = "Writing to file...";
        }
        #endregion

        #region Form Events
        private void WikiForm_Load(object sender, EventArgs e)
        {
            PopulateComboBox();
        }

        #endregion

        private void listViewDisplay_MouseClick(object sender, MouseEventArgs e)
        {
            currentItem = listViewDisplay.SelectedIndices[0];
            PopBoxes(currentItem);
        }

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
            catch
            {
                stripLabel.Text = "Error attempting to delete record using double click.";
            }
        }
    }
}
