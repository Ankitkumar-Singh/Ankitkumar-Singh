using AnkitSinghAssignments.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace AnkitSinghAssignments.Controllers
{
    public class Assignment2Controller : Controller
    {
        // To show (list) all guest on index view.
        public ActionResult Index()
        {
            GuestListContext guestListContext = new GuestListContext();
            List<ListOfGuest> guests = guestListContext.ListOfGuest.ToList();
            return View(guests);
        }

        //To show specific guest deatils with selected id.
        public ActionResult Guestshow(int id)
        {
            GuestListContext guestListContext = new GuestListContext();
            ListOfGuest guest = guestListContext.ListOfGuest.Single(x => x.GuestId == id);
            return View(guest);
        }

    }
}
