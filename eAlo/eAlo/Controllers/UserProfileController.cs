using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eAlo.Controllers
{
    public class UserProfileController : Controller
    {
        // GET: UserProfile
        public ActionResult UserProfile()
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



            if (Session["Email"]==null)
            {
                return Redirect("~/Login/Login");
            }
           

            return View();
        }
        public ActionResult Post()
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



            if (Session["Email"]==null)
            {
                return Redirect("~/Login/Login");
            }

            return View();
        }

        public ActionResult ProductCell()
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


            if (Session["Email"]==null)
            {
                return Redirect("~/Login/Login");
            }

            return View();
        }
        public ActionResult SelectPlace()
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


            if (Session["Email"]==null)
            {
                return Redirect("~/Login/Login");
            }
            Models.SelectPlace s = new Models.SelectPlace();
            s. DTB=Request.Params["DTB"];
            s.Cat = Request.Params["Cat"];

            return View(s);
        }
        public ActionResult Education()
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

            if (Session["Email"]==null)
            {
                return Redirect("~/Login/Login");
            }

            return View();
        }
        public ActionResult Property()
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


            if (Session["Email"]==null)
            {
                return Redirect("~/Login/Login");
            }

            return View();
        }

    }
}