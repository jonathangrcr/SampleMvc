using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SampleMvc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<string> GetPets()
        {
            return new[]
            {
                "FlutterShy",
                "Kira",
                "Poppy",
                "Everest"
            };
        }
    }
}
