using System.ComponentModel.DataAnnotations;

namespace APILibrarySystem.Models
{
    public class Author
    {
        public int Id { get; set; }
        [Required]
        public string? FirstName { get; set; } 
        [Required]
        public string? LastName { get; set; }
        public string? Bio { get; set; }
        public DateTime? DateOfBirth { get; set; }

        public ICollection<Book>? Books { get; set; }
    }
}
