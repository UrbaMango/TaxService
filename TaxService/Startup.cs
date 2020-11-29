using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using TaxService.Services;
using LiteDB;
using TaxService.LiteDB;
using Microsoft.Extensions.Configuration;

namespace TaxService
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                .SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_2_1);

            services.Configure<LiteDbOptions>(Configuration.GetSection("LiteDbOptions"));
            services.AddSingleton<ILiteDbContext, LiteDbContext>();
            services.AddSingleton<ITaxedCitiesServices, Services.TaxedCitiesServices>();
            services.AddSingleton<ITaxRulesServices, Services.TaxRulesServices>();
            services.AddTransient<ICalculateServices, Services.CalculateServices>();

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
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();

        }
    }
}
