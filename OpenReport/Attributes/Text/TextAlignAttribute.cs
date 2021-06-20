using System;

using OpenReport.Styles;

namespace OpenReport.Attributes.Text
{
    [AttributeUsage(AttributeTargets.Property)]
    public class TextAlignAttribute : Attribute, ICustonAttribute
    {
        public TextAlignStyle TextAlign { get; set; }

        public TextAlignAttribute(TextAlignStyle textAlign)
        {
            TextAlign = textAlign;
        }

        public string GetElementAttribute()
        {
            return $"align='{TextAlign.ToString().ToLower()}'";
        }
    }
}
