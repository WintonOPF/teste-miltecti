namespace miltecti_api.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using miltecti_api.Entities;
    using miltecti_api.Services;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [ApiController]
    [Route("api/[controller]")]
    public class AnuncioController : ControllerBase
    {
        private readonly IAnuncioService _service;

        public AnuncioController(IAnuncioService service)
        {
            _service = service;
        }

        [HttpPost("produto")]
        public async Task<ActionResult> CreateProduto([FromBody] ProdutoEntity produto)
        {
            await _service.CreateProdutoAsync(produto);
            return CreatedAtAction(nameof(GetById), new { id = produto.Id }, produto);
        }

        [HttpPost("servico")]
        public async Task<ActionResult> CreateServico([FromBody] ServicoEntity servico)
        {
            await _service.CreateServicoAsync(servico);
            return CreatedAtAction(nameof(GetById), new { id = servico.Id }, servico);
        }

        [HttpGet]
        public async Task<ActionResult<List<AnuncioEntity>>> GetAll()
        {
            var anuncios = await _service.GetAllAnunciosAsync();
            return Ok(anuncios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AnuncioEntity>> GetById(int id)
        {
            var anuncio = await _service.GetAnuncioByIdAsync(id);
            if (anuncio == null) return NotFound();
            return Ok(anuncio);
        }
    }

}
