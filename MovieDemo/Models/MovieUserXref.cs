using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MovieDemo.Models
{
    public class MovieUserXref : AuditModel
    {
        /// <summary>
        ///     PK
        /// </summary>
        [Key]
        public int MovieUserId { get; set; }

        /// <summary>
        ///     Ref to movie
        /// </summary>
        [ForeignKey("Movie")]
        [Required]
        public int MovieId { get; set; }
        public virtual Movie Movie { get; set; }

        /// <summary>
        ///     Ref to user
        /// </summary>
        [ForeignKey("User")]
        [StringLength(128)]
        [Required]
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}