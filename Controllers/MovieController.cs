using System.Web.Mvc;
using MovieBooking.Models;
using movie_booking.Models;

namespace Movie_Booking.Controllers
{
    public class MovieController : Controller
    {
        Moviehandler db = new Moviehandler();

        // Display Movies
        public ActionResult Index()
        {
            var data = db.Get_All_Movies();

            ViewBag.Category = db.Get_Movie_Category();

            return View(data);
        }

        // Add Movie Page
        public ActionResult Create()
        {
            ViewBag.Category = db.Get_Movie_Category();

            return View();
        }

        // Add Movie
        [HttpPost]
        public ActionResult Create(Movie movie)
        {
            db.Add_Movie(movie);

            return RedirectToAction("Index");
        }

        // Display Movie By Category
        public ActionResult ByCategory(int id)
        {
            var data = db.Get_Movies_By_Category(id);

            ViewBag.Category = db.Get_Movie_Category();

            return View("Index", data);
        }
    }
}