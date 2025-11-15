using APILibrarySystem.Models;
using System.ComponentModel.DataAnnotations;

namespace APILibrarySystem.DTOs
{
    public class GenreDto : BaseEntity
    {

        [Required]
        public string Name { get; set; } = default!;

        public string Description { get; set; } = default!;
    }
}