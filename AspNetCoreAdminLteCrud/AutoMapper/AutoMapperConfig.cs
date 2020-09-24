using AspNetCoreAdminLteCrud.Models;
using AspNetCoreAdminLteCrud.ViewModels;
using AutoMapper;

namespace AspNetCoreAdminLteCrud.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Paciente, PacienteViewModel>().ReverseMap();
        }
    }
}
