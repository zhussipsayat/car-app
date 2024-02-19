using api.Data;
using api.Dtos;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class CarRepository : ICarRepository
    {
        private readonly AppDBContext _context;

        public CarRepository(AppDBContext context)
        {
            _context = context;
        }

        public async Task<List<Car>> GetAllAsync()
        {
            return await _context.Cars.ToListAsync();
        }

        public async Task<Car?> GetByIdAsync(int id)
        {
            return await _context.Cars.FindAsync(id);
        }

        public async Task<Car> CreateAsync(Car carModel)
        {
            await _context.Cars.AddAsync(carModel);
            await _context.SaveChangesAsync();

            return carModel;
        }

        public async Task<Car?> UpdateAsync(int id, UpdateCarRequestDto carDto)
        {
            var existingCar = await _context.Cars.FirstOrDefaultAsync(x => x.Id == id);

            if (existingCar is null)
            {
                return null;
            }

            _context.Entry(existingCar).CurrentValues.SetValues(carDto);

            await _context.SaveChangesAsync();

            return existingCar;
        }

        public async Task<Car?> DeleteAsync(int id)
        {
            var carModel = await _context.Cars.FirstOrDefaultAsync(x => x.Id == id);

            if (carModel is null)
            {
                return null;
            }

            _context.Cars.Remove(carModel);
            await _context.SaveChangesAsync();

            return carModel;
        }
    }
}
