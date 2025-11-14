namespace APILibrarySystem.DTOs
{
    public class BookDto
    {
        public string? Title { get; set; }
        public string? ISBN { get; set; }
        public int PublicationYear { get; set; }
        public int AuthorId { get; set; }
        public int GenreId { get; set; }
    }
}
