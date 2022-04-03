using Microsoft.AspNetCore.Mvc;
using ASPNET.Api.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Net.Http.Headers;

namespace ASPNET.Api.Configuration
{
    public static class ApiConfig
    {
        public static IServiceCollection AddWebApiConfig(this IServiceCollection services)
        {
            services.AddControllers();
            services.Configure<ApiBehaviorOptions>(
                op =>
                {
                    op.SuppressModelStateInvalidFilter = true;
                });
            services.AddApiVersioning(op => 
            {
                op.AssumeDefaultVersionWhenUnspecified = true;
                op.DefaultApiVersion = new ApiVersion(2, 0);
                op.ReportApiVersions = true;
            });
            services.AddVersionedApiExplorer(op => {
                op.GroupNameFormat = "'v'VVV";
                op.SubstituteApiVersionInUrl = true;
            });
            services.AddCors(op => {
                op.AddPolicy("Development",
                    builder => builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    //.AllowCredentials()
                    );
            });

            services.AddCors(op => {
                op.AddPolicy("Production",
                    builder => builder
                    .WithMethods("GET")
                    .WithOrigins("https://localhost")
                    .SetIsOriginAllowedToAllowWildcardSubdomains()
                    // .WithHeaders(HeaderNames.ContentType, "x-custom-header")
                    .AllowAnyHeader()
                    
                    ); ;
            });
            return services;
        }
        public static IApplicationBuilder UseApiConfig(this IApplicationBuilder app, IWebHostEnvironment env) {
            app.UseHttpsRedirection();

            if (env.IsDevelopment())
            {
                app.UseCors("Development");
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseCors("Production");
                app.UseHsts();
            }
            // app.UseMiddleware<ExceptionMiddleware>();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseStaticFiles();
            return app;
        }
    }
}
