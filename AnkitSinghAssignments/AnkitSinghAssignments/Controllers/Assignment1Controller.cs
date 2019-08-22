using AnkitSinghAssignments.Models;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace AnkitSinghAssignments.Controllers
{
    public class Assignment1Controller : Controller
    {
        // View Page call.
        public ViewResult Index()
        {
            return View();
        }

        [HttpGet]
        public ViewResult RsvpForm()
        {
            return View();
        }

        #region Post form data to database and sent mail to the user.
        [HttpPost]
        public ViewResult RsvpForm(GuestResponse guestResponse)
        {
            if (ModelState.IsValid)
            {
                //var body = "<p style='color:red;margin:20px;font-size:24px'>Email From: DailA Dabba </p><p style='color:green;margin:20px;font-size:20px'>Message:Your account created. thanks for using Dail A Dabba.</p><pstyle='color:red;margin:20px;font-size:24px'>Welcome to our Dabba Service</p>";
                //var message = new MailMessage();
                //message.To.Add(new MailAddress(guestResponse.Email));  // Sender email id
                //message.From = new MailAddress("aress.iphone5@gmail.com");  // From email
                //message.Subject = "Test email from webapp";
                //message.Body = string.Format(body);
                //message.IsBodyHtml = true;

                //using (var smtp = new SmtpClient())
                //{
                //    var credential = new NetworkCredential
                //    {
                //        UserName = "aress.iphone5@gmail.com",
                //        Password = "Aress123$"
                //    };
                //    smtp.Credentials = credential;
                //    smtp.Host = "smtp.gmail.com";
                //    smtp.Port = 587;
                //    smtp.EnableSsl = true;
                //    smtp.Send(message);
                //}

                // Insert form data to database.
                string connectionString = ConfigurationManager.ConnectionStrings["GuestListContext"].ConnectionString;

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO GuestList(Name, Email, Phone, WillAttend) VALUES(@name, @email, @phone, @willAttend)", con))
                    {
                        cmd.Parameters.AddWithValue("@name", guestResponse.Name);
                        cmd.Parameters.AddWithValue("@email", guestResponse.Email);
                        cmd.Parameters.AddWithValue("@phone", guestResponse.Phone);
                        cmd.Parameters.AddWithValue("@willAttend", guestResponse.WillAttend);

                        con.Open();
                        cmd.ExecuteNonQuery();
                        return View("Thanks", guestResponse);
                    }
                }
            }
            else
            {
                // To show validation errors.
                return View();
            }
        }
        #endregion

    }
}