using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VaccinationStationRegistrationSystem.Data;
using VaccinationStationRegistrationSystem.Models;

namespace VaccinationStationRegistrationSystem.Services
{
    public class VaccinationStationService
    {
        private readonly VaccinationSystemDataContext _vaccinationSystemDataContext;

        public VaccinationStationService(VaccinationSystemDataContext vaccinationSystemDataContext)
        {
            _vaccinationSystemDataContext = vaccinationSystemDataContext;
        }

        public async Task<List<VaccinationStation>> GetAllVaccinationStationsAsync()
        {
            return await _vaccinationSystemDataContext.VaccinationStations.ToListAsync();
        }

        public async Task<VaccinationStation> AddVaccineStationAsync(VaccinationStation vaccinationStation)
        {
            if (_vaccinationSystemDataContext.VaccinationStations.Any(vs => vs.Name == vaccinationStation.Name))
                throw new InvalidOperationException("Já existe uma estação de vacinação com esse nome.");

            _vaccinationSystemDataContext.VaccinationStations.Add(vaccinationStation);
            await _vaccinationSystemDataContext.SaveChangesAsync();
            return vaccinationStation;
        }

        public async Task DeleteVaccinationStationAsync(int id)
        {
            var vaccinesByStation = await _vaccinationSystemDataContext.Vaccines.Where(vc => vc.VaccinationStationId == id).FirstOrDefaultAsync();
            
            var station = await _vaccinationSystemDataContext.VaccinationStations.Where(vs => vs.Id == id).FirstOrDefaultAsync();

            if (station == null || vaccinesByStation != null)
                throw new InvalidOperationException("Não é póssível Deletar um Posto de vacinação");

            _vaccinationSystemDataContext.VaccinationStations.Remove(station);
            await _vaccinationSystemDataContext.SaveChangesAsync();
        }

        public async Task<VaccinationStation> EditVaccinationStationAsync(VaccinationStation vaccinationStation, int id)
        {
            var vaccinationStationToEdit = await _vaccinationSystemDataContext.VaccinationStations.Where(vs => vs.Id == id).FirstOrDefaultAsync();

            if (vaccinationStationToEdit == null)
                throw new InvalidOperationException("Não foi possível encontrar um posto de vacinação.");

            vaccinationStationToEdit.Name = vaccinationStation.Name;

            await _vaccinationSystemDataContext.SaveChangesAsync();
            return vaccinationStationToEdit;
        }

    }
}
