using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eAlo.Controllers
{
    public class PagaController : Controller
    {

        private String[] getParms(String Area)
        {
            String[] Kabadi = new String[4];

            char[] a = Area.ToCharArray();
            int count = 0;
            int start = 0;

            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != '*')
                {

                    Kabadi[count] += a[i];
                }
                else
                {
                    start++;
                }
                if (start == 3)
                {
                    count++;
                    start = 0;
                }
            }

            return Kabadi;

        }



        // GET: Paga
        public ActionResult Duli()
        {

            String[] Kabadi = getParms(Request.Params["Area"].ToString());
            Session["TripleH"] = Kabadi[0];
            Session["Seth"] = Kabadi[1];

            return Redirect("~/Ads/Ads?Ops=allads&Page=1");
        }
        public ActionResult Dula()
        {

           // String[] Kabadi = getParms(Request.Params["Area"].ToString());
            Session["TripleH"] = null;
            Session["Seth"] = null;

            return Redirect("~/Ads/Ads?Ops=allads&Page=1");
        }
        public ActionResult Dulo()
        {
            Session["Query"] = null;
            return Redirect("~/Ads/Ads?Ops=allads&Page=1");
        }
        public ActionResult IccWorldCup2019()
        {
            return View();
        }

    }
}