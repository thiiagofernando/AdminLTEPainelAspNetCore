using AspNetCoreAdminLteCrud.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using AspNetCoreAdminLteCrud.ViewModels;

namespace AspNetCoreAdminLteCrud.Data
{
    public class MeuDbContext : DbContext
    {
        public MeuDbContext(DbContextOptions<MeuDbContext> options) : base(options) { }

        public DbSet<Paciente> pacientes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //varchar(100) default para string para nao criar varchar(MAX)
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                  .SelectMany(e => e.GetProperties()
                      .Where(p => p.ClrType == typeof(string))))
            {
                property.SetColumnType("varchar(100)");
            }

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MeuDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<AspNetCoreAdminLteCrud.ViewModels.PacienteViewModel> PacienteViewModel { get; set; }
    }
}
