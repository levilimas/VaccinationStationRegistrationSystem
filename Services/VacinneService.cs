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
            ValidateVaccines(vaccine);

            _vaccinationSystemDataContext.Vaccines.Add(vaccine);
            await _vaccinationSystemDataContext.SaveChangesAsync();
            return vaccine;
        }

        public async Task DeleteVaccineAsync(int id)
        {
            var vaccine = await _vaccinationSystemDataContext.Vaccines.Where(vc => vc.Id == id).FirstOrDefaultAsync();

            if (vaccine == null)
                throw new InvalidOperationException("Não é póssível excluir a vacina.");

            _vaccinationSystemDataContext.Vaccines.Remove(vaccine);
            await _vaccinationSystemDataContext.SaveChangesAsync();
        }

        public async Task<Vaccine> EditVaccineAsync(Vaccine updatedVaccine, int id)
        {
            var vaccineToEdit = await _vaccinationSystemDataContext.Vaccines.Where(vs => vs.Id == id).FirstOrDefaultAsync();

            if (vaccineToEdit == null)
                throw new InvalidOperationException("Não foi possível encontrar a vacina.");

            ValidateVaccines(updatedVaccine);

            _vaccinationSystemDataContext.Vaccines.Update(vaccineToEdit);

            return vaccineToEdit;
        }


        private void ValidateVaccines(Vaccine vaccine)
        {
            if (vaccine.ExpiryDate <= DateTime.Now)
                throw new InvalidOperationException("A vacina deve ter data de validade futura.");

            if (_vaccinationSystemDataContext.Vaccines.Any(vc => vc.BatchNumber == vaccine.BatchNumber))
                throw new InvalidOperationException("As vacinas não podem ter do mesmo lote");

            if (!_vaccinationSystemDataContext.VaccinationStations.Any(vs => vs.Id == vaccine.VaccinationStationId))
                throw new InvalidOperationException("Posto de vacinação não encontrado.");
        }

    }
}
