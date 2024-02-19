using api.Dtos;
using api.Models;

namespace api.Mappers
{
    public static class CarMappers
    {
        public static CarDto ToCarDto(this Car carModel)
        {
            return new CarDto
            {
                Id = carModel.Id,
                BrandName = carModel.BrandName,
                ModelName = carModel.ModelName,
                HColorId = carModel.HColorId,
            };
        }

        public static Car ToCarFromCreateDto(this CreateCarRequestDto createCarDto)
        {
            return new Car
            {
                BrandName = createCarDto.BrandName,
                ModelName = createCarDto.ModelName,
                HColorId = createCarDto.HColorId,
            };
        }
    }
}
