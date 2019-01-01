using Microsoft.AspNetCore.Builder;

namespace ApiPan.Middleware
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UsePrepareMealMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<PrepareMealMiddleware>();
        }
    }
}
