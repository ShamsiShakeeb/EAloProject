using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eAlo.Controllers
{
    public class AdminController : Controller
    {

        public String Space(String x)
        {
            String res = "";
            char[] a = x.ToCharArray();
            for(int i = 0; i < x.Length; i++)
            {
                res += a[i];
            }
            return res;

        }

        class getData : Models.Database
        {

            public ArrayList email = new ArrayList();
            public ArrayList PID = new ArrayList();
            public ArrayList UserDetails = new ArrayList();
            public ArrayList price = new ArrayList();
            public ArrayList FixedDetails = new ArrayList();
            public ArrayList Phone = new ArrayList();
            public int DataCount = 0;
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
                        Fd += "\n";
                    }
                }
                return Fd;

            }

            public void theData()
            {
                DatabaseCon("EAlo");
                getData("Select * from ApproveTable");
                int count = 0;

                while (reading.Read())
                {
                    if (count != 0)
                    {
                        email.Add(reading[7].ToString());
                        PID.Add(reading[8].ToString());
                        Phone.Add(reading[9].ToString());
                        UserDetails.Add(Value(reading[5].ToString()));
                        price.Add(Value(reading[6].ToString()));
                        FixedDetails.Add(Value(reading[4].ToString()));
                        DataCount++;
                    }
                    count++;
                }
                DatabaseCon("EAlo").Close();
            }
            public ArrayList theImg(String email,String PID)
            {
                ArrayList imgList = new ArrayList();
                DatabaseCon("EAlo");
                getData("Select img1,img2,img3,img4,img5 from ApproveTable where UID="+"'"+email   +"' and PID="+"'" +PID     +"'");
                while (reading.Read())
                {
                    imgList.Add(reading[0].ToString());
                    imgList.Add(reading[1].ToString());
                    imgList.Add(reading[2].ToString());
                    imgList.Add(reading[3].ToString());
                    imgList.Add(reading[4].ToString());
                    break;
                }
                DatabaseCon("EAlo").Close();
                return imgList;
            }

        }

        class ApproveData : Models.Database
        {
            public String[] getData(String email , String PID)
            {
                String[] x = new String[15];
                DatabaseCon("EAlo");
                getData("Select * from ApproveTable where UID=" + "'" + email + "' and PID=" + "'" + PID + "'");
                while (reading.Read())
                {
                    x[0] = reading[0].ToString();
                    x[1] = reading[1].ToString();
                    x[2] = reading[2].ToString();
                    x[3] = reading[3].ToString();
                    x[4] = reading[4].ToString();
                    x[5] = reading[5].ToString();
                    x[6] = reading[6].ToString();
                    x[7] = reading[7].ToString();
                    x[8] = reading[8].ToString();
                    x[9] = reading[9].ToString();
                    x[10] = reading[10].ToString();
                    x[11] = reading[11].ToString();
                    x[12] = reading[12].ToString();
                    x[13] = reading[13].ToString();
                    x[14] = reading[14].ToString();
                    break;
                }
                DatabaseCon("EAlo").Close();
                return x;
            }
        }

        public static Boolean adminV = false;

        // GET: Admin
        public ActionResult Admin()
        {
            if (Session["AdminLogin"] != null)
            {
                try
                {
                    if (!Request.Params["Password"].Equals("EAlo") && !Request.Params["Admin"].Equals("EAlo"))
                    {
                        adminV = true;
                    }
                }
                catch (Exception e)
                {
                    if (adminV == false)
                    {
                        return Redirect("~/EAlo/EAlo");
                    }
                }

                getData gd = new getData();
                gd.theData();
                Models.ListOfApproveTable loa = new Models.ListOfApproveTable();
                loa.email = gd.email;
                loa.UserDetails = gd.UserDetails;
                loa.FixedDetails = gd.FixedDetails;
                loa.price = gd.price;
                loa.PID = gd.PID;
                loa.Phone = gd.Phone;
                loa.count = gd.DataCount;
                return View(loa);
            }
            else
            {
                return Redirect("~/AdminLogin/AdminLogin");
            }
        }
        public ActionResult ViewImg()
        {
            Models.ListOfImg loi = new Models.ListOfImg();
            String email = Request.Params["UID"].ToString();
            String PID = Request.Params["PID"].ToString();
            getData gd = new getData();
           
            loi.img = gd.theImg(email, PID); 

            return View(loi);
        }
        public ActionResult Approve()
        {

            String UID = Request.Params["UID"].ToString() ;
            String PID = Request.Params["PID"].ToString() ;
            Models.Database db = new Models.Database();
            ApproveData apd = new ApproveData();
            String[] x= apd.getData(UID, PID);
            db.DatabaseCon("EAloAllInfo");
            db.setData("Insert into InfoTable (Dates,DTB,Cat,City,Region,FixedDetails,UserDetails,Price,UID,PID,Phone,img1,img2,img3,img4,img5) values(" + "'" + "Dates" + "'," + "'" + x[0] + "'," + "'" + x[1] + "'," + "'" + x[2] + "'," + "'" + x[3] + "'," + "'" + x[4] + "'," + "'" + x[5] + "'," + "'" + x[6] + "'," + "'" + x[7] + "'," + "'" + x[8] + "'," + "'" + x[9] + "'," + "'" + x[10] + "'," + "'" + x[11] + "'," + "'" + x[12] + "'," + "'" + x[13] + "'," + "'" + x[14] + "'" + ")");
            //db.DatabaseCon("EAloAllInfo").Close();
            db.DatabaseCon("EAloCity");
            db.setData("Insert into "+Space(x[2])+" (Dates,DTB,Cat,City,Region,FixedDetails,UserDetails,Price,UID,PID,Phone,img1,img2,img3,img4,img5) values(" + "'" + "Dates" + "'," + "'" + x[0] + "'," + "'" + x[1] + "'," + "'" + x[2] + "'," + "'" + x[3] + "'," + "'" + x[4] + "'," + "'" + x[5] + "'," + "'" + x[6] + "'," + "'" + x[7] + "'," + "'" + x[8] + "'," + "'" + x[9] + "'," + "'" + x[10] + "'," + "'" + x[11] + "'," + "'" + x[12] + "'," + "'" + x[13] + "'," + "'" + x[14] + "'" + ")");
           /// db.DatabaseCon("EAloCity").Close();
            db.DatabaseCon("EAlo"+Space(x[0]));
            db.setData("Insert into " + "Cetagory" + " (Dates,DTB,Cat,City,Region,FixedDetails,UserDetails,Price,UID,PID,Phone,img1,img2,img3,img4,img5) values(" + "'" + "Dates" + "'," + "'" + x[0] + "'," + "'" + x[1] + "'," + "'" + x[2] + "'," + "'" + x[3] + "'," + "'" + x[4] + "'," + "'" + x[5] + "'," + "'" + x[6] + "'," + "'" + x[7] + "'," + "'" + x[8] + "'," + "'" + x[9] + "'," + "'" + x[10] + "'," + "'" + x[11] + "'," + "'" + x[12] + "'," + "'" + x[13] + "'," + "'" + x[14] + "'" + ")");
           // db.DatabaseCon("EAlo" + Space(x[0])).Close();
            db.DatabaseCon("EAlo");
            db.setData("Delete from ApproveTable where UID=" + "'" + UID + "' and PID=" + "'" + PID + "'");
           // db.DatabaseCon("EAlo").Close();
            



            return Redirect("~/Admin/Admin?Password=EAlo&Admin=EAlo");
        }
        public ActionResult Delete()
        {

            String UID = Request.Params["UID"].ToString();
            String PID = Request.Params["PID"].ToString();
            Models.Database db = new Models.Database();
            db.DatabaseCon("EAlo");
            db.setData("Delete from ApproveTable where UID='" + UID + "' And PID='" + PID+ "'");
            return Redirect("~/Admin/Admin?Password=EAlo&Admin=EAlo");
        }
    }
}




