using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using VehicleService.Data;
using VehicleService.Models;
using VehicleService.Repositories;

namespace VehicleService.Repositories
{
    public class MechanicRepository : IMechanicRepository
    {
        private readonly ApplicationDbContext _context;

        public MechanicRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Mechanic>> GetAllMechanicsAsync()
        {
            return await _context.Mechanics.ToListAsync();
        }

        public async Task<Mechanic> GetMechanicByIdAsync(int id)
        {
            return await _context.Mechanics.FindAsync(id);
        }

        public async Task AddMechanicAsync(Mechanic mechanic)
        {
            await _context.Mechanics.AddAsync(mechanic);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateMechanicAsync(Mechanic mechanic)
        {
            _context.Mechanics.Update(mechanic);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMechanicAsync(int id)
        {
            var mechanic = await _context.Mechanics.FindAsync(id);
            if (mechanic != null)
            {
                _context.Mechanics.Remove(mechanic);
                await _context.SaveChangesAsync();
            }
        }
    }
}
