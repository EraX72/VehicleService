using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VehicleService.Models;
using VehicleService.Repositories;

namespace VehicleService.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class ServiceRecordController : Controller
    {
        private readonly IServiceRecordRepository _serviceRecordRepository;

        public ServiceRecordController(IServiceRecordRepository serviceRecordRepository)
        {
            _serviceRecordRepository = serviceRecordRepository;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var serviceRecords = await _serviceRecordRepository.GetAllServiceRecordsAsync();
            return View(serviceRecords);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ServiceRecord serviceRecord)
        {
            if (ModelState.IsValid)
            {
                await _serviceRecordRepository.AddServiceRecordAsync(serviceRecord);
                return RedirectToAction(nameof(Index));
            }
            return View(serviceRecord);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var serviceRecord = await _serviceRecordRepository.GetServiceRecordByIdAsync(id);
            if (serviceRecord == null)
            {
                return NotFound();
            }
            return View(serviceRecord);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ServiceRecord serviceRecord)
        {
            if (id != serviceRecord.ServiceRecordId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _serviceRecordRepository.UpdateServiceRecordAsync(serviceRecord);
                return RedirectToAction(nameof(Index));
            }
            return View(serviceRecord);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var serviceRecord = await _serviceRecordRepository.GetServiceRecordByIdAsync(id);
            if (serviceRecord == null)
            {
                return NotFound();
            }
            return View(serviceRecord);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _serviceRecordRepository.DeleteServiceRecordAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
