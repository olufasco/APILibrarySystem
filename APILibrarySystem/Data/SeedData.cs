using APILibrarySystem.Models;
using Microsoft.EntityFrameworkCore;

namespace APILibrarySystem.Data
{
    public static class SeedData
    {
        public static void Initialize(LibraryDbContext context)
        {
            context.Database.Migrate();

            if (!context.Authors.Any())
            {
                var author1 = new Author
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Chinua",
                    LastName = "Achebe",
                    Bio = "Renowned Nigerian novelist and author of 'Things Fall Apart'."
                };

                var author2 = new Author
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Wole",
                    LastName = "Soyinka",
                    Bio = "Nobel Prize-winning playwright and poet from Nigeria."
                };

                context.Authors.AddRange(author1, author2);

                var genre1 = new Genre
                {
                    Id = Guid.NewGuid(),
                    Name = "Historical Fiction"
                };

                var genre2 = new Genre
                {
                    Id = Guid.NewGuid(),
                    Name = "Drama"
                };

                context.Genres.AddRange(genre1, genre2);

                var book1 = new Book
                {
                    Id = Guid.NewGuid(),
                    Title = "Things Fall Apart",
                    AuthorId = author1.Id,
                    GenreId = genre1.Id,
                    ISBN = "9780199110834"
                };

                var book2 = new Book
                {
                    Id = Guid.NewGuid(),
                    Title = "Death and the King's Horseman",
                    AuthorId = author2.Id,
                    GenreId = genre2.Id,
                    ISBN = "9762788299928"
                };

                context.Books.AddRange(book1, book2);

                context.SaveChanges();
            }
        }
    }
}