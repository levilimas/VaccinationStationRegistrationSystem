using System.ComponentModel.DataAnnotations;

namespace VaccinationStationRegistrationSystem.Models
{
    public class VaccinationStation
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
