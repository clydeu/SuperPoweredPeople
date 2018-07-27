using Moq;
using SuperPoweredPeople.Data.IdentifierService.Interface;
using SuperPoweredPeople.Data.Repositories.Interface;
using System.Collections.Generic;

namespace SuperPoweredPeople.Data.UnitTests.TestData
{
    public class SuperPoweredDataTestData
    {
        public static IEnumerable<object[]> GetConstructorArgumentNullExceptionDataParameters()
        {
            var repoMock = new Mock<IAllSuperPoweredRepository>();
            var identifierService1 = new Mock<IIdentifierService>();
            var identifierService2 = new Mock<IIdentifierService>();
            var identifierServices = new List<Mock<IIdentifierService>>
            {
                identifierService1, identifierService2
            };
            yield return new object[] { null, identifierServices, "repo" };
            yield return new object[] { repoMock, null, "identifierServices" };
        }
    }
}
