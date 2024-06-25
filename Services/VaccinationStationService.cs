using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using VaccinationStationRegistrationSystem.Data;
using VaccinationStationRegistrationSystem.Models;

namespace VaccinationStationRegistrationSystem.Services
{
    public class VaccinationStationservice
    {
        private readonly VaccinationSystemDataContext _vaccinationSystemDataContext;

        public VaccinationStationservice(VaccinationSystemDataContext vaccinationSystemDataContext)
        {
            _vaccinationSystemDataContext = vaccinationSystemDataContext;
        }

        public async Task<List<VaccinationStation>> GetAllVaccinationStationsAsync()
        {
            return await _vaccinationSystemDataContext.VaccinationStations.Include(vs => vs.Vaccines).ToListAsync();
        }

        public async Task<VaccinationStation> AddVaccineStationAsync(VaccinationStation vaccinationStation)
        {
            if (_vaccinationSystemDataContext.VaccinationStations.Any(vs => vs.Name == vaccinationStation.Name))
                throw new InvalidOperationException("A station with this name already exists.");

            _vaccinationSystemDataContext.VaccinationStations.Add(vaccinationStation);
            await _vaccinationSystemDataContext.SaveChangesAsync();
            return vaccinationStation;
        }

        public async Task DeleteVaccineStationAsync(int id)
        {
            var station = await _vaccinationSystemDataContext.VaccinationStations(vs => vs.Vaccines).FirstOrDefaultAsync(vs => vs.Id == id);

            if (station == null || station.Vaccination.Any())
                throw new InvalidOperationException("Cannot delete a station with vaccines.");

            _vaccinationSystemDataContext.VaccinationStations.Remove(station);
            await _vaccinationSystemDataContext.SaveChangesAsync();
        }
    }
}
