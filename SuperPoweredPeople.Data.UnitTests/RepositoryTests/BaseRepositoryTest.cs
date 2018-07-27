using FluentAssertions;
using Moq;
using SuperPoweredPeople.Data.Repositories.Interface;
using SuperPoweredPeople.Data.UnitTests.TestData;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Abstractions;
using System.Threading.Tasks;
using Xunit;

namespace SuperPoweredPeople.Data.UnitTests.RepositoryTests
{
    public abstract class BaseRepositoryTest<T> where T : IRepository
    {
        protected Mock<FileBase> fileMock;
        protected Mock<IFileSystem> fileSystemMock;
        protected string path;
        protected T repo;
        protected readonly Func<string, IFileSystem, T> creator;

        public BaseRepositoryTest(Func<string, IFileSystem, T> creator)
        {
            path = @"C:\Tests\REGISTRADO.DAT";
            fileMock = new Mock<FileBase>();
            fileMock.Setup(x => x.Exists(path)).Returns(true);
            fileSystemMock = new Mock<IFileSystem>();
            fileSystemMock.SetupGet(x => x.File).Returns(fileMock.Object);
            repo = creator(path, fileSystemMock.Object);
            this.creator = creator;
        }

        [Theory]
        [MemberData(nameof(RepositoryTestData.GetConstructorDataParameters),
            MemberType = typeof(RepositoryTestData))]
        public virtual void Constructor_Should_Throw_ArgumentNullException_When_Parameter_Is_Null(string path,
            Mock<IFileSystem> mockedFileSytem, string paramName)
        {
            Action act = () => creator(path, mockedFileSytem?.Object);

            act.Should().ThrowExactly<ArgumentNullException>().Which.ParamName.Should().Be(paramName);
        }

        [Fact]
        public void AddAsync_Should_Throw_ArgumentNullException_When_Names_Is_Null()
        {
            Action act = () => repo.AddAsync(null);

            act.Should().ThrowExactly<ArgumentNullException>().Which.ParamName.Should().Be("names");
        }

        [Theory]
        [MemberData(nameof(RepositoryTestData.GetAddAsyncDataParameters),
            MemberType = typeof(RepositoryTestData))]
        public async Task AddAsync_Should_Behave_As_Expected(IEnumerable<string> names, Times expectedCall)
        {
            fileMock.Setup(x => x.WriteAllLines(path, names));
            
            await repo.AddAsync(names);

            fileMock.Verify(x => x.WriteAllLines(path, names), expectedCall);
        }

        [Theory]
        [MemberData(nameof(RepositoryTestData.GetGetAsyncDataParameters),
            MemberType = typeof(RepositoryTestData))]
        public async Task GetAsync_Should_Behave_As_Expected(IEnumerable<string> names, Times expectedCall)
        {
            fileMock.Setup(x => x.ReadLines(path)).Returns(names);
            
            var result = await repo.GetAsync();

            fileMock.Verify(x => x.ReadLines(path), expectedCall);
            result.Should().BeEquivalentTo(names);
        }
    }
}
