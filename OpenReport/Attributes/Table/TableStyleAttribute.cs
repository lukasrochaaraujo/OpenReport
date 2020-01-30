using System;

using OpenReport.Styles;

namespace OpenReport.Attributes.Table
{
    [AttributeUsage(AttributeTargets.Class)]
    public class TableStyleAttribute : Attribute, ICustonAttribute
    {
        private TableStyle TableStyle;

        public TableStyleAttribute(TableStyle tableStyle)
        {
            TableStyle = tableStyle;
        }

        public string GetElementAttribute()
        {
            switch (TableStyle)
            {
                case TableStyle.Bordered:
                    return "pure-table pure-table-bordered";
                case TableStyle.HorizontalBorders:
                    return "pure-table pure-table-horizontal";
                case TableStyle.Striped:
                    return "pure-table pure-table-striped";
                case TableStyle.Default:
                default:
                    return "pure-table";
            }
        }
    }
}
