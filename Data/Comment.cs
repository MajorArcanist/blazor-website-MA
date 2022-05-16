namespace BlazorApp.Data;
using System.ComponentModel.DataAnnotations;

public class Comment
{
    public int Id {get; set;}
    public int ImageId { get; set; }
    
    [Required(ErrorMessage = "Enter a valid screen name.")]
    [StringLength(20, MinimumLength = 3, ErrorMessage = "Screen name cannot have less than 3 characters and more than 20 characters in length")]
    public string Commentor { get; set;} = string.Empty;

    [Required(ErrorMessage = "Enter comment contents.")]
    [StringLength(300, MinimumLength = 3, ErrorMessage = "Comments must be between 3 to 300 characters.")]
    public string Contents { get; set; } = string.Empty;
}
