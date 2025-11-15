using APILibrarySystem.Data;
using APILibrarySystem.Models;
using APILibrarySystem.Repositories.Interfaces;

namespace APILibrarySystem.Repositories.Implementations
{
    public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(LibraryDbContext context) : base(context) { }
    }
}