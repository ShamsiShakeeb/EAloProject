﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eAlo.Controllers
{
    public class PropertyController : Controller
    {

        private void Images(HttpPostedFileBase Image, HttpPostedFileBase Image1, HttpPostedFileBase Image2, HttpPostedFileBase Image3, HttpPostedFileBase Image4, String PID)
        {
            try
            {

                if (Image.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(Image.FileName);
                    this.img1 = PID + "-1-" + fileName;

                    var path = Path.Combine(Server.MapPath("~/Content/PostImg"), this.img1);
                    Image.SaveAs(path);
                }
            }
            catch (Exception e)
            {

            }
            try
            {
                if (Image1.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(Image1.FileName);
                    this.img2 = PID + "-2-" + fileName;
                    var path = Path.Combine(Server.MapPath("~/Content/PostImg"), this.img2);
                    Image1.SaveAs(path);
                }
            }
            catch (Exception e)
            {

            }
            try
            {
                if (Image2.ContentLength > 0)
                {

                    var fileName = Path.GetFileName(Image2.FileName);
                    this.img3 = PID + "-3-" + fileName;
                    var path = Path.Combine(Server.MapPath("~/Content/PostImg"), this.img3);
                    Image2.SaveAs(path);
                }
            }
            catch (Exception e)
            {

            }
            try
            {
                if (Image3.ContentLength > 0)
                {

                    var fileName = Path.GetFileName(Image3.FileName);
                    this.img4 = PID + "-4-" + fileName;
                    var path = Path.Combine(Server.MapPath("~/Content/PostImg"), this.img4);
                    Image3.SaveAs(path);
                }
            }
            catch (Exception e)
            {

            }
            try
            {
                if (Image4.ContentLength > 0)
                {

                    var fileName = Path.GetFileName(Image4.FileName);
                    this.img5 = PID + "-5-" + fileName;
                    var path = Path.Combine(Server.MapPath("~/Content/PostImg"), this.img5);
                    Image4.SaveAs(path);
                }
            }
            catch (Exception e)
            {

            }
        }


        public String img1 = "", img2 = "", img3 = "", img4 = "", img5 = "";

        public String space(String x)
        {
            char[] a = x.ToCharArray();
            String res = "";
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != ' ')
                {
                    res += a[i];
                }
            }
            return res;

        }


        class TheValues : Models.Database
        {
            public String Value()
            {
                DatabaseCon("EAlo");
                getData("Select * from OutputTable");
                String kabadi = "";
                while (reading.Read())
                {
                    kabadi += reading[0];
                }
                DatabaseCon("EAlo").Close();

                String[] splt = kabadi.Split('*');
                String rs = "";
                for (int i = 0; i < splt.Length; i++)
                {
                    try
                    {
                        int x = Convert.ToInt32(splt[i]);
                        rs += (char)x;
                    }
                    catch (Exception e)
                    {
                        return rs;
                    }
                }

                return rs;
            }

            public String getTheLastPID()
            {
                DatabaseCon("EAlo");

                getData("SELECT TOP 1 * FROM ApproveTable");
                String Data = "";
                while (reading.Read())
                {
                    Data = reading[8].ToString();
                    break;
                }
                DatabaseCon("EAlo").Close();
                return Data;
            }
        }


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

        private String AscciStar(String Value)
        {
            char[] a = Value.ToCharArray();
            String FixD = "";
            for (int i = 0; i < a.Length; i++)
            {
                if (!(a[i] == '<' && a[i + 1] == 'b' && a[i + 2] == 'r' && a[i + 3] == '/' && a[i + 4] == '>'))
                    FixD += (int)a[i] + "*";
                else
                {

                    FixD += a[i];
                    FixD += a[i + 1];
                    FixD += a[i + 2];
                    FixD += a[i + 3];

                    FixD += a[i + 4];



                    FixD += "*";
                    i++; i++; i++; i++; i++;
                }
            }
            return FixD;
        }

        // GET: Property
        public ActionResult ComercialSpace()
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


            if (Session["Email"].ToString().Equals("Null"))
            {
                return Redirect("~/Login/Login");
            }

            String Area = Request.Params["Area"];

            String[] Ans = getParms(Area);

            Models.MobilePhone mp = new Models.MobilePhone();
            mp.City = Ans[0];
            mp.Region = Ans[1];
            mp.DTB = Ans[2];
            mp.Cat = Ans[3];

            Session["DTB"] = Ans[2];
            Session["Cat"] = Ans[3];
            Session["City"] = Ans[0];
            Session["Region"] = Ans[1];
            return View();
        }

        [HttpPost]
        public ActionResult ComercialSpace(HttpPostedFileBase Image, HttpPostedFileBase Image1, HttpPostedFileBase Image2, HttpPostedFileBase Image3, HttpPostedFileBase Image4, String item_type, String size,  String size1, String address, String title, String description, String price2, String MaxMinprice, String negotiable)
        {
            TheValues tv = new TheValues();

            if (Session["Email"].ToString().Equals("Null"))
            {
                return Redirect("~/Login/Login");
            }

            String x = (Convert.ToInt32(space(tv.getTheLastPID())) + 1).ToString();

            Images(Image, Image1, Image2, Image3, Image4, x);



            Models.MobilePhone mb = new Models.MobilePhone();


            /* */

            mb.FixedDetails = "প্রপার্টির ধরণ: " + item_type + " <br/> ফ্ল্যাটের আয়তন: " + size + " <br/> " + "আয়তন টাইপ: " + size1 + " <br/> " + "ঠিকানা: " + address + " <br/> ";

            mb.Price = price2 + "" + "" + MaxMinprice + "" + negotiable;

            mb.UserDetails = "বিজ্ঞাপন শিরোনাম: " + title + " <br/> " + "বিবরণ: " + description;

            /* */


            Models.Database db = new Models.Database();

            db.DatabaseCon("EAlo");
            db.setData("Insert into ApproveTable(DTB,Cat,City,Region,FixedDetails,Price,UID,UserDetails,PID,img1,img2,img3,img4,img5,Phone) values(" + "'" + Session["DTB"].ToString() + "'," + "'" + Session["Cat"].ToString() + "'," + "'" + Session["City"].ToString() + "'," + "'" + Session["Region"].ToString() + "'," + "'" + AscciStar(mb.FixedDetails) + "'," + "'" + AscciStar(mb.Price) + "'," + "'" + Session["Email"].ToString() + "'," + "'" + AscciStar(mb.UserDetails) + "'," + "'" + x + "'," + "'" + this.img1 + "'," + "'" + this.img2 + "'," + "'" + this.img3 + "'," + "'" + this.img4 + "'," + "'" + this.img5 + "'," + "'" + Session["Phone"].ToString() + "'" + ")");
            db.DatabaseCon("EAlo");
            db.setData("Update ApproveTable set PID= '" + x + "' where UID='UID'");

            return Redirect("~/Confirm/Confirm");
            // return Redirect("~/" + Session["DTB"] + "/" + Session["Cat"] + "?Area=" + Session["City"] + "***" + Session["Region"] + "***" + Session["DTB"] + "***" + Session["Cat"]);

        }

        public ActionResult FlatAndApartment()
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



            if (Session["Email"].ToString().Equals("Null"))
            {
                return Redirect("~/Login/Login");
            }

            String Area = Request.Params["Area"];

            String[] Ans = getParms(Area);

            Models.MobilePhone mp = new Models.MobilePhone();
            mp.City = Ans[0];
            mp.Region = Ans[1];
            mp.DTB = Ans[2];
            mp.Cat = Ans[3];

            Session["DTB"] = Ans[2];
            Session["Cat"] = Ans[3];
            Session["City"] = Ans[0];
            Session["Region"] = Ans[1];
            return View();
        }
        [HttpPost]
        public ActionResult FlatAndApartment(HttpPostedFileBase Image, HttpPostedFileBase Image1, HttpPostedFileBase Image2, HttpPostedFileBase Image3, HttpPostedFileBase Image4, String bedrooms, String bathrooms, String size, String address, String title, String description, String price2,String MaxMinprice, String negotiable)
        {

            TheValues tv = new TheValues();

            if (Session["Email"].ToString().Equals("Null"))
            {
                return Redirect("~/Login/Login");
            }

            String x = (Convert.ToInt32(space(tv.getTheLastPID())) + 1).ToString();

            Images(Image, Image1, Image2, Image3, Image4, x);



            Models.MobilePhone mb = new Models.MobilePhone();


            /* */

            mb.FixedDetails = "বেড: "+bathrooms + " <br/> " + "বাথ: "+bathrooms+ " <br/> " + "ফ্ল্যাটের আয়তন: "+size + " <br/> " + "ঠিকানা: "+address+" <br/> ";

            mb.Price = price2 +  "" +""+MaxMinprice + "" + negotiable;

            mb.UserDetails = "বিজ্ঞাপন শিরোনাম: "+title+" <br/> "+ "বিবরণ: "+description;

            /* */


            Models.Database db = new Models.Database();

            db.DatabaseCon("EAlo");
            db.setData("Insert into ApproveTable(DTB,Cat,City,Region,FixedDetails,Price,UID,UserDetails,PID,img1,img2,img3,img4,img5,Phone) values(" + "'" + Session["DTB"].ToString() + "'," + "'" + Session["Cat"].ToString() + "'," + "'" + Session["City"].ToString() + "'," + "'" + Session["Region"].ToString() + "'," + "'" + AscciStar(mb.FixedDetails) + "'," + "'" + AscciStar(mb.Price) + "'," + "'" + Session["Email"].ToString() + "'," + "'" + AscciStar(mb.UserDetails) + "'," + "'" + x + "'," + "'" + this.img1 + "'," + "'" + this.img2 + "'," + "'" + this.img3 + "'," + "'" + this.img4 + "'," + "'" + this.img5 + "'," + "'" + Session["Phone"].ToString() + "'" + ")");
            db.DatabaseCon("EAlo");
            db.setData("Update ApproveTable set PID= '" + x + "' where UID='UID'");

            return Redirect("~/Confirm/Confirm");
            // return Redirect("~/" + Session["DTB"] + "/" + Session["Cat"] + "?Area=" + Session["City"] + "***" + Session["Region"] + "***" + Session["DTB"] + "***" + Session["Cat"]);

        }

        public ActionResult Garraze()
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


            if (Session["Email"].ToString().Equals("Null"))
            {
                return Redirect("~/Login/Login");
            }

            String Area = Request.Params["Area"];

            String[] Ans = getParms(Area);

            Models.MobilePhone mp = new Models.MobilePhone();
            mp.City = Ans[0];
            mp.Region = Ans[1];
            mp.DTB = Ans[2];
            mp.Cat = Ans[3];

            Session["DTB"] = Ans[2];
            Session["Cat"] = Ans[3];
            Session["City"] = Ans[0];
            Session["Region"] = Ans[1];
            return View();
        }


        [HttpPost]
        public ActionResult Garraze(HttpPostedFileBase Image, HttpPostedFileBase Image1, HttpPostedFileBase Image2, HttpPostedFileBase Image3, HttpPostedFileBase Image4, String address, String title, String description, String price2, String negotiable)
        {
            TheValues tv = new TheValues();

            if (Session["Email"].ToString().Equals("Null"))
            {
                return Redirect("~/Login/Login");
            }

            String x = (Convert.ToInt32(space(tv.getTheLastPID())) + 1).ToString();

            Images(Image, Image1, Image2, Image3, Image4, x);



            Models.MobilePhone mb = new Models.MobilePhone();



            mb.Price = price2 + "" + negotiable;


            String a0 = "ঠিকানা : " + address + " <br/> ";
            String a1 = "বিজ্ঞাপন শিরোনাম : " + title + " <br/> ";
            String a2 = "বিবরণ : " + description + " <br/> ";

            mb.FixedDetails = a0;
            mb.UserDetails = a1 + a2;



            Models.Database db = new Models.Database();

            db.DatabaseCon("EAlo");
            db.setData("Insert into ApproveTable(DTB,Cat,City,Region,FixedDetails,Price,UID,UserDetails,PID,img1,img2,img3,img4,img5,Phone) values(" + "'" + Session["DTB"].ToString() + "'," + "'" + Session["Cat"].ToString() + "'," + "'" + Session["City"].ToString() + "'," + "'" + Session["Region"].ToString() + "'," + "'" + AscciStar(mb.FixedDetails) + "'," + "'" + AscciStar(mb.Price) + "'," + "'" + Session["Email"].ToString() + "'," + "'" + AscciStar(mb.UserDetails) + "'," + "'" + x + "'," + "'" + this.img1 + "'," + "'" + this.img2 + "'," + "'" + this.img3 + "'," + "'" + this.img4 + "'," + "'" + this.img5 + "'," + "'" + Session["Phone"].ToString() + "'" + ")");
            db.DatabaseCon("EAlo");
            db.setData("Update ApproveTable set PID= '" + x + "' where UID='UID'");

            return Redirect("~/Confirm/Confirm");
            //return Redirect("~/" + Session["DTB"] + "/" + Session["Cat"] + "?Area=" + Session["City"] + "***" + Session["Region"] + "***" + Session["DTB"] + "***" + Session["Cat"]);
        }

        public ActionResult House()
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



            if (Session["Email"].ToString().Equals("Null"))
            {
                return Redirect("~/Login/Login");
            }

            String Area = Request.Params["Area"];

            String[] Ans = getParms(Area);

            Models.MobilePhone mp = new Models.MobilePhone();
            mp.City = Ans[0];
            mp.Region = Ans[1];
            mp.DTB = Ans[2];
            mp.Cat = Ans[3];

            Session["DTB"] = Ans[2];
            Session["Cat"] = Ans[3];
            Session["City"] = Ans[0];
            Session["Region"] = Ans[1];
            return View();
        }


        [HttpPost]
        public ActionResult House(HttpPostedFileBase Image, HttpPostedFileBase Image1, HttpPostedFileBase Image2, HttpPostedFileBase Image3, HttpPostedFileBase Image4, String bedrooms, String bathrooms, String land_size, String house_size, String address, String title, String description, String price2, String negotiable)
        {
            TheValues tv = new TheValues();

            if (Session["Email"].ToString().Equals("Null"))
            {
                return Redirect("~/Login/Login");
            }

            String x = (Convert.ToInt32(space(tv.getTheLastPID())) + 1).ToString();

            Images(Image, Image1, Image2, Image3, Image4, x);



            Models.MobilePhone mb = new Models.MobilePhone();



            mb.Price = price2 + "" + negotiable;


            String a0 = "বেড : " + bedrooms + " <br/> ";
            String a1 = "বাথ : " + bathrooms + " <br/> ";
            String a2 = "জমির আয়তন : " + land_size + " <br/> ";
            String a3 = "বাড়ির আয়তন : " + house_size + " <br/> ";
            String a4 = "ঠিকানা : " + address + " <br/> ";
            String a5 = "বিজ্ঞাপন শিরোনাম : " + title + " <br/> ";
            String a6 = "বিবরণ : " + description + " <br/> ";

            mb.FixedDetails = a0 + a1 + a2 + a3 + a4;
            mb.UserDetails = a5 + a6;



            Models.Database db = new Models.Database();

            db.DatabaseCon("EAlo");
            db.setData("Insert into ApproveTable(DTB,Cat,City,Region,FixedDetails,Price,UID,UserDetails,PID,img1,img2,img3,img4,img5,Phone) values(" + "'" + Session["DTB"].ToString() + "'," + "'" + Session["Cat"].ToString() + "'," + "'" + Session["City"].ToString() + "'," + "'" + Session["Region"].ToString() + "'," + "'" + AscciStar(mb.FixedDetails) + "'," + "'" + AscciStar(mb.Price) + "'," + "'" + Session["Email"].ToString() + "'," + "'" + AscciStar(mb.UserDetails) + "'," + "'" + x + "'," + "'" + this.img1 + "'," + "'" + this.img2 + "'," + "'" + this.img3 + "'," + "'" + this.img4 + "'," + "'" + this.img5 + "'," + "'" + Session["Phone"].ToString() + "'" + ")");
            db.DatabaseCon("EAlo");
            db.setData("Update ApproveTable set PID= '" + x + "' where UID='UID'");
            return Redirect("~/Confirm/Confirm");

            //   return Redirect("~/" + Session["DTB"] + "/" + Session["Cat"] + "?Area=" + Session["City"] + "***" + Session["Region"] + "***" + Session["DTB"] + "***" + Session["Cat"]);
        }

        public ActionResult NewDevelopment()
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


            if (Session["Email"].ToString().Equals("Null"))
            {
                return Redirect("~/Login/Login");
            }

            String Area = Request.Params["Area"];

            String[] Ans = getParms(Area);

            Models.MobilePhone mp = new Models.MobilePhone();
            mp.City = Ans[0];
            mp.Region = Ans[1];
            mp.DTB = Ans[2];
            mp.Cat = Ans[3];

            Session["DTB"] = Ans[2];
            Session["Cat"] = Ans[3];
            Session["City"] = Ans[0];
            Session["Region"] = Ans[1];
            return View();
        }



        public ActionResult PlotAndLand()
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


            if (Session["Email"].ToString().Equals("Null"))
            {
                return Redirect("~/Login/Login");
            }

            String Area = Request.Params["Area"];

            String[] Ans = getParms(Area);

            Models.MobilePhone mp = new Models.MobilePhone();
            mp.City = Ans[0];
            mp.Region = Ans[1];
            mp.DTB = Ans[2];
            mp.Cat = Ans[3];

            Session["DTB"] = Ans[2];
            Session["Cat"] = Ans[3];
            Session["City"] = Ans[0];
            Session["Region"] = Ans[1];
            return View();
        }


        [HttpPost]
        public ActionResult PlotAndLand(HttpPostedFileBase Image, HttpPostedFileBase Image1, HttpPostedFileBase Image2, HttpPostedFileBase Image3, HttpPostedFileBase Image4,String item_type , String item_type1, String item_type2, String item_type3, String size, String size1, String address, String title, String description, String price2,String MaxMinprice, String negotiable)
        {
            TheValues tv = new TheValues();

            if (Session["Email"].ToString().Equals("Null"))
            {
                return Redirect("~/Login/Login");
            }

            String x = (Convert.ToInt32(space(tv.getTheLastPID())) + 1).ToString();

            Images(Image, Image1, Image2, Image3, Image4, x);



            Models.MobilePhone mb = new Models.MobilePhone();


            /* */

            mb.FixedDetails = "জমির ধরণ: "+item_type+""+item_type1+""+item_type2+""+item_type3+ " <br/> জমির আয়তন: " + size+ " <br/> " + "আয়তন টাইপ: "+size1+ " <br/> " + "ঠিকানা: "+address+" <br/> ";

            mb.Price = price2 + "" + "" + MaxMinprice + "" + negotiable;

            mb.UserDetails = "বিজ্ঞাপন শিরোনাম: " + title + " <br/> " + "বিবরণ: " + description;

            /* */


            Models.Database db = new Models.Database();

            db.DatabaseCon("EAlo");
            db.setData("Insert into ApproveTable(DTB,Cat,City,Region,FixedDetails,Price,UID,UserDetails,PID,img1,img2,img3,img4,img5,Phone) values(" + "'" + Session["DTB"].ToString() + "'," + "'" + Session["Cat"].ToString() + "'," + "'" + Session["City"].ToString() + "'," + "'" + Session["Region"].ToString() + "'," + "'" + AscciStar(mb.FixedDetails) + "'," + "'" + AscciStar(mb.Price) + "'," + "'" + Session["Email"].ToString() + "'," + "'" + AscciStar(mb.UserDetails) + "'," + "'" + x + "'," + "'" + this.img1 + "'," + "'" + this.img2 + "'," + "'" + this.img3 + "'," + "'" + this.img4 + "'," + "'" + this.img5 + "'," + "'" + Session["Phone"].ToString() + "'" + ")");
            db.DatabaseCon("EAlo");
            db.setData("Update ApproveTable set PID= '" + x + "' where UID='UID'");

            return Redirect("~/Confirm/Confirm");
            // return Redirect("~/" + Session["DTB"] + "/" + Session["Cat"] + "?Area=" + Session["City"] + "***" + Session["Region"] + "***" + Session["DTB"] + "***" + Session["Cat"]);


        }
    }
}