using System;
using System.Threading.Tasks;
using ASPNET.Business.Models;

namespace ASPNET.Business.Intefaces
{
    public interface IFornecedorService : IDisposable
    {
        Task<List<Fornecedor>> Visualizar();
        Task<bool> Adicionar(Fornecedor fornecedor);
        Task<bool> Atualizar(Fornecedor fornecedor);
        Task<bool> Remover(Guid id);

        Task AtualizarEndereco(Endereco endereco);
    }
}