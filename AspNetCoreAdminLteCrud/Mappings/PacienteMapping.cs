using AspNetCoreAdminLteCrud.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AspNetCoreAdminLteCrud.Mappings
{
    public class PacienteMapping : IEntityTypeConfiguration<Paciente>
    {
        public void Configure(EntityTypeBuilder<Paciente> builder)
        {
            builder.HasKey(h => h.Id);
            builder.Property(h => h.Nome).IsRequired();
            builder.Property(h => h.Email).IsRequired();
            builder.Property(h => h.Telefone).IsRequired();
            builder.Property(h => h.Clinica).IsRequired();
        }
    }
}
