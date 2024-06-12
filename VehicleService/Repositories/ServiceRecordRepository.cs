using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using VehicleService.Data;
using VehicleService.Models;
using VehicleService.Repositories;

namespace VehicleService.Repositories
{
    public class ServiceRecordRepository : IServiceRecordRepository
    {
        private readonly ApplicationDbContext _context;

        public ServiceRecordRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ServiceRecord>> GetAllServiceRecordsAsync()
        {
            return await _context.ServiceRecords.ToListAsync();
        }

        public async Task<ServiceRecord> GetServiceRecordByIdAsync(int id)
        {
            return await _context.ServiceRecords.FindAsync(id);
        }

        public async Task AddServiceRecordAsync(ServiceRecord serviceRecord)
        {
            await _context.ServiceRecords.AddAsync(serviceRecord);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateServiceRecordAsync(ServiceRecord serviceRecord)
        {
            _context.ServiceRecords.Update(serviceRecord);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteServiceRecordAsync(int id)
        {
            var serviceRecord = await _context.ServiceRecords.FindAsync(id);
            if (serviceRecord != null)
            {
                _context.ServiceRecords.Remove(serviceRecord);
                await _context.SaveChangesAsync();
            }
        }
    }
}