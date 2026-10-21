
using System.ComponentModel.DataAnnotations;

namespace CinemaBookingMVC.Models
{
    public class Movie
    {
        public int MovieId { get; set; }

        [Required]
        public string MovieName { get; set; } = string.Empty;

        [Required]
        public string Genre { get; set; } = string.Empty;

        [Required]
        public string Language { get; set; } = string.Empty;

        [Range(1, 10000)]
        public decimal TicketPrice { get; set; }

        [Range(0, 1000)]
        public int AvailableSeats { get; set; }
    }
}
