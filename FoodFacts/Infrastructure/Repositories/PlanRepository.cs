using Microsoft.EntityFrameworkCore;
using FoodFacts.Domain.Entities;
using FoodFacts.Infrastructure.Data;
using FoodFacts.Interfaces.Repositories;

namespace FoodFacts.Infrastructure.Repositories
{
    public class PlanRepository : IPlanRepository
    {
        private readonly FoodFactsDbContext _context;

        public PlanRepository(FoodFactsDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Plan>> GetAllAsync()
        {
            return await _context.Plans.ToListAsync();
        }

        public async Task<Plan> GetByIdAsync(int id)
        {
            return await _context.Plans.FindAsync(id);
        }

        public async Task AddAsync(Plan plan)
        {
            _context.Plans.Add(plan);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Plan plan)
        {
            _context.Entry(plan).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var plan = await _context.Plans.FindAsync(id);
            if (plan != null)
            {
                _context.Plans.Remove(plan);
                await _context.SaveChangesAsync();
            }
        }
    }
}