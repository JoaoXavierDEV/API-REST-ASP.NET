using Microsoft.AspNetCore.Mvc;
using ASPNET.Api.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ASPNET.Api.Configuration
{
    public static class ApiConfig
    {
        public static IServiceCollection WebApiConfig(this IServiceCollection services)
        {
            services.AddControllers();
            services.Configure<ApiBehaviorOptions>(
                op =>
                {
                    op.SuppressModelStateInvalidFilter = true;
                });
            services.AddCors(op => {
                op.AddPolicy("Development",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    //.AllowCredentials()
                    );
            });
            return services;
        }
        public static IApplicationBuilder UseMVCConfiguration(this IApplicationBuilder app, IConfiguration config,IWebHostEnvironment env) {
            app.UseCors("Development");
            app.UseHttpsRedirection();
            app.UseAuthorization();
            // app.MapControllers();

            return app;
        }
    }
}
