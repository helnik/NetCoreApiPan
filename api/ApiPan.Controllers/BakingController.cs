using ApiPan.Decorations;
using ApiPan.Interfaces;
using ApiPan.Types;
using Microsoft.AspNetCore.Mvc;

namespace ApiPan.Controllers
{
    //Add the[FromBody] attribute to the parameter in your ASP.NET Core controller action
    //Note, if you're using ASP.NET Core 2.1, you can also use the [ApiController] attribute to
    //automatically infer the [FromBody] binding source for your complex action method parameters.
    //See the documentation https://docs.microsoft.com/en-us/aspnet/core/web-api/?view=aspnetcore-2.1#binding-source-parameter-inference for details.
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

        [HttpPost("getOpinionForMeal")]
        [ActionName("getOpinionForMeal")]
        public string GetOpinionForMeal(Meal request) => $"{request.StrMeal} is fantastic!";

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
