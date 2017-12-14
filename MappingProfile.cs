using AutoMapper;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerDto>();

            CreateMap<CustomerDto, Customer>()
                .ForMember(rec => rec.Id, opt => opt.Ignore());

            CreateMap<Movie, MovieDto>();

            CreateMap<MovieDto, Movie>()
                .ForMember(rec => rec.Id, opt => opt.Ignore());

            CreateMap<MembershipType, MembershipTypeDto>();

            CreateMap<MembershipTypeDto, MembershipType>()
                .ForMember(rec => rec.Id, opt => opt.Ignore());
        }
    }
}
