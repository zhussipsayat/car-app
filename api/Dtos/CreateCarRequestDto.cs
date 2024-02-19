using api.Models;
using System.ComponentModel.DataAnnotations;

namespace api.Dtos
{
    public class CreateCarRequestDto
    {
        public string BrandName { get; set; } = string.Empty;
        public string ModelName { get; set; } = string.Empty;
        public int? HColorId { get; set; }
    }
}
