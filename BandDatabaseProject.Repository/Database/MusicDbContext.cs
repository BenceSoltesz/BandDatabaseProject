using BandDatabaseProject.Client.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace BandDatabaseProject.Repository
{
    public class MusicDbContext : DbContext
    {


        public DbSet<Band> Bands { get; set; }
        public DbSet<Concert> Concerts { get; set; }
        public DbSet<LongPlaying> LongPlayings { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Venue> Venues { get; set; }

        public MusicDbContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder
                    .UseLazyLoadingProxies()
                    .UseInMemoryDatabase("music");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Band>()
                .HasOne(band => band.Manager)
                .WithMany(manager => manager.ManagedBands)
                .HasForeignKey(band => band.ManagerId)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Concert>()
               .HasOne(concert => concert.Band)
               .WithMany(band => band.Concerts)
               .HasForeignKey(concert => concert.BandId)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<LongPlaying>()
                .HasOne(lp => lp.WriterBand)
                .WithMany(band => band.LongPlayings)
                .HasForeignKey(lp => lp.BandId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Concert>()
                .HasOne(concert => concert.Venue)
                .WithMany(venue => venue.Concerts)
                .HasForeignKey(concert => concert.VenueId)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Band>().HasData(new Band[] {

            new Band("1#Tankcsapda#Rock#Hungary#1#1990-01-01"), //ID, Name, Genre, From, MangerID, Estabilished
            new Band(2,"Alvin és a mókusok","Rock", "Hungary", 1 ,"1993-03-12"),
            new Band(3,"Fatal Error", "Rock","Hungary",2, "2011-08-21"),
            new Band(4,"Sorbonne Sexual", "Alternative rock","Hungary",2, "2016-01-17"),
            new Band(5,"Bad Habit", "Punk pop","Hungary",3, "2013-09-11"),
            new Band(6,"Queen", "Classic rock", "United Kingdom", 4,"1971-01-01"),
            new Band(7,"Michael Jackson", "Pop" , "USA",4,"1966-01-01"),
            new Band(8,"The Beatles","Brit Rock", "United Kingdom", 4, "1960-01-01")
            });


            modelBuilder.Entity<Manager>().HasData(new Manager[] {
                new Manager("1#Nagy László"),
                new Manager("2#Kiss Imre"),
                new Manager("3#Posta Tamás"),
                new Manager("4#Emma Brown"),
            });

            modelBuilder.Entity<Concert>().HasData(new Concert[] {

                new Concert("1#1#FonixCsarnokJubileum#10#1#1995-01-01#2000"), //20000 | ID, BandId,ConcertName, TicketPrice, (Datagenerator goes vrumvrum(I Dont use this)),VenueID,ConcertDate,SoldTickets 
                new Concert("2#1#FonixCsarnok#10#1#1995-02-01#2000"), //20000
                new Concert("3#1#FonixCsarnokNagyJubileum#10#1#2000-02-01#1000"),//10000

                new Concert(4,2,"Alvin 2021 Tavasz Békéscsaba",2500,600,3,"2021-04-24"),  //id 3 Békéscsaba
                new Concert(5,2,"Alvin 2021 Tavasz Budapest",2500,1500,2,"2021-05-13"),                 //id 2 Budapest

                //To do

            }) ;


            modelBuilder.Entity<LongPlaying>().HasData(new LongPlaying[] {
                    // To do
        });

            modelBuilder.Entity<Venue>().HasData(new Venue[] {
            
                new Venue(1,"Fonixcsarnok",true),
                new Venue(2,"Budapest Analóg Music Hall",true),
                new Venue(3,"Békéscsaba Művelődési központ",false),
                new Venue(4,"Debrecen Roncs Bár",true),
                new Venue(5,"Miskolc Gösser Pub", false),
                //To do



            });
        }

    }
}
