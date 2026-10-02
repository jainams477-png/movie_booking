using System.Linq;
using System.Web.Mvc;
using MovieBooking.Models;
using movie_booking.Models;

namespace Movie_Booking.Controllers
{
    public class BookingController : Controller
    {
        Moviehandler db = new Moviehandler();

        // Booking Page
        public ActionResult Create()
        {
            ViewBag.Movies = db.Get_All_Movies();

            return View();
        }

        // Book Ticket
        [HttpPost]
        public ActionResult Create(booking b)
        {
            // Get selected movie
            var movie = db.Get_All_Movies()
                          .FirstOrDefault(x => x.Movie_ID == b.Movie_ID);

            if (movie != null)
            {
                // Get category from movie
                b.Cat_ID = movie.Cat_ID;

                // Calculate amount
                b.amount = movie.rate * b.no_tickets;

                db.Add_Booking(b);
            }

            return RedirectToAction("Index");
        }

        // Display Bookings
        public ActionResult Index()
        {
            var data = db.Get_All_Bookings();

            return View(data);
        }
    }
}