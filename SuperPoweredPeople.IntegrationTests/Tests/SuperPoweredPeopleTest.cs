using FluentAssertions;
using SuperPoweredPeople.IntegrationTests.Setup;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace SuperPoweredPeople.IntegrationTests.Tests
{
    public class SuperPoweredPeopleTest : BaseTest
    {
        [Fact]
        public async Task GetAllSuperPoweredPeople()
        {
            var expected = File.ReadAllLines(Path.Combine(DataPath, "RESGISTRADOS.DAT")).AsEnumerable();
            var result = await restService.GetAllSuperPoweredPeople();

            result.Should().NotBeEmpty();
            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public async Task GetAllSuperHeroes()
        {
            var expected = File.ReadAllLines(Path.Combine(DataPath, "SuperHeroes.DAT")).AsEnumerable();
            var result = await restService.GetAllSuperHero();

            result.Should().NotBeEmpty();
            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public async Task GetAllVillains()
        {
            var expected = File.ReadAllLines(Path.Combine(DataPath, "Villains.DAT")).AsEnumerable();
            var result = await restService.GetAllVillain();

            result.Should().NotBeEmpty();
            result.Should().BeEquivalentTo(expected);
        }
    }
}
