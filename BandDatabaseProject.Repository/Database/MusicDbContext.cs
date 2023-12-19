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
                new Band("1#HarmonyHues#Rock#USA#3#2005-07-12"),
            new Band("2#GrooveGalaxy#Funk#UK#7#2008-05-23"),
            new Band("3#MoonlitMelodies#Indie#Canada#2#2010-09-15"),
            new Band("4#FunkyFusion#Funk#USA#8#2003-12-08"),
            new Band("5#NatureNirvana#Folk#Australia#5#2012-03-30"),
            new Band("6#StellarSounds#Rock#USA#1#2007-11-18"),
            new Band("7#EtherealEnsemble#Indie#Canada#9#2015-02-04"),
            new Band("8#SoulfulSymphony#Soul#UK#4#2006-08-27"),
            new Band("9#MysticMelodies#Indie#USA#6#2011-06-10"),
            new Band("10#CelestialCanvas#Rock#Australia#10#2014-04-22"),
            new Band("11#SereneSonic#Electronic#USA#3#2009-01-17"),
            new Band("12#WhimsicalWaltz#Indie#Canada#7#2013-10-05"),
            new Band("13#DazzlingDuet#Pop#USA#5#2004-06-29"),
            new Band("14#HarmonicHarbor#Rock#UK#1#2002-09-14"),
            new Band("15#StarlitSymphony#Soul#Canada#9#2005-04-01"),
            new Band("16#LushLagoonLyrics#Folk#Australia#4#2010-11-12"),
            new Band("17#MelodicMingle#Indie#USA#8#2012-08-18"),
            new Band("18#CelestialCrescendo#Rock#UK#2#2006-03-27"),
            new Band("19#SonicSunrise#Electronic#Canada#10#2014-01-09"),
            new Band("20#GalacticGrove#Rock#Australia#6#2003-07-02"),
            new Band("21#MysticalMeadow#Folk#USA#1#2008-05-17"),
            new Band("22#CelestialCanyon#Rock#Canada#7#2011-12-30"),
            new Band("23#LuminousLullaby#Indie#Australia#5#2013-09-22"),
            new Band("24#SylvanSerenade#Folk#USA#3#2004-04-15"),
            new Band("25#HarmonicHootenanny#Rock#UK#9#2009-11-28"),
            new Band("26#WhimsicalWonders#Indie#Canada#2#2012-06-03"),
            new Band("27#AstralAria#Electronic#USA#8#2007-02-16"),
            new Band("28#LuminousLyrics#Rock#Australia#10#2015-07-09"),
            new Band("29#SylvanSymphony#Soul#USA#6#2006-10-21"),
            new Band("30#CelestialConcerto#Electronic#UK#1#2003-03-04"),
            new Band("31#SonicSymphony#Rock#Canada#4#2010-12-17"),
            new Band("32#RockingRhapsody#Pop#Australia#7#2013-02-08"),
            new Band("33#FunkyFiesta#Funk#USA#9#2005-09-01"),
            new Band("34#MelodicMystique#Indie#UK#3#2008-06-14"),
            new Band("35#ReggaeRhapsody#Reggae#Canada#8#2012-01-27"),
            new Band("36#JazzJam#Jazz#Australia#2#2014-10-10"),
            new Band("37#SoulfulSerenade#Soul#USA#10#2007-07-03"),
            new Band("38#ElectricEcho#Electronic#UK#5#2011-04-26"),
            new Band("39#BluesBallad#Blues#Canada#1#2013-11-18"),
            new Band("40#IndieInterlude#Indie#Australia#6#2004-08-31"),
            new Band("41#MetalMelodies#Metal#USA#3#2009-06-13"),
            new Band("42#NatureNostalgia#Folk#UK#8#2012-03-06"),
            new Band("43#WhimsicalWaves#Indie#Canada#5#2015-01-19"),
            new Band("44#EtherealEchoes#Electronic#Australia#9#2006-05-02"),
            new Band("45#HarmonyHarbor#Rock#USA#4#2010-09-15"),
            new Band("46#SonicSerenity#Electronic#UK#10#2013-06-28"),
            new Band("47#CelestialChords#Rock#Canada#2#2005-01-11"),
            new Band("48#LushLullaby#Folk#Australia#7#2008-08-24"),
            new Band("49#MoonlitMelodies#Indie#USA#9#2011-05-07"),
            new Band("50#SylvanSerendipity#Folk#Canada#5#2004-02-20"),
            new Band("51#Tankcsapda#Rock#Hungary#1#1990-01-01") //ID, Name, Genre, From, MangerID, Estabilished
            });


            modelBuilder.Entity<Manager>().HasData(new Manager[] {
                new Manager("1#John Smith"),
                new Manager("2#Alice Johnson"),
                new Manager("3#David Williams"),
                new Manager("4#Emma Brown"),
                new Manager("5#Michael Davis"),
                new Manager("6#Laura Miller"),
                new Manager("7#Chris Wilson"),
                new Manager("8#Jessica Taylor"),
                new Manager("9#Brian Jolds"),
                new Manager("10#Olivia Lee")
            });

            modelBuilder.Entity<Concert>().HasData(new Concert[] {
                new Concert("1#5#RhythmicRendezvous#10#150#10#2023-03-15#120"),
                new Concert("2#12#HarmonyHaven#8#200#5#2023-04-20#180"),
                new Concert("3#8#MelodyMingle#12#100#15#2023-05-10#75"),
                new Concert("4#19#GrooveGathering#6#300#8#2023-06-05#250"),
                new Concert("5#2#BeatBash#10#250#12#2023-07-12#200"),
                new Concert("6#18#TuneFiesta#5#180#18#2023-08-08#150"),
                new Concert("7#3#SymphonySoiree#12#120#3#2023-09-25#90"),
                new Concert("8#16#ConcordCarnival#8#280#16#2023-10-30#220"),
                new Concert("9#7#SonicSpectacle#10#170#7#2023-11-15#140"),
                new Concert("10#1#AriaAffair#6#220#1#2023-12-20#180"),
                new Concert("11#14#FunkyFusionFest#12#190#14#2024-01-05#160"),
                new Concert("12#11#EclecticEnsembleExpo#8#350#11#2024-02-18#300"),
                new Concert("13#9#JazzJamboree#10#130#9#2024-03-22#100"),
                new Concert("14#2#VibratoVoyage#6#270#2#2024-04-08#230"),
                new Concert("15#19#SerendipitySonata#8#240#19#2024-05-15#200"),
                new Concert("16#6#MysticMelodiesMixer#10#160#6#2024-06-30#120"),
                new Concert("17#13#SoulfulSyncShow#6#200#13#2024-07-10#180"),
                new Concert("18#4#BlissfulBeatsBonanza#12#300#4#2024-08-28#250"),
                new Concert("19#17#EuphonyExtravaganza#8#180#17#2024-09-05#150"),
                new Concert("20#8#HarmoniousHootenanny#10#250#8#2024-10-12#200"),
                new Concert("21#5#LyricalLagoon#6#120#5#2024-11-20#90"),
                new Concert("22#14#MellowMelodiesMashup#12#220#14#2024-12-02#180"),
                new Concert("23#10#VintageVibesVariety#8#170#10#2025-01-15#140"),
                new Concert("24#3#RetroRhapsody#10#280#3#2025-02-28#220"),
                new Concert("25#16#CadenceCruise#6#150#16#2025-03-10#120"),
                new Concert("26#7#FestivalFantasia#8#200#7#2025-04-18#160"),
                new Concert("27#12#EchoExposition#10#250#12#2025-05-22#200"),
                new Concert("28#1#PulsePandemonium#6#190#1#2025-06-05#160"),
                new Concert("29#15#RagaRevelry#12#300#15#2025-07-15#250"),
                new Concert("30#9#WhimsicalWaltzWave#8#130#9#2025-08-20#100"),
                new Concert("31#4#AuroraAcapellaAffair#10#240#4#2025-09-28#200"),
                new Concert("32#11#LuminaryLullabyLecture#6#180#11#2025-10-10#150"),
                new Concert("33#2#EclipseEuphony#12#160#2#2025-11-18#130"),
                new Concert("34#19#CrescendoCraze#8#350#19#2025-12-25#300"),
                new Concert("35#6#SonorousSafari#10#170#6#2026-01-08#140"),
                new Concert("36#13#JubilantJazzJaunt#6#270#13#2026-02-15#230"),
                new Concert("37#7#AstonishingAcapellaAdventure#12#220#7#2026-03-22#180"),
                new Concert("38#16#PanoramicPianoParade#8#120#16#2026-04-30#90"),
                new Concert("39#1#VividVocalVortex#10#200#1#2026-05-05#160"),
                new Concert("40#14#RadiantRhythmRendezvous#12#300#14#2026-06-12#250"),
                new Concert("41#3#DynamicDanceDose#8#250#3#2026-07-25#200"),
                new Concert("42#10#SpectacularSerenadeShow#10#190#10#2026-08-08#160"),
                new Concert("43#9#LivelyLyricLagoon#12#280#9#2026-09-18#220"),
                new Concert("44#15#MesmericMelodyMingle#8#150#15#2026-10-28#120"),
                new Concert("45#4#VibrantVerseVoyage#10#220#4#2026-11-05#180"),
                new Concert("46#12#MysticalMusicalMedley#6#170#12#2026-12-15#140"),
                new Concert("47#8#MagicalMelancholyMixer#8#160#8#2027-01-22#130"),
                new Concert("48#2#SymphonicSensationSoiree#10#240#2#2027-02-28#200"),
                new Concert("49#17#HarmonicHavoc#12#130#17#2027-03-08#100"),
                new Concert("50#11#WhirlwindWaltzWonder#8#200#11#2027-04-18#160"),
                new Concert("51#6#EtherealEnigmaExhibition#10#300#6#2027-05-22#250"),
                new Concert("52#13#EclipticEuphoria#12#180#13#2027-06-30#150"),
                new Concert("53#1#LunarLullabyLollapalooza#8#250#1#2027-07-10#200"),
                new Concert("54#16#CelestialConcerto#10#120#16#2027-08-15#90"),
                new Concert("55#5#HarmonyHaven#12#150#5#2027-09-28#120"),
                new Concert("56#14#MelodyMingle#8#200#14#2027-10-05#160"),
                new Concert("57#10#RhythmicRendezvous#10#300#10#2027-11-18#250"),
                new Concert("58#9#HarmonyHaven#12#180#9#2027-12-25#150"),
                new Concert("59#15#MelodyMingle#8#250#15#2028-01-02#200"),
                new Concert("60#7#RhythmicRendezvous#10#190#7#2028-02-15#160"),
                new Concert("61#2#HarmonyHaven#12#280#2#2028-03-22#220"),
                new Concert("62#17#MelodyMingle#8#170#17#2028-04-28#140"),
                new Concert("63#3#RhythmicRendezvous#10#220#3#2028-05-10#180"),
                new Concert("64#11#HarmonyHaven#12#160#11#2028-06-18#130"),
                new Concert("65#1#MelodyMingle#8#240#1#2028-07-25#200"),
                new Concert("66#18#RhythmicRendezvous#10#130#18#2028-08-08#100"),
                new Concert("67#6#HarmonyHaven#12#200#6#2028-09-18#160"),
                new Concert("68#13#MelodyMingle#8#300#13#2028-10-28#250"),
                new Concert("69#8#RhythmicRendezvous#10#120#8#2028-11-05#90"),
                new Concert("70#15#HarmonyHaven#12#220#15#2028-12-15#180"),
                new Concert("71#4#MelodyMingle#8#250#4#2029-01-22#200"),
                new Concert("72#12#RhythmicRendezvous#10#120#12#2029-02-28#90"),
                new Concert("73#9#HarmonyHaven#12#220#9#2029-03-08#180"),
                new Concert("74#16#MelodyMingle#8#170#16#2029-04-18#140"),
                new Concert("75#7#RhythmicRendezvous#10#280#7#2029-05-25#220"),
                new Concert("76#2#HarmonyHaven#12#150#2#2029-06-05#120"),
                new Concert("77#19#MelodyMingle#8#200#19#2029-07-15#160"),
                new Concert("78#5#RhythmicRendezvous#10#300#5#2029-08-20#250"),
                new Concert("79#14#HarmonyHaven#12#180#14#2029-09-28#150"),
                new Concert("80#3#MelodyMingle#8#250#3#2029-10-10#200"),
                new Concert("81#10#RhythmicRendezvous#10#120#10#2029-11-18#90"),
                new Concert("82#1#HarmonyHaven#12#220#1#2029-12-30#180"),
                new Concert("83#18#MelodyMingle#8#170#18#2030-01-08#140"),
                new Concert("84#6#RhythmicRendezvous#10#280#6#2030-02-15#220"),
                new Concert("85#13#HarmonyHaven#12#150#13#2030-03-22#120"),
                new Concert("86#8#MelodyMingle#8#200#8#2030-04-28#160"),
                new Concert("87#15#RhythmicRendezvous#10#300#15#2030-05-05#250"),
                new Concert("88#4#HarmonyHaven#12#180#4#2030-06-15#150"),
                new Concert("89#11#MelodyMingle#8#250#11#2030-07-22#200"),
                new Concert("90#9#RhythmicRendezvous#10#190#9#2030-08-30#160"),
                new Concert("91#16#HarmonyHaven#12#220#16#2030-09-08#180"),
                new Concert("92#7#MelodyMingle#8#170#7#2030-10-18#140"),
                new Concert("93#2#RhythmicRendezvous#10#280#2#2030-11-25#220"),
                new Concert("94#19#HarmonyHaven#12#150#19#2030-12-02#120"),
                new Concert("95#5#MelodyMingle#8#200#5#2031-01-15#160"),
                new Concert("96#14#RhythmicRendezvous#10#300#14#2031-02-22#250"),
                new Concert("97#10#HarmonyHaven#12#180#10#2031-03-30#150"),
                new Concert("98#3#MelodyMingle#8#250#3#2031-04-08#200"),
                new Concert("99#12#RhythmicRendezvous#10#120#12#2031-05-18#90"),
                new Concert("100#1#HarmonyHaven#12#220#1#2031-06-25#180"),
                new Concert("101#51#FonixCsarnokJubileum#10#1#21#1995-01-01#2000"), //20000 | ID, BandId,ConcertName, TicketPrice, (Datagenerator goes vrumvrum(I Dont use this)),VenueID,ConcertDate,SoldTickets 
                new Concert("102#51#FonixCsarnok#10#1#21#1995-02-01#2000"), //20000
                new Concert("103#51#FonixCsarnokNagyJubileum#10#1#21#2000-02-01#1000")//10000
            });


            modelBuilder.Entity<LongPlaying>().HasData(new LongPlaying[] {
                  new LongPlaying("1#HarmonyHues#45#2010#50000#13#13"),
            new LongPlaying("2#GrooveGalaxy#60#2015#75000#18#27"),
            new LongPlaying("3#MoonlitMelodies#40#2012#30000#12.5#8"),
            new LongPlaying("4#FunkyFusion#50#2018#45000#16.75#42"),
            new LongPlaying("5#NatureNirvana#55#2014#60000#20#16"),
            new LongPlaying("6#StellarSounds#48#2011#40000#14.2#35"),
            new LongPlaying("7#EtherealEnsemble#52#2016#55000#17.85#21"),
            new LongPlaying("8#SoulfulSymphony#58#2013#70000#19.5#11"),
            new LongPlaying("9#MysticMelodies#42#2017#35000#12.6#28"),
            new LongPlaying("10#CelestialCanvas#47#2019#80000#15.75#7"),
            new LongPlaying("11#SereneSonic#49#2010#42000#13.2#49"),
            new LongPlaying("12#WhimsicalWaltz#46#2015#68000#20.1#15"),
            new LongPlaying("13#DazzlingDuet#53#2012#52000#18.9#46"),
            new LongPlaying("14#HarmonicHarbor#44#2016#47000#17.45#31"),
            new LongPlaying("15#StarlitSymphony#51#2013#59000#19.65#3"),
            new LongPlaying("16#LushLagoonLyrics#43#2018#63000#20.05#22"),
            new LongPlaying("17#MelodicMingle#60#2014#75000#20#5"),
            new LongPlaying("18#CelestialCrescendo#55#2011#42000#13.2#37"),
            new LongPlaying("19#SonicSunrise#48#2017#50000#15.75#14"),
            new LongPlaying("20#GalacticGrove#52#2013#65000#18.85#43"),
            new LongPlaying("21#MysticalMeadow#50#2019#70000#19.95#29"),
            new LongPlaying("22#CelestialCanyon#45#2012#47000#17.45#17"),
            new LongPlaying("23#LuminousLullaby#57#2018#58000#20.4#1"),
            new LongPlaying("24#SylvanSerenade#53#2015#42000#15.75#38"),
            new LongPlaying("25#HarmonicHootenanny#49#2011#56000#19.8#19"),
            new LongPlaying("26#WhimsicalWonders#51#2016#69000#20.7#44"),
            new LongPlaying("27#AstralAria#54#2013#50000#17.85#8"),
            new LongPlaying("28#LuminousLyrics#56#2010#60000#20.9#26"),
            new LongPlaying("29#SylvanSymphony#58#2017#72000#23.8#12"),
            new LongPlaying("30#CelestialConcerto#50#2014#48000#18.9#33"),
            new LongPlaying("31#SonicSymphony#48#2016#49000#18.45#20"),
            new LongPlaying("32#RockingRhapsody#50#2012#55000#19.8#6"),
            new LongPlaying("33#FunkyFiesta#55#2018#60000#20#42"),
            new LongPlaying("34#MelodicMystique#44#2014#48000#18.9#9"),
            new LongPlaying("35#ReggaeRhapsody#53#2011#52000#19.65#26"),
            new LongPlaying("36#JazzJam#47#2017#47000#17.45#14"),
            new LongPlaying("37#SoulfulSerenade#51#2013#59000#19.65#38"),
            new LongPlaying("38#ElectricEcho#58#2019#72000#23.8#33"),
            new LongPlaying("39#BluesBallad#49#2012#49000#18.45#16"),
            new LongPlaying("40#IndieInterlude#56#2016#56000#19.8#22"),
            new LongPlaying("41#MetalMelodies#50#2013#60000#20.9#1"),
            new LongPlaying("42#NatureNostalgia#46#2010#46000#17.4#7"),
            new LongPlaying("43#WhimsicalWaves#54#2015#54000#18.9#36"),
            new LongPlaying("44#EtherealEchoes#57#2011#59000#19.65#29"),
            new LongPlaying("45#HarmonyHarbor#42#2017#47000#17.45#12"),
            new LongPlaying("46#SonicSerenity#48#2014#58000#20.4#35"),
            new LongPlaying("47#CelestialChords#52#2010#52000#19.8#18"),
            new LongPlaying("48#LushLullaby#51#2016#69000#23.8#5"),
            new LongPlaying("49#MoonlitMelodies#59#2013#56000#20.9#44"),
            new LongPlaying("50#SylvanSerendipity#46#2010#59000#19.65#9"),
            new LongPlaying("51#ReggaeRhythms#50#2017#52000#19.8#23"),
            new LongPlaying("52#FunkyFusion#45#2012#49000#18.45#42"),
            new LongPlaying("53#JazzJamboree#53#2019#58000#20.4#17"),
            new LongPlaying("54#SoulfulSerenade#56#2014#63000#19.95#32"),
            new LongPlaying("55#ElectronicExtravaganza#49#2011#52000#19.8#4"),
            new LongPlaying("56#BluesBlast#47#2017#47000#17.45#27"),
            new LongPlaying("57#IndieInferno#55#2013#59000#19.65#13"),
            new LongPlaying("58#MetalMania#52#2010#52000#19.8#6"),
            new LongPlaying("59#NatureNirvana#58#2016#68000#20.7#38"),
            new LongPlaying("60#WhimsicalWoodstock#50#2012#51000#19.275#11"),
            new LongPlaying("61#Agyarorszag#60#1995#2000#10#51"), //20000
            new LongPlaying("62#Menyorszagturiszt#60#2001#4000#10#51"), //40000
            new LongPlaying("63#Jonnek A Tankok#55#1996#6000#10#51") //60000
        });

            modelBuilder.Entity<Venue>().HasData(new Venue[] {
                new Venue("1#MelodyManor#HarmonyHall"),
                new Venue("2#RockRendezvous#EchoChamber"),
                new Venue("3#JazzJubilee#GrooveGallery"),
                new Venue("4#FolkFusion#AcousticArena"),
                new Venue("5#ElectroExpanse#BeatBox"),
                new Venue("6#SoulSanctuary#RhythmRoom"),
                new Venue("7#BluesBash#MelodicMansion"),
                new Venue("8#PopPalace#SonicStudio"),
                new Venue("9#IndieIntersection#HarmonyHall"),
                new Venue("10#MetalManiaMansion#EchoChamber"),
                new Venue("11#CountryCove#GrooveGallery"),
                new Venue("12#ReggaeRidge#AcousticArena"),
                new Venue("13#SymphonySphere#BeatBox"),
                new Venue("14#OperaOasis#RhythmRoom"),
                new Venue("15#FolkFiesta#MelodicMansion"),
                new Venue("16#ElectronicEden#SonicStudio"),
                new Venue("17#SoulfulSanctuary#HarmonyHall"),
                new Venue("18#JazzJungle#EchoChamber"),
                new Venue("19#RockRhythmRealm#GrooveGallery"),
                new Venue("20#BluesBoulevard#AcousticArena"),
                new Venue("21#Fonixcsarnok#Nagyterem")

            });
        }

    }
}
