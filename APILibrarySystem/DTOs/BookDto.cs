using APILibrarySystem.Models;

namespace APILibrarySystem.DTOs
{
    public class BookDto
    {
        public string Title { get; set; } = default!;
        public string ISBN { get; set; } = default!;
        public int PublicationYear { get; set; }
        public Guid AuthorId { get; set; }
        public Guid GenreId { get; set; }
    }
}
