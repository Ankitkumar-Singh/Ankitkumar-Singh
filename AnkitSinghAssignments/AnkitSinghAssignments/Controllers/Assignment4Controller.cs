using AnkitSinghAssignments.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace AnkitSinghAssignments.Controllers
{
    /// <summary></summary>
    /// <seealso cref="System.Web.Mvc.Controller" />
    public class Assignment4Controller : Controller
    {
        private GuestManagementEntities db = new GuestManagementEntities();

        // GET: Assignment4
        public ActionResult Index()
        {
            return View(db.GuestLists.ToList());
        }

        // GET: Assignment4/Details/5
        /// <summary>Show detailses of specified identifier.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GuestList guestList = db.GuestLists.Find(id);
            if (guestList == null)
            {
                return HttpNotFound();
            }
            return View(guestList);
        }

        // GET: Assignment4/Create
        public ActionResult Create()
        {
            return View();
        }


        /// <summary>Creates the specified guest list.</summary>
        /// <param name="guestList">The guest list.</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GuestId,Name,Email,Phone,WillAttend")] GuestList guestList)
        {
            if (ModelState.IsValid)
            {
                db.GuestLists.Add(guestList);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(guestList);
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GuestList guestList = db.GuestLists.Find(id);
            if (guestList == null)
            {
                return HttpNotFound();
            }
            return View(guestList);
        }


        /// <summary>Edits the specified guest list.</summary>
        /// <param name="guestList">The guest list.</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GuestId,Name,Email,Phone,WillAttend")] GuestList guestList)
        {
            if (ModelState.IsValid)
            {
                db.Entry(guestList).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(guestList);
        }

        /// <summary>Deletes the specified identifier.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GuestList guestList = db.GuestLists.Find(id);
            if (guestList == null)
            {
                return HttpNotFound();
            }
            return View(guestList);
        }

        /// <summary>Deletes the confirmed.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GuestList guestList = db.GuestLists.Find(id);
            db.GuestLists.Remove(guestList);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

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
