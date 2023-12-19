using BandDatabaseProject.Client.Models;
using BandDatabaseProject.Logic.Interfaces;
using BandDatabaseProject.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BandDatabaseProject.Logic.Classes
{
    public class LongPlayingLogic : ILongPlayingLogic
    {

        IRepository<LongPlaying> repo;
        public LongPlayingLogic(IRepository<LongPlaying> repo)
        {
            this.repo = repo;
        }

        public void Create(LongPlaying item)
        {
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public LongPlaying Read(int id)
        {
            var x = this.repo.Read(id);
            if (x == null)
            {
                throw new ArgumentException("LP not exists");
            }
            return x;
        }

        public IQueryable<LongPlaying> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(LongPlaying item)
        {
            this.repo.Update(item);
        }
    }
}
