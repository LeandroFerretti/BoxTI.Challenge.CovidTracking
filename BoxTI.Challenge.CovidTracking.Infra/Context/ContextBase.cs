
using Domain.Entidades;
using Infra.Mapeamentos;
using Microsoft.EntityFrameworkCore;

namespace Infra.Context
{
    public class ContextBase : DbContext
    {
        public DbSet<CovidPais> Covid { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=LeandroDataBase;Data Source=localhost\\SQLEXPRESS"
            );
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CovidPaisMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
