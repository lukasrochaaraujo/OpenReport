using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

using OpenReport.Attributes;

namespace OpenReport.Layouts.Elements
{
    public class TableElement<T> : IElement
    {
        private ICollection<T> CollectionData;
        private StringBuilder TableHeader;
        private StringBuilder TableBody;
        private StringBuilder TableFooter;

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

            return $@"
            <table width='100%'>
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
            var instanceT = Activator.CreateInstance<T>();
            PropertyInfo[] props = instanceT.GetType().GetProperties();
            foreach (PropertyInfo prop in props)
            {
                List<string> elementAttributes = new List<string>();
                var attrs = prop.GetCustomAttributes();
                
                foreach (var attr in attrs) 
                    elementAttributes.Add(((ICustonAttribute)attr).GetElementAttribute());
                
                TableHeader.Append($"<th {string.Join(" ", elementAttributes)}>{prop.Name}</th>");
            }
        }

        private void PrepareBody()
        {
            foreach (var dataRow in CollectionData)
            {
                TableBody.Append("<tr>");
                PropertyInfo[] props = dataRow.GetType().GetProperties();
                
                foreach (PropertyInfo prop in props)
                    TableBody.Append($"<td>{prop.GetValue(dataRow)}</td>");

                TableBody.Append("</tr>");
            }
        }
    }
}
