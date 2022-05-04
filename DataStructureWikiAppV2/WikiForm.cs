using System;
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
                linRB.ForeColor = Color.Red;
                nonLinRB.ForeColor = Color.Red;
                stripLabel.Text = "Please specify Linear/Non-Linear.";
                return null;
            }
        }

        // Will return bool checking if all text boxes are appropriately filled.
        private bool CheckTextBoxes()
        {
            return true;
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
            catch
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
            catch
            {
                // error msgs
            }
        }
        #endregion

        #region Buttons
        private void addButton_Click(object sender, EventArgs e)
        {
        
            Information information = new Information();
            information.setName(nameBox.Text);
            information.setCategory(catBox.SelectedItem.ToString());
            information.setStructure(CheckRadioBoxValue());
            information.setDescription(descBox.Text);
            wiki.Add(information);
            DisplayListView();

        }

        private void editButton_Click(object sender, EventArgs e)
        {

        }

        private void delButton_Click(object sender, EventArgs e)
        {

        }

        private void clearButton_Click(object sender, EventArgs e)
        {

        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            LoadFromFile(fileName);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            SaveToFile(fileName);
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
