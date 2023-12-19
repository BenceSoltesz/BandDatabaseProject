using BandDatabaseProject.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BandDatabaseProject.Logic.Interfaces
{
    public interface IConcertLogic
    {

        void Create(Concert item);
        void Delete(int id);
        Concert Read(int id);
        IQueryable<Concert> ReadAll();
        void Update(Concert item);
    }
}
