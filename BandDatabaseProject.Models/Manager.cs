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
    public class Manager
    {


        public Manager()
        {
            ManagedBands = new HashSet<Band>();
        }
        public Manager(int managerId, string managerName)
        {
            this.ManagerId = managerId;
            this.ManagerName = managerName;
        }
        public Manager(string input)
        {
            string[] split = input.Split('#');
            ManagerId = int.Parse(split[0]);
            ManagerName = split[1];
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ManagerId { get; set; }

        public string ManagerName { get; set; }
        [JsonIgnore]
        public virtual ICollection<Band> ManagedBands { get; set; }
    }
}
