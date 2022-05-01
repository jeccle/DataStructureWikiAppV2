using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureWikiAppV2
{
    internal class Information : IComparable<Information>
    {
        private string name;
        private string category;
        private string structure;
        private string description;

        public Information(string name, string category, string structure, string description)
        {
            this.name = name;
            this.category = category;  
            this.structure = structure;
            this.description = description;
        }

        override public string ToString()
        {
            return name + " " + category + " " + structure + " " + description;
        }

        private int CompareTo()
    }
}

