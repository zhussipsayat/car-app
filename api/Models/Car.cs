using System.ComponentModel.DataAnnotations;
namespace api.Models
{
    public class Car
    {
        public int Id { get; set; }       
        [Required]
        [MaxLength(100)]
        public string BrandName { get; set; } = string.Empty;
        [Required]
        [MaxLength(100)]
        public string ModelName { get; set; } = string.Empty;
        public int? HColorId { get; set; }
        public HColor? HColor { get; set; }

    }
}
