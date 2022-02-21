using ASPNET.Business.Intefaces;
using ASPNET.Business.Notificacoes;
using ASPNET.Business.Services;
using ASPNET.Data.Context;
using ASPNET.Data.Repository;
using DevIO.Api.Extensions;

namespace ASPNET.Api.Configuration
{
    public static class DependencyInjectionConfig

    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<MeuDbContext>();
            services.AddScoped<IFornecedorRepository, FornecedorRepository>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();

            services.AddScoped<INotificador, Notificador>();
            services.AddScoped<IFornecedorService, FornecedorService>();
            services.AddScoped<IProdutoService, ProdutoService>();
            

            // services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            // services.AddScoped<IUser, AspNetUser>();
          
            return services;
        }
    }
}
