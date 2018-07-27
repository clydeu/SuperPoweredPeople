using AutoFixture.Xunit2;
using FluentAssertions;
using Moq;
using SuperPoweredPeople.Data.IdentifierService.Interface;
using SuperPoweredPeople.Data.Repositories.Interface;
using SuperPoweredPeople.Data.UnitTests.TestData;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace SuperPoweredPeople.Data.UnitTests.IdentifierServiceTests
{
    public abstract class BaseIdentifierServiceTest<T, TRepository> where T : IIdentifierService 
                                                           where TRepository : class, IRepository
    {
        protected readonly Func<TRepository, T> creator;
        protected readonly Mock<TRepository> repositoryMock;
        protected readonly T identifier;

        public BaseIdentifierServiceTest(Func<TRepository, T> creator)
        {
            this.creator = creator;
            repositoryMock = new Mock<TRepository>();
            identifier = creator(repositoryMock.Object);
        }

        [Fact]
        public void Constructor_Should_Throw_ArgumentNullException()
        {
            Action act = () => creator(null);

            act.Should().ThrowExactly<ArgumentNullException>().Which.ParamName.Should().Be("repository");
        }

        [Theory]
        [MemberData(nameof(IdentifierTestData.GetAddDataParameters),
            MemberType = typeof(IdentifierTestData))]
        public void Add_Should_Throw_ArgumentNullException(string name)
        {
            Action act = () => identifier.Add(name);

            act.Should().ThrowExactly<ArgumentNullException>().Which.ParamName.Should().Be("name");
        }

        [Theory]
        [AutoData]
        public void Add_Should_Work_As_Expected(string name)
        {
            identifier.Add(name);

            identifier.Names.Should().NotBeNullOrEmpty();
        }

        [Theory]
        [MemberData(nameof(IdentifierTestData.GetIsMatchParameters),
            MemberType = typeof(IdentifierTestData))]
        public void IsMatch_Should_Throw_ArgumentNullException(string name)
        {
            Action act = () => identifier.IsMatch(name);

            act.Should().ThrowExactly<ArgumentNullException>().Which.ParamName.Should().Be("name");
        }

        [Theory]
        [AutoData]
        public async Task Save_Should_Persist_Data_To_Repository(string name)
        {
            identifier.Add(name);
            repositoryMock.Setup(x => x.AddAsync(identifier.Names)).Returns(Task.FromResult(0));
            
            await identifier.Save();

            repositoryMock.Verify(x => x.AddAsync(identifier.Names), Times.Once());
        }

        [Theory]
        [AutoData]
        public async Task Save_Should_Not_Persist_Data_To_Repository_When_Names_Collection_Is_Empty(string name)
        {
            await identifier.Save();

            repositoryMock.Verify(x => x.AddAsync(It.IsAny<IEnumerable<string>>()), Times.Never());
        }
    }
}
