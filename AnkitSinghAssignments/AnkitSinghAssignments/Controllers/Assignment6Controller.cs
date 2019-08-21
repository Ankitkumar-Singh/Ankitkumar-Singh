using AnkitSinghAssignments.Models;
using System.Linq;
using System.Web.Mvc;

namespace AnkitSinghAssignments.Controllers
{
    public class Assignment6Controller : Controller
    {
        private GuestManagementEntities db = new GuestManagementEntities();

        // To show table helper 
        public ActionResult Index()
        {
            return View(db.UserComments.ToList());
        }

    }
}