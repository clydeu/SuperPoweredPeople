using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuperPoweredPeople.Data.Repositories.Interface
{
    public interface IRepository
    {
        Task<IEnumerable<string>> GetAsync();
        Task AddAsync(IEnumerable<string> names);
    }
}
