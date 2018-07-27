using SuperPoweredPeople.Data.Repositories.Interface;
using System.IO.Abstractions;

namespace SuperPoweredPeople.Data.Repositories
{
    public class VillainFileRepository : BaseFileRepository, IVillainRepository
    {
        public VillainFileRepository(string path, IFileSystem fileSystem) : base(path, fileSystem)
        {
        }
    }
}
