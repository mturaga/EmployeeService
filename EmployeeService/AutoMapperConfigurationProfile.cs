using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeService
{
    public class AutoMapperConfigurationProfile : Profile
    {
        public AutoMapperConfigurationProfile():base()
        {
            CreateMap<Business.Dto.Employee, EmployeeDto>()               
                .ForMember(dest => dest.EmployeeId, opt => opt.MapFrom(src => src.EmployeeId.ToString()));
        }
    }
}
