using APILibrarySystem.Models;
using System.ComponentModel.DataAnnotations;

namespace APILibrarySystem.DTOs
{
    public class AuthorDto : BaseEntity
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Bio { get; set; } = string.Empty;
    }
}