using Microsoft.EntityFrameworkCore;

namespace KenkataWebshop.WebApi
{
    public class SqlContext : DbContext
    {
        public SqlContext(DbContextOptions<SqlContext> options) :base(options)
        {
        }

        
    }
}
