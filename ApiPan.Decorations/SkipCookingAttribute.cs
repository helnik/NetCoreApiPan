using System;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ApiPan.Decorations
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class SkipCookingAttribute : ActionFilterAttribute { }
}
