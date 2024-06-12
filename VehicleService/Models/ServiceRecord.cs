using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VehicleService.Models
{
    public class ServiceRecord
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ServiceRecordId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [ForeignKey("Vehicle")]
        public int VehicleId { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Cost { get; set; }

        public Vehicle Vehicle { get; set; }
    }
}

    