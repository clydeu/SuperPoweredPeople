using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using SuperPoweredPeople.Data;
using SuperPoweredPeople.Data.IdentifierService;
using SuperPoweredPeople.Data.IdentifierService.Interface;
using SuperPoweredPeople.Data.Repositories;
using SuperPoweredPeople.Data.Repositories.Interface;
using SuperPoweredPeople.Services;
using SuperPoweredPeople.Services.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Abstractions;

namespace SuperPoweredPeople
{
    public class Startup
    {
        //This path works for now when playing the project from VS
        protected virtual string DataPath => "~/../../Resources";
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            var fileSystem = new FileSystem();
            services.AddTransient<IAllSuperPoweredRepository>(s => 
                new AllSuperPoweredFileRepository(Path.Combine(DataPath, "RESGISTRADOS.DAT"), fileSystem));
            services.AddTransient<ISuperHeroRepository>(x => 
                new SuperHeroFileRepository(Path.Combine(DataPath, "SuperHeroes.DAT"), fileSystem));
            services.AddTransient<IVillainRepository>(x => 
                new VillainFileRepository(Path.Combine(DataPath, "Villains.DAT"), fileSystem));
            services.AddTransient<SuperHeroIdentifierService>();
            services.AddTransient<VillainIdentifierService>();
            services.AddTransient<ILogger, Logger>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public async void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            try
            {
                app.ApplicationServices.GetService<ILogger>()?.TrackEvent(nameof(SuperPoweredPeopleData.SplitSuperPoweredPeople));
                await SuperPoweredPeopleData.SplitSuperPoweredPeople(
                    app.ApplicationServices.GetService<IAllSuperPoweredRepository>(),
                    new List<IIdentifierService>
                    {
                        app.ApplicationServices.GetService<SuperHeroIdentifierService>(),
                        app.ApplicationServices.GetService<VillainIdentifierService>()
                    });
            }
            catch (Exception ex)
            {
                app.ApplicationServices.GetService<ILogger>()?.TrackError(ex);
                throw;
            }
        }
    }
}
