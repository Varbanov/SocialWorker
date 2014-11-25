using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialWorker.Data.Common.Models
{
    public abstract class DeletableEntity : AuditInfo, IDeletableEntity
    {
        [Editable(false)]
        [Index]
        public bool IsDeleted { get; set; }

        [Editable(false)]
        public DateTime? DeletedOn { get; set; }

    }
}
