using SocialWorker.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialWorker.Data.Models
{
    public class Visit : DeletableEntity
    {
        public Visit()
        {
            this.Medicines = new HashSet<Medicine>();
        }


        [Key]
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string Shopping { get; set; }

        public string HouseholdWork { get; set; }

        public int ClientId { get; set; }

        public virtual AppUser Client { get; set; }

        public int SocialWorkerId { get; set; }

        public virtual AppUser SocialWorker { get; set; }

        public int MealId { get; set; }

        public virtual Meal Meal { get; set; }

        public virtual ICollection<Medicine> Medicines { get; set; }



    }
}
