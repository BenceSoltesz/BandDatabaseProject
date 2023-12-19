using BandDatabaseProject.Client.Models;
using BandDatabaseProject.Logic.Classes;
using BandDatabaseProject.Logic.Interfaces;
using BandDatabaseProject.Logic;
using BandDatabaseProject.Repository.Interfaces;
using BandDatabaseProject.Repository.ModelRepositories;
using BandDatabaseProject.Repository;
using Microsoft.OpenApi.Models;

namespace BandDatabaseProject.Endpoint
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddTransient<MusicDbContext>();

            services.AddTransient<IRepository<Band>, BandRepository>();
            services.AddTransient<IRepository<Concert>, ConcertRepository>();
            services.AddTransient<IRepository<Manager>, ManagerRepository>();
            services.AddTransient<IRepository<Venue>, VenueRepository>();
            services.AddTransient<IRepository<LongPlaying>, LongPlayingRepository>();


            services.AddTransient<IBandLogic, BandLogic>();
            services.AddTransient<IConcertLogic, ConcertLogic>();
            services.AddTransient<IManagerLogic, ManagerLogic>();
            services.AddTransient<IVenueLogic, VenueLogic>();
            services.AddTransient<ILongPlayingLogic, LongPlayingLogic>();


            services.AddControllers();
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "P0SPO9_HFT_2023241.Endpoint", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "P0SPO9_HFT_2023241.Endpoint v1"));

            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });
        }
    }
}
