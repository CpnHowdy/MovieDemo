using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieDemo.Models
{
    /// <summary>
    ///     Model for movies
    /// </summary>
    public class Movie : AuditModel
    {
        [Key]
        public int MovieId { get; set; }
        public string ImdbId { get; set; }
    }
}