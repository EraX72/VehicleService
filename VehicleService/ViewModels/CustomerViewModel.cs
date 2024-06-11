using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VehicleService.ViewModels;
public class CustomerViewModel
{
    public int CustomerId { get; set; }

    [Required(ErrorMessage = "First name is required")]
    [StringLength(100, ErrorMessage = "First name cannot exceed 100 characters")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Last name is required")]
    [StringLength(100, ErrorMessage = "Last name cannot exceed 100 characters")]
    public string LastName { get; set; }

    [Required(ErrorMessage = "Email address is required")]
    [EmailAddress(ErrorMessage = "Invalid email address")]
    public string Email { get; set; }

    public ICollection<VehicleViewModel> Vehicles { get; set; }
}
