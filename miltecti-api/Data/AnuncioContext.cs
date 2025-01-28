namespace miltecti_api.Data;

using Microsoft.EntityFrameworkCore;
using miltecti_api.Entities;
using miltecti_api.Models;

public class AnuncioContext : DbContext
{
    public DbSet<AnuncioEntity> Anuncios { get; set; }
    public DbSet<ProdutoEntity> Produtos { get; set; }
    public DbSet<ServicoEntity> Servicos { get; set; }

    public AnuncioContext(DbContextOptions<AnuncioContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProdutoEntity>().ToTable("Produtos");
        modelBuilder.Entity<ServicoEntity>().ToTable("Servicos");
    }
}
