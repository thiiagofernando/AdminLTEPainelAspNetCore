using AspNetCoreAdminLteCrud.Data;
using AspNetCoreAdminLteCrud.Interfaces;
using AspNetCoreAdminLteCrud.Models;

namespace AspNetCoreAdminLteCrud.Repository
{
    public class PacienteRepository : Repository<Paciente>, IPacienteRepository
    {
        public PacienteRepository(MeuDbContext context) : base(context) { }

    }
}
