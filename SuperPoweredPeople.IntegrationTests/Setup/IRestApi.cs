using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuperPoweredPeople.IntegrationTests.Setup
{
    public interface IRestApi
    {
        [Get("")]
        Task<IEnumerable<string>> GetAllSuperPoweredPeople();
        [Get("/superhero")]
        Task<IEnumerable<string>> GetAllSuperHero();
        [Get("/villain")]
        Task<IEnumerable<string>> GetAllVillain();
    }
}
