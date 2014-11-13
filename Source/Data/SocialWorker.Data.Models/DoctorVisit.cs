using SocialWorker.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialWorker.Data.Models
{
    public class DoctorVisit : DeletableEntity
    {
        [Key]
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string Prescription { get; set; }

        public string Description { get; set; }

        public int DoctorId { get; set; }
        public int ClientId { get; set; }

        public virtual AppUser Doctor { get; set; }
        
        public virtual AppUser Client { get; set; }




    }
}
