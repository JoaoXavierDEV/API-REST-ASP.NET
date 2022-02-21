using ASPNET.Api.ViewModels;
using ASPNET.Business.Intefaces;
using ASPNET.Business.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ASPNET.Api.Controllers
{
    [Route("api/produtos")]
    
    public class ProdutosController : MainController
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IProdutoService _produtoService;
        private readonly IMapper _mapper;

        public ProdutosController(IProdutoRepository produtoRepository,
                                    IProdutoService produtoService,
                                    IMapper mapper,
                                    INotificador notificador) : base(notificador)
        {
            _produtoRepository = produtoRepository;
            _produtoService = produtoService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ProdutoViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<ProdutoViewModel>>(await _produtoRepository.ObterProdutosFornecedores());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ProdutoViewModel>> ObterPorId(Guid id)
        {
            var produto = await ObterProdutos(id);
            if(produto == null) return NotFound();
            return Ok(produto);
        }
        [HttpPost]
        public async Task<ActionResult<ProdutoViewModel>> Adicionar(ProdutoViewModel produtoViewModel)
        {
            if(!ModelState.IsValid) return CustomResponse(ModelState);
            var imagemNome = Guid.NewGuid() + "_" + produtoViewModel.Imagem;
            if (!UploadArquivo(produtoViewModel.Imagem,imagemNome))
            {
                return CustomResponse();
            }
            produtoViewModel.Imagem = imagemNome;
            await _produtoService.Adicionar(_mapper.Map<Produto>(produtoViewModel));
            return CustomResponse(produtoViewModel);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<ProdutoViewModel>> Excluir(Guid id)
        {
            var produto = ObterProdutos(id);
            if (produto == null) return NotFound();
            await _produtoService.Remover(id);

            return CustomResponse(produto);
        }

        private bool UploadArquivo(string arquivo, string imgNome)
        {
            var imageDataByteArray = Convert.FromBase64String(arquivo);
            if (string.IsNullOrEmpty(arquivo))
            {
                // ModelState.AddModelError(string.Empty, "Forneça uma imagem para este produto");
                NotificarErro("NOTIFICAERRO - Forneça uma imagem para este produto");
                return false;
            }

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwroot/imagens", imgNome);

            if ( System.IO.File.Exists(filePath))
            {
                // ModelState.AddModelError(String.Empty, "Já existe um caminho com este nome");
                NotificarErro("Já existe um caminho com este nome");
                return false;
            }
            System.IO.File.WriteAllBytes(filePath, imageDataByteArray);
            return true;
        }

        private async Task<ProdutoViewModel> ObterProdutos(Guid id)
        {
            return _mapper.Map<ProdutoViewModel>(await _produtoRepository.ObterProdutosPorFornecedor(id));
        }

    }
}
