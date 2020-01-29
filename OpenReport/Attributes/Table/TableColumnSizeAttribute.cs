using System;

namespace OpenReport.Attributes.Table
{
    [AttributeUsage(AttributeTargets.Property)]
    public class TableColumnSizeAttribute : Attribute, ICustonAttribute
    {
        private int Width { get; set; }

        public TableColumnSizeAttribute(int percent = 0)
        {
            Width = percent;
        }

        public string GetElementAttribute()
        {
            return Width == 0 ?
                   "" :
                   $"width='{Width.ToString("F2")}%'";
        }
    }
}
