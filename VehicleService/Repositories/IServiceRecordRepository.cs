using System.Collections.Generic;
using System.Threading.Tasks;
using VehicleService.Models;

namespace VehicleService.Repositories
{
    public interface IServiceRecordRepository
    {
        Task<IEnumerable<ServiceRecord>> GetAllServiceRecordsAsync();
        Task<ServiceRecord> GetServiceRecordByIdAsync(int id);
        Task AddServiceRecordAsync(ServiceRecord serviceRecord);
        Task UpdateServiceRecordAsync(ServiceRecord serviceRecord);
        Task DeleteServiceRecordAsync(int id);

    }
}
