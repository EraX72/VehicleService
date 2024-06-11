namespace VehicleService.Models
{
    public class ServiceRecord
    {
        public int ServiceRecordId { get; set; }
        public DateTime Date { get; set; }
        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }
        public string Description { get; set; }
        public decimal Cost { get; set; }
    }

}
