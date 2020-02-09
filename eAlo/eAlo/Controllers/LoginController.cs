using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eAlo.Controllers
{
    public class LoginController : Controller
    {

        private class UserAccount : Models.Database
        {
            public String[]  Login(String account , String password)
            {
                String[] x = new String[2];
                x[0] = "No Data";

                
                    DatabaseCon("EAlo");
                    getData("Select Email,Phone from users where Email=" + "'" + account + "' and Password=" + "'" + password + "'");

                    while (reading.Read())
                    {
                        x[0] = reading[0].ToString();
                        x[1] = reading[1].ToString();
                        break;
                    }
                    DatabaseCon("EAlo").Close();
                    return x;
                
               
            }
        }

        // GET: Login
        public ActionResult Login(String account , String password)
        {


            string sua = Request.UserAgent.Trim().ToLower();

            var request = HttpContext.Request;



            if (request.Browser.IsMobileDevice)
            {
                sua += "*Mobile";
            }
            else
            {
                sua += "*Laptop/Desktop";
                //laptop or desktop
            }

            if (sua.Contains("iphone") || sua.Contains("ipad") || sua.Contains("android"))
            {
                Session["D"] = "Mobile";
            }
            else
            {
                String[] x = sua.Split('*');
                if (x[1].Equals("Mobile"))
                {
                    Session["D"] = "Mobile";
                }
                else
                {
                    Session["D"] = "Desktop";
                }
            }





            try
            {


                Session["Email"] = "Null";
                UserAccount ua = new UserAccount();
                String[] Email = ua.Login(account, password);
                if (!(Email[0].Equals("No Data")))
                {
                    Session["Email"] = Email[0];
                    Session["Phone"] = Email[1];
                    return Redirect("~/UserProfile/UserProfile");
                }
               



            }

            catch(Exception e)
            {
               
                return View();
            }

            return View();
        }
    }
}