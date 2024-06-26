using Microsoft.AspNetCore.Mvc;
using VaccinationStationRegistrationSystem.Models;
using VaccinationStationRegistrationSystem.Services;

namespace VaccinationStationRegistrationSystem.Controllers
{
    [ApiController]
    [Route("VaccineStation")]
    public class VaccinationStationController : ControllerBase
    {
        private readonly VaccinationStationService _stationService;

        public VaccinationStationController(VaccinationStationService stationService)
        {
            _stationService = stationService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VaccinationStation>>> GetVaccinationStations()
        {            
            return Ok(await _stationService.GetAllVaccinationStationsAsync());
        }

        [HttpPost]
        public async Task<ActionResult<VaccinationStation>> AddVaccinationStation(VaccinationStation station)
        {
            try
            {
                var newStation = await _stationService.AddVaccineStationAsync(station);
                return CreatedAtAction(nameof(GetVaccinationStations), new { id = newStation.Id }, newStation);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVaccinationStation(int id)
        {
            try
            {
                await _stationService.DeleteVaccinationStationAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> EditVaccinationStation(VaccinationStation vaccinationStation, int id)
        {
            try
            {
                var vaccinationStationToEdit = await _stationService.EditVaccinationStationAsync(vaccinationStation, id);
                return Ok(vaccinationStationToEdit);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
