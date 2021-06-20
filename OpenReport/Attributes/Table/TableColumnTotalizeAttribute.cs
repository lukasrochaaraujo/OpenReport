using System;

using OpenReport.Styles;

namespace OpenReport.Attributes.Table
{
    [AttributeUsage(AttributeTargets.Property)]
    public class TableColumnTotalizeAttribute : Attribute
    {
        private ColumnFormatStyle Format;

        public TableColumnTotalizeAttribute(ColumnFormatStyle format)
        {
            Format = format;
        }

        public string FormatValue(decimal value)
        {
            switch (Format)
            {
                case ColumnFormatStyle.Decimal:
                    return value.ToString("N2");
                case ColumnFormatStyle.Integer:
                default:
                    return ((int)value).ToString();
            }
        }
    }
}
