using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class HColorRepository : IHColorRepository
    {
        private readonly AppDBContext _context;

        public HColorRepository(AppDBContext context)
        {
            _context = context;
        }

        public async Task<List<HColor>> GetAllAsync()
        {
            return await _context.HColors.Include(c => c.Cars).ToListAsync();
        }
    }
}
