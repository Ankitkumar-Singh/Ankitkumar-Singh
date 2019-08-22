using AnkitSinghAssignments.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace AnkitSinghAssignments.Controllers
{
    public class Assignment2Controller : Controller
    {
        // To show (list) all guest on index view.
        /// <summary>Indexes this instance.</summary>
        /// <returns> Guest list in view</returns>
        public ActionResult Index()
        {
            GuestListContext guestListContext = new GuestListContext();
            List<ListOfGuest> guests = guestListContext.ListOfGuest.ToList();
            return View(guests);
        }

        //To show specific guest deatils with selected id.
        /// <summary>Guestshows the specified identifier.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Signle user detials</returns>
        public ActionResult Guestshow(int id)
        {
            GuestListContext guestListContext = new GuestListContext();
            ListOfGuest guest = guestListContext.ListOfGuest.Single(x => x.GuestId == id);
            return View(guest);
        }

    }
}
