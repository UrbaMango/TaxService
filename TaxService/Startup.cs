using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using System.IO;
using TaxService.LiteDB;
using TaxService.Services;

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

      //services.AddCors();

      services.AddCors(options =>
      {
        options.AddPolicy("CorsPolicy",
            builder => builder.WithOrigins("http://localhost:4200")
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials());
      });
      

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
      
       app.UseCors("CorsPolicy");
     // app.UseCors(
      //  options => options.WithOrigins("http://localhost:4200/").AllowAnyMethod()
      //  );

      app.UseMvc();
     


    }
  }
}
