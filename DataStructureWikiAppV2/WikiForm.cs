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
        List<Information> wiki = new List<Information>();
        string[] categories = new string[6] { "Array", "List", "Tree", "Graph", "Abstract", "Hash" };
        string fileName = "";

        #region Util
        private void populateComboBox()
        {
            foreach (string category in categories)
            {
                catBox.Items.Add(category);
            }
        }

        #endregion

        #region File I/O
        private void loadFromFile()
        {
            try
            {
                using (Stream stream = File.Open(fileName, FileMode.Open))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    string[] words = new string[4];
                    // May be incorrect.
                    while (!stream.CanRead)
                    {
                        var line = (Information)bin.Deserialize(stream);
                        wiki.Add(line);
                    }
                }
            }
            catch
            {
                // Error msgs
            }
        }

        private void saveToFile()
        {
            try
            {
                using (Stream stream = File.Open(fileName, FileMode.OpenOrCreate))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    foreach (Information structure in wiki)
                    {
                        bin.Serialize(stream, structure);
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
        #endregion

        #region Form Events
        private void WikiForm_Load(object sender, EventArgs e)
        {
            populateComboBox();
        }

        #endregion
    }
}
