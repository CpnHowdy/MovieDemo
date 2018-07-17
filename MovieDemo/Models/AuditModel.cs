using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieDemo.Models
{
    public class AuditModel
    {
        // "Create" cols
        [Required]
        [StringLength(128)]
        public string CreatedUser { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }

        // "Update" cols
        [StringLength(128)]
        public string UpdatedUser { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}