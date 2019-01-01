using ApiPan.Decorations;
using ApiPan.Interfaces;
using ApiPan.Types;
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
        [ActionName("getRecipeByMealName")]
        [Route("api/[controller]/getRecipeByMealName/{mealName}")]
        public MealsList GetRecipeByMealName(string mealName) => cooker.GetRecipeByMealName(mealName);


        [HttpGet]
        [ActionName("startBaking")]
        [Route("api/[controller]/startBaking/{temp}")]
        public string StartBaking(int temp) => cooker.StartCooking(temp);

        [HttpGet]
        [ActionName("getBakingStartTime")]
        [Route("api/[controller]/getBakingStartTime")]
        public string GetBakingStartTime() => cooker.GetCookingStartTime().ToString("HH:mm:ss");

        [HttpGet]
        [SkipCooking]
        [ActionName("getDelivery")]
        [Route("api/[controller]/getDelivery")]
        public string GetDelivery() => "No way I will get here with the attribute decoration";
    }
}
