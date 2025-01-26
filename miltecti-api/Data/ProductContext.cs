using Microsoft.EntityFrameworkCore;
using miltecti_api.Models;

namespace miltecti_api.Data
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}
