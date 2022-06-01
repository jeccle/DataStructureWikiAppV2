using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureWikiAppV2
{
    // [PC]#1 Create separate class file containing specified four fields.
    [Serializable]
    internal class Information : IComparable<Information>
    {
        private string name;
        private string category;
        private string structure;
        private string description;

        public Information()
        {

        }

        public Information(string name, string category, string structure, string description)
        {
            setName(name);
            setCategory(category);  
            setStructure(structure);
            setDescription(description);
        }

        override public string ToString()
        {
            return name + " " + category + " " + structure + " " + description;
        }

        public string DisplayInformation()
        {
            return name + " " + category;
        }
        
        
        public int CompareTo(Information newInfoName)
        {
            return name.ToLower().CompareTo(newInfoName.name.ToLower());
        }

        public string getName()
        {
            return name;
        }

        public void setName(string newName)
        {
            name = newName;
        }

        public string getCategory()
        {
            return category;
        }

        public void setCategory(string newCategory)
        {
            category = newCategory;
        }

        public string getStructure()
        {
            return structure;
        }

        public void setStructure(string newStructure)
        {
            structure = newStructure;
        }

        public string getDescription()
        {
            return description;
        }

        public void setDescription(string newDescription)
        {
            description = newDescription;
        }
    }
}

