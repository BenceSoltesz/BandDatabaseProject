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
        public Venue(int venueId, string venueName, bool room)
        {
            this.VenueId = venueId;
            this.VenueName = venueName;
            this.BackStage = room;
        }
        public Venue(string input)
        {
            string[] split = input.Split('#');
            VenueId = int.Parse(split[0]);
            VenueName = split[1];
            BackStage = bool.Parse(split[2]);
            Concerts = new HashSet<Concert>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VenueId { get; set; }
        [Required]
        public string VenueName { get; set; }
        public bool BackStage { get; set; }
        [JsonIgnore]
        public virtual ICollection<Concert> Concerts { get; set; }

    }
}
