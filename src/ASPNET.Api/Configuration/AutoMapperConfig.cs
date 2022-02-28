using ASPNET.Api.ViewModels;
using ASPNET.Business.Models;
using AutoMapper;

namespace ASPNET.Api.Configuration;

public class AutoMapperConfig : Profile
{
    public AutoMapperConfig()
    {
        // se não tiver construtores ou parâmetros, usar ReverseMap()
        CreateMap<Fornecedor, FornecedorViewModel>().ReverseMap();
        CreateMap<Endereco, EnderecoViewModel>().ReverseMap();
        CreateMap<ProdutoViewModel, Produto>();
        CreateMap<ProdutoImagemViewModel, Produto>().ReverseMap();
        CreateMap<Produto, ProdutoViewModel>()
            .ForMember(dest => dest.NomeFornecedor, opt => opt.MapFrom(src => src.Fornecedor.Nome));
    }
}

