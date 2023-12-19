using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BandDatabaseProject.Client.Models
{
    internal class Concert
    {

        public Concert()
        {

        }
        public Concert(string input)
        {
            string[] split = input.Split('#');
            ConcertId = int.Parse(split[0]);
            BandId = int.Parse(split[1]);
            ConcertName = split[2];
            TicketPrice = int.Parse(split[3]);
            VenueId = int.Parse(split[5]);
            ConcertDate = DateTime.Parse(split[6].Replace("-", "."));
            SoldTickets = int.Parse(split[7]);
            Revenue = SoldTickets * TicketPrice;
        }


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ConcertId { get; set; }
        [Required]
        public int BandId { get; set; }
        [Required]
        public string ConcertName { get; set; }
        public int TicketPrice { get; set; }
        public int SoldTickets { get; set; }
        public double Revenue { get; set; }
        public int VenueId { get; set; }

        public DateTime ConcertDate { get; set; }
        [JsonIgnore]
        public virtual Venue Venue { get; set; }
        [JsonIgnore]
        public virtual Band Band { get; set; }
    }
}
