using BandDatabaseProject.Client.Models;
using BandDatabaseProject.Repository.GenericRepository;
using BandDatabaseProject.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BandDatabaseProject.Repository.ModelRepositories
{
    public class VenueRepository : Repository<Venue>, IRepository<Venue>
    {

        public VenueRepository(MusicDbContext ctx) : base(ctx)
        {

        }

        public override Venue Read(int id)
        {
            return ctx.Venues.FirstOrDefault(x => x.VenueId == id);
        }

        public override void Update(Venue item)
        {
            var old = Read(item.VenueId);
            old.VenueName = item.VenueName;
            old.Room = item.Room;
            ctx.SaveChanges();
        }
    }
}
