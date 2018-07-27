using SuperPoweredPeople.Data.Repositories.Interface;
using System.IO.Abstractions;

namespace SuperPoweredPeople.Data.Repositories
{
    public class SuperHeroFileRepository : BaseFileRepository, ISuperHeroRepository
    {
        public SuperHeroFileRepository(string path, IFileSystem fileSystem) : base(path, fileSystem)
        {
        }
    }
}
