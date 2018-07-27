using AutoFixture;
using Moq;
using System.Collections.Generic;
using System.IO.Abstractions;
using System.Linq;

namespace SuperPoweredPeople.Data.UnitTests.TestData
{
    public class RepositoryTestData
    {
        public static IEnumerable<object[]> GetConstructorDataParameters()
        {
            var fileSystemMocked = new Mock<IFileSystem>();
            yield return new object[] { null, fileSystemMocked, "path" };
            yield return new object[] { string.Empty, fileSystemMocked, "path" };
            yield return new object[] { "      ", fileSystemMocked, "path" };
            yield return new object[] { @"C:\Tests\REGISTRADO.DAT", null, "fileSystem" };
        }

        public static IEnumerable<object[]> GetAddAsyncDataParameters()
        {
            yield return new object[] { Enumerable.Empty<string>(), Times.Never() };
            yield return new object[] { new Fixture().CreateMany<string>(5), Times.Once() };
        }

        public static IEnumerable<object[]> GetGetAsyncDataParameters()
        {
            yield return new object[] { Enumerable.Empty<string>(), Times.Once() };
            yield return new object[] { new Fixture().CreateMany<string>(5), Times.Once() };
        }
    }
 }
