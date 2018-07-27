using FluentAssertions;
using Moq;
using SuperPoweredPeople.Data.Repositories;
using System;
using System.IO;
using Xunit;

namespace SuperPoweredPeople.Data.UnitTests.RepositoryTests
{
    public class AllSuperPoweredRepositoryTest : BaseRepositoryTest<AllSuperPoweredFileRepository>
    {
        public AllSuperPoweredRepositoryTest() : 
            base((path, fileSystem) => new AllSuperPoweredFileRepository(path, fileSystem))
        {
        }

        [Fact]
        public void Constructor_Should_Throw_FileNotFoundException_When_Path_Is_Not_Found()
        {
            fileMock.Setup(x => x.Exists(path)).Returns(false);

            Action act = () => new AllSuperPoweredFileRepository(path, fileSystemMock.Object);

            var exception = act.Should().ThrowExactly<FileNotFoundException>().Which;
            exception.Message.Should().Be(path);
            fileMock.Verify(x => x.Exists(path), Times.AtLeastOnce());
        }
    }
}
