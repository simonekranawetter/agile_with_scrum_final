using KenkataWebshop.WebApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace KenkataWebshop.WebApi
{
    public class SqlContext : DbContext
    {
        public SqlContext(DbContextOptions<SqlContext> options) :base(options)
        {
        }

        public DbSet<ProductEntity> Products => Set<ProductEntity>();
        public DbSet<CategoryEntity> Category => Set<CategoryEntity>();
        
    }
}
