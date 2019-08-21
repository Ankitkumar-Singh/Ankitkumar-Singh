using AnkitSinghAssignments.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Mvc;

namespace WebApplication5.Controllers
{
    public class Assignment9Controller : Controller
    {
        //DepartmentNewDataModel object is created
        private GuestManagementEntities1 db = new GuestManagementEntities1();

        #region "Index action method  with search and sort"        
        /// <summary>
        /// Index Action Method Contains Search,Sort And Pagination FunctioNALITY
        /// </summary>
        /// <param name="searchBy"></param>
        /// <param name="search"></param>
        /// <param name="page"></param>
        /// <param name="sortBy"></param>
        /// <returns></returns>
        public ActionResult Index(string searchBy, string search, int? page, string sortBy)
        {

            var dept = db.DepartmentNewTables.AsQueryable();
            ViewBag.SortNameParameter = String.IsNullOrEmpty(sortBy) ? "Dept_Name desc" : "";
            ViewBag.SortIdParameter = String.IsNullOrEmpty(sortBy) ? "Dept_Id desc" : "";

            if (searchBy == "DepartmentName")
            {
                dept = (db.DepartmentNewTables.Where(x => x.Dept_Name == search || search == null));
            }
            else if (searchBy == "Location")
            {
                dept = (db.DepartmentNewTables.Where(x => x.Location == search || search == null));
            }
            else if (searchBy == "TotalEmployee")
            {
                dept = db.DepartmentNewTables.Where(x => x.TotalEmployee.ToString().StartsWith(search));
            }
            else
            {
                dept = (db.DepartmentNewTables.Where(x => x.Dept_Details.Equals(search) || search == null));
            }

            switch (sortBy)
            {
                case "Dept_Name desc":
                    dept = dept.OrderByDescending(x => x.Dept_Name);
                    break;

                case "Dept_Id desc":
                    dept = dept.OrderByDescending(x => x.Dept_Id);
                    break;

                default:
                    dept = dept.OrderBy(x => x.Location);
                    break;
            }

            return View(dept.ToPagedList(page ?? 1, 4));

        }
        #endregion

        #region TO delete Multiple selected values
        [HttpPost]
        public ActionResult MultipleDelete(IEnumerable<int> departmentDelete)
        {
            foreach (var item in departmentDelete)
            {
                var delete = db.DepartmentNewTables.FirstOrDefault(s => s.Dept_Id == item);
                if (delete != null)
                {
                    db.DepartmentNewTables.Remove(delete);
                }
            }

            db.SaveChanges();
            return RedirectToAction("Index");
        }
        #endregion

        [HandleError]
        public ActionResult notFound()
        {
            return View();
        }

        #region "Dispose Method"       
        /// <summary>
        /// Dispose Method to dispose the database object
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        #endregion
    }
}
