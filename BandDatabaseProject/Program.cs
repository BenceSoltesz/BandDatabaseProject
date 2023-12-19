using BandDatabaseProject.Client;
using BandDatabaseProject.Client.Models;
using ConsoleTools;


using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;



namespace BandDatabaseProject.Client
{
    public class Program
    {
        static RestService rest;
        static void Create(string entity)
        {
            if (entity == "Band")
            {
                Console.Write("Enter Band Name: ");
                string name = Console.ReadLine();
                Console.Write("Enter Band Origin: ");
                string origin = Console.ReadLine();
                Console.Write("Enter Band Genre: ");
                string genre = Console.ReadLine();
                Console.Write("Enter Band ManagerId: ");
                int managerId = int.Parse(Console.ReadLine());
                Console.Write("Enter Band Established(yyyy-mm-dd): ");
                DateTime established = DateTime.Parse(Console.ReadLine().Replace('-', '.'));

                rest.Post(new Band()
                {
                    BandName = name,
                    Origin = origin,
                    Genre = genre,
                    ManagerId = managerId,
                    Established = established,
                }, "band");
            }
            if (entity == "Concert")
            {
                Console.Write("Enter Concert Name: ");
                string name = Console.ReadLine();
                Console.Write("Enter Concert BandId: ");
                int bandId = int.Parse(Console.ReadLine());
                Console.Write("Enter Concert TicketPrice: ");
                int ticketPrice = int.Parse(Console.ReadLine());
                Console.Write("Enter Concert SoldTickets: ");
                int soldTickets = int.Parse(Console.ReadLine());
                Console.Write("Enter Concert VenueId: ");
                int venueId = int.Parse(Console.ReadLine());

                rest.Post(new Concert()
                {
                    ConcertName = name,
                    BandId = bandId,
                    TicketPrice = ticketPrice,
                    SoldTickets = soldTickets,
                    VenueId = venueId
                }, "concert");
            }
            if (entity == "Manager")
            {
                Console.Write("Enter Manager Name: ");
                string name = Console.ReadLine();
                rest.Post(new Manager() { ManagerName = name }, "manager");
            }
            if (entity == "LongPlaying")
            {
                Console.Write("Enter LongPlaying Name: ");
                string name = Console.ReadLine();
                Console.Write("Enter LongPlaying LengthInMinute: ");
                int lengthInMinute = int.Parse(Console.ReadLine());
                Console.Write("Enter LongPlaying ReleaseYear: ");
                int releaseYear = int.Parse(Console.ReadLine());
                Console.Write("Enter LongPlaying SoldCopies: ");
                int soldCopies = int.Parse(Console.ReadLine());
                Console.Write("Enter LongPlaying Price: ");
                int price = int.Parse(Console.ReadLine());
                Console.Write("Enter LongPlaying BandId: ");
                int bandId = int.Parse(Console.ReadLine());


                rest.Post(new LongPlaying()
                {
                    LongPlayingName = name,
                    LengthInMinute = lengthInMinute,
                    ReleaseYear = releaseYear,
                    SoldCopies = soldCopies,
                    Price = price,
                    BandId = bandId
                }, "longPlaying");
            }

            if (entity == "Venue")
            {
                Console.Write("Enter Venue Name: ");
                string name = Console.ReadLine();
                Console.Write("Enter Venue RoomName: ");
                string room = Console.ReadLine();

                rest.Post(new Venue()
                {
                    VenueName = name,
                    BackStage = room
                }, "venue");

            }
        }

        static void List(string entity)
        {

            if (entity == "Band")
            {
                List<Band> bands = rest.Get<Band>("band");
                foreach (var item in bands)
                {
                    Console.WriteLine(item.BandId + " : " +
                        item.BandName + " : " +
                        item.Origin + " : " +
                        item.Genre + " : ");
                }
            }

            if (entity == "Concert")
            {
                List<Concert> concerts = rest.Get<Concert>("concert");
                foreach (var item in concerts)
                {
                    Console.WriteLine(item.ConcertId + " : " +
                        item.ConcertName + " : " +
                        item.ConcertDate + " : " +
                        item.TicketPrice);
                }
            }
            if (entity == "Manager")
            {
                List<Manager> managers = rest.Get<Manager>("manager");
                foreach (var item in managers)
                {
                    Console.WriteLine(item.ManagerId + " : " +
                        item.ManagerName);
                }
            }
            if (entity == "LongPlaying")
            {
                List<LongPlaying> longPlayings = rest.Get<LongPlaying>("longPlaying");
                foreach (var item in longPlayings)
                {
                    Console.WriteLine(item.LongPlayingId + " : " +
                        item.LongPlayingName + " : " +
                        item.LengthInMinute + " : " +
                        item.LongPlayingName + " : " +
                        item.Price + " : " +
                        item.SoldCopies);
                }
            }
            if (entity == "Venue")
            {
                List<Venue> venues = rest.Get<Venue>("venue");
                foreach (var item in venues)
                {
                    Console.WriteLine(item.VenueId + " : " +
                        item.VenueName + " : backstage: " +
                         item.BackStage);
                }
            }
            Console.ReadLine();
        }

