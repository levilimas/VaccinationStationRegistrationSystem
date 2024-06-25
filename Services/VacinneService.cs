using Microsoft.EntityFrameworkCore;
using VaccinationStationRegistrationSystem.Data;
using VaccinationStationRegistrationSystem.Models;

namespace VaccinationStationRegistrationSystem.Services
{
    public class VaccineService
    {
        private readonly VaccinationSystemDataContext _vaccinationSystemDataContext;

        public VaccineService(VaccinationSystemDataContext vaccinationSystemDataContext)
        {
            _vaccinationSystemDataContext = vaccinationSystemDataContext;
        }

        public async Task<List<Vaccine>> GetAllVaccinesAsync()
        {
            return await _vaccinationSystemDataContext.Vaccines.ToListAsync();
        }

        public async Task<Vaccine> AddVaccineAsync(Vaccine vaccine)
        {
            if (vaccine.ExpiryDate <= DateTime.Now)
                throw new InvalidOperationException("A vacina encontra-se com data de validade vencida.");

            _vaccinationSystemDataContext.Vaccines.Add(vaccine);
            await _vaccinationSystemDataContext.SaveChangesAsync();
            return vaccine;
        }
    }
}
