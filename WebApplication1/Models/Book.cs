using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models;

public class Book
{
    public UInt32 Id { get; set; }

    [Required(ErrorMessage = "Title is required.")]
    public string? Title { get; set; }

    [Required(ErrorMessage = "Author is required.")]
    public string? Author { get; set; }

    [Required(ErrorMessage = "Edit year is required.")]
    [Range(1, 10000, ErrorMessage = "Pages count must be between 1 and 10,000.")]
    public UInt16? PagesCount { get; set; }

    [Required(ErrorMessage = "Edit year is required.")]
    [RegularExpression(@"\d{4}", ErrorMessage = "Edit year must be a 4-digit number.")]
    public string? EditYear { get; set; }
}