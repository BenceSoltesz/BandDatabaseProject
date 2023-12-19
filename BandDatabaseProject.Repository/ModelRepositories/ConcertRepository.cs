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
    public class ConcertRepository : Repository<Concert>, IRepository<Concert>
    {
        public ConcertRepository(MusicDbContext ctx) : base(ctx)
        {

        }
        public override Concert Read(int id)
        {
            return ctx.Concerts.FirstOrDefault(x => x.ConcertId == id);
        }

        public override void Update(Concert item)
        {

            var old = Read(item.ConcertId);
            old.ConcertName = item.ConcertName;
            old.BandId = item.BandId;
            old.TicketPrice = item.TicketPrice;
            old.SoldTickets = item.SoldTickets;
            old.VenueId = item.VenueId;
            ctx.SaveChanges();
        }
    }
}
