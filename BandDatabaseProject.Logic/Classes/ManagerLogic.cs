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
    public class ManagerLogic : IManagerLogic
    {
        IRepository<Manager> repo;
        public ManagerLogic(IRepository<Manager> repo)
        {
            this.repo = repo;
        }
        public void Create(Manager item)
        {
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Manager Read(int id)
        {
            var x = this.repo.Read(id);
            if (x == null)
            {
                throw new ArgumentException("Manager not exists");
            }
            return x;
        }

        public IQueryable<Manager> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Manager item)
        {
            this.repo.Update(item);
        }

        public IEnumerable<Manager> MostProductive()
        {

            //return repo.ReadAll().Where(x => x.ManagedBands.Count() == repo.ReadAll().Select(x => new {
            //    BandCount = x.ManagedBands.Count
            //    }).Max(x=>x.BandCount));

            var result = repo.ReadAll()
                 .GroupBy(x => x.ManagerId)
                 .Select(x => new {
                     managerId = x.Key,
                     allConcert = repo.Read(x.Key).ManagedBands.Sum(x => x.Concerts.Count)
                 }
                 ).Where(x => x.allConcert == (repo.ReadAll()
                                                     .GroupBy(x => x.ManagerId)
                                                     .Select(x => new {
                                                         managerId = x.Key,
                                                         allConcert = repo.Read(x.Key).ManagedBands.Sum(x => x.Concerts.Count)
                                                     }).Max(x => x.allConcert)));

            List<Manager> returnList = new List<Manager>();
            foreach (var x in result)
            {
                returnList.Add(repo.Read(x.managerId));
            }

            return returnList;


        }
    }
}
