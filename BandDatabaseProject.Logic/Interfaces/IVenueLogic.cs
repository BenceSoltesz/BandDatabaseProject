using BandDatabaseProject.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BandDatabaseProject.Logic.Interfaces
{
    public interface IVenueLogic
    {
        void Create(Venue item);
        void Delete(int id);
        Venue Read(int id);
        IQueryable<Venue> ReadAll();
        void Update(Venue item);
    }

}
