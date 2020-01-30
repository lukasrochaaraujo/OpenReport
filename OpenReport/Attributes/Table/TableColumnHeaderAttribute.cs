using System;

namespace OpenReport.Attributes.Table
{
    public class TableColumnHeaderAttribute : Attribute
    {
        public string Description;

        public TableColumnHeaderAttribute(string description)
        {
            Description = description;
        }
    }
}
