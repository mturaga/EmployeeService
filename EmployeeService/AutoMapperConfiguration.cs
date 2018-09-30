using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeService
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<AutoMapperConfigurationProfile>();
            });

            Mapper.Configuration.AssertConfigurationIsValid();
        }
    }
}
