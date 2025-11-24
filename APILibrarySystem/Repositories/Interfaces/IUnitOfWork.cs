using System;
using System.Threading.Tasks;

namespace APILibrarySystem.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IBookRepository Books { get; }
        IAuthorRepository Authors { get; }
        IGenreRepository Genres { get; }

        Task<int> SaveAsync();
    }
}