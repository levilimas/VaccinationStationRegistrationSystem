using Microsoft.AspNetCore.Mvc;
using VaccinationStationRegistrationSystem.Models;
using VaccinationStationRegistrationSystem.Services;

namespace VaccinationStationRegistrationSystem.Controllers
{
    [ApiController]
    [Route("Vaccines")]
    public class VaccinesController : ControllerBase
    {
        private readonly VaccineService _vaccineService;

        public VaccineController(VaccineService vaccineService)
        {
            _vaccineService = vecinneService;
        }
        
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVaccine(int id)
        {
            try
            {
                await _vaccineService.DeleteVaccineAsync(id);
                return Ok("Vacina Deletada com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> EditVaccine(Vaccine vaccine, int id)
        {
            try
            {
                var vaccineToEdit = await _vaccineService.EditVaccineAsync(vaccine, id);
                return Ok(vaccineToEdit);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
