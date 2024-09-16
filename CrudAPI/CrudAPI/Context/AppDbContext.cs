
using Microsoft.EntityFrameworkCore;

namespace CrudAPI.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {

        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }


        public DbSet<Models.Product> Product { get; set; }
    }
}
