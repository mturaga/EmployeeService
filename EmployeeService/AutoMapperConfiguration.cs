using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeService
{
    public class AutoMapperConfiguration
    {
        public static IMapper Configure()
        {
            var mapper = new MapperConfiguration((x) => {

                x.AddProfile<AutoMapperConfigurationProfile>();
            });

            return mapper.CreateMapper();
            
        }
    }
}
