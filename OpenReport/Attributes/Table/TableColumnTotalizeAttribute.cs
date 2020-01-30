using System;

using OpenReport.Styles;

namespace OpenReport.Attributes.Table
{
    [AttributeUsage(AttributeTargets.Property)]
    public class TableColumnTotalizeAttribute : Attribute
    {
        private ColumnFormat Format;

        public TableColumnTotalizeAttribute(ColumnFormat format)
        {
            Format = format;
        }

        public string FormatValue(decimal value)
        {
            switch (Format)
            {
                case ColumnFormat.Decimal:
                    return value.ToString("N2");
                case ColumnFormat.Integer:
                default:
                    return ((int)value).ToString();
            }
        }
    }
}
