using AutoMapper;
using TicketGenerator.DTOs;
using TicketGenerator.Entities;

namespace TicketGenerator.AutoMapper
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Ticket, TicketDto>();
            CreateMap<TicketDto, Ticket>();
            CreateMap<BoxDto, Box>()
              .ForMember(dest => dest.Id, opt => opt.Ignore())
              .ForMember(dest => dest.DateCreation, opt => opt.Ignore())
              .ForMember(dest => dest.TicketBoxes, opt => opt.Ignore());
            CreateMap<Box, BoxDto>();
            CreateMap<TicketBoxDto, Ticket>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.DateCreation, opt => opt.Ignore())
                .ForSourceMember(source=> source.Boxes, opt => opt.DoNotValidate());
            CreateMap<Ticket, TicketBoxDto>()
                .ForMember(dest => dest.Boxes, opt => opt.MapFrom(src => src.TicketBoxes.Select(tb => tb.Box)));
          
        }
    }
}
