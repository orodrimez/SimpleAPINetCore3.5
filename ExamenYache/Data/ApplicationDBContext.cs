using ExamenYache.Models;
using Microsoft.EntityFrameworkCore;
namespace ExamenYache.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        { }

        public DbSet<Fruta> Fruta { get; set; }
    }
}
