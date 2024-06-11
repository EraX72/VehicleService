using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using System.Threading.Tasks;
using VehicleService.Models;
using VehicleService.ViewModels;
using System.Collections.Generic;

public class CustomerController : Controller
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;

    public CustomerController(ICustomerRepository customerRepository, IMapper mapper)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
    }

    public async Task<IActionResult> Index()
    {
        var customers = await _customerRepository.GetAllAsync();
        var customerViewModels = _mapper.Map<IEnumerable<CustomerViewModel>>(customers);
        return View(customerViewModels);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CustomerViewModel customerViewModel)
    {
        if (ModelState.IsValid)
        {
            var customer = _mapper.Map<Customer>(customerViewModel);
            await _customerRepository.AddAsync(customer);
            return RedirectToAction(nameof(Index));
        }
        return View(customerViewModel);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var customer = await _customerRepository.GetByIdAsync(id);
        if (customer == null)
        {
            return NotFound();
        }
        var customerViewModel = _mapper.Map<CustomerViewModel>(customer);
        return View(customerViewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(CustomerViewModel customerViewModel)
    {
        if (ModelState.IsValid)
        {
            var customer = _mapper.Map<Customer>(customerViewModel);
            await _customerRepository.UpdateAsync(customer);
            return RedirectToAction(nameof(Index));
        }
        return View(customerViewModel);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var customer = await _customerRepository.GetByIdAsync(id);
        if (customer == null)
        {
            return NotFound();
        }
        var customerViewModel = _mapper.Map<CustomerViewModel>(customer);
        return View(customerViewModel);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _customerRepository.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Details(int id)
    {
        var customer = await _customerRepository.GetByIdAsync(id);
        if (customer == null)
        {
            return NotFound();
        }
        var customerViewModel = _mapper.Map<CustomerViewModel>(customer);
        return View(customerViewModel);
    }
}
