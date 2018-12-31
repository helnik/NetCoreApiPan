using ApiPan.Decorations;
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

        [HttpGet]
        [SkipCooking]
        [ActionName("getDelivery")]
        [Route("api/[controller]/getDelivery")]
        public string GetDelivery()
        {
            return "No way I will get here with the attribute decoration";
        }
    }
}
