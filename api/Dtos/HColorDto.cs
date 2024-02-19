using api.Models;
using System.ComponentModel.DataAnnotations;

namespace api.Dtos
{
    public class HColorDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<CarDto> Cars { get; set; } = new List<CarDto>();
    }
}
