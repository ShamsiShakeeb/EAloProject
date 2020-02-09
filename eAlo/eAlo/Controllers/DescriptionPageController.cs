using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eAlo.Controllers
{
    public class DescriptionPageController : Controller
    {
        class theData : Models.Database
        {


            public String Value(String x)
            {

                String[] a = x.Split('*');
                String Fd = "";
                for (int i = 0; i < a.Length; i++)
                {
                    try
                    {

                        Fd += (char)Convert.ToInt32(a[i]);

                    }
                    catch (Exception e)
                    {
                        Fd += a[i];
                    }
                }
                return Fd;

            }

            public String Ud = "";
            public String Fd = "";
            public String City = "";
            public String Region = "";
            public ArrayList Price = new ArrayList();
            public ArrayList Phone = new ArrayList();
            public ArrayList img = new ArrayList();

            public void getData(String DTB, String Cat , String PID)
            {
                DatabaseCon("EAlo" + DTB);
                getData("Select City,Region,UserDetails,FixedDetails,Price,Phone,img1,img2,img3,img4,img5 from Cetagory where Cat='" + Cat + "' And PID='" + PID+"'");
                while (reading.Read())
                {
                    City = reading[0].ToString();
                    Region = reading[1].ToString();
                    Ud=(Value(reading[2].ToString()));
                    Fd=(Value(reading[3].ToString()));
                    Price.Add(Value(reading[4].ToString()));
                    Phone.Add(reading[5].ToString());
                    img.Add(reading[6].ToString());
                    img.Add(reading[7].ToString());
                    img.Add(reading[8].ToString());
                    img.Add(reading[9].ToString());
                    img.Add(reading[10].ToString());
                   
                    break;
                }
                DatabaseCon("EAlo" + DTB).Close();
            }
        }

        public String[] brValue(String x)
        {
            ArrayList lol = new ArrayList();
            char[] a = x.ToCharArray();
            String boom = "";
            for(int i = 0; i < a.Length; i++)
            {
                if(a[i]=='<' && a[i+1]=='b' && a[i+2]=='r' && a[i+3]=='/' && a[i + 4] == '>')
                {
                    lol.Add(boom);
                    boom = "";
                    i++;
                    i++;
                    i++;
                    i++;
                }
                else
                boom += a[i];
            }

            String[] y;
            if (lol.Count != 0)
            {
                y= new String[lol.Count];
                for (int i = 0; i < y.Length; i++)
                {
                    y[i] = lol[i].ToString();
                }
            }
            else
            {
                y = new String[1];
                y[0] = boom;

            }
            return y;
        }
        
        // GET: DescriptionPage
        public ActionResult Description()
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

            String DTB="", Cat="", PID="";
            try
            {
                DTB = Request.Params["DTB"].ToString();
                Cat = Request.Params["Cat"].ToString();
                PID = Request.Params["PID"].ToString();
            }
            catch(Exception e)
            {
                String[] temp = new String[3];
                temp = Request.Params["DTB"].ToString().Split(' ');
                DTB = temp[0];
                Cat = temp[1];
                PID = temp[2];
            }

            theData data = new theData();
            data.getData(DTB, Cat, PID);
            Models.Decription des = new Models.Decription();
            des.Ud=brValue(data.Ud);
            des.Fd=brValue(data.Fd);
            des.Price = data.Price;
            des.Phone = data.Phone;
            des.img = data.img;
            des.City = data.City;
            des.Region = data.Region;
            des.DTB = DTB;
            des.Cat = Cat;

            return View(des);
        }

       
    }
}