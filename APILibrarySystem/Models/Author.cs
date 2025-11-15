using System.ComponentModel.DataAnnotations;

namespace APILibrarySystem.Models
{
    public class Author : BaseEntity
    {
        [Required]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
        public string Bio { get; set; } = default!;
        public DateTime DateOfBirth { get; set; } = DateTime.UtcNow;

        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
