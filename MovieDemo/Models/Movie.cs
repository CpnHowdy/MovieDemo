using System.ComponentModel.DataAnnotations;

namespace MovieDemo.Models
{
    /// <summary>
    ///     Model for movies
    /// </summary>
    public class Movie : AuditModel
    {
        [Key]
        public int MovieId { get; set; }
        public int TmdbId { get; set; }
        public string ImdbId { get; set; }
    }
}