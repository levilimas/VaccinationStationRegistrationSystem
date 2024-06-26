using System.ComponentModel.DataAnnotations;

namespace VaccinationStationRegistrationSystem.Models
{
    public class Vaccine
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Manufacturer { get; set; }

        [Required]
        public string BatchNumber { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public DateTime ExpiryDate { get; set; }

        [Required]
        public int VaccinationStationId { get; set; }

    }

}
