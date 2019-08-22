using AnkitSinghAssignments.Models;
using System.Linq;
using System.Web.Mvc;

namespace AnkitSinghAssignments.Controllers
{
    public class Assignment11Controller : Controller
    {
        private GuestManagementEntities db = new GuestManagementEntities();

        #region Inserting values in databse.
        // Validating user email and inserting unique email id and user details in database.
        public ActionResult index()
        {
            return View();
        }

        // POST: Assignment11/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult index([Bind(Include = "GuestId,Name,Email,Phone,WillAttend")] GuestList guestList)
        {
            if (ModelState.IsValid)
            {
                db.GuestLists.Add(guestList);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(guestList);
        }
        #endregion

        #region "Check Email Availability"
        /// <summary>Determines whether [is email available] [the specified email].</summary>
        /// <param name="Email">The email.</param>
        /// <returns></returns>
        public JsonResult IsEmailAvailable(string Email)
        {
            return Json(!db.GuestLists.Any(x => x.Email == Email), JsonRequestBehavior.AllowGet);
        }
        #endregion

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }

}
