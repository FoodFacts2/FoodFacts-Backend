using Microsoft.EntityFrameworkCore;
using FoodFacts.Domain.Entities;
using FoodFacts.Infrastructure.Data;
using FoodFacts.Interfaces.Repositories;

namespace FoodFacts.Infrastructure.Repositories
{
    public class RolRepository : IRolRepository
    {
        private readonly FoodFactsDbContext _context;

        public RolRepository(FoodFactsDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Rol>> GetAllAsync()
        {
            return await _context.Rols.ToListAsync();
        }

        public async Task<Rol> GetByIdAsync(int id)
        {
            return await _context.Rols.FindAsync(id);
        }

        public async Task AddAsync(Rol rol)
        {
            _context.Rols.Add(rol);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Rol rol)
        {
            _context.Entry(rol).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var rol = await _context.Rols.FindAsync(id);
            if (rol != null)
            {
                _context.Rols.Remove(rol);
                await _context.SaveChangesAsync();
            }
        }
    }
}