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
    public class Venue
    {
        public Venue()
        {
            Concerts = new HashSet<Concert>();
        }
        public Venue(string input)
        {
            string[] split = input.Split('#');
            VenueId = int.Parse(split[0]);
            VenueName = split[1];
            Room = split[2];
            Concerts = new HashSet<Concert>();
        }



        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VenueId { get; set; }
        [Required]
        public string VenueName { get; set; }
        public string Room { get; set; }
        [JsonIgnore]
        public virtual ICollection<Concert> Concerts { get; set; }

    }
}
