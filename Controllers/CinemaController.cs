
using Microsoft.AspNetCore.Mvc;
using CinemaBookingMVC.Models;

namespace CinemaBookingMVC.Controllers
{
    public class CinemaController : Controller
    {
        private static List<Movie> movies = new List<Movie>
        {
            new Movie
            {
                MovieId = 1,
                MovieName = "Avengers: Endgame",
                Genre = "Action",
                Language = "English",
                TicketPrice = 200,
                AvailableSeats = 100
            },
            new Movie
            {
                MovieId = 2,
                MovieName = "3 Idiots",
                Genre = "Comedy",
                Language = "Hindi",
                TicketPrice = 150,
                AvailableSeats = 80
            },
            new Movie
            {
                MovieId = 3,
                MovieName = "Jawan",
                Genre = "Action",
                Language = "Hindi",
                TicketPrice = 180,
                AvailableSeats = 60
            }
        };

        private static List<Booking> bookings = new List<Booking>();
        private static int nextBookingId = 1;

        public IActionResult Index()
        {
            ViewBag.Movies = movies;
            return View(bookings);
        }

        [HttpGet]
        public IActionResult BookTicket()
        {
            ViewBag.Movies = movies;
            return View(new Booking());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult BookTicket(Booking booking)
        {
            var movie = movies.FirstOrDefault(m => m.MovieId == booking.MovieId);

            if (movie == null)
            {
                ModelState.AddModelError("MovieId", "Please select a valid movie.");
            }
            else if (booking.NumberOfTickets > movie.AvailableSeats)
            {
                ModelState.AddModelError(
                    "NumberOfTickets",
                    "Not enough seats are available."
                );
            }

            if (!ModelState.IsValid)
            {
                ViewBag.Movies = movies;
                return View(booking);
            }

            booking.BookingId = nextBookingId++;
            booking.BookingDate = DateTime.Today;
            booking.CancellationDate = null;

            movie!.AvailableSeats -= booking.NumberOfTickets;
            bookings.Add(booking);

            TempData["Success"] = "Your ticket booking was successful!";

            return RedirectToAction(nameof(Index));
        }

        public IActionResult MovieDetails(int id)
        {
            var booking = bookings.FirstOrDefault(b => b.BookingId == id);

            if (booking == null)
            {
                return NotFound();
            }

            ViewBag.Movie = movies.FirstOrDefault(
                m => m.MovieId == booking.MovieId
            );

            return View(booking);
        }

        public IActionResult About()
        {
            return View();
        }
    }
}
