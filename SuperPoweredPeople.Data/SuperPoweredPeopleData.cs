using SuperPoweredPeople.Data.IdentifierService.Interface;
using SuperPoweredPeople.Data.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperPoweredPeople.Data
{
    public static class SuperPoweredPeopleData
    {
        public static async Task SplitSuperPoweredPeople(IAllSuperPoweredRepository repo, 
            IEnumerable<IIdentifierService> identifierServices)
        {
            if (repo == null)
                throw new ArgumentNullException(nameof(repo));
            else if (identifierServices == null)
                throw new ArgumentNullException(nameof(identifierServices));
            else if (identifierServices.Count() == 0)
                throw new ArgumentException("Service collection must not be empty.", nameof(identifierServices));

            var names = await repo.GetAsync();
            if (names.Count() > 0)
            {
                foreach (var name in names)
                {
                    identifierServices.FirstOrDefault(x => x.IsMatch(name)).Add(name);
                }

                foreach (var service in identifierServices)
                {
                    await service.Save();
                }
            }
        }
    }
}
