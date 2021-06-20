using System;
using System.Collections.Generic;
using System.Windows.Forms;

using OpenReport.Attributes.Table;
using OpenReport.Layouts.Elements;
using OpenReport.Styles;

namespace OpenReport.Test
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            var header = new HeaderElement()
            {
                HeaderTop = "TOP HEADER",
                HeaderContent = "TABLE HEADER"
            };

            var table = new TableElement<Product>(new List<Product>()
            {
                new Product() { Description = "Pizza", UnitValue = 10.5m, SaleValue = 10.5m * 1.3m },
                new Product() { Description = "Homebread", UnitValue = 10.5m, SaleValue = 10.5m * 1.3m },
                new Product() { Description = "Pasta", UnitValue = 10.5m, SaleValue = 10.5m * 1.3m },
                new Product() { Description = "Cheese", UnitValue = 10.5m, SaleValue = 10.5m * 1.3m },
                new Product() { Description = "Bacon", UnitValue = 10.5m, SaleValue = 10.5m * 1.3m },
                new Product() { Description = "Nuts", UnitValue = 10.5m, SaleValue = 10.5m * 1.3m },
                new Product() { Description = "Sugar", UnitValue = 10.5m, SaleValue = 10.5m * 1.3m },
                new Product() { Description = "Milk", UnitValue = 10.5m, SaleValue = 10.5m * 1.3m },
            });

            var document = new DocumentElement(header);
            document.AppendContent(table.Render());

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ORDocumentViewer(document));
        }
    }

    [TableStyle(TableStyle.Striped)]
    public class Product
    {
        [TableColumnHeader("Description")]
        [TableColumnSize(50)]
        public string Description { get; set; }

        [TableColumnHeader("UNIT Value")]
        public decimal UnitValue { get; set; }

        [TableColumnHeader("SALE Value")]
        [TableColumnTotalize(ColumnFormatStyle.Decimal)]
        public decimal SaleValue { get; set; }
    }
}
