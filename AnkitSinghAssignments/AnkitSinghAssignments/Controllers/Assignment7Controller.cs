using AnkitSinghAssignments.Models;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace AnkitSinghAssignments.Controllers
{
    public class Assignment7Controller : Controller
    {
        private GuestManagementEntities db = new GuestManagementEntities();

        // GET: Assignment7
        public ActionResult Index()
        {
            return View(db.UserComments.ToList());
        }

        // GET: Assignment7/Details/5

        // GET: Assignment7/Create
        public ActionResult Create()
        {
            return View();
        }

        #region Adding bold, underscore text fromatting.

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "Id,UserName,Comments")] UserComment userComment)
        {
            StringBuilder sbComments = new StringBuilder();
            sbComments.Append(HttpUtility.HtmlEncode(userComment.Comments));

            sbComments.Replace("&lt;b&gt;", "<b>");
            sbComments.Replace("&lt;/b&gt;", "</b>");
            sbComments.Replace("&lt;u&gt;", "<u>");
            sbComments.Replace("&lt;/u&gt;", "</u>");
            userComment.Comments = sbComments.ToString();

            // HTML encode the text that is coming from name textbox
            string strEncodedName = HttpUtility.HtmlEncode(userComment.UserName);
            userComment.UserName = strEncodedName;

            if (ModelState.IsValid)
            {
                db.UserComments.Add(userComment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userComment);
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
