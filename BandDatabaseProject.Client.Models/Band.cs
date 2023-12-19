using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System;

namespace BandDatabaseProject.Client.Models
{
    public class Band
    {
        public Band(int bandId, string bandName,string genre, string origin, int managerId, string established)
        {
            this.BandId = bandId;
            this.BandName = bandName;
            this.Genre = genre;
            this.Origin = origin;
            this.ManagerId = managerId;
            this.Established = DateTime.Parse(established.Replace('-', '.'));
        }
        public Band()
        {
            Concerts = new HashSet<Concert>();
            LongPlayings = new HashSet<LongPlaying>();
        }
        public Band(string input)
        {
            string[] split = input.Split('#');
            BandId = int.Parse(split[0]);
            BandName = split[1];
            Genre = split[2];
            Origin = split[3];
            ManagerId = int.Parse(split[4]);
            Established = DateTime.Parse(split[5].Replace('-', '.'));
            Concerts = new HashSet<Concert>();
            LongPlayings = new HashSet<LongPlaying>();

        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BandId { get; set; }
        [Required]
        public string BandName { get; set; }
        public string Genre { get; set; }
        public string Origin { get; set; }
        public int ManagerId { get; set; }

        public DateTime Established { get; set; }
        [JsonIgnore]
        public virtual Manager Manager { get; set; }
        [JsonIgnore]
        public virtual ICollection<Concert> Concerts { get; set; }
        [JsonIgnore]
        public virtual ICollection<LongPlaying> LongPlayings { get; set; }

        public override bool Equals(object obj)
        {
            var o = obj as Band;
            return o != null && o.BandName.Equals(this.BandName);
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(this.BandName);
        }

    }
}
