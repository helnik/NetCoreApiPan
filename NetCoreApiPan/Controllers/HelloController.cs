using Microsoft.AspNetCore.Mvc;

namespace NetCoreApiPan.Controllers
{
    [ApiController]
    [Route("api/hello")]
    public class HelloController : ControllerBase
    {
        //Disable from launchsetting.json default behavior (i.e. api/values) let it use a welcome message
        //instead of using: app.Run(async (context) => { await context.Response.WriteAsync("Welcome to NetCoreApiPan !!"); });
        //in configure. app.Run is terminal will swallow status codes
        [HttpGet("getHello")]
        [ActionName("getHello")]
        public string GetHello() => "Welcome to NetCoreApiPan API";
    }
}
