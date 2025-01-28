using Microsoft.AspNetCore.Mvc;
using miltecti_api.Entities;
using miltecti_api.Models;

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
