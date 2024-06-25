using Microsoft.AspNetCore.Mvc;

namespace VaccinationStationRegistrationSystem.Controllers
{
    [ApiController]
    [Route("Vaccines")]
    public class VaccinesController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "text";
        }
    }
}
