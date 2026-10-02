using System.Web.Mvc;
using MovieBooking.Models;
using movie_booking.Models;

namespace Movie_Booking.Controllers
{
    public class UserController : Controller
    {
        Moviehandler db = new Moviehandler();

        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        // POST: Login
        [HttpPost]
        public ActionResult Login(User user)
        {
            if (ModelState.IsValid)
            {
                var loggedUser = db.User_Login(user);
 
                if (loggedUser != null)
                {
                    // Store user data in Session
                    Session["User_ID"] = loggedUser.User_ID;
                    Session["User_Name"] = loggedUser.User_Name;

                    return RedirectToAction(
                        "Index",
                        "Movie"
                    );
                }
                else
                {
                    ViewBag.Message =
                        "Invalid Username or Password";
                }
            }

            return View(user);
        }

        // Logout
        public ActionResult Logout()
        {
            Session.Clear();

            return RedirectToAction("Login");
        }
    }
}