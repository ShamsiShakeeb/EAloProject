using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eAlo.Controllers
{
    public class AdminLoginController : Controller
    {
        // GET: AdminLogin
        public ActionResult AdminLogin(String a , String b)
        {
            try
            {
                if (a.Equals("EAlo") && b.Equals("EAlo"))
                {
                    Session["AdminLogin"] = "Done";
                    return Redirect("~/Admin/Admin?Password=EAlo&Admin=EAlo");
                }
                else
                {
                    Session["AdminLogin"] = null;
                }
            }
            catch(Exception e)
            {
                Session["AdminLogin"] = null;
            }
            return View();
        }
    }
}