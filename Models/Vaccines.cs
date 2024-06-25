namespace VaccinationStationRegistrationSystem.Models
{
    public class Vaccine
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Manufacturer { get; set; }

        public string BatchNumber { get; set; }

        public int Quantity { get; set; }

        public DateTime ExpiryDate { get; set; }

        public int VaccinationStationId { get; set; }

    }

}
