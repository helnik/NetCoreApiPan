using ApiPan.Decorations;
using ApiPan.Implementation;
using ApiPan.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using ApiPan.Middleware;
using Microsoft.AspNetCore.Http;

namespace NetCoreApiPan
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            RegisterDIServices(services);
            services
                .AddMvc(options => RegisterFilters(options.Filters))
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddApplicationPart(Assembly.Load("ApiPan.Controllers"))
                .AddControllersAsServices();
        }

        private void RegisterDIServices(IServiceCollection services)
        {
            services
                .AddSingleton<ICooker, Baker>()
                .AddSingleton<ITemperatureChecker, TemperatureChecker>();
        }

        private void RegisterFilters(FilterCollection filters)
        {
            filters.Add(new SkipCookingFilter());
            filters.Add<TemperatureFilter>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.MapWhen(context => context.Request.Path.Value.Contains("alcohol"), AlcoholMapMiddleware.HandleAlcohol);
            app.Map("/cocktail", AlcoholMapMiddleware.HandleCocktail);
            app.UsePrepareMealMiddleware();
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
