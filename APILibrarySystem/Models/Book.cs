using System.ComponentModel.DataAnnotations;

namespace APILibrarySystem.Models
{
    public class Book : BaseEntity
    {
        [Required]
        public string Title { get; set; } = string.Empty;
        [Required]
        public string ISBN { get; set; } = string.Empty;
        public int PublicationYear { get; set; }

        public Guid AuthorId { get; set; }
        public Author Author { get; set; } = null!;

        public Guid GenreId { get; set; }
        public Genre Genre { get; set; } = null!;
    }
}
