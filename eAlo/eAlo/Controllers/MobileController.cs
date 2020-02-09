using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace eAlo.Controllers
{
    public class MobileController : Controller
    {


        private void Images(HttpPostedFileBase Image, HttpPostedFileBase Image1, HttpPostedFileBase Image2, HttpPostedFileBase Image3, HttpPostedFileBase Image4, String PID)
        {
            try
            {

                if (Image.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(Image.FileName);
                    this.img1 = PID+"-1-"+fileName;

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


        public String img1="", img2="", img3="", img4="", img5="";

        public String space(String x)
        {
            char[] a = x.ToCharArray();
            String res = "";
            for(int i = 0; i < a.Length; i++)
            {
                if(a[i]!=' ')
                {
                    res += a[i];
                }
            }
            return res;

        }


        class TheValues: Models.Database
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
                for(int i = 0; i < splt.Length; i++)
                {
                    try
                    {
                        int x = Convert.ToInt32(splt[i]);
                        rs += (char) x;
                    }
                    catch(Exception e)
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
            
            for(int i = 0; i < a.Length; i++)
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
                if(!(a[i]=='<' && a[i+1]=='b' && a[i + 2] == 'r' && a[i + 3] == '/' && a[i + 4] == '>'))
                FixD += (int)a[i] + "*";
                else
                {
                    
                    FixD += a[i];
                    FixD += a[i + 1];
                    FixD += a[i+2];
                    FixD += a[i + 3];
                    
                    FixD += a[i + 4];
                    


                    FixD +="*";
                    i++;i++; i++; i++;i++;
                }
            }
            return FixD;
        }










        // GET: Mobile
       
        public ActionResult MobilePhone()
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
           // return Redirect("~/Mobile/MobilePhone?Area="+this.City+"***"+this.Region+"***"+this.DTB+"***"+this.Cat);
        }
        [HttpPost]
        public ActionResult MobilePhone(HttpPostedFileBase Image, HttpPostedFileBase Image1, HttpPostedFileBase Image2, HttpPostedFileBase Image3, HttpPostedFileBase Image4,String used,String brand,String model,String songskoron,String fields1, String fields2, String fields3, String fields4, String fields5, String fields6, String fields7, String fields8, String fields9, String fields10, String fields11, String fields12, String fields13,String description,String geniune,String price,String negotiable)
        {
            TheValues tv = new TheValues();

            if (Session["Email"].ToString().Equals("Null"))
            {
                return Redirect("~/Login/Login");
            }

            String x = (Convert.ToInt32(space(tv.getTheLastPID())) + 1).ToString();
            
            Images(Image,Image1,Image2,Image3,Image4,x);

          

            Models.MobilePhone mb = new Models.MobilePhone();


            /* */

            mb.FixedDetails = "কন্ডিশন: " + used + " <br/> " + "ব্র্যান্ড: " + brand + " <br/> " + "মডেল: " + model + " <br/> " + "ফিচার: " + fields1 + "" + fields2 + "" + fields3 + "" + fields4 + "" + fields5 + "" + fields6 + "" + fields7 + "" + fields8 + "" + fields9 + "" + fields10 + "" + fields11 + "" + fields12 + "" + fields13 + " <br/> " + "সংস্করণ: " + songskoron + " <br/> " + "জেনুইন: " + geniune + " <br/> ";
            
            mb.Price = price + "" + negotiable;
            
            mb.UserDetails = description;
            
            /* */

           
            Models.Database db = new Models.Database();
            
            db.DatabaseCon("EAlo");
            db.setData("Insert into ApproveTable(DTB,Cat,City,Region,FixedDetails,Price,UID,UserDetails,PID,img1,img2,img3,img4,img5,Phone) values(" + "'" + Session["DTB"].ToString() + "'," + "'" + Session["Cat"].ToString() + "'," + "'" + Session["City"].ToString() + "'," + "'" + Session["Region"].ToString() + "'," + "'" + AscciStar(mb.FixedDetails) + "'," + "'" + AscciStar(mb.Price) + "'," + "'" + Session["Email"].ToString() + "'," + "'" + AscciStar(mb.UserDetails) + "'," + "'" + x + "'," + "'" + this.img1 + "'," + "'" + this.img2 + "'," + "'" + this.img3 + "'," + "'" + this.img4 + "'," + "'" + this.img5 + "'," + "'" + Session["Phone"].ToString()  +"'"+      ")");
            db.DatabaseCon("EAlo");
            db.setData("Update ApproveTable set PID= '" + x + "' where UID='UID'");

            return Redirect("~/Confirm/Confirm");
            //  return Redirect("~/Mobile/MobilePhone?Area=" + Session["City"] + "***" + Session["Region"] + "***" + Session["DTB"] + "***" + Session["Cat"]);
        }




        public ActionResult MobilePhoneAndAccsories()
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
        public ActionResult MobilePhoneAndAccsories(HttpPostedFileBase Image, HttpPostedFileBase Image1, HttpPostedFileBase Image2, HttpPostedFileBase Image3, HttpPostedFileBase Image4,String item_type,String condition,String Heading,String Description,String price,String negotiable)
        {
            TheValues tv = new TheValues();
            String x = (Convert.ToInt32(space(tv.getTheLastPID())) + 1).ToString();

            Images(Image, Image1, Image2, Image3, Image4, x);

            Models.MobilePhone mb = new Models.MobilePhone();

            mb.FixedDetails = "পণ্যের ধরণ = " + item_type + " <br/> " + "কন্ডিশন = " + condition + " <br/> ";
            
            mb.Price = price + "" + negotiable;

            mb.UserDetails = "বিজ্ঞাপন শিরোনাম: " + Heading + " <br/> " + "বিবরণ: " + Description + "";

            Models.Database db = new Models.Database();

            db.DatabaseCon("EAlo");
            db.setData("Insert into ApproveTable(DTB,Cat,City,Region,FixedDetails,Price,UID,UserDetails,PID,img1,img2,img3,img4,img5,Phone) values(" + "'" + Session["DTB"].ToString() + "'," + "'" + Session["Cat"].ToString() + "'," + "'" + Session["City"].ToString() + "'," + "'" + Session["Region"].ToString() + "'," + "'" + AscciStar(mb.FixedDetails) + "'," + "'" + AscciStar(mb.Price) + "'," + "'" + Session["Email"].ToString() + "'," + "'" + AscciStar(mb.UserDetails) + "'," + "'" + x + "'," + "'" + this.img1 + "'," + "'" + this.img2 + "'," + "'" + this.img3 + "'," + "'" + this.img4 + "'," + "'" + this.img5 + "',"+"'"+Session["Phone"].ToString()    +"'" + ")");
            db.DatabaseCon("EAlo");
            db.setData("Update ApproveTable set PID= '" + x + "' where UID='UID'");

            return Redirect("~/Confirm/Confirm");
            // return Redirect("~/Mobile/MobilePhoneAndAccsories?Area=" + Session["City"] + "***" + Session["Region"] + "***" + Session["DTB"] + "***" + Session["Cat"]);
        }

        public ActionResult SimCard()
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
        public ActionResult SimCard(HttpPostedFileBase Image, HttpPostedFileBase Image1, HttpPostedFileBase Image2, HttpPostedFileBase Image3, HttpPostedFileBase Image4,String condition,String Heading,String description,String price,String negotiable)
        {
            if (Session["Email"].ToString().Equals("Null"))
            {
                return Redirect("~/Login/Login");
            }

            TheValues tv = new TheValues();
            String x = (Convert.ToInt32(space(tv.getTheLastPID())) + 1).ToString();

            Images(Image, Image1, Image2, Image3, Image4, x);

            Models.MobilePhone mb = new Models.MobilePhone();

            mb.FixedDetails = "কন্ডিশন: " + condition + " <br/> ";

            mb.UserDetails = "বিজ্ঞাপন শিরোনাম: " + Heading + " <br/> " + "বিবরণ: " + description + "";

            mb.Price = price + "" + negotiable;

            Models.Database db = new Models.Database();

            db.DatabaseCon("EAlo");
            db.setData("Insert into ApproveTable(DTB,Cat,City,Region,FixedDetails,Price,UID,UserDetails,PID,img1,img2,img3,img4,img5,Phone) values(" + "'" + Session["DTB"].ToString() + "'," + "'" + Session["Cat"].ToString() + "'," + "'" + Session["City"].ToString() + "'," + "'" + Session["Region"].ToString() + "'," + "'" + AscciStar(mb.FixedDetails) + "'," + "'" + AscciStar(mb.Price) + "'," + "'" + Session["Email"].ToString() + "'," + "'" + AscciStar(mb.UserDetails) + "'," + "'" + x + "'," + "'" + this.img1 + "'," + "'" + this.img2 + "'," + "'" + this.img3 + "'," + "'" + this.img4 + "'," + "'" + this.img5 + "'," + "'" + Session["Phone"].ToString() + "'"  + ")");
            db.DatabaseCon("EAlo");
            db.setData("Update ApproveTable set PID= '" + x + "' where UID='UID'");

            return Redirect("~/Confirm/Confirm");
            // return Redirect("~/Mobile/SimCard?Area=" + Session["City"] + "***" + Session["Region"] + "***" + Session["DTB"] + "***" + Session["Cat"]);
        }


        public ActionResult MobilePhoneService()
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
        public ActionResult MobilePhoneService(HttpPostedFileBase Image, HttpPostedFileBase Image1, HttpPostedFileBase Image2, HttpPostedFileBase Image3, HttpPostedFileBase Image4, String condition, String Heading, String description, String price, String negotiable)
        {
            TheValues tv = new TheValues();
            String x = (Convert.ToInt32(space(tv.getTheLastPID())) + 1).ToString();

            Images(Image, Image1, Image2, Image3, Image4, x);

            Models.MobilePhone mb = new Models.MobilePhone();

            mb.FixedDetails = "কন্ডিশন: " + condition + " <br/> ";

            mb.UserDetails = "বিজ্ঞাপন শিরোনাম: " + Heading + " <br/> " + "বিবরণ: " + description + "";

            mb.Price = price + "" + negotiable;

            Models.Database db = new Models.Database();

            db.DatabaseCon("EAlo");
            db.setData("Insert into ApproveTable(DTB,Cat,City,Region,FixedDetails,Price,UID,UserDetails,PID,img1,img2,img3,img4,img5,Phone) values(" + "'" + Session["DTB"].ToString() + "'," + "'" + Session["Cat"].ToString() + "'," + "'" + Session["City"].ToString() + "'," + "'" + Session["Region"].ToString() + "'," + "'" + AscciStar(mb.FixedDetails) + "'," + "'" + AscciStar(mb.Price) + "'," + "'" + Session["Email"].ToString() + "'," + "'" + AscciStar(mb.UserDetails) + "'," + "'" + x + "'," + "'" + this.img1 + "'," + "'" + this.img2 + "'," + "'" + this.img3 + "'," + "'" + this.img4 + "'," + "'" + this.img5 + "'," + "'" + Session["Phone"].ToString() + "'" +  ")");
            db.DatabaseCon("EAlo");
            db.setData("Update ApproveTable set PID= '" + x + "' where UID='UID'");

            return Redirect("~/Confirm/Confirm");
            // return Redirect("~/Mobile/MobilePhoneService?Area=" + Session["City"] + "***" + Session["Region"] + "***" + Session["DTB"] + "***" + Session["Cat"]);
        }




    }
}