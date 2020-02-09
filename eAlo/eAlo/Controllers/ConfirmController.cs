using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eAlo.Controllers
{
    public class ConfirmController : Controller
    {
        // GET: Confirm
        public ActionResult Confirm()
        {

            if (Session["Email"]==null)
            {
                return Redirect("~/Login/Login");
            }

            return View();
          //  return Redirect("~/" + Session["DTB"] + "/" + Session["Cat"] + "?Area=" + Session["City"] + "***" + Session["Region"] + "***" + Session["DTB"] + "***" + Session["Cat"]);
        }
    }
}