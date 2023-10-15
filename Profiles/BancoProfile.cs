using AutoMapper;
using questor_challenge.Data.DTO;

namespace questor_challenge.Profiles
{
    public class BancoProfile : Profile
    {
        public BancoProfile()
        {
            // Source -> Target
            CreateMap<CreateBancoDTO, Banco>();
            CreateMap<Banco, ReadBancoDTO>().ForMember(bancoDTO => bancoDTO.Id, opt => opt.MapFrom(banco => banco.Id));
            CreateMap<ReadBancoDTO, Banco>();
        }
    }
}
