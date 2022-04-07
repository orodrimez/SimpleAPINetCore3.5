using ExamenYache.Models;
using ExamenYache.Models.Dto;
using AutoMapper;

namespace ExamenYache.Mapper
{
    public class FrutasMapper : Profile
    {
        public FrutasMapper()
        {
            CreateMap<Fruta, FrutaDto>().ReverseMap();
            CreateMap<Fruta, FrutaCrearDto>().ReverseMap();
        }
    }
}
