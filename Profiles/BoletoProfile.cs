using AutoMapper;
using questor_challenge.DTOs;
using questor_challenge.Models;

namespace Questor.Questao2.Api.Profiles
{
    public class BoletoProfile : Profile
    {
        public BoletoProfile()
        {
            // Source -> Target
            CreateMap<Boleto, BoletoDTO>();
            CreateMap<BoletoDTO, Boleto>();
        }
    }
}
