using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace ApiPan.Decorations
{
    public class SkipCookingFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            bool hasSkipCooking = context.ActionDescriptor
                .FilterDescriptors
                .Any(f => f.Filter is SkipCookingAttribute);

            if (hasSkipCooking)
                context.Result = new ContentResult
                {
                    Content = "Better order some delivery!"
                };
        }

        public void OnActionExecuted(ActionExecutedContext context) { }
    }
}
