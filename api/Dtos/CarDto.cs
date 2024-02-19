using api.Models;
using System.ComponentModel.DataAnnotations;

namespace api.Dtos
{
    public class CarDto
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "Brand name cannot be over 100 characters")]
        public string BrandName { get; set; } = string.Empty;
        [Required]
        [MaxLength(100, ErrorMessage = "Model name cannot be over 100 characters")]
        public string ModelName { get; set; } = string.Empty;
        public int? HColorId { get; set; }
    }
}
