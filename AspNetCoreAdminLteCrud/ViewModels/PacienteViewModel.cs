using System;
using System.ComponentModel.DataAnnotations;

namespace AspNetCoreAdminLteCrud.ViewModels
{
    public class PacienteViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Clinica { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
