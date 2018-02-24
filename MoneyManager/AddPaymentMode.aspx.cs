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
    public partial class AddPaymentMode : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection();
        }

        protected void btnAddPayMode_Click(object sender, EventArgs e)
        {
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            conn.Open();

            string type = tbPaymentModeType.Text;

 
            string queryInsert = "INSERT INTO dbo.PaymentMode (Type) VALUES ('"+type+"')";
            SqlCommand cmd = new SqlCommand(queryInsert, conn);
            cmd.ExecuteNonQuery();

            conn.Close();

            tbPaymentModeType.Text = "";
            Response.Write("<script>alert('Payment Mode Added..!!')</script>");
        }
    }
}