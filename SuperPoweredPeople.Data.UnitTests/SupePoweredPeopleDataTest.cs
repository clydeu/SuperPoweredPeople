using AutoFixture.Xunit2;
using FluentAssertions;
using Moq;
using SuperPoweredPeople.Data.IdentifierService.Interface;
using SuperPoweredPeople.Data.Repositories.Interface;
using SuperPoweredPeople.Data.UnitTests.TestData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace SuperPoweredPeople.Data.UnitTests
{
    public class SupePoweredPeopleDataTest
    {
        [Theory]
        [MemberData(nameof(SuperPoweredDataTestData.GetConstructorArgumentNullExceptionDataParameters),
            MemberType = typeof(SuperPoweredDataTestData))]
        public void SplitSuperPoweredPeople_Should_Throw_ArgumentNullException(
            Mock<IAllSuperPoweredRepository> repoMock,
            IEnumerable<Mock<IIdentifierService>> identifierServicesMock, string paramName)
        {
            Func<Task> act = async () => await SuperPoweredPeopleData.SplitSuperPoweredPeople(repoMock?.Object,
                identifierServicesMock?.Select(x => x.Object));

            act.Should().ThrowExactly<ArgumentNullException>().Which.ParamName.Should().Be(paramName);
        }

        [Fact]
        public void SplitSuperPoweredPeople_Should_Throw_ArgumentException()
        {
            var repoMock = new Mock<IAllSuperPoweredRepository>();
            Func<Task> act = async () => await SuperPoweredPeopleData.SplitSuperPoweredPeople(repoMock.Object,
                Enumerable.Empty<IIdentifierService>());

            var exception = act.Should().ThrowExactly<ArgumentException>().Which;
            exception.Message.Should().Be("Service collection must not be empty.\r\nParameter name: identifierServices");
        }

        [Theory]
        [AutoData]
        public async Task SplitSuperPoweredPeople_Should_Work_As_Expected(IEnumerable<string> names)
        {
            var repoMock = new Mock<IAllSuperPoweredRepository>();
            repoMock.Setup(x => x.GetAsync()).Returns(Task.FromResult(names));
            var identifierService1 = new Mock<IIdentifierService>();
            identifierService1.Setup(x => x.IsMatch(It.IsAny<string>())).Returns(false);
            var identifierService2 = new Mock<IIdentifierService>();
            identifierService2.Setup(x => x.IsMatch(It.IsAny<string>())).Returns(true);
            var identifierServices = new List<IIdentifierService>
            {
                identifierService1.Object, identifierService2.Object
            };

            await SuperPoweredPeopleData.SplitSuperPoweredPeople(repoMock.Object, identifierServices);

            var namesCount = names.Count();
            repoMock.Verify(x => x.GetAsync(), Times.Once());
            identifierService1.Verify(x => x.IsMatch(It.IsAny<string>()), Times.Exactly(namesCount));
            identifierService1.Verify(x => x.Save(), Times.Once());
            identifierService2.Verify(x => x.IsMatch(It.IsAny<string>()), Times.Exactly(namesCount));
            identifierService2.Verify(x => x.Add(It.IsAny<string>()), Times.Exactly(namesCount));
            identifierService2.Verify(x => x.Save(), Times.Once());
        }

        [Fact]
        public async Task SplitSuperPoweredPeople_Should_Not_Throw_Exception_When_Names_Is_Empty()
        {
            var repoMock = new Mock<IAllSuperPoweredRepository>();
            repoMock.Setup(x => x.GetAsync()).Returns(Task.FromResult(Enumerable.Empty<string>()));
            var identifierService1 = new Mock<IIdentifierService>();
            identifierService1.Setup(x => x.IsMatch(It.IsAny<string>())).Returns(false);
            var identifierService2 = new Mock<IIdentifierService>();
            identifierService2.Setup(x => x.IsMatch(It.IsAny<string>())).Returns(true);
            var identifierServices = new List<IIdentifierService>
            {
                identifierService1.Object, identifierService2.Object
            };

            await SuperPoweredPeopleData.SplitSuperPoweredPeople(repoMock.Object, identifierServices);

            repoMock.Verify(x => x.GetAsync(), Times.Once());
            identifierService1.Verify(x => x.IsMatch(It.IsAny<string>()), Times.Never());
            identifierService1.Verify(x => x.Add(It.IsAny<string>()), Times.Never());
            identifierService1.Verify(x => x.Save(), Times.Never());
            identifierService2.Verify(x => x.IsMatch(It.IsAny<string>()), Times.Never());
            identifierService2.Verify(x => x.Add(It.IsAny<string>()), Times.Never());
            identifierService2.Verify(x => x.Save(), Times.Never());
        }
    }
}
