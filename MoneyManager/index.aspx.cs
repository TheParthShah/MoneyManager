using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace MoneyManager
{
    public partial class index : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            conn.Open();
        }

        protected void btnlogin_Click(object sender, EventArgs e)
        {
            string uname = tbuname.Text;
            string pwd = tbpwd.Text;

            //Retriving the User Name and Password
            string SelectUserQuery = "SELECT * FROM dbo.UserLogin WHERE UserName='" + uname + "' AND Password='" + pwd + "' ";
            SqlDataAdapter adapter = new SqlDataAdapter(SelectUserQuery, conn);

            //Filling the DataSet
            DataSet ds = new DataSet();
            adapter.Fill(ds);

            //Retriving the Users FullName
            string UserNameQuery = "SELECT UserId, FullName FROM UserLogin WHERE UserName='" + uname + "'";
            SqlDataAdapter adapter2 = new SqlDataAdapter(UserNameQuery, conn);

            DataSet ds2 = new DataSet();
            adapter2.Fill(ds2);


            //if the data is present or not
            if (ds.Tables[0].Rows.Count > 0)
            {
                Session["id"] = ds2.Tables[0].Rows[0]["UserId"].ToString();
                Session["name"] = ds2.Tables[0].Rows[0]["FullName"].ToString();
                Response.Redirect("Home.aspx");
            }
            else
            {
                Response.Write("<script>alert('invalid username and password')</script>");
            }
        }
    }
}