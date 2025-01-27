using miltecti_api.Entities;

namespace miltecti_api.Services
{
    public interface IAnuncioService
    {
        Task<List<AnuncioEntity>> GetAllAnunciosAsync();
        Task<AnuncioEntity> GetAnuncioByIdAsync(int id);
        Task CreateProdutoAsync(ProdutoEntity produto);
        Task CreateServicoAsync(ServicoEntity servico);
        Task UpdateAnuncioAsync(AnuncioEntity anuncio);
        Task DeleteAnuncioAsync(int id);
    }
}
