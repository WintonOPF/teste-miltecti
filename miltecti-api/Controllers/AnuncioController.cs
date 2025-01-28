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
            Console.WriteLine(anuncio);
            var response = await _service.CreateAnuncioAsync(anuncio);
            if (response.Errors != null) return BadRequest(response);
            return Ok(response);
 
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
