using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

using OpenReport.Attributes;
using OpenReport.Attributes.Table;
using OpenReport.Styles;

namespace OpenReport.Layouts.Elements
{
    public class TableElement<T> : IElement
    {
        private T InstanceOfT = Activator.CreateInstance<T>();
        private ICollection<T> CollectionData;
        private StringBuilder TableHeader;
        private StringBuilder TableBody;
        private StringBuilder TableFooter;
        private string TableStyleClass;

        public TableElement(ICollection<T> collection)
        {
            CollectionData = collection;
            TableHeader = new StringBuilder();
            TableBody = new StringBuilder();
            TableFooter = new StringBuilder();
        }

        public string Render()
        {
            PrepareHeader();
            PrepareBody();
            PrepareFooter();

            return $@"
            <table class='{TableStyleClass}' width='100%'>
                <thead>
                    <tr>{TableHeader.ToString()}</tr>
                </thead>
                <tbody> 
                    {TableBody.ToString()} 
                </tbody>
                <tfoot>
                    <tr>{TableFooter.ToString()}</tr>
                </tfoot>
            </table>
            ";
        }

        private void PrepareHeader()
        {
            PropertyInfo[] props = InstanceOfT.GetType().GetProperties();
            foreach (PropertyInfo prop in props)
            {
                string headerName = prop.Name;
                var elementAttributes = new List<string>();
                var attrs = prop.GetCustomAttributes();

                foreach (var attr in attrs)
                {
                    if (attr is ICustonAttribute)
                        elementAttributes.Add(((ICustonAttribute)attr).GetElementAttribute());
                    
                    if (attr is TableColumnHeaderAttribute)
                        headerName = ((TableColumnHeaderAttribute)attr).Description;
                }

                TableHeader.Append($"<th {string.Join(" ", elementAttributes)}>{headerName}</th>");
            }
        }

        private void PrepareBody()
        {
            int row = 0;
            bool isTableStriped = false;
            
            var tableStyleAttr = InstanceOfT.GetType().GetCustomAttribute<TableStyleAttribute>();
            if (tableStyleAttr != null)
            {
                TableStyleClass = ((ICustonAttribute)tableStyleAttr).GetElementAttribute();
                isTableStriped = TableStyleClass.Contains(TableStyle.Striped.ToString().ToLower());
            }

            foreach (var dataRow in CollectionData)
            {
                TableBody.Append("<tr " + (isTableStriped && row % 2 == 0 ? "class='pure-table-odd'>" : ">"));
                PropertyInfo[] props = dataRow.GetType().GetProperties();
                
                foreach (PropertyInfo prop in props)
                    TableBody.Append($"<td>{prop.GetValue(dataRow)}</td>");

                TableBody.Append("</tr>");
                row++;
            }
        }

        private void PrepareFooter()
        {
            PropertyInfo[] props = InstanceOfT.GetType().GetProperties();
            foreach (PropertyInfo prop in props)
            {
                var elementAttributes = new List<string>();
                string content = "";

                var attributes = prop.GetCustomAttributes();
                foreach (var attribute in attributes)
                {
                    if (attribute is ICustonAttribute)
                        elementAttributes.Add(((ICustonAttribute)attribute).GetElementAttribute());

                    if (attribute is TableColumnTotalizeAttribute)
                    {
                        decimal sum = CollectionData.Sum(c => decimal.Parse(prop.GetValue(c).ToString()));
                        content = "<b>" + ((TableColumnTotalizeAttribute)attribute).FormatValue(sum) + "</b>";
                    }
                }

                TableFooter.Append($"<td {string.Join(" ", elementAttributes)}>{content}</td>");
            }
        }
    }
}
