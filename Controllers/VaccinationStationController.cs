using Microsoft.AspNetCore.Mvc;
using VaccinationStationRegistrationSystem.Models;
using VaccinationStationRegistrationSystem.Services;

namespace VaccinationStationRegistrationSystem.Controllers
{
    [ApiController]
    [Route("VaccineStation")]
    public class VaccinationStationController : ControllerBase
    {
        private readonly VaccinationStationservice _stationService;

        public VaccinationStationController(VaccinationStationservice stationService)
        {
            _stationService = stationService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VaccinationStation>>> GetVaccineStations()
        {
            return Ok(await _stationService.GetAllVaccinationStationsAsync());
        }

        [HttpPost]
        public async Task<ActionResult<VaccinationStation>> AddVaccineStation(VaccinationStation station)
        {
            try
            {
                var newStation = await _stationService.AddVaccineStationAsync(station);
                return CreatedAtAction(nameof(GetVaccineStations), new { id = newStation.Id }, newStation);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVaccineStation(int id)
        {
            try
            {
                await _stationService.DeleteVaccineStationAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
