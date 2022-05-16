namespace BlazorApp.Data;

public class Image
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;

    public string Description {get; set;} = string.Empty;
    public string Path { get; set; } = string.Empty;
    public string Format {get; set;} = string.Empty;
}
