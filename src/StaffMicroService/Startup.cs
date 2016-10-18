using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.PlatformAbstractions;
using StaffMicroService.Models;
using StaffMicroService.Repositories;
using Steeltoe.Discovery.Client;
using Steeltoe.Extensions.Configuration;
using Swashbuckle.Swagger.Model;
using System.IO;

namespace StaffMicroService
{
    /// <summary>
    /// 
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="env"></param>
        /// <param name="factory"></param>
        public Startup(IHostingEnvironment env, ILoggerFactory factory)
        {
            factory.AddConsole(minLevel: LogLevel.Debug);

            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddCloudFoundry()
                .AddEnvironmentVariables();

            Configuration = builder.Build();

            //generate app settings
            GenerateSettings();
        }

        /// <summary>
        /// 
        /// </summary>
        public IConfigurationRoot Configuration { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(AppSettings.ConnectionString)
            );

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddDiscoveryClient(Configuration);
            services.AddSwaggerGen();

            var appEnvironment = PlatformServices.Default.Application;

            services.ConfigureSwaggerGen(options =>
            {
                options.SingleApiVersion(new Info
                {
                    Version = "v1",
                    Title = "Staff Microservice",
                    Description = "Staff Microservice Documentation",
                    TermsOfService = "None"
                });
                options.IncludeXmlComments(Path.Combine(appEnvironment.ApplicationBasePath, $"StaffMicroService.xml"));
            });

            services.AddRouting(options => options.LowercaseUrls = true);
            services.AddCors();

            services.AddMvc();
        }

        /// <summary>
        /// 
        /// </summary>
        private void GenerateSettings()
        {
            AppSettings.ConnectionString = Configuration["Data:ConnectionString"];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        /// <param name="loggerFactory"></param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseStaticFiles();

            app.UseDiscoveryClient();

            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUi();
        }
    }
}
