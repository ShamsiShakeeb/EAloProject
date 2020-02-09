using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eAlo.Controllers
{
    public class RegistrationController : Controller
    {
        // GET: Registration
        public ActionResult Registration(String name , String email , String phone, String password,String password_confirm)
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



            Models.Registration rg = new Models.Registration();
            try
            {

                rg.name = name;
                rg.password = password;
                rg.email = email;
                rg.password_confrim = password_confirm;
                if (!(rg.password.Equals(rg.password_confrim)))
                {
                    rg.msg = "Password Doesnt Match";
                    
                }
                else
                {
                    Models.Database db = new Models.Database();
                    db.DatabaseCon("EAlo");
                    db.setData("Insert into users(Name,Email,Password,Phone) values(" +"'"+rg.name   +"'," + "'" + rg.email + "'," + "'" + rg.password + "',"+"'" +phone     +"'" + ")");
                  
                    ///Database
                }
                return View(rg);

            }
            catch(Exception e)
            {
                return View(rg);

            }

            
        }
    }
}