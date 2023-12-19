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
    public class BandRepository : Repository<Band>, IRepository<Band>
    {
        public BandRepository(MusicDbContext ctx) : base(ctx)
        {

        }
        public override Band Read(int id)
        {
            return ctx.Bands.FirstOrDefault(x => x.BandId == id);
        }

        public override void Update(Band item)
        {
            var old = Read(item.BandId);
            old.BandName = item.BandName;
            old.Established = item.Established;
            old.ManagerId = item.ManagerId;
            old.Genre = item.Genre;
            old.Origin = item.Origin;
            ctx.SaveChanges();
        }
    }
}
