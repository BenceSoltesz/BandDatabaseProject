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
    public class VenueLogic : IVenueLogic
    {
        IRepository<Venue> repo;
        public VenueLogic(IRepository<Venue> repo)
        {
            this.repo = repo;
        }
        public void Create(Venue item)
        {           
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Venue Read(int id)
        {
            var x = this.repo.Read(id);
            if (x == null)
            {
                throw new ArgumentException("Concert not exists");
            }
            return x;
        }

        public IQueryable<Venue> ReadAll()
        {
            return this.repo.ReadAll();
        }


        public void Update(Venue item)
        {
            this.repo.Update(item);
        }

        public IEnumerable<ConcertInfo> AllConcert(int id)
        {

            var result = repo.Read(id)
                .Concerts
                .Select(x => new ConcertInfo
                {
                    Year = x.ConcertDate.Year,
                    BandName = x.Band.BandName,
                    ConcertName = x.ConcertName,
                    VenueName = x.Venue.VenueName
                });
            return result.OrderBy(x => x.Year);
        }
        public class ConcertInfo
        {

            public int Year;
            public string BandName;
            public string VenueName;
            public string ConcertName;

            public override bool Equals(object obj)
            {
                ConcertInfo yearInfo = obj as ConcertInfo;
                if (yearInfo == null)
                {
                    return false;
                }
                else
                {
                    return this.Year == yearInfo.Year &&
                            this.VenueName == yearInfo.VenueName &&
                            this.ConcertName == yearInfo.ConcertName &&
                            this.BandName == yearInfo.BandName;
                }
            }

            public override int GetHashCode()
            {
                return HashCode.Combine(this.Year, this.VenueName, this.BandName, this.ConcertName);
            }

        }
    }
}
