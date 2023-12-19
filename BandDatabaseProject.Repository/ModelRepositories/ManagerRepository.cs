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
    public class ManagerRepository : Repository<Manager>, IRepository<Manager>
    {
        public ManagerRepository(MusicDbContext ctx) : base(ctx)
        {

        }
        public override Manager Read(int id)
        {
            return ctx.Managers.FirstOrDefault(x => x.ManagerId == id);
        }

        public override void Update(Manager item)
        {

            var old = Read(item.ManagerId);
            old.ManagerName = item.ManagerName;
            ctx.SaveChanges();
        }
    }
}
