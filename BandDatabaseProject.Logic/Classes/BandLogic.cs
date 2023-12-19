using BandDatabaseProject.Client.Models;
using BandDatabaseProject.Logic.Interfaces;
using BandDatabaseProject.Repository.Interfaces;

namespace BandDatabaseProject.Logic
{
    public class BandLogic : IBandLogic
    {
        IRepository<Band> repo;
        public BandLogic(IRepository<Band> repo)
        {
            this.repo = repo;
        }

        public void Create(Band item)
        {
            if (item.BandName.Length < 2)
            {
                throw new ArgumentException("Name is too short");
            }

            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public IEnumerable<DiscInfo> Discografi(int id)
        {
            Band query = repo.ReadAll().First(x => x.BandId == id);

            var result = query.LongPlayings.Select(x => new DiscInfo
            {
                Year = x.ReleaseYear,
                BandName = query.BandName,
                LengthInMinute = x.LengthInMinute,
                LpName = x.LongPlayingName,
            }).OrderBy(x => x.Year);
            return result;

        }

        public int BestManagerId()
        {
            var query = repo.ReadAll();

            var result = query.GroupBy(x => x.ManagerId).Select(y => new {
                manegerId = y.Key,
                numberOfBands = y.Count()
            }).Max(x => x.numberOfBands);
            return result;

        }

        public IEnumerable<LongPlaying> LongestLP(int id)
        {
            return this.repo.Read(id).LongPlayings
                .Where(x => x.LengthInMinute == repo.Read(id).LongPlayings.Max(x => x.LengthInMinute));
        }

        public Band Read(int id)
        {
            var x = this.repo.Read(id);
            if (x == null)
            {
                throw new ArgumentException("Band not exists");
            }
            return x;
        }

        public IQueryable<Band> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Band item)
        {
            this.repo.Update(item);
        }

        public IEnumerable<YearlyRevenue> AllRevenueByYear(int id)
        {

            Band query;

            try
            {
                query = this.repo.Read(id);
            }
            catch (Exception)
            {

                throw new ArgumentException("There is no band with this id");

            }


            return query.LongPlayings.GroupBy(x => x.ReleaseYear)
                            .Select(x => new YearlyRevenue
                            {
                                Year = x.Key,
                                Revenue = x.Sum(x => x.Revenue)
                            })
                .Union(query.Concerts.GroupBy(x => x.ConcertDate.Year)
                            .Select(x => new YearlyRevenue
                            {
                                Year = x.Key,
                                Revenue = x.Sum(x => x.Revenue)
                            }))
                .GroupBy(x => x.Year)
                .Select(x => new YearlyRevenue
                {
                    Year = x.Key,
                    Revenue = x.Sum(x => x.Revenue)
                }).OrderBy(x => x.Year);
        }

        public Band OldestBand()
        {

            return repo.ReadAll().Where(x => x.Established.Year == (repo.ReadAll().Min(x => x.Established.Year))).OrderBy(x => x.Established).First();
        }

        public class DiscInfo
        {
            public string BandName { get; set; }
            public string LpName { get; set; }
            public int Year { get; set; }
            public int LengthInMinute { get; set; }

            public override bool Equals(object obj)
            {
                DiscInfo discInfo = obj as DiscInfo;

                if (discInfo == null)
                {
                    return false;
                }
                else
                {
                    return
                        this.BandName == discInfo.BandName &&
                        this.LpName == discInfo.LpName &&
                        this.Year == discInfo.Year &&
                        this.LengthInMinute == discInfo.LengthInMinute;

                }
            }
            public override int GetHashCode()
            {
                return HashCode.Combine(this.BandName, this.LpName, this.Year, this.LengthInMinute);
            }
        }
        public class YearlyRevenue
        {
            public int Year { get; set; }
            public double Revenue { get; set; }

            public override bool Equals(object obj)
            {
                YearlyRevenue yearlyRevenue = obj as YearlyRevenue;
                return
                    this.Revenue == yearlyRevenue.Revenue &&
                    this.Year == yearlyRevenue.Year;
            }
            public override int GetHashCode()
            {
                return HashCode.Combine(this.Revenue, this.Year);
            }



        }



    }
}
