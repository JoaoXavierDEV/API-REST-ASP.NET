using System;
using System.Threading.Tasks;
using ASPNET.Business.Intefaces;
using ASPNET.Business.Models;
using ASPNET.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace ASPNET.Data.Repository
{
    public class EnderecoRepository : Repository<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(MeuDbContext context) : base(context) { }

        public async Task<Endereco> ObterEnderecoPorFornecedor(Guid fornecedorId)
        {
            return await Db.Enderecos.AsNoTracking()
                .FirstOrDefaultAsync(f => f.FornecedorId == fornecedorId);
        }
    }
}