using SuperPoweredPeople.Data.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.IO.Abstractions;
using System.Linq;
using System.Threading.Tasks;

namespace SuperPoweredPeople.Data.Repositories
{
    public abstract class BaseFileRepository : IRepository
    {
        private readonly string path;
        private readonly IFileSystem fileSystem;

        public BaseFileRepository(string path, IFileSystem fileSystem)
        {
            if (string.IsNullOrEmpty(path?.Trim()))
                throw new ArgumentNullException(nameof(path));

            this.path = path;
            this.fileSystem = fileSystem ?? throw new ArgumentNullException(nameof(fileSystem));
        }

        public virtual Task AddAsync(IEnumerable<string> names)
        {
            if (names == null)
                throw new ArgumentNullException(nameof(names));
            else if (names.Count() > 0)
            {
                fileSystem.File.WriteAllLines(path, names);
            }

            return Task.FromResult(0);
        }

        public virtual Task<IEnumerable<string>> GetAsync()
        {
            return Task.FromResult(fileSystem.File.ReadLines(path));
        }
    }
}
