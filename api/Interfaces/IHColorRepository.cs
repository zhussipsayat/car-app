using api.Models;

namespace api.Interfaces
{
    public interface IHColorRepository
    {
        Task<List<HColor>> GetAllAsync();
    }
}
