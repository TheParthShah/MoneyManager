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
    public partial class EditCategory : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

            if (!IsPostBack)
            {
                gvbind();
            }
        }

        //binding data with the gridview
        protected void gvbind()
        {
            conn.Open();

            string selectQuery = "SELECT CategoryId,CategoryName,TransactionTypeName FROM dbo.Category,dbo.TransactionType WHERE Category.TransactionTypeId = TransactionType.TransactionTypeId";
            SqlCommand cmd = new SqlCommand(selectQuery, conn);

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataSet ds = new DataSet();
            da.Fill(ds);

            conn.Close();

            if (ds.Tables[0].Rows.Count > 0)
            {
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
            else
            {
                ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                GridView1.DataSource = ds;
                GridView1.DataBind();
                int columncount = GridView1.Rows[0].Cells.Count;
                GridView1.Rows[0].Cells.Clear();
                GridView1.Rows[0].Cells.Add(new TableCell());
                GridView1.Rows[0].Cells[0].ColumnSpan = columncount;
                GridView1.Rows[0].Cells[0].Text = "No Records Found";
            }
        }


        //Deleting From The GridView
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];
            //Label lbldeleteid = (Label)row.FindControl("lblID");
            conn.Open();

            string deleteQuery = "DELETE FROM dbo.Category WHERE CategoryId  = '" + Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString()) + "'";
            SqlCommand cmd = new SqlCommand(deleteQuery, conn);

            cmd.ExecuteNonQuery();

            conn.Close();

            gvbind();
        }


        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            gvbind();
        }


        //Updating Row Vise after selecting the edit button
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int CatId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());

            GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];

            //Label lblID = (Label)row.FindControl("lblID");
            TextBox CategoryName = (TextBox)row.Cells[0].Controls[0];
            TextBox TransactionType = (TextBox)row.Cells[1].Controls[0];

            GridView1.EditIndex = -1;

            conn.Open();

            string updateQuery = "UPDATE dbo.Category SET CategoryName = '"+CategoryName.Text+"', TransactionTypeId = (SELECT TransactionTypeId FROM dbo.TransactionType WHERE TransactionTypeName = '"+TransactionType.Text+"') WHERE CategoryId = '"+CatId+"'";
            SqlCommand cmd = new SqlCommand(updateQuery, conn);
            cmd.ExecuteNonQuery();

            conn.Close();

            gvbind();

        }


        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            gvbind();
        }
        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            gvbind();
        }


    }
}