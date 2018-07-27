using Microsoft.AspNetCore.Mvc;
using SuperPoweredPeople.Data.Repositories.Interface;
using SuperPoweredPeople.Services.Interface;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace SuperPoweredPeople.Controllers
{
    //[Route("[controller]")]
    public class SuperPoweredPeopleController : ApiController
    {
        private readonly IAllSuperPoweredRepository allRepo;
        private readonly ISuperHeroRepository heroRepo;
        private readonly IVillainRepository villainRepo;
        private readonly ILogger logger;

        public SuperPoweredPeopleController(IAllSuperPoweredRepository allRepo, 
            ISuperHeroRepository heroRepo, IVillainRepository villainRepo, ILogger logger)
        {
            this.allRepo = allRepo;
            this.heroRepo = heroRepo;
            this.villainRepo = villainRepo;
            this.logger = logger;
        }

        [Route("")]
        [HttpGet]
        public async Task<IActionResult> GetAllSuperPoweredPeople()
        {
            try
            {
                logger.TrackEvent(nameof(GetAllSuperPoweredPeople));
                return Ok(await allRepo.GetAsync());
            }
            catch(Exception ex)
            {
                logger.TrackError(ex);
                return InternalServerError(ex);
            }
        }

        [Route("superhero")]
        [HttpGet]
        public async Task<IActionResult> GetAllSuperHeroPeople()
        {
            try
            {
                logger.TrackEvent(nameof(GetAllSuperHeroPeople));
                return Ok(await heroRepo.GetAsync());
            }
            catch (Exception ex)
            {
                logger.TrackError(ex);
                return InternalServerError(ex);
            }
        }

        [Route("villain")]
        [HttpGet]
        public async Task<IActionResult> GetAllVillainPeople()
        {
            try
            {
                logger.TrackEvent(nameof(GetAllVillainPeople));
                return Ok(await villainRepo.GetAsync());
            }
            catch (Exception ex)
            {
                logger.TrackError(ex);
                return InternalServerError(ex);
            }
        }
    }
}
