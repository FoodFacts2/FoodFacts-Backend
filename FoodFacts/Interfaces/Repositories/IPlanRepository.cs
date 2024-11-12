using FoodFacts.Domain.Entities;

namespace FoodFacts.Interfaces.Repositories
{
    public interface IPlanRepository
    {
        Task<IEnumerable<Plan>> GetAllAsync();
        Task<Plan> GetByIdAsync(int id);
        Task AddAsync(Plan plan);
        Task UpdateAsync(Plan plan);
        Task DeleteAsync(int id);
    }
}