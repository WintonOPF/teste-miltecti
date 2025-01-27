using miltecti_api.Entities;

namespace miltecti_api.Repositories
{
    public interface IAnuncioRepository
    {
        Task<List<AnuncioEntity>> GetAllAsync();
        Task<AnuncioEntity> GetByIdAsync(int id);
        Task AddAsync(AnuncioEntity anuncio);
        Task UpdateAsync(AnuncioEntity anuncio);
        Task DeleteAsync(int id);
    }
}
