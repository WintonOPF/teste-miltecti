using Microsoft.AspNetCore.Mvc;
using miltecti_api.Entities;
using miltecti_api.Models;

namespace miltecti_api.Services
{
    public interface IAnuncioService
    {
        Task CreateAnuncioAsync(AnuncioEntity anuncio);
        Task<List<AnuncioEntity>> GetAllAnunciosAsync();
        Task<AnuncioEntity> GetAnuncioByIdAsync(int id);
        Task UpdateAnuncioAsync(AnuncioEntity anuncio);
        Task DeleteAnuncioAsync(int id);
    }
}
