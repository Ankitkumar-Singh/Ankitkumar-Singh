using AnkitSinghAssignments.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using System.Reflection;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Web.UI;

namespace AnkitSinghAssignments.TableHelper
{
    public static class TableHelper
    {
        #region Table Helper with employee list as parameter
        /// <summary>
        /// Tables the specified emp.
        /// </summary>
        /// <param name="helper">The helper.</param>
        /// <param name="emp">The emp.</param>
        /// <returns></returns>
        public static HtmlString Table(this HtmlHelper helper, List<UserComment> emp)
        {
            if (helper is null)
            {
                throw new ArgumentNullException(nameof(helper));
            }
            HtmlTable ht = new HtmlTable();
            //Get the columns
            HtmlTableRow htColumnsRow = new HtmlTableRow();
            typeof(UserComment).GetProperties().Select(prop =>
            {
                HtmlTableCell htCell = new HtmlTableCell();
                htCell.InnerText = prop.Name;
                return htCell;
            }).ToList().ForEach(cell => htColumnsRow.Cells.Add(cell));
            ht.Rows.Add(htColumnsRow);
            //Get the remaining rows
            emp.ForEach(delegate (UserComment obj)
            {
                HtmlTableRow htRow = new HtmlTableRow();
                obj.GetType().GetProperties().ToList().ForEach(delegate (PropertyInfo prop)
                {
                    HtmlTableCell htCell = new HtmlTableCell();
                    htCell.InnerText = prop.GetValue(obj, null).ToString();
                    htRow.Cells.Add(htCell);
                });
                ht.Rows.Add(htRow);
            });
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            ht.RenderControl(hw);
            String HTMLContent = sb.ToString();
            return new MvcHtmlString(sb.ToString());
        }
        #endregion

        #region Table Helper with employee list and class as parameter
        /// <summary>
        /// Tables the specified data.
        /// </summary>
        /// <param name="helper">The helper.</param>
        /// <param name="Data">The data.</param>
        /// <param name="class">The class.</param>
        /// <returns></returns>
        public static IHtmlString Table(this HtmlHelper helper, List<UserComment> emp, string @class)
        {
            if (helper is null)
            {
                throw new ArgumentNullException(nameof(helper));
            }
            HtmlTable ht = new HtmlTable();
            ht.Attributes.Add("class", @class);
            //Get the columns
            HtmlTableRow htColumnsRow = new HtmlTableRow();
            typeof(UserComment).GetProperties().Select(prop =>
            {
                HtmlTableCell htCell = new HtmlTableCell();
                htCell.InnerText = prop.Name;
                return htCell;
            }).ToList().ForEach(cell => htColumnsRow.Cells.Add(cell));
            ht.Rows.Add(htColumnsRow);
            //Get the remaining rows
            emp.ForEach(delegate (UserComment obj)
            {
                HtmlTableRow htRow = new HtmlTableRow();
                obj.GetType().GetProperties().ToList().ForEach(delegate (PropertyInfo prop)
                {
                    HtmlTableCell htCell = new HtmlTableCell();
                    htCell.InnerText = prop.GetValue(obj, null).ToString();
                    htRow.Cells.Add(htCell);
                });
                ht.Rows.Add(htRow);
            });
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            ht.RenderControl(hw);
            String HTMLContent = sb.ToString();
            return new MvcHtmlString(sb.ToString());
        }
        #endregion
    }
}
