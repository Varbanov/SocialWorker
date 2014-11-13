using SocialWorker.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialWorker.Data.Models
{
    public class Meal : DeletableEntity
    {
        [Key]
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public AppUser User { get; set; }

        public string Description { get; set; }
    }
}
