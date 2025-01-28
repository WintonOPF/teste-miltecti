using miltecti_api.Entities;
using miltecti_api.Models;
using miltecti_api.Repositories;

namespace miltecti_api.Services
{
    public class AnuncioService : IAnuncioService
    {
        private readonly IAnuncioRepository _repository;      

        public AnuncioService(
            IAnuncioRepository repository       
        )
        {
            _repository = repository;      
        }

        public async Task<List<AnuncioEntity>> GetAllAnunciosAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<AnuncioEntity> GetAnuncioByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<ResponseModel<AnuncioEntity>> CreateAnuncioAsync(AnuncioModel model)
        {
            var anuncio = new AnuncioEntity();
            if (model.TipoAnuncio.ToLower() == "produto")
            {           
                anuncio = new ProdutoEntity().ToType(model);
            }
            else if (model.TipoAnuncio.ToLower() == "serviço")
            {
                anuncio = new ServicoEntity().ToType(model);        
            }

            var errors = anuncio.Validate();
            if (errors != null) return new ResponseModel<AnuncioEntity>(errors);
            await _repository.AddAsync(anuncio);
            return new ResponseModel<AnuncioEntity>(anuncio);
        }

    }
}
