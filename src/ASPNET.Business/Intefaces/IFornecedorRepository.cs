using System;
using System.Threading.Tasks;
using ASPNET.Business.Models;

namespace ASPNET.Business.Intefaces
{
    public interface IFornecedorRepository : IRepository<Fornecedor>
    {
        Task<List<Fornecedor>> Visualizar();
        Task<Fornecedor> ObterFornecedorEndereco(Guid id);
        Task<Fornecedor> ObterFornecedorProdutosEndereco(Guid id);
    }
}