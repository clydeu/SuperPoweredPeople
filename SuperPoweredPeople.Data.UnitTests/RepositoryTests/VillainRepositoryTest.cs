using SuperPoweredPeople.Data.Repositories;

namespace SuperPoweredPeople.Data.UnitTests.RepositoryTests
{
    public class VillainRepositoryTest : BaseRepositoryTest<VillainFileRepository>
    {
        public VillainRepositoryTest() :
            base((path, fileSystem) => new VillainFileRepository(path, fileSystem))
        {
        }
    }
}
