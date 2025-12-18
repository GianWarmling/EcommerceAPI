using AutoMapper;
using EcommerceAPI.Models;
using EcommerceAPI.DTOs;

namespace EcommerceAPI.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Produto, ProdutoDto>();
            CreateMap<CriarProdutoDto, Produto>()
                .ForMember(dest => dest.CriadoEm, opt => opt.MapFrom(_ => DateTime.UtcNow))
                .ForMember(dest => dest.Ativo, opt => opt.MapFrom(_ => true));

            CreateMap<AtualizarProdutoDto, Produto>();
        }
    }
}
