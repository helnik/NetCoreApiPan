using ApiPan.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ApiPan.Decorations
{
    public class TemperatureFilter : IActionFilter
    {
        private readonly ITemperatureChecker temperatureChecker;

        public TemperatureFilter(ITemperatureChecker tempChecker)
        {
            temperatureChecker = tempChecker;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ActionArguments.TryGetValue("temp", out object tempValue) || !(tempValue is int temperature))
                return;
            if (!temperatureChecker.IsCookingReadyTemperature(temperature))
                context.Result = new ContentResult
                {
                    Content = "Please wait until ingredients reach room temperature...."
                };
        }

        public void OnActionExecuted(ActionExecutedContext context) { }
    }
}
