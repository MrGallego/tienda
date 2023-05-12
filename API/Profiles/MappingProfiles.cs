using API.Dtos;
using AutoMapper;
using Core.Entities;

namespace API.Profiles
{
    public class MappingProfiles: Profile
    {
        public MappingProfiles()
        {
            CreateMap<Producto, ProductoDto>().ReverseMap();
            CreateMap<Tienda, TiendaDto>().ReverseMap();

            CreateMap<Producto, ProductoListDto>()
                .ForMember(dest=>dest.Tienda, origin=>origin
                .MapFrom(origin =>origin.Tienda.Nombre))
                .ReverseMap()
                .ForMember(origin=>origin.Tienda, dest=> dest.Ignore());

            CreateMap<Producto, ProductoAddUpdateDto>()
                .ReverseMap()
                .ForMember(origin => origin.Tienda, dest => dest.Ignore());
        }
    }
}
