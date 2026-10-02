using System.Web.Mvc;
using MovieBooking.Models;
using movie_booking.Models;

namespace Movie_Booking.Controllers
{
    public class MovieCategoryController : Controller
    {
        Moviehandler db = new Moviehandler();

        // GET
        public ActionResult Index()
        {
            var data = db.Get_Movie_Category();

            return View(data);
        }

        // GET
        public ActionResult Create()
        {
            return View();
        }

        // POST
        [HttpPost]
        public ActionResult Create(Movie_Category mc)
        {
            if (ModelState.IsValid)
            {
                db.Add_Movie_category(mc);

                return RedirectToAction("Index");
            }

            return View(mc);
        }
    }
}