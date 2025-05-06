using AutoMapper;
using LoginBackend.Dtos;
using LoginBackend.Models;
using LoginBackend20243S.Models;

namespace LoginBackend.Utilidades
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<DepartamentoSinIdDTO, Departamento>().ReverseMap();
            CreateMap<Departamento, DepartamentoConIdDTO>().ReverseMap();
            // CreateMap<Origen, Destino>();
            // CreateMap<Destino, Origen>();
        }
    }
}