        static void Read(string entity)
        {
            if (entity == "Band")
            {
                Console.Write("Enter Band's id to read: ");
                int id = int.Parse(Console.ReadLine());
                Band item = rest.Get<Band>(id, "band");
                Console.WriteLine(item.BandId + " : " +
                        item.BandName + " : " +
                        item.Origin + " : " +
                        item.Genre + " : " +
                        item.Manager.ManagerName);
            }
            if (entity == "Concert")
            {
                Console.Write("Enter Concert's id to read: ");
                int id = int.Parse(Console.ReadLine());
                Concert item = rest.Get<Concert>(id, "concert");
                Console.WriteLine(item.ConcertId + " : " +
                        item.ConcertName + " : " +
                        item.ConcertDate + " : " +
                        item.Band.BandName + " : " +
                        item.TicketPrice);
            }
            if (entity == "Manager")
            {
                Console.Write("Enter Manager's id to read: ");
                int id = int.Parse(Console.ReadLine());
                Manager item = rest.Get<Manager>(id, "manager");
                Console.WriteLine(item.ManagerId + " : " +
                        item.ManagerName);
            }
            if (entity == "LongPlaying")
            {
                Console.Write("Enter LongPlaying's id to read: ");
                int id = int.Parse(Console.ReadLine());
                LongPlaying item = rest.Get<LongPlaying>(id, "longPlaying");
                Console.WriteLine(item.LongPlayingId + " : " +
                        item.LongPlayingName + " : " +
                        item.LengthInMinute + " : " +
                        item.LongPlayingName + " : " +
                        item.Price + " : " +
                        item.SoldCopies);
            }
            if (entity == "Venue")
            {
                Console.Write("Enter Venue's id to read: ");
                int id = int.Parse(Console.ReadLine());
                Venue item = rest.Get<Venue>(id, "venue");
                Console.WriteLine(item.VenueId + " : " +
                        item.VenueName + " : backstage: " +
                         item.BackStage);
            }
            Console.ReadLine();
        }

