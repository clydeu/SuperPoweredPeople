using SuperPoweredPeople.Data.IdentifierService.Interface;
using SuperPoweredPeople.Data.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuperPoweredPeople.Data.IdentifierService
{
    public abstract class BaseIdentifierService : IIdentifierService
    {
        private List<string> names = new List<string>();
        public IEnumerable<string> Names => names;
        private readonly IRepository repository;

        public BaseIdentifierService(IRepository repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public virtual void Add(string name)
        {
            if (string.IsNullOrEmpty(name?.Trim()))
                throw new ArgumentNullException(nameof(name));

            names.Add(name);
        }

        public abstract bool IsMatch(string name);

        public virtual async Task Save()
        {
            if (names.Count > 0)
            {
                await repository.AddAsync(Names);
            }
        }
    }
}
