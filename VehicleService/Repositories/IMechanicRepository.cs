using System.Collections.Generic;
using System.Threading.Tasks;
using VehicleService.Models;

namespace VehicleService.Repositories
{
    public interface IMechanicRepository
    {
        Task<IEnumerable<Mechanic>> GetAllMechanicsAsync();
        Task<Mechanic> GetMechanicByIdAsync(int id);
        Task AddMechanicAsync(Mechanic mechanic);
        Task UpdateMechanicAsync(Mechanic mechanic);
        Task DeleteMechanicAsync(int id);
    }
}
