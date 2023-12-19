using BandDatabaseProject.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BandDatabaseProject.Logic.Interfaces
{
    public interface IManagerLogic
    {
        public void Create(Manager item);
        public void Delete(int id);
        public Manager Read(int id);
        public IQueryable<Manager> ReadAll();
        public void Update(Manager item);

        public IEnumerable<Manager> MostProductive();
    }
}
