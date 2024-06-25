using Microsoft.EntityFrameworkCore;
using VaccinationStationRegistrationSystem.Data;
using VaccinationStationRegistrationSystem.Models;

namespace VaccinationStationRegistrationSystem.Services
{
    public class VacinneService
    {
        private readonly VaccinationSystemDataContext _vaccinationSystemDataContext;
        public VacinneService(VaccinationSystemDataContext vaccinationSystemDataContext)
        {
            _vaccinationSystemDataContext = vaccinationSystemDataContext;
        }

        public IEnumerable<VaccinationSystemDataContext> GetAllVaccines()
        {
            return _vaccinationSystemDataContext;
        }

        public Vaccine GetVaccineById(int id)
        {
            return _vaccinationSystemDataContext.FirstOrDefault(v => v.Id == id);
        }

        public bool AddVaccine(Vaccine vaccine)
        {
            if (_vaccinationSystemDataContext.Any(v => v.Batch == vaccine.Batch))
            {
                throw new ArgumentException("Vaccine with the same batch number already exists.");
            }

            if (ExpiryDate > DateTime.Now)
            {
                throw new ArgumentException("Vaccine expiry date must be in the future.");
            }

            _vaccinationSystemDataContext.Add(vaccine);
            return true;
        }

        public bool RemoveVaccine(int id)
        {
            var vaccine = GetVaccineById(id);
            if (vaccine != null)
            {
                _vaccinationSystemDataContext.Remove(vaccine);
                return true;
            }

            return false;
        }

        public bool UpdateVaccine(int id, Vaccine updatedVaccine)
        {
            var vaccine = GetVaccineById(id);
            if (vaccine != null)
            {
                if (_vaccinationSystemDataContext.Any(v => v.BatchNumber == updatedVaccine.BatchNumber && v.Id != id))
                {
                    throw new ArgumentException("Another vaccine with the same batch number already exists.");
                }

                vaccine.Name = updatedVaccine.Name;
                vaccine.Manufacturer = updatedVaccine.Manufacturer;
                vaccine.BatchNumber = updatedVaccine.BatchNumber;
                vaccine.Quantity = updatedVaccine.Quantity;
                vaccine.ExpiryDate = updatedVaccine.ExpiryDate;

                return true;
            }

            return false;
        }
    }
}
