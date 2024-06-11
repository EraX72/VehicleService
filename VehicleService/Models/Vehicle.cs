using System.Collections.Generic;
using VehicleService.Models;

public class Vehicle
{
    public int VehicleId { get; set; }
    public string Make { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }
    public ICollection<ServiceRecord> ServiceRecords { get; set; }
}