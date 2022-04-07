using ASPNET.Api.Extensions;

namespace ASPNET.Api.Configuration
{
    public static class LoggerConfig
    {
        public static IServiceCollection AddLoggingConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddElmahIo(o =>
            {
                o.ApiKey = "5f82b2b41ad34fa2a1bb0c9c5fda0a13";
                o.LogId = new Guid("ceeac5e5-7e62-4dcd-9bf4-810f7e3b2f3b");
                o.Application = "Testessss";
            });

            services.AddHealthChecksUI()
                 .AddSqlServerStorage(configuration.GetConnectionString("DefaultConnection"));
            services.AddHealthChecks()
                .AddElmahIoPublisher(options =>
                {
                    options.ApiKey = "5f82b2b41ad34fa2a1bb0c9c5fda0a13";
                    options.LogId = new Guid("ceeac5e5-7e62-4dcd-9bf4-810f7e3b2f3b");
                    options.HeartbeatId = "API Fornecedores";
                    options.Application = "APITESTES";
                })
                .AddCheck("Produtos", new Extensions.SqlServerHealthCheck(configuration.GetConnectionString("DefaultConnection")), tags: new string[] { "produtos", "verificaQuantidade" })
                .AddSqlServer(configuration.GetConnectionString("DefaultConnection"), name: "SQL SERVER", tags: new string[] {"sql", "banco de dados"});

            return services;
        }

        public static IApplicationBuilder UseLoggingConfig(this IApplicationBuilder app)
        {
            app.UseElmahIo();
            return app;
        }
    }
}
