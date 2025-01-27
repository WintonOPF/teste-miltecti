using Microsoft.AspNetCore.Mvc;
using miltecti_api.Entities;
using miltecti_api.Models;

namespace miltecti_api.Services
{
    public interface IAnuncioService
    {
        Task<ResponseModel<AnuncioEntity>> CreateAnuncioAsync(AnuncioModel anuncio);
        Task<List<AnuncioEntity>> GetAllAnunciosAsync();
        Task<AnuncioEntity> GetAnuncioByIdAsync(int id);
    }
}
