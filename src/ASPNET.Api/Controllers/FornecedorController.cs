using ASPNET.Api.ViewModels;
using ASPNET.Business.Intefaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ASPNET.Api.Controllers
{
    [Route("api/fornecedores")]
    public class FornecedorController : MainController
    {
        private readonly IFornecedorRepository _fornecedorRepository;
        private readonly IFornecedorService _fornecedorService;
        private readonly IMapper _mapper;

        public FornecedorController(IFornecedorRepository fornecedorRepository,
                                    IMapper mapper, IFornecedorService fornecedorService)
        {
            _fornecedorRepository = fornecedorRepository;
            _mapper = mapper;
            _fornecedorService = fornecedorService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FornecedorViewModel>>> ObterTodos()
        {
            // o retorno já é um 200, recomendasse usar ActionResult somente em casos de erro ex: 400, 404, 403
             //var fornecedor = _mapper.Map<IEnumerable<FornecedorViewModel>>(await _fornecedorRepository.ObterTodos());
            var fornecedor = _mapper.Map<IEnumerable<FornecedorViewModel>>(await _fornecedorService.Visualizar());
            return Ok(fornecedor);
        }
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<FornecedorViewModel>> ObterPorID(Guid id)
        {
            var fornecedor = _mapper.Map<IEnumerable<FornecedorViewModel>>(await _fornecedorRepository.ObterPorId(id));
            if (fornecedor == null) return NotFound();
            return Ok(fornecedor);
        }

        [HttpPost]
        public async Task<ActionResult<FornecedorViewModel>> Adicionar(FornecedorViewModel fornecedorView)
        {
            if(!ModelState.IsValid) return BadRequest();

            return Ok();

        }


        public async Task<FornecedorViewModel> ObterFornecedorProdutosPorEndereco(Guid id)
        {
            return _mapper.Map<FornecedorViewModel>(await _fornecedorRepository.ObterFornecedorProdutosEndereco(id));
        }

    }
}
