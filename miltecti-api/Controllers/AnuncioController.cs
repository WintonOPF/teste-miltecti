namespace miltecti_api.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using miltecti_api.Entities;
    using miltecti_api.Models;
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

        [HttpPost("anuncio")]
        public async Task<ActionResult> CreateAnuncio([FromBody] AnuncioModel anuncio)
        {
            if (anuncio.TipoAnuncio.ToLower() == "produto")
            {
                var produto = new ProdutoEntity() 
                {
                    NomeAnuncio = anuncio.NomeAnuncio,
                    DataPublicacao = anuncio.DataPublicacao,
                    Valor = anuncio.Valor,
                    Cidade = anuncio.Cidade,
                    Categoria = anuncio.Categoria,
                    Modelo = anuncio.Modelo,
                    Condicao = anuncio.Condicao,
                    Quantidade = anuncio.Quantidade ?? 0,
                    TipoAnuncio = anuncio.TipoAnuncio
                };
                await _service.CreateAnuncioAsync(produto);
                return CreatedAtAction(nameof(GetById), new { id = produto.Id }, produto);

            } else //if (anuncio.TipoAnuncio.ToLower() == "servico")
            {
                var servico = new ServicoEntity()
                {
                    NomeAnuncio = anuncio.NomeAnuncio,
                    DataPublicacao = anuncio.DataPublicacao,
                    Valor = anuncio.Valor,
                    Cidade = anuncio.Cidade,
                    TipoServico = anuncio.TipoServico,
                    TipoAnuncio = anuncio.TipoAnuncio
                };

                await _service.CreateAnuncioAsync(servico);
                return CreatedAtAction(nameof(GetById), new { id = servico.Id }, servico);
            } 
        }

        [HttpGet]
        public async Task<ActionResult<List<AnuncioModel>>> GetAll()
        {
            var anuncios = await _service.GetAllAnunciosAsync();
            return Ok(anuncios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AnuncioModel>> GetById(int id)
        {
            var anuncio = await _service.GetAnuncioByIdAsync(id);
            if (anuncio == null) return NotFound();
            return Ok(anuncio);
        }
    }

}
