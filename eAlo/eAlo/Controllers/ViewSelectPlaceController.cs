using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eAlo.Controllers
{
    public class ViewSelectPlaceController : Controller
    {
        // GET: ViewSelectPlace
        public ActionResult ViewSelectPlace()
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


            Models.SelectPlace ss = new Models.SelectPlace();
            ss.DTB = "Paga";
            ss.Cat = "Duli";
            return View(ss);
        }
    }
}