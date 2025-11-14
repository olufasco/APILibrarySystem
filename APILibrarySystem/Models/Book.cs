using System.ComponentModel.DataAnnotations;

namespace APILibrarySystem.Models
{
    public class Book
    {
        public int Id { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        public string? ISBN { get; set; }
        public int PublicationYear { get; set; }

        public int AuthorId { get; set; }
        public Author? Author { get; set; }

        public int GenreId { get; set; }
        public Genre? Genre { get; set; }
    }
}
