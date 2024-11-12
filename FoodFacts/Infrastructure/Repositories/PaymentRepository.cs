using Microsoft.EntityFrameworkCore;
using FoodFacts.Domain.Entities;
using FoodFacts.Infrastructure.Data;
using FoodFacts.Interfaces.Repositories;

namespace FoodFacts.Infrastructure.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly FoodFactsDbContext _context;

        public PaymentRepository(FoodFactsDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Payment>> GetAllAsync()
        {
            return await _context.Payments.ToListAsync();
        }

        public async Task<Payment> GetByIdAsync(int id)
        {
            return await _context.Payments.FindAsync(id);
        }

        public async Task AddAsync(Payment payment)
        {
            _context.Payments.Add(payment);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Payment payment)
        {
            _context.Entry(payment).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var payment = await _context.Payments.FindAsync(id);
            if (payment != null)
            {
                _context.Payments.Remove(payment);
                await _context.SaveChangesAsync();
            }
        }
    }
}