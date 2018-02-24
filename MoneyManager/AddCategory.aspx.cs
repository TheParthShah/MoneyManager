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
    public partial class AddCategory : System.Web.UI.Page
    {
        SqlConnection conn1;
        protected void Page_Load(object sender, EventArgs e)
        {
            conn1 = new SqlConnection();
        }
        

        protected void btnAddCategory_Click(object sender, EventArgs e)
        {
            conn1.ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            conn1.Open();

            int transactionType = rblTranType.SelectedIndex;
            string category = tbCategoryName.Text;

            transactionType += 1;

            string queryInsert = "INSERT INTO dbo.Category (CategoryName,TransactionTypeId) VALUES ('"+category+"','"+transactionType+"')";
            SqlCommand cmd = new SqlCommand(queryInsert,conn1);
            cmd.ExecuteNonQuery();

            conn1.Close();

            tbCategoryName.Text = "";
            Response.Write("<script>alert('Category Added..!!')</script>");


        }
    }
}