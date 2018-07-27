using SuperPoweredPeople.Data.Repositories.Interface;
using System.IO;
using System.IO.Abstractions;

namespace SuperPoweredPeople.Data.Repositories
{
    public class AllSuperPoweredFileRepository : BaseFileRepository, IAllSuperPoweredRepository
    {
        public AllSuperPoweredFileRepository(string path, IFileSystem fileSystem) : base(path, fileSystem)
        {
            if (!fileSystem.File.Exists(path))
                throw new FileNotFoundException(path);
        }
    }
}
