using SuperPoweredPeople.Data.Repositories;

namespace SuperPoweredPeople.Data.UnitTests.RepositoryTests
{
    public class SuperHeroRepositoryTest : BaseRepositoryTest<SuperHeroFileRepository>
    {
        public SuperHeroRepositoryTest() :
            base((path, fileSystem) => new SuperHeroFileRepository(path, fileSystem))
        {
        }
    }
}
