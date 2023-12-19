using BandDatabaseProject.Client.Models;
using BandDatabaseProject.Logic.Classes;
using BandDatabaseProject.Logic;
using BandDatabaseProject.Repository.Interfaces;
using Moq;
using NUnit.Framework;
using static BandDatabaseProject.Logic.BandLogic;
using static BandDatabaseProject.Logic.Classes.VenueLogic;

namespace BandDatabaseProject.Test
{
    [TestFixture]
    public class TesterClass
    {
        BandLogic mockBandLogic;
        ConcertLogic mockConcertLogic;
        LongPlayingLogic mockLongPlayingLogic;
        ManagerLogic mockManagerLogic;
        VenueLogic mockVenueLogic;

        Mock<IRepository<Band>> mockBandRepo;
        Mock<IRepository<Concert>> mockConcertRepo;
        Mock<IRepository<LongPlaying>> mockLongPlayingRepo;
        Mock<IRepository<Manager>> mockManagerRepo;
        Mock<IRepository<Venue>> mockVenueRepo;

        [SetUp]
        public void Init()
        {

            var bandList = new List<Band>() {
                new Band("1#Tankcsapda#Rock#Hungary#1#1990-01-01"),
                new Band("2#Guns'n'Roses#Rock#USA#2#1980-07-05"),
                new Band("3#Paddy And The Rats#Folk Metal#Hungary#3#2001-03-14"),
                new Band("4#Daft Punk#Electronic#France#1#2002-10-23"),
                new Band("5#Fatal Error#Rock#Hungary#3#2013-06-11")
            };

            var concertList = new List<Concert>() {
                new Concert("1#1#FonixCsarnokJubileum#10#1#1995-01-01#2000"), 
                new Concert("2#1#FonixCsarnok#10#1#1995-02-01#2000"),
                new Concert("3#1#FonixCsarnokNagyJubileum#10#1#2000-02-01#1000"),
                new Concert("4#2#Europe Tour 2xxx England#30#2#2006-06-06#20000"),
                new Concert("5#3#Miskolc Szilveszteri évzáró#10#4#2010-12-31#500"),
                new Concert("6#3#Campus Feszticál#50#5#2021-07-27#100000"),
                new Concert("7#4#Campus Fesztivál#50#5#2021-07-28#100000"),
                new Concert("8#5#Aquarium Klub#0#6#2022-10-10#1000"),
                new Concert("9#5#BarHole Acoustic#00#7#2021-12-08#100"),
            };

            var longPlayingsList = new List<LongPlaying>() {
                new LongPlaying("1#Adjon az Ég#55#2000#200000#5#1"),
                new LongPlaying("2#Use Your Illusion I#76#1991#6850000#15#2"),
                new LongPlaying("3#Agyarország#55#1995#175400#8#1"),
                new LongPlaying("4#Halandó#43#2022#2000#0#5"),
                new LongPlaying("5#Get Lucky#40#202007#5000000#10#4"),
            };

            var venueList = new List<Venue>(){
                new Venue(1,"Fõnix Csarnok",true),
                new Venue(2,"Wembley Stadium",true),
                new Venue(3,"Paris Eifel Stadium", true),
                new Venue(4,"Grizzly Music Pub", true),
                new Venue(5,"Campus Festival", true),
                new Venue(6,"AquariumPub", true),
                new Venue(7,"BarHole", true)
            };

            var managerList = new List<Manager>(){
                new Manager("1#Kiss Jenõ"),
                new Manager("2#Ozzy Osbourne"),
                new Manager("3#Nikk Dzsegör"),
                new Manager("4#Brian Epstein")
            };


            foreach (var band in bandList)
            {
                band.Manager = managerList.FirstOrDefault(x => x.ManagerId == band.ManagerId);
                band.Concerts = concertList.Where(x => x.BandId == band.BandId).ToList();
                band.LongPlayings = longPlayingsList.Where(x => x.BandId == band.BandId).ToList();
            }
            foreach (var manager in managerList)
            {
                manager.ManagedBands = bandList.Where(x => x.ManagerId == manager.ManagerId).ToList();
            }
            foreach (var venue in venueList)
            {
                venue.Concerts = concertList.Where(x => x.VenueId == venue.VenueId).ToList();
            }
            foreach (var concert in concertList)
            {
                concert.Venue = venueList.FirstOrDefault(x => x.VenueId == concert.VenueId);
                concert.Band = bandList.FirstOrDefault(x => x.BandId == concert.BandId);
            }
            foreach (var lp in longPlayingsList)
            {
                lp.WriterBand = bandList.FirstOrDefault(x => x.BandId == lp.BandId);
            }


            mockBandRepo = new Mock<IRepository<Band>>();
            mockConcertRepo = new Mock<IRepository<Concert>>();
            mockLongPlayingRepo = new Mock<IRepository<LongPlaying>>();
            mockVenueRepo = new Mock<IRepository<Venue>>();
            mockManagerRepo = new Mock<IRepository<Manager>>();

            mockBandRepo.Setup(x => x.ReadAll()).Returns(bandList.AsQueryable());
            mockConcertRepo.Setup(x => x.ReadAll()).Returns(concertList.AsQueryable());
            mockLongPlayingRepo.Setup(x => x.ReadAll()).Returns(longPlayingsList.AsQueryable());
            mockVenueRepo.Setup(x => x.ReadAll()).Returns(venueList.AsQueryable());
            mockManagerRepo.Setup(x => x.ReadAll()).Returns(managerList.AsQueryable());


            for (int i = 1; i <= bandList.Count; i++)
            {
                mockBandRepo.Setup(m => m.Read(i)).Returns(bandList[i - 1]);
            }
            mockBandLogic = new BandLogic(mockBandRepo.Object);


            for (int i = 1; i <= concertList.Count; i++)
            {
                mockConcertRepo.Setup(m => m.Read(i)).Returns(concertList[i - 1]);
            }
            mockConcertLogic = new ConcertLogic(mockConcertRepo.Object);


            for (int i = 1; i <= longPlayingsList.Count; i++)
            {
                mockLongPlayingRepo.Setup(m => m.Read(i)).Returns(longPlayingsList[i - 1]);
            }
            mockLongPlayingLogic = new LongPlayingLogic(mockLongPlayingRepo.Object);


            for (int i = 1; i <= venueList.Count; i++)
            {
                mockVenueRepo.Setup(m => m.Read(i)).Returns(venueList[i - 1]);
            }
            mockVenueLogic = new VenueLogic(mockVenueRepo.Object);


            for (int i = 1; i <= managerList.Count; i++)
            {
                mockManagerRepo.Setup(m => m.Read(i)).Returns(managerList[i - 1]);
            }
            mockManagerLogic = new ManagerLogic(mockManagerRepo.Object);

        }


