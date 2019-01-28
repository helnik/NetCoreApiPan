using ApiPan.Decorations;
using ApiPan.Interfaces;
using ApiPan.Types;
using Microsoft.AspNetCore.Mvc;

namespace ApiPan.Controllers
{
    [ApiController]
    [Route("api/baking")]
    public class BakingController : ControllerBase
    {
        private readonly ICooker _cooker;
        public BakingController(ICooker cookerService)
        {
            _cooker = cookerService;
        }

        [HttpGet("getRecipeByMealName/{mealName}")]
        [ActionName("getRecipeByMealName")]
        public MealsList GetRecipeByMealName(string mealName) => _cooker.GetRecipeByMealName(mealName);


        [HttpGet("startBaking/{temp}")]
        [ActionName("startBaking")]
        public string StartBaking(int temp) => _cooker.StartCooking(temp);

        [HttpGet("getBakingStartTime")]
        [ActionName("getBakingStartTime")]
        public string GetBakingStartTime() => _cooker.GetCookingStartTime().ToString("HH:mm:ss");

        [HttpGet("getDelivery")]
        [ActionName("getDelivery")]
        [SkipCooking]
        public string GetDelivery() => "No way I will get here with the attribute decoration";
    }
}
