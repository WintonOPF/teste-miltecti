using miltecti_api.Entities;
using miltecti_api.Models;
using miltecti_api.Repositories;
using miltecti_api.Validators;

namespace miltecti_api.Services
{
    public class AnuncioService : IAnuncioService
    {
        private readonly IAnuncioRepository _repository;
        private readonly IValidator<AnuncioEntity> _anuncioValidator;
        private readonly IValidator<ProdutoEntity> _produtoValidator;
        private readonly IValidator<ServicoEntity> _servicoValidator;

        public AnuncioService(
            IAnuncioRepository repository,
            IValidator<AnuncioEntity> anuncioValidator
        )
        {
            _repository = repository;
            _anuncioValidator = anuncioValidator;
        }

        public async Task<List<AnuncioEntity>> GetAllAnunciosAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<AnuncioEntity> GetAnuncioByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task CreateAnuncioAsync(AnuncioEntity anuncio)
        {
            _anuncioValidator.Validate(anuncio);
            await _repository.AddAsync(anuncio);
        }

        public async Task CreateProdutoAsync(ProdutoEntity produto)
        {
            _produtoValidator.Validate(produto);
            await _repository.AddAsync(produto);
        }

        public async Task CreateServicoAsync(ServicoEntity servico)
        {
            _servicoValidator.Validate(servico);
            await _repository.AddAsync(servico);
        }

        public async Task UpdateAnuncioAsync(AnuncioEntity anuncio)
        {
            await _repository.UpdateAsync(anuncio);
        }

        public async Task DeleteAnuncioAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
