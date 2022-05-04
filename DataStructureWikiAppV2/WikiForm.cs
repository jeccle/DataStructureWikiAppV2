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
            {
                return "Linear";
            }
            else if (nonLinRB.Checked)
            {
                
                return "Non-Linear";
            }
            else
            {
                return "null";
            }
        }

        // Will return bool checking if all text boxes are appropriately filled.
        private bool CheckTextBoxes()
        {
            if (!(CheckRadioBoxValue() == "null") && !string.IsNullOrEmpty(nameBox.Text) && !string.IsNullOrEmpty(catBox.Text)
                && !string.IsNullOrEmpty(descBox.Text))
            {
                return true;
            }
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

        private void DisplayListView()
        {
            listViewDisplay.Items.Clear();
            for (int i = 0; i < wiki.Count; i++)
            {
                ListViewItem structureDisplay = new ListViewItem(wiki[i].getName());
                structureDisplay.SubItems.Add(wiki[i].getCategory());
                listViewDisplay.Items.Add(structureDisplay);
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
            nonLinRB.ForeColor = Color.Black;
            descBox.Clear();
            stripLabel.Text = "";
        }
        #endregion

        #region File I/O
        private void LoadFromFile(string selectedFile)
        {
            try
            {
                using (BinaryReader bin = new BinaryReader(new FileStream(selectedFile, FileMode.Open)))
                {
                    string[] words = new string[4];
                    // May be incorrect.
                    while (!bin.BaseStream.CanRead)
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
                using (BinaryWriter bin = new BinaryWriter(new FileStream(selectedFile, FileMode.OpenOrCreate)))
                {
                    foreach (Information structure in wiki)
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
            if (CheckTextBoxes())
            {
                Information information = new Information();
                information.setStructure(CheckRadioBoxValue());
                information.setName(nameBox.Text);
                information.setCategory(catBox.SelectedItem.ToString());
                information.setDescription(descBox.Text);
                wiki.Add(information);
                DisplayListView();
                ClearColors();
                ClearBoxes();
            }
            else
            {
                //MessageBox.Show("testing");
            }

        }

        private void editButton_Click(object sender, EventArgs e)
        {

        }

        private void delButton_Click(object sender, EventArgs e)
        {

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

    }
}
