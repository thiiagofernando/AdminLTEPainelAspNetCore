using System;

namespace AspNetCoreAdminLteCrud.Models
{
    public class Paciente : Entity
    {
        public Paciente()
        {
            DataCadastro = DateTime.Now;
        }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Clinica { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
