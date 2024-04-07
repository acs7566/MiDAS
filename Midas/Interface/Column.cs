namespace Midas.Interface;
public class Column
{
    public Column(string? field, string? title, string? format = null, string? filter = null)
    {
        Field = field;
        Title = title;
        Format = format;
        Filter = filter;
    }

    public string? Field { get; set; }
    public string? Title { get; set; }
    public string? Format { get; set; }
    public string? Filter { get; set; }
}