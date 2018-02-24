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
    public partial class Transaction : System.Web.UI.Page
    {
        SqlConnection conn1;
        string uid;
        int rblTranCat;
        protected void Page_Load(object sender, EventArgs e)
        {
            uid = Session["name"].ToString();
            conn1 = new SqlConnection();
            rblTranCat = rblTranType.SelectedIndex;
            rblTranCat += 1;
        }

        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]

        public static List<string> PaymentMode(String prefixText, int count)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "SELECT Type FROM dbo.PaymentMode WHERE Type LIKE @SearchText + '%'";
                    cmd.Parameters.AddWithValue("@SearchText", prefixText);
                    cmd.Connection = conn;
                    conn.Open();
                    List<string> PayMode = new List<string>();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            PayMode.Add(sdr["Type"].ToString());
                        }
                    }
                    conn.Close();
                    return PayMode;
                }
            }
        }


        
        
        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> Categories(String prefixText, int count)
        {
            
            
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "SELECT CategoryName, TransactionTypeId FROM dbo.Category WHERE  CategoryName LIKE @SearchText + '%' ";
                    //cmd.CommandText = "SELECT CategoryName, TransactionTypeId FROM dbo.Category, dbo.TransactionType WHERE Category.TransactionTypeId = TransactionType.TransactionTypeId AND CategoryName LIKE @SearchText + '%' ";
                    cmd.Parameters.AddWithValue("@SearchText", prefixText);
                    cmd.Connection = conn;
                    conn.Open();
                    List<string> Category = new List<string>();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            Category.Add(sdr["CategoryName"].ToString());
                        }
                    }
                    conn.Close();
                    return Category;
                }
            }
        }

        protected void btnRecord_Click(object sender, EventArgs e)
        {
            conn1.ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            conn1.Open();

            string date = tbTranDate.Text;
            int transactionType = rblTranType.SelectedIndex;
            string paymentMode = tbPayMode.Text;
            string category = tbTranCategory.Text;
            string transactionName = tbTranNAme.Text;
            string details = tbDetails.Text;
            int amount = Int32.Parse(tbAmout.Text);
            

            int CategoryId, PayModeId;
            transactionType += 1;
            //Response.Write(category);

            //Getting the Category ID
            string getCategoryID = "SELECT CategoryId FROM Category WHERE CategoryName = '" + category + "' ";
            SqlCommand cmdCatId = new SqlCommand(getCategoryID, conn1);
            CategoryId =(int) cmdCatId.ExecuteScalar();


            //Getting the payment Mode ID
            string getPaymentModeID = "SELECT PaymentModeId FROM PaymentMode WHERE Type = '" + paymentMode + "' ";
            SqlCommand cmdPayId = new SqlCommand(getPaymentModeID, conn1);
            PayModeId = (int)cmdPayId.ExecuteScalar();


            string queryInsert = "INSERT INTO Records(TranDate, TransactionTypeId, PaymentModeId, CategoryId, Amount, Contents, Details) VALUES ('"+date+"','"+transactionType+"','"+PayModeId+"','"+CategoryId+"','"+amount+"', '"+transactionName+"', '"+details+"');" ;
            SqlCommand cmd1 = new SqlCommand(queryInsert, conn1);
            cmd1.ExecuteNonQuery();

            //Clearing the tb.
            tbAmout.Text = "";
            tbDetails.Text = "";
            tbPayMode.Text = "";
            tbTranCategory.Text = "";
            tbTranDate.Text = "";
            tbTranNAme.Text = "";

            Response.Write("<script>alert('Transaction Recorded..!!')</script>");
            Response.Redirect("Transaction.aspx");
        }
    }
}