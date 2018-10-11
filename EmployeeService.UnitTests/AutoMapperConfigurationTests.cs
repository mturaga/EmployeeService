using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmployeeService.UnitTests
{
    [TestClass]
    public class AutoMapperConfigurationTests
    {
        [TestMethod]
        public void AssertAutoMapperConfigurationIsValid()
        {
            var mapper = AutoMapperConfiguration.Configure();
            mapper.ConfigurationProvider.AssertConfigurationIsValid();
        }
    }
}
