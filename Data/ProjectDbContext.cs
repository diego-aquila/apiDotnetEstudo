using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class ProjectDbContext : DbContext
    {
        public ProjectDbContext(DbContextOptions<ProjectDbContext> options) : base(options)
        {
        }


        public DbSet<Cidade> Cidade { get; set; }
        public DbSet<Estado> Estado { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Pessoa> Pessoa { get; set; }
        public DbSet<Conta> Conta { get; set; }
    }
    

    
}
