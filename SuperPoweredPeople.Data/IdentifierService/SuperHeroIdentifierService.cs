using SuperPoweredPeople.Data.Repositories.Interface;
using System;

namespace SuperPoweredPeople.Data.IdentifierService
{
    public class SuperHeroIdentifierService : BaseIdentifierService
    {
        public SuperHeroIdentifierService(ISuperHeroRepository repository) : base (repository)
        {
        }

        public override bool IsMatch(string name)
        {
            if (string.IsNullOrEmpty(name?.Trim()))
                throw new ArgumentNullException(nameof(name));

            var result = false;
            if (name.IndexOf("d", StringComparison.OrdinalIgnoreCase) < 0)
            {
                result = true;
            }

            return result;
        }
    }
}
