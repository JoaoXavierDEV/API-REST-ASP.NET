#pragma warning disable CS8603 // Possível retorno de referência nula.
using System;
using System.Threading.Tasks;
using ASPNET.Business.Intefaces;
using ASPNET.Business.Models;
using ASPNET.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace ASPNET.Data.Repository
{
    public class FornecedorRepository : Repository<Fornecedor>, IFornecedorRepository
    {
        public FornecedorRepository(MeuDbContext context) : base(context)
        {
        }
        public async Task<List<Fornecedor>> Visualizar()
        {
            return await ObterTodos();
                
        }

        public async Task<Fornecedor> ObterFornecedorEndereco(Guid id)
        {
            return await Db.Fornecedores.AsNoTracking()
                .Include(c => c.Endereco)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Fornecedor> ObterFornecedorProdutosEndereco(Guid id)
        {
            return await Db.Fornecedores.AsNoTracking()
                //.Where(c => c.Id == id)
                //.Include(c => c.Produtos)
               // .Include(c => c.Endereco)
                 // .Select(c => c.Id)
                //.FirstAsync();
                // .ToList();
                 .SingleAsync(c => c.Id == id);
        }
    }
}
#pragma warning restore CS8603 // Possível retorno de referência nula.