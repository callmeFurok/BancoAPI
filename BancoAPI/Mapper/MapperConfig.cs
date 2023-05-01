using AutoMapper;
using BancoAPI.Modelos;
using BancoAPI.Modelos.Dtos;

namespace BancoAPI.Mapper
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Cliente, CrearClienteDto>().ReverseMap();
            CreateMap<Cuenta, CrearCuentaDto>().ReverseMap();
        }
    }
}
