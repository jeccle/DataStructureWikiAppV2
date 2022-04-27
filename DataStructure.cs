using System;
namespace DataStructureWikiAppV2

public class DataStructure
{
	private string name;
	private string category;
	private string structure;
	private string description;

	public DataStructure()
	{

	}

	public string ToString()
    {
		return name + " " + category + " " + structure + " " + description;
    }

}
