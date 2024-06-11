using System.ComponentModel.DataAnnotations;

namespace VehicleService.ViewModels
{
    public class VehicleViewModel
    {
        public int VehicleId { get; set; }

        [Required(ErrorMessage = "Make is required")]
        [StringLength(100, ErrorMessage = "Make cannot exceed 100 characters")]
        public string Make { get; set; }

        [Required(ErrorMessage = "Model is required")]
        [StringLength(100, ErrorMessage = "Model cannot exceed 100 characters")]
        public string Model { get; set; }

        [Required(ErrorMessage = "Year is required")]
        public int Year { get; set; }
    }
}