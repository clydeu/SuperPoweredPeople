using FluentAssertions;
using SuperPoweredPeople.Data.IdentifierService;
using SuperPoweredPeople.Data.Repositories.Interface;
using SuperPoweredPeople.Data.UnitTests.TestData;
using Xunit;

namespace SuperPoweredPeople.Data.UnitTests.IdentifierServiceTests
{
    public class SuperHeroIdentifierServiceTest : BaseIdentifierServiceTest<SuperHeroIdentifierService, ISuperHeroRepository>
    {
        public SuperHeroIdentifierServiceTest() : 
            base(repo => new SuperHeroIdentifierService(repo))
        {
        }

        [Theory]
        [MemberData(nameof(IdentifierTestData.GetSuperHeroIsMatchTrue),
            MemberType = typeof(IdentifierTestData))]
        public void IsMatch_Should_Return_True(string name)
        {
            var result = identifier.IsMatch(name);

            result.Should().BeTrue();
        }

        [Theory]
        [MemberData(nameof(IdentifierTestData.GetSuperHeroIsMatchFalse),
            MemberType = typeof(IdentifierTestData))]
        public void IsMatch_Should_Return_False(string name)
        {
            var result = identifier.IsMatch(name);

            result.Should().BeFalse();
        }
    }
}
