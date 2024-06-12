using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VehicleService.Models;
using VehicleService.Repositories;

namespace VehicleService.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class MechanicController : Controller
    {
        private readonly IMechanicRepository _mechanicRepository;

        public MechanicController(IMechanicRepository mechanicRepository)
        {
            _mechanicRepository = mechanicRepository;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var mechanics = await _mechanicRepository.GetAllMechanicsAsync();
            return View(mechanics);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Mechanic mechanic)
        {
            if (ModelState.IsValid)
            {
                await _mechanicRepository.AddMechanicAsync(mechanic);
                return RedirectToAction(nameof(Index));
            }
            return View(mechanic);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var mechanic = await _mechanicRepository.GetMechanicByIdAsync(id);
            if (mechanic == null)
            {
                return NotFound();
            }
            return View(mechanic);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Mechanic mechanic)
        {
            if (id != mechanic.MechanicId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _mechanicRepository.UpdateMechanicAsync(mechanic);
                return RedirectToAction(nameof(Index));
            }
            return View(mechanic);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var mechanic = await _mechanicRepository.GetMechanicByIdAsync(id);
            if (mechanic == null)
            {
                return NotFound();
            }
            return View(mechanic);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _mechanicRepository.DeleteMechanicAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
