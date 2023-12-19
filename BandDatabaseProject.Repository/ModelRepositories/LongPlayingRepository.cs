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
    public class LongPlayingRepository : Repository<LongPlaying>, IRepository<LongPlaying>
    {
        public LongPlayingRepository(MusicDbContext ctx) : base(ctx)
        {

        }
        public override LongPlaying Read(int id)
        {
            return ctx.LongPlayings.FirstOrDefault(x => x.LongPlayingId == id);
        }

        public override void Update(LongPlaying item)
        {

            var old = Read(item.LongPlayingId);
            old.LongPlayingName = item.LongPlayingName;
            old.LengthInMinute = item.LengthInMinute;
            old.ReleaseYear = item.ReleaseYear;
            old.SoldCopies = item.SoldCopies;
            old.Price = item.Price;
            old.BandId = item.BandId;
            ctx.SaveChanges();
        }
    }
}
