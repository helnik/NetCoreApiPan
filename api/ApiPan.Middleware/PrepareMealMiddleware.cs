using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace ApiPan.Middleware
{
    public class PrepareMealMiddleware
    {
        private readonly RequestDelegate _next;

        public PrepareMealMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Do work that doesn't write to the Response.
            Trace.WriteLine($"Start using prepare meal middleware. Request Path = {context.Request.Path}");
            await _next(context);
            // Do logging or other work that doesn't write to the Response.
            Trace.WriteLine("Exiting meal middleware");
        }
    }
}