        [Test]
        [TestCase(1)]
        [TestCase(3)]
        [TestCase(5)]
        public void AllRevenueByYearTest(int id)
        {
            ;
            var result = mockBandLogic.AllRevenueByYear(id);


            var expected = new Dictionary<int, IEnumerable<YearlyRevenue>>();

            expected.Add(1, new List<YearlyRevenue>(){
                new YearlyRevenue (){
                    Year = 1995,
                    Revenue = 1443200
                },
                new YearlyRevenue (){
                    Year = 2000,
                    Revenue = 1010000
                }
                });

            expected.Add(3, new List<YearlyRevenue>(){
                new YearlyRevenue (){
                    Year = 2010,
                    Revenue = 5000
                },
                new YearlyRevenue (){
                    Year = 2021,
                    Revenue = 5000000
                }
                });

            expected.Add(5, new List<YearlyRevenue>(){
                new YearlyRevenue (){
                    Year = 2021,
                    Revenue = 0
                },
                new YearlyRevenue (){
                    Year = 2022,
                    Revenue = 0
                }
                });
            Assert.That(result, Is.EqualTo(expected[id]));
        }

        [Test]
        public void BandCreateTestWithCorrectData()
        {

            Band testBand = new Band() { BandName = "Bad Habit" };

            mockBandLogic.Create(testBand);

            mockBandRepo.Verify(x => x.Create(testBand), Times.Once);
        }
        [Test]
        public void BandCreateTestWithInCorrectData()
        {

            Band testBand = new Band() { BandName = "B" };
            try
            {
                mockBandLogic.Create(testBand);
            }
            catch { }

            mockBandRepo.Verify(x => x.Create(testBand), Times.Never);
        }

        [Test]
        public void ConcertCreateTestWithCorrectData()
        {

            Concert testConcert = new Concert()
            {
                ConcertName = "Bad Habit Concert",
                BandId = 3,
                TicketPrice = 10,
                SoldTickets = 1000
            };

            mockConcertLogic.Create(testConcert);

            mockConcertRepo.Verify(x => x.Create(testConcert), Times.Once);
        }

