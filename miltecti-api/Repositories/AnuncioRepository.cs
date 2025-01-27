using Microsoft.EntityFrameworkCore;
using miltecti_api.Data;
using miltecti_api.Entities;
using miltecti_api.Models;

namespace miltecti_api.Repositories
{
    public class AnuncioRepository : IAnuncioRepository
    {
        private readonly AnuncioContext _context;

        public AnuncioRepository(AnuncioContext context)
        {
            _context = context;
        }

        public async Task<List<AnuncioEntity>> GetAllAsync()
        {
            return await _context.Anuncios.ToListAsync();
        }

        public async Task<AnuncioEntity> GetByIdAsync(int id)
        {
            return await _context.Anuncios.FindAsync(id);
        }

        public async Task AddAsync(AnuncioEntity anuncio)
        {
            await _context.Anuncios.AddAsync(anuncio);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(AnuncioEntity anuncio)
        {
            _context.Anuncios.Update(anuncio);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Anuncios.FindAsync(id);
            if (entity != null)
            {
                _context.Anuncios.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
