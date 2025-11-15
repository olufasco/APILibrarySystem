using APILibrarySystem.Models;
using System.ComponentModel.DataAnnotations;

namespace APILibrarySystem.DTOs
{
    public class AuthorDto : BaseEntity
    {

        [Required]
        public string FirstName { get; set; } = default!;

        [Required]
        public string LastName { get; set; } = default!;    

        public string Bio { get; set; } = default!;

        public DateTime DateOfBirth { get; set; }
    }
}