using AnkitSinghAssignments.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace AnkitSinghAssignments.Controllers
{
    public class Assignment4Controller : Controller
    {
        private GuestManagementEntities db = new GuestManagementEntities();

        // GET: Assignment4
        public ActionResult Index()
        {
            return View(db.GuestLists.ToList());
        }

        // GET: Assignment4/Details/5
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

        // POST: Assignment4/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: Assignment4/Edit/5
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

        // POST: Assignment4/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: Assignment4/Delete/5
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

        // POST: Assignment4/Delete/5
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
