# Open Report
A simple library to display minimal reports for WinForms applications

**Example**

```csharp
[TableStyle(TableStyle.Striped)]
public class Produto
{
    [TableColumnHeader("Description")]
    [TableColumnSize(50)]
    public string Description { get; set; }

    [TableColumnHeader("Stock")]
    [TableColumnTotalize(ColumnFormatStyle.Integer)]
    public int StockAmmount { get; set; }
}
```

![exemple](OpenReportExample.png?raw=true)