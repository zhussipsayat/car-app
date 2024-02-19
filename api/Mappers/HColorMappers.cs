using api.Dtos;
using api.Models;

namespace api.Mappers
{
    public static class HColorMappers
    {
        public static HColorDto ToHColorDto(this HColor hColorModel)
        {
            return new HColorDto
            {
                Id = hColorModel.Id,
                Name = hColorModel.Name,
                Cars = hColorModel.Cars.Select(c => c.ToCarDto()).ToList()
            };
        }
    }
}
