using ApiPan.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiPan.Controllers
{
    [ApiController]
    public class BakingController : ControllerBase
    {
        private readonly ICooker cooker;
        public BakingController(ICooker cookerService)
        {
            cooker = cookerService;
        }

        [HttpGet]
        [ActionName("getBakingStartTime")]
        [Route("api/[controller]/getBakingStartTime")]
        public string GetBakingStartTime() => cooker.GetCookingStartTime().ToString("HH:mm:ss");
    }
}
