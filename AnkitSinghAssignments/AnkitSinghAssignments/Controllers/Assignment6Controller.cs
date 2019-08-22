using AnkitSinghAssignments.Models;
using System.Linq;
using System.Web.Mvc;

namespace AnkitSinghAssignments.Controllers
{
    public class Assignment6Controller : Controller
    {
        private GuestManagementEntities db = new GuestManagementEntities();

        /// <summary>Indexes this instance.</summary>
        /// <returns> To show table helper.</returns>
        public ActionResult Index()
        {
            return View(db.UserComments.ToList());
        }

    }
}