using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuperPoweredPeople.Data.IdentifierService.Interface
{
    public interface IIdentifierService
    {
        IEnumerable<string> Names { get; }
        bool IsMatch(string name);
        void Add(string name);
        Task Save();
    }
}
