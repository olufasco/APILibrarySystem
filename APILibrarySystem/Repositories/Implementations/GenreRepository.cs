using APILibrarySystem.Data;
using APILibrarySystem.Models;
using APILibrarySystem.Repositories.Interfaces;

namespace APILibrarySystem.Repositories.Implementations
{
    public class GenreRepository : GenericRepository<Genre>, IGenreRepository
    {
        public GenreRepository(LibraryDbContext context) : base(context) { }
    }
}