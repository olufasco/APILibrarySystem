using System.ComponentModel.DataAnnotations;

namespace APILibrarySystem.Models
{
    public class Genre
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public string? Description { get; set; }

        public ICollection<Book>? Books { get; set; }
    }
}
