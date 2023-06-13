using AutoMapper;
using Core.Dtos;
using Core.Entities;
namespace API.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Company, CompanyDto>()
                .ForMember(c => c.FullAddress,
                    opt => opt.MapFrom(x => string.Join(' ', x.Address, x.Country)));
            CreateMap<Employee, EmployeeDto>();
            CreateMap<CompanyCreationDto, Company>();
            CreateMap<EmployeeCreationDto, Employee>();
        }
    }
}
