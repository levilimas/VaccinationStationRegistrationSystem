using Microsoft.AspNetCore.Mvc;
using VaccinationStationRegistrationSystem.Models;
using VaccinationStationRegistrationSystem.Services;

namespace VaccinationStationRegistrationSystem.Controllers
{
    [ApiController]
    [Route("Vaccines")]
    public class VaccinesController(VaccineService vaccineService) : ControllerBase
    {
        private readonly VaccineService _vaccineService = vaccineService;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vaccine>>> GetVaccines()
        {
            return Ok(await _vaccineService.GetAllVaccinesAsync());
        }

        [HttpPost]
        public async Task<ActionResult<Vaccine>> AddVaccine(Vaccine vaccine)
        {
            try
            {
                var newVaccine = await _vaccineService.AddVaccineAsync(vaccine);
                return CreatedAtAction(nameof(GetVaccines), new { id = newVaccine.Id }, newVaccine);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
