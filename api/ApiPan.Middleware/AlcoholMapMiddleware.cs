using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace ApiPan.Middleware
{
    public static class AlcoholMapMiddleware
    {
        public static void HandleAlcoholAsync(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Alcohol usage is not supported by this api...");
            });
        }

        public static void HandleCocktailAsync(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Cocktail preparation is not supported by this api...");
            });
        }
    }
}
