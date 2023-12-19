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
 
        //LP - means a full sized 33rpm vinyl
        public class LongPlaying
        {
            public LongPlaying()
            {

            }
            public LongPlaying(string input)
            {

                string[] split = input.Split('#');
                LongPlayingId = int.Parse(split[0]);
                LongPlayingName = split[1];
                LengthInMinute = int.Parse(split[2]);
                ReleaseYear = int.Parse(split[3]);
                SoldCopies = int.Parse(split[4]);
                Price = double.Parse(split[5].Replace(".", ","));
                BandId = int.Parse(split[6]);

                Revenue = Price * SoldCopies;
            }

            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int LongPlayingId { get; set; }
            [Required]
            public string LongPlayingName { get; set; }
            public int LengthInMinute { get; set; }
            public int ReleaseYear { get; set; }
            public int SoldCopies { get; set; }
            public double Price { get; set; }
            public double Revenue { get; set; }

            public int BandId { get; set; }
            [JsonIgnore]
            public virtual Band WriterBand { get; set; }


            public override bool Equals(object obj)
            {

                var o = obj as LongPlaying;

                return o.BandId == this.BandId && o.LongPlayingName.Equals(this.LongPlayingName) && o.ReleaseYear == this.ReleaseYear && o.LengthInMinute == this.LengthInMinute;
            }
            public override int GetHashCode()
            {
                return HashCode.Combine(this.BandId, this.LongPlayingName, this.ReleaseYear, this.LengthInMinute);
            }
        }
}