        [Test]
        public void ConcertCreateTestWithInCorrectData()
        {

            Concert testConcert = new Concert()
            {
                ConcertName = "Bad Habit Concert",
                BandId = 3,
                TicketPrice = 10,
                SoldTickets = -10
            };
            try
            {
                mockConcertLogic.Create(testConcert);
            }
            catch { }
            mockConcertRepo.Verify(x => x.Create(testConcert), Times.Never);
        }


        [Test]
        public void BestManagerIdTest()
        {

            int result = mockBandLogic.BestManagerId();

            Assert.AreEqual(2, result);
        }


        [Test]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(5)]
        public void AllConcertTest(int id)
        {
            var result = mockVenueLogic.AllConcert(id);

            var expected = new Dictionary<int, IEnumerable<ConcertInfo>>();

            expected.Add(1, new List<ConcertInfo>() {
                new ConcertInfo {
                    Year = 1995,
                    BandName = "Tankcsapda",
                    ConcertName = "FonixCsarnokJubileum",
                    VenueName = "Fõnix Csarnok"
                },
                new ConcertInfo {
                    Year = 1995,
                    BandName = "Tankcsapda",
                    ConcertName = "FonixCsarnok",
                    VenueName = "Fõnix Csarnok"
                },
                new ConcertInfo {
                    Year = 2000,
                    BandName = "Tankcsapda",
                    ConcertName = "FonixCsarnokNagyJubileum",
                    VenueName = "Fõnix Csarnok"
                }
            });

            expected.Add(2, new List<ConcertInfo>() {
                new ConcertInfo {
                    Year = 2006,
                    BandName = "Guns'n'Roses",
                    ConcertName = "Europe Tour 2xxx England",
                    VenueName = "Wembley Stadium"
                }
            });
            expected.Add(5, new List<ConcertInfo>() {
                new ConcertInfo {
                    Year = 2021,
                    BandName="Paddy And The Rats",
                    ConcertName = "Campus Feszticál",
                    VenueName = "Campus Festival"
                },
                new ConcertInfo {
                    Year = 2021,
                    BandName="Daft Punk",
                    ConcertName = "Campus Fesztivál",
                    VenueName = "Campus Festival"
                }
            });



            Assert.That(result, Is.EqualTo(expected[id]));
        }

        [Test]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void LongestLpTest(int id)
        {

            var result = mockBandLogic.LongestLP(id);

            var expected = new Dictionary<int, List<LongPlaying>>();
            expected.Add(1, new List<LongPlaying>() {
                 new LongPlaying("1#Adjon az Ég#55#2000#200000#5#1"),
                 new LongPlaying("3#Agyarország#55#1995#175400#8#1"),
            });
            expected.Add(2, new List<LongPlaying>() {
                 new LongPlaying("2#Use Your Illusion I#76#1991#6850000#15#2")
            });
            expected.Add(3, new List<LongPlaying>()
            {
            });

            Assert.That(result, Is.EqualTo(expected[id]));
        }

        [Test]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void DiscografiTest(int id)
        {


            var result = mockBandLogic.Discografi(id);

            var expected = new Dictionary<int, List<DiscInfo>>();

            expected.Add(1, new List<DiscInfo>() {
                 new DiscInfo {
                    Year = 1995,
                    BandName = "Tankcsapda",
                    LengthInMinute = 55,
                    LpName = "Agyarország"
                },
                new DiscInfo {
                    Year = 2000,
                    BandName = "Tankcsapda",
                    LengthInMinute = 55,
                    LpName = "Adjon az Ég"
                }
            });
            expected.Add(2, new List<DiscInfo>() {
                new DiscInfo {
                    Year = 1991,
                    BandName = "Guns'n'Roses",
                    LengthInMinute = 76,
                    LpName = "Use Your Illusion I"
                }
            });
            expected.Add(3, new List<DiscInfo>() { });
        }


        [Test]
        public void MostProductiveManagerTest()
        {
            var result = mockManagerLogic.MostProductive();

            List<Manager> expected = new List<Manager>();
            expected.Add(mockManagerLogic.Read(1));
            expected.Add(mockManagerLogic.Read(3));
            Assert.AreEqual(expected, result);

        }

        [Test]
        public void OldestBandTest()
        {
            var result = mockBandLogic.OldestBand();
            Band expected = new Band("2#Guns'n'Roses#Rock#USA#2#1980-07-05");

            Assert.AreEqual(expected, result);

        }


        //to do more for practice

    }
}
