using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Customer.Api.Implementations;
using Customer.Api.Interfaces;
using Doodle.Dal.Implementations;
using Doodle.Dal.Interfaces;
using Doodle.Dal.UnitOfWork;
using Doodle.Infrastructure.DoodleClient;
using Doodle.Infrastructure.SharedConfig;
using Doodle.SqlEntities.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Customer.Api
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
            services.AddControllers();
            string FullName = System.Reflection.Assembly.GetExecutingAssembly().FullName;
            services.AddCors();
            services.AddApiVersioning(o =>
            {
                o.ReportApiVersions = true;
                o.DefaultApiVersion = new ApiVersion(1, 0);
                o.AssumeDefaultVersionWhenUnspecified = true;
            });
            services.AddSwaggerGen();





            //services.Configure<AppSettings>(JsonConfig.CreateConfigurationContainer().GetSection("AppSettings"));

            string connection = string.Empty;
            string ConnectionString =  Configuration.GetConnectionString("DoodleDatabase");
            
            if (!string.IsNullOrEmpty(ConnectionString))
            {
                connection = ConnectionString;
            }
            services.AddDbContext<DoodleContext>(cfg => cfg.UseSqlServer(connection));
           

            services.AddScoped<ICustomer, CustomerRepo>();
            services.AddScoped<ILeadRepo, LeadRepo>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();
            app.UseCors(builder =>
                      builder.SetIsOriginAllowed(origin => true)
                             .AllowAnyMethod()
                             .AllowAnyHeader()
                             .AllowCredentials());
            app.UseAuthentication();
            app.UseAuthorization();


            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "V1");
                
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