        static void Update(string entity)
        {
            if (entity == "Band")
            {
                Console.Write("Enter Band's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Band old = rest.Get<Band>(id, "band");

                Console.Write($"New name [old: {old.BandName}]: ");
                string name = Console.ReadLine();
                Console.Write($"New Origin [old: {old.Origin}]: ");
                string origin = Console.ReadLine();
                Console.Write($"New Genre [old: {old.Genre}]: ");
                string genre = Console.ReadLine();
                Console.Write($"New ManegerId [old: {old.ManagerId}]: ");
                string managerId = Console.ReadLine();
                Console.Write($"New Established(yyyy-mm-dd) [old: {old.Established}]: ");
                string established = Console.ReadLine();

                old.BandName = name;
                old.Origin = origin;
                old.Genre = genre;
                old.ManagerId = int.Parse(managerId);
                old.Established = DateTime.Parse(established.Replace('-', '.'));
                old.BandName = name;
                rest.Put(old, "band");
            }

            if (entity == "Concert")
            {
                Console.Write("Enter Concert's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Concert old = rest.Get<Concert>(id, "concert");

                Console.Write($"New name [old: {old.ConcertName}]: ");
                string name = Console.ReadLine();
                Console.Write($"New BandId [old: {old.BandId}]: ");
                int bandId = int.Parse(Console.ReadLine());
                Console.Write($"New TicketPrice [old: {old.TicketPrice}]: ");
                int ticketPrice = int.Parse(Console.ReadLine());
                Console.Write($"New SoldTickets [old: {old.SoldTickets}]: ");
                int soldTickets = int.Parse(Console.ReadLine());
                Console.Write($"New VenueId [old: {old.VenueId}]: ");
                int venueId = int.Parse(Console.ReadLine());

                old.ConcertName = name;
                old.BandId = bandId;
                old.TicketPrice = ticketPrice;
                old.SoldTickets = soldTickets;
                old.VenueId = venueId;
                rest.Put(old, "concert");
            }

            if (entity == "Manager")
            {
                Console.Write("Enter Manager's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Manager old = rest.Get<Manager>(id, "manager");

                Console.Write($"New name [old: {old.ManagerName}]: ");
                string name = Console.ReadLine();

                old.ManagerName = name;
                rest.Put(old, "manager");
            }

            if (entity == "Venue")
            {
                Console.Write("Enter Venue's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Venue old = rest.Get<Venue>(id, "venue");

                Console.Write($"New name [old: {old.VenueName}]: ");
                string name = Console.ReadLine();
                Console.Write($"Is there a Backstage?(Y/N) [old: {old.BackStage}]: ");
                string room = Console.ReadLine();

                old.VenueName = name;
                if (room.ToUpper().Equals("Y"))
                {
                    old.BackStage = true;
                }
                else
                {
                    old.BackStage = false;
                }
                
                rest.Put(old, "venue");
            }

            if (entity == "LongPlaying")
            {
                Console.Write("Enter LongPlaying's id to update: ");
                int id = int.Parse(Console.ReadLine());
                LongPlaying old = rest.Get<LongPlaying>(id, "longPlaying");

                Console.Write($"New LongPlayingName [old: {old.LongPlayingName}]: ");
                string name = Console.ReadLine();
                Console.Write($"New LengthInMinute [old: {old.LengthInMinute}]: ");
                int lengthInMinute = int.Parse(Console.ReadLine());
                Console.Write($"New ReleaseYear [old: {old.ReleaseYear}]: ");
                int releaseYear = int.Parse(Console.ReadLine());
                Console.Write($"New SoldCopies [old: {old.SoldCopies}]: ");
                int soldCopies = int.Parse(Console.ReadLine());
                Console.Write($"New Price [old: {old.Price}]: ");
                int price = int.Parse(Console.ReadLine());
                Console.Write($"New BandId [old: {old.BandId}]: ");
                int bandId = int.Parse(Console.ReadLine());



                old.LongPlayingName = name;
                old.LengthInMinute = lengthInMinute;
                old.ReleaseYear = releaseYear;
                old.SoldCopies = soldCopies;
                old.Price = price;
                old.BandId = bandId;
                rest.Put(old, "longPlaying");
            }


        }
        static void Delete(string entity)
        {
            if (entity == "Band")
            {
                Console.Write("Enter Band's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "band");
            }

            if (entity == "Concert")
            {
                Console.Write("Enter Concert's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "concert");
            }

            if (entity == "LongPlaying")
            {
                Console.Write("Enter LongPlaying's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "longPlaying");
            }

            if (entity == "Manager")
            {
                Console.Write("Enter Manager's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "manager");
            }

            if (entity == "Venue")
            {
                Console.Write("Enter Venue's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "venue");
            }

        }
        static void OldestBand()
        {

        }
        public static void Main(string[] args)
        {

            rest = new RestService("http://localhost:5037/", "band");

            var concertSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Concert"))
                .Add("Read", () => Read("Concert"))
                .Add("Create", () => Create("Concert"))
                .Add("Delete", () => Delete("Concert"))
                .Add("Update", () => Update("Concert"))
                .Add("Exit", ConsoleMenu.Close);

            var longPlayingSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("LongPlaying"))
                .Add("Read", () => Read("LongPlaying"))
                .Add("Create", () => Create("LongPlaying"))
                .Add("Delete", () => Delete("LongPlaying"))
                .Add("Update", () => Update("LongPlaying"))
                .Add("Exit", ConsoleMenu.Close);

            var managerSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Manager"))
                .Add("Read", () => Read("Manager"))
                .Add("Create", () => Create("Manager"))
                .Add("Delete", () => Delete("Manager"))
                .Add("Update", () => Update("Manager"))
                .Add("Exit", ConsoleMenu.Close);

            var bandSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Band"))
                .Add("Read", () => Read("Band"))
                .Add("Create", () => Create("Band"))
                .Add("Delete", () => Delete("Band"))
                .Add("Update", () => Update("Band"))
                .Add("OldestBand", () => OldestBand())
                .Add("Exit", ConsoleMenu.Close);

            var venueSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Venue"))
                .Add("Read", () => Read("Venue"))
                .Add("Create", () => Create("Venue"))
                .Add("Delete", () => Delete("Venue"))
                .Add("Update", () => Update("Venue"))
                .Add("Exit", ConsoleMenu.Close);


            var menu = new ConsoleMenu(args, level: 0)
                .Add("Bands", () => bandSubMenu.Show())
                .Add("Concerts", () => concertSubMenu.Show())
                .Add("LongPlayings", () => longPlayingSubMenu.Show())
                .Add("Managers", () => managerSubMenu.Show())
                .Add("Venues", () => venueSubMenu.Show())
                .Add("Exit", ConsoleMenu.Close);

            menu.Show();


        }
    }
}

