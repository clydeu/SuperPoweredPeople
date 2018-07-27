using FluentAssertions;
using SuperPoweredPeople.Data.IdentifierService;
using SuperPoweredPeople.Data.Repositories.Interface;
using SuperPoweredPeople.Data.UnitTests.TestData;
using Xunit;

namespace SuperPoweredPeople.Data.UnitTests.IdentifierServiceTests
{
    public class VillainIdentifierServiceTest : BaseIdentifierServiceTest<VillainIdentifierService, IVillainRepository>
    {
        public VillainIdentifierServiceTest() :
            base(repo => new VillainIdentifierService(repo))
        {
        }

        [Theory]
        [MemberData(nameof(IdentifierTestData.GetVillainIsMatchTrue),
            MemberType = typeof(IdentifierTestData))]
        public void IsMatch_Should_Return_True(string name)
        {
            var result = identifier.IsMatch(name);

            result.Should().BeTrue();
        }

        [Theory]
        [MemberData(nameof(IdentifierTestData.GetVillainIsMatchFalse),
            MemberType = typeof(IdentifierTestData))]
        public void IsMatch_Should_Return_False(string name)
        {
            var result = identifier.IsMatch(name);

            result.Should().BeFalse();
        }
    }
}
