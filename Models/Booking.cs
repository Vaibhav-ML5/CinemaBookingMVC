
using System.ComponentModel.DataAnnotations;

namespace CinemaBookingMVC.Models
{
    public class Booking
    {
        public int BookingId { get; set; }

        [Required]
        public string CustomerName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [Phone]
        public string Phone { get; set; } = string.Empty;

        [Required]
        public int MovieId { get; set; }

        public DateTime BookingDate { get; set; } = DateTime.Today;

        [Required]
        public DateTime ShowDate { get; set; } = DateTime.Today;

        [Range(1, 10, ErrorMessage = "You can book between 1 and 10 tickets.")]
        public int NumberOfTickets { get; set; }

        public DateTime? CancellationDate { get; set; }
    }
}
