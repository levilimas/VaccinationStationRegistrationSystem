namespace VaccinationStationRegistrationSystem.Models
{
    public class VaccinationStation
    {
        public int Id { get; set; }

        public string Name { get; set; }


        public ICollection<Vaccine> Vaccines { get; set; }
    }
}
