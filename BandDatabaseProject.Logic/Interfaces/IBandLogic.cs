using BandDatabaseProject.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BandDatabaseProject.Logic.BandLogic;

namespace BandDatabaseProject.Logic.Interfaces
{
    public interface IBandLogic
    {

        public void Create(Band item);
        public void Delete(int id);
        public Band Read(int id);
        public IQueryable<Band> ReadAll();
        public void Update(Band item);

        public IEnumerable<LongPlaying> LongestLP(int id);
        public IEnumerable<YearlyRevenue> AllRevenueByYear(int id);
        public IEnumerable<DiscInfo> Discografi(int id);
        public Band OldestBand();

    }
}
