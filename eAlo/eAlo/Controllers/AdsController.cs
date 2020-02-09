using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eAlo.Controllers
{
    public class AdsController : Controller
    {

        public static int index = 0;
        public static int incva=0;
        

        class getAds : Models.Database
        {

            public int page = 0;
            
           public getAds(int page)
            {
                this.page = page;
            }


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
                        Fd += "<br/>";
                    }
                }
                return Fd;

            }


            public String ValueH(String x)
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
                        Fd += "";
                    }
                }
                return Fd;

            }


            public ArrayList udH = new ArrayList();
            public ArrayList Fd = new ArrayList();
            public ArrayList price = new ArrayList();



            public ArrayList DTB = new ArrayList();
            public ArrayList Cat = new ArrayList();
            public ArrayList PID = new ArrayList();
            public ArrayList UID = new ArrayList();



            public ArrayList img = new ArrayList();

            public int count = 0;

            

            public String HeadLine(String Ud)
            {
                String result = "";
                char[] a = Ud.ToCharArray();
                for(int i = 0; i < a.Length; i++)
                {
                    if(a[i]=='<' && a[i+1]=='b' && a[i+2]=='r' && a[i+3]=='/' && a[i + 4] == '>')
                    {
                        break;
                    }
                    else
                    {
                        result += a[i];
                    }
                }
                return result;
            }

            public void AllData(String DatabaseName,String ColumnName,String WhereCluse,String Query,String xx ,String yy)
            {
                if (Query.Equals(" "))
                {
                    int lo = (this.page - 1) * 25;

                    DatabaseCon(DatabaseName);
                    if (WhereCluse.Equals("JohnCena") || WhereCluse.Equals("all"))
                    {
                        if (xx.Equals("Null"))
                        {
                            getData("Select DTB,Cat,FixedDetails,UserDetails,Price,UID,PID,img1 from " + ColumnName + " Order By ID desc Offset " + lo + " Rows FETCH NEXT 25 ROWS ONLY");
                        }
                        else
                        {
                            if (!(xx.Equals(yy)))
                            {
                                getData("Select DTB,Cat,FixedDetails,UserDetails,Price,UID,PID,img1 from " + ColumnName + " where City='" +xx+"' and Region='"+yy+"'"+" Order By ID desc Offset " + lo + " Rows FETCH NEXT 25 ROWS ONLY");
                            }
                            else
                            {
                                getData("Select DTB,Cat,FixedDetails,UserDetails,Price,UID,PID,img1 from " + ColumnName + " where City='" + xx + "'" + " Order By ID desc Offset " + lo + " Rows FETCH NEXT 25 ROWS ONLY");
                            }
                        }
                    }
                    else
                    {
                        if(xx.Equals("Null"))
                        getData("Select DTB,Cat,FixedDetails,UserDetails,Price,UID,PID,img1 from " + ColumnName + " Where Cat='" + WhereCluse + "' Order By ID desc Offset " + lo + " Rows FETCH NEXT 25 ROWS ONLY ");
                        else
                        {
                            if (xx.Equals(yy))
                            {
                                getData("Select DTB,Cat,FixedDetails,UserDetails,Price,UID,PID,img1 from " + ColumnName + " Where Cat='" + WhereCluse + "' and City='" + xx + "' " + " Order By ID desc Offset " + lo + " Rows FETCH NEXT 25 ROWS ONLY ");
                            }
                            else
                            {
                                getData("Select DTB,Cat,FixedDetails,UserDetails,Price,UID,PID,img1 from " + ColumnName + " Where Cat='" + WhereCluse + "' and City='" + xx + "' and Region='" +yy+"' " + " Order By ID desc Offset " + lo + " Rows FETCH NEXT 25 ROWS ONLY ");
                            }
                        }
                    }
                    while (reading.Read())
                    {
                        DTB.Add(reading[0].ToString());
                        Cat.Add(reading[1].ToString());
                        Fd.Add(ValueH(reading[2].ToString()));
                        udH.Add(HeadLine(Value(reading[3].ToString())));
                        price.Add(ValueH(reading[4].ToString()));
                        UID.Add(reading[5].ToString());
                        PID.Add(reading[6].ToString());
                        img.Add(reading[7].ToString());

                        count++;
                    }
                    DatabaseCon(DatabaseName).Close();
                }
                else
                {
                    int lo = index;

                    DatabaseCon(DatabaseName);
                    if (WhereCluse.Equals("JohnCena") || WhereCluse.Equals("all"))
                    {
                        if(xx.Equals("Null"))
                        getData("Select DTB,Cat,FixedDetails,UserDetails,Price,UID,PID,img1 from " + ColumnName + " Order By ID desc Offset " + lo + " rows");
                        else
                        {
                            if (xx.Equals(yy))
                            {
                                getData("Select DTB,Cat,FixedDetails,UserDetails,Price,UID,PID,img1 from " + ColumnName + " where City='"+xx+"'"+" Order By ID desc Offset " + lo + " rows");
                            }
                            else
                            {
                                getData("Select DTB,Cat,FixedDetails,UserDetails,Price,UID,PID,img1 from " + ColumnName + " where City='" + xx + "' and Region='"+yy+"'" + " Order By ID desc Offset " + lo + " rows");
                            }
                        }
                    }
                    else
                    {
                        if(xx.Equals("Null"))
                        getData("Select DTB,Cat,FixedDetails,UserDetails,Price,UID,PID,img1 from " + ColumnName + " Where Cat='" + WhereCluse + "' Order By ID desc Offset " + lo + " rows");
                        else
                        {
                            if(xx.Equals(yy))
                            getData("Select DTB,Cat,FixedDetails,UserDetails,Price,UID,PID,img1 from " + ColumnName + " Where Cat='" + WhereCluse + "' and City='"+xx+"'" +" Order By ID desc Offset " + lo + " rows");
                            else
                            {
                                getData("Select DTB,Cat,FixedDetails,UserDetails,Price,UID,PID,img1 from " + ColumnName + " Where Cat='" + WhereCluse + "' and City='" + xx + "' and Region='"+yy+"'" + " Order By ID desc Offset " + lo + " rows");
                            }
                        }
                    }
                    while (reading.Read())
                    {

                        index++;

                        String x = ValueH(reading[2].ToString()).ToLower();
                        String y = ValueH(reading[3].ToString()).ToLower();

                        String result = x + y;

                        if (result.Contains(Query.ToLower()))
                        {

                            DTB.Add(reading[0].ToString());
                            Cat.Add(reading[1].ToString());
                            Fd.Add(ValueH(reading[2].ToString()));
                            udH.Add(HeadLine(Value(reading[3].ToString())));
                            price.Add(ValueH(reading[4].ToString()));
                            UID.Add(reading[5].ToString());
                            PID.Add(reading[6].ToString());
                            img.Add(reading[7].ToString());

                            count++;

                            if (count == 25)
                                break;
                        }
                    }
                    DatabaseCon(DatabaseName).Close();
                }
            }
        }
        public static Boolean svr = false;
        public static int page = 0;
        public int srchPage = 0;

        public Boolean Query(String query)
        {
            int x = 0;
            try
            {
                x = query.Length;
            }
            catch
            {
                x = 0;
            }
            if (x == 0)
                return false;
            else
                return true;
        }

       
        // GET: Ads
        public ActionResult Ads(String query)
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
            






            String par=Request.Params["Ops"].ToString();
            page = Convert.ToInt32(Request.Params["Page"].ToString());

            if (par.Equals("allads"))
            {
                Models.Ads ad = new Models.Ads();
                getAds gd = new getAds(page);
                ad.inc = page;
                Session["Database"] = "allads";
                Session["Cetagory"] = "all";
                Boolean src = false;

                try
                {
                    String x = Request.Params["srch"].ToString();
                    if(Query(query) == false)
                    query = x;
                    else
                    {
                        index = 0;
                    }
                    src = true;
                }
                catch(Exception e)
                {
                    if (Query(query) == true)
                    {
                        index = 0;
                    }

                        src = false;
                }


                if (Query(query) == false && src==false)
                {
                    String x,y;
                    if (Session["TripleH"] == null)
                    {
                         x = "Null";
                         y = "Null";

                    }
                    else
                    {
                        x = Session["TripleH"].ToString();
                        y = Session["Seth"].ToString();
                    }
                    gd.AllData("EAloAllInfo", "InfoTable", "JohnCena", " ",x,y);
                }
                else
                {
                    String x, y;
                    if (Session["TripleH"] == null)
                    {
                        x = "Null";
                        y = "Null";

                    }
                    else
                    {
                        x = Session["TripleH"].ToString();
                        y = Session["Seth"].ToString();
                    }

                    Session["Query"] = query;
                    gd.AllData("EAloAllInfo", "InfoTable", "JohnCena", Session["Query"].ToString(),x,y);


                }
                ad.DTB = gd.DTB;
                ad.Cat = gd.Cat;
                ad.Fd = gd.Fd;
                ad.udH = gd.udH;
                ad.price = gd.price;
                ad.UID = gd.UID;
                ad.PID = gd.PID;
                ad.img = gd.img;

                ad.Count = gd.count;

                if (gd.count == 0)
                {
                        incva++;
                        index = 0;
                        if(incva<3)
                        return Redirect("~/Ads/Ads?Ops=allads&Page=1");
                       else
                      {
                        return View(ad);
                      }
                    
                }
                else
                    return View(ad);

            }

            else
            {
                Models.Ads ad = new Models.Ads();
                getAds gd = new getAds(page);
                Session["Database"] = par;
                try
                {
                    Session["Cetagory"] = Request.Params["Cat"].ToString();
                }
                catch(Exception e)
                {
                    Session["Cetagory"] = "JohnCena";
                }
                Boolean src = false;


                try
                {
                    String x = Request.Params["srch"].ToString();
                    if (Query(query) == false)
                        query = x;
                    else
                    {
                        index = 0;
                    }
                    src = true;
                }

                catch (Exception e)
                {
                    if (Query(query) == true)
                    {
                        index = 0;
                    }

                    src = false;
                }




                ad.inc = page;
                if (Session["Cetagory"].ToString().Equals("JohnCena"))
                {
                    if (Query(query) == false && src == false)
                    {

                        String x, y;
                        if (Session["TripleH"] == null)
                        {
                            x = "Null";
                            y = "Null";

                        }
                        else
                        {
                            x = Session["TripleH"].ToString();
                            y = Session["Seth"].ToString();
                        }

                        gd.AllData("EAlo" + Session["Database"].ToString(), "Cetagory", "JohnCena", " ",x,y);
                    }
                    else
                    {
                        String x, y;
                        if (Session["TripleH"] == null)
                        {
                            x = "Null";
                            y = "Null";

                        }
                        else
                        {
                            x = Session["TripleH"].ToString();
                            y = Session["Seth"].ToString();
                        }

                        Session["Query"] = query;
                        gd.AllData("EAlo" + Session["Database"].ToString(), "Cetagory", "JohnCena", Session["Query"].ToString(),x,y);
                    }
                }
                else
                {
                    if (Query(query) == false && src == false)
                    {
                        String x, y;
                        if (Session["TripleH"] == null)
                        {
                            x = "Null";
                            y = "Null";

                        }
                        else
                        {
                            x = Session["TripleH"].ToString();
                            y = Session["Seth"].ToString();
                        }
                        gd.AllData("EAlo" + Session["Database"].ToString(), "Cetagory", Session["Cetagory"].ToString(), " ",x,y);
                    }
                    else
                    {

                        String x, y;
                        if (Session["TripleH"] == null)
                        {
                            x = "Null";
                            y = "Null";

                        }
                        else
                        {
                            x = Session["TripleH"].ToString();
                            y = Session["Seth"].ToString();
                        }

                        Session["Query"] = query;
                        gd.AllData("EAlo" + Session["Database"].ToString(), "Cetagory", Session["Cetagory"].ToString(),Session["Query"].ToString(),x,y);
                    }
                }
                ad.DTB = gd.DTB;
                ad.Cat = gd.Cat;
                ad.Fd = gd.Fd;
                ad.udH = gd.udH;
                ad.price = gd.price;
                ad.UID = gd.UID;
                ad.PID = gd.PID;
                ad.img = gd.img;

                ad.Count = gd.count;

                if (svr == true)
                {
                    svr = false;
                    return View(ad);
                }
                
                if (gd.count == 0)
                {
                    svr = true;
                    return Redirect("~/Ads/Ads?Ops="+Session["Database"].ToString()+"&Page=1&Cat="+Session["Cetagory"]);
                    
                }
                else
                    return View(ad);




              
            }
        }
        [HttpPost]
        public ActionResult Ads(String query,String x)
        {


            if (Query(query) == true)
            {
                Session["Query"] = query;
                index = 0;
            }

            if(Session["Query"]==null)
            return Redirect("~/Ads/Ads?Ops="+Session["Database"]+"&Page="+(page+1)+"&Cat="+Session["Cetagory"]);
            else
            {
                return Redirect("~/Ads/Ads?Ops=" + Session["Database"] + "&Page=" + (srchPage + 1) + "&Cat=" + Session["Cetagory"]+"&srch="+Session["Query"].ToString());
            }
        }
        
    }
}