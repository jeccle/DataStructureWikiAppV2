using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureWikiAppV2
{
    internal class Information
    {
        private string name;
        private string category;
        private string structure;
        private string description;

        public Information()
        {

        }

        override public string ToString()
        {
            return name + " " + category + " " + structure + " " + description;
        }

    }
}

