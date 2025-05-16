using OrganizedScannApi.Data;
using OrganizedScannApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganizedScannApi.Services
{
    public class MotorcycleService
    {
        private readonly ApplicationDbContext _context;

        public MotorcycleService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Motorcycle>> GetAllAsync(string? brand = null, int? year = null)
        {
            IQueryable<Motorcycle> query = _context.Motorcycles;

            if (!string.IsNullOrEmpty(brand))
                query = query.Where(m => m.Brand == brand);

            if (year.HasValue)
                query = query.Where(m => m.Year == year.Value);

            return await query.ToListAsync();
        }

        public async Task<Motorcycle?> GetByIdAsync(int id)
        {
            return await _context.Motorcycles.FindAsync(id);
        }

        public async Task<Motorcycle> CreateAsync(Motorcycle motorcycle)
        {
            _context.Motorcycles.Add(motorcycle);
            await _context.SaveChangesAsync();
            return motorcycle;
        }

        public async Task UpdateAsync(int id, Motorcycle motorcycle)
        {
            motorcycle.Id = id;
            _context.Motorcycles.Update(motorcycle);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var motorcycle = await GetByIdAsync(id);
            if (motorcycle != null)
            {
                _context.Motorcycles.Remove(motorcycle);
                await _context.SaveChangesAsync();
            }
        }
    }
}
