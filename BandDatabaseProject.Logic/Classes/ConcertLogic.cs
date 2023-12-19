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
    public class ConcertLogic : IConcertLogic
    {

        IRepository<Concert> repo;
        public ConcertLogic(IRepository<Concert> repo)
        {
            this.repo = repo;
        }

        public void Create(Concert item)
        {
            if (item.SoldTickets < 0)
            {
                throw new ArgumentException("Sold tickets cannot bellow zero");
            }
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Concert Read(int id)
        {
            var x = this.repo.Read(id);
            if (x == null)
            {
                throw new ArgumentException("Concert not exists");
            }
            return x;
        }

        public IQueryable<Concert> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Concert item)
        {
            this.repo.Update(item);
        }
    }
}
