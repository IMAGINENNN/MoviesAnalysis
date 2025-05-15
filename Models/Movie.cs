using System.ComponentModel.DataAnnotations;

namespace MoviesAnalysis.Models
{
    public class Movie
    {
        public int Id { get; set; }

        public int TmdbId { get; set; }

        [Required]
        public string Title { get; set; }

        public string Overview { get; set; }

        public string PosterPath { get; set; }

        public string ReleaseDate { get; set; }
    }
}
