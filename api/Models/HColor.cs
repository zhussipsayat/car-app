using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace api.Models
{
    public class HColor
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        
        [JsonIgnore]
        public List<Car> Cars { get; set; } = new List<Car>();
    }
}