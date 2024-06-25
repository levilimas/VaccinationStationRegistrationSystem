namespace VaccinationStationRegistrationSystem.Models
{
    public class VaccinationStation
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public List<Vaccine> Vaccines { get; set; }

        public VaccinationStation()
        {
            Vaccines = new List<Vaccine>();
        }

        public bool HasVaccines()
        {
            return Vaccines.Count > 0;
        }
    }
}
