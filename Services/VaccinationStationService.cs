using VaccinationStationRegistrationSystem.Models;

namespace VaccinationStationRegistrationSystem.Services
{
    public class VaccinationStationService
    {

        private readonly List<VaccinationStation> _vaccinationStations;

        public VaccinationStationService()
        {
            _vaccinationStations = new List<VaccinationStation>();
        }

        public IEnumerable<VaccinationStation> GetAllVaccinationStations()
        {
            return _vaccinationStations;
        }

        public VaccinationStation GetVaccinationStationById(int id)
        {
            return _vaccinationStations.FirstOrDefault(c => c.Id == id);
        }

        public bool AddVaccinationStation(VaccinationStation vaccinationStation)
        {
            if (_vaccinationStations.Any(c => c.Name.Equals(vaccinationStation.Name, StringComparison.OrdinalIgnoreCase)))
            {
                throw new ArgumentException("Já existe um posto de vacinação com o mesmo nome.");
            }

            _vaccinationStations.Add(vaccinationStation);
            return true;
        }

        public bool RemoveVaccinationStation(int id)
        {
            var vaccinationStation = GetVaccinationStationById(id);
            if (vaccinationStation != null)
            {
                if (vaccinationStation.HasVaccines())
                {
                    throw new InvalidOperationException("Não é possível excluir um posto de vacinação que possui vacinas.");
                }

                _vaccinationStations.Remove(vaccinationStation);
                return true;
            }

            return false;
        }

        public bool UpdateVaccinationStation(int id, VaccinationStation updatedVaccinationStation)
        {
            var vaccinationStation = GetVaccinationStationById(id);
            if (vaccinationStation != null)
            {
                if (_vaccinationStations.Any(c => c.Name.Equals(updatedVaccinationStation.Name, StringComparison.OrdinalIgnoreCase) && c.Id != id))
                {
                    throw new ArgumentException("Já existe outro Posto de Vacinação com o mesmo nome.");
                }

                vaccinationStation.Name = updatedVaccinationStation.Name;
                vaccinationStation.Address = updatedVaccinationStation.Address;

                return true;
            }

            return false;
        }
    }
}
