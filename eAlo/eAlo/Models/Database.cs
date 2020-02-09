using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace eAlo.Models
{
    public class Database
    {

        private String Connection = "";
        public static SqlConnection connection;
        public static SqlDataReader reading;

        public SqlConnection DatabaseCon(String Connection)
        {

            this.Connection = Connection;

            if (this.Connection.Equals("EAloBusinessAndIndustry"))
            {
                this.Connection = "EAloBusinessAndInd";
            }
           
            else if (this.Connection.Equals("EAloFashionHelathBeauty"))
            {
                this.Connection = "EAloFashionHelathB";
            }
            else if (this.Connection.Equals("EAloHobySportsChild"))
            {
                this.Connection = "EAloHobySportsChil";
            }

            ///   this.Connection = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            /// connection = new SqlConnection("Server=.;Database=" + Connection + "; Integrated Security=true");
            connection = new SqlConnection("Data Source=SQL5003.site4now.net;Initial Catalog=DB_A486D2_"+this.Connection+";User Id=DB_A486D2_"+this.Connection+"_admin;Password=sa01762120546;");

            connection.Open();

            return connection;
        }




        public void setData(String Query)
        {

            //// DatabaseCon(this.Connection);
            SqlConnection sc = new SqlConnection();
            SqlCommand com = new SqlCommand();
           /// sc.ConnectionString = ("Data Source=.;Database=" + this.Connection + ";Integrated Security=True");
            sc.ConnectionString = ("Data Source=SQL5003.site4now.net;Initial Catalog=DB_A486D2_"+this.Connection+";User Id=DB_A486D2_"+this.Connection+"_admin;Password=sa01762120546;");
            sc.Open();
            com.Connection = sc;


            com.CommandText = (Query);
            com.ExecuteNonQuery();
            sc.Close();
        }

        public void getData(String Query)
        {


            SqlCommand comand = new SqlCommand(

            Query, connection);

            reading = comand.ExecuteReader();



        }
        public int Empty(String x)
        {

            char[] a = x.ToCharArray();

            int len = x.Length;

            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] == ' ')
                {
                    len--;
                }
            }
            return len;
        }



    }
}