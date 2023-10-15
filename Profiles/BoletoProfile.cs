using AutoMapper;
using questor_challenge.DTOs;
using questor_challenge.Models;

namespace questor_challenge.Profiles
{
    public class BoletoProfile : Profile
    {
        public BoletoProfile()
        {
            // Source -> Target
            CreateMap<CreateBoletoDTO, Boleto>();
            CreateMap<Boleto, ReadBoletoDTO>().ForMember(boletoDTO => boletoDTO.Id, opt => opt.MapFrom(boleto => boleto.Id));
            CreateMap<ReadBoletoDTO, Boleto>();
        }
    }
}
