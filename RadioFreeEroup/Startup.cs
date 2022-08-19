using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using RadioFreeEroup.Domain.IJsonItem;
using RadioFreeEroup.Domain.Interfaces;
using RadioFreeEroup.Infrastructure;
using RadioFreeEroup.Infrastructure.Context;
using RadioFreeEroup.Infrastructure.Repository;
using RadioFreeEroup.Infrastructure.UnitOfWork;
using RadioFreeEurop.Apllication.Service.IService;
using RadioFreeEurop.Apllication.Service.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RadioFreeEroup
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        readonly string CorsPolicy = "CorsPolicy";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddDbContext<JsonItemContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddTransient<IJsonItemDiffService, JsonItemDiffService>();
            services.AddTransient<IJsonItemRepository, JsonItemRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            ConfigureCors(services);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "RadioFreeEroup", Version = "v1" });
            });
        }


        private void ConfigureCors(IServiceCollection services)
        {
            var list = new List<string>();
            Configuration.GetSection("AllowedHosts").Bind(list);
            services.AddCors(options =>
            {
                options.AddPolicy(CorsPolicy, builder =>
                {
                    builder.WithOrigins(list.ToArray()).SetIsOriginAllowed(x => _ = true).AllowAnyHeader().AllowAnyMethod().AllowCredentials();
                });

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "RadioFreeEroup v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors(CorsPolicy);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
