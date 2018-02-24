using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using System.IO;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.DataVisualization.Charting;

namespace MoneyManager
{
    public partial class Home : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            
            if (!IsPostBack)
            {
                //binding the data with gridview
                gvbind();

                //Populating the label
                LabelPopulation();

                //Charts
                GetRecordsExpenseChartInfo();
                GetRecordsIncomeChartInfo();
            }
        }



        protected void LabelPopulation()
        {
            conn.Open();

            int exp, income;
            //For Expense
            string ExpSumQuery = "SELECT SUM(Amount) AS Amount FROM dbo.Records WHERE Records.TransactionTypeId = 2";
            SqlCommand cmd = new SqlCommand(ExpSumQuery, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            lblExpense.Text = ds.Tables[0].Rows[0]["Amount"].ToString();
            exp = Convert.ToInt32(ds.Tables[0].Rows[0]["Amount"]);
            lblExpense.ForeColor = Color.Red;

            //For Income
            string IncomeSumQuery = "SELECT SUM(Amount) AS Amount FROM dbo.Records WHERE Records.TransactionTypeId = 1";
            SqlCommand cmd1 = new SqlCommand(IncomeSumQuery, conn);
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);

            lblIncome.Text = ds1.Tables[0].Rows[0]["Amount"].ToString();
            income = Convert.ToInt32(ds1.Tables[0].Rows[0]["Amount"]);
            lblIncome.ForeColor = Color.Blue;

            //for total = Income - Expence
            //int total = income - exp;
            if (income > exp)
            {
                int total = income - exp;
                lblTotal.Text = total.ToString();
                lblTotal.ForeColor = System.Drawing.Color.Blue;
            }
            else if (income < exp)
            {
                int total = exp - income;
                lblTotal.Text = total.ToString();
                lblTotal.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                lblTotal.ForeColor = Color.Black;
            }
            conn.Close();
        }

        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            this.gvbind();
        }


        protected void ExportToExcel(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=RecordsExport.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                //To Export all pages
                GridView1.AllowPaging = false;
                this.gvbind();

                GridView1.HeaderRow.BackColor = Color.White;
                foreach (TableCell cell in GridView1.HeaderRow.Cells)
                {
                    cell.BackColor = GridView1.HeaderStyle.BackColor;
                }
                foreach (GridViewRow row in GridView1.Rows)
                {
                    row.BackColor = Color.White;
                    foreach (TableCell cell in row.Cells)
                    {
                        if (row.RowIndex % 2 == 0)
                        {
                            cell.BackColor = GridView1.AlternatingRowStyle.BackColor;
                        }
                        else
                        {
                            cell.BackColor = GridView1.RowStyle.BackColor;
                        }
                        cell.CssClass = "textmode";
                    }
                }

               // GridView1.RenderControl(hw);

                //style to format numbers to string
                string style = @"<style> .textmode { } </style>";
                Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }





        private void GetRecordsIncomeChartInfo()
        {
            DataTable dt = new DataTable();

            conn.Open();

            string selectExpQuery = "SELECT Amount as Price, CategoryName As Category  FROM dbo.Records, dbo.Category WHERE Records.CategoryId = Category.CategoryId AND Records.TransactionTypeId = 1 ";
            SqlCommand cmd = new SqlCommand(selectExpQuery, conn);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            conn.Close();

            string[] x = new string[dt.Rows.Count];
            int[] y = new int[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                x[i] = dt.Rows[i][1].ToString();
                y[i] = Convert.ToInt32(dt.Rows[i][0]);
            }

            IncomeInfo.Series[0].Points.DataBindXY(x, y);
            IncomeInfo.Series[0].ChartType = SeriesChartType.Pie;
            IncomeInfo.ChartAreas["Income"].Area3DStyle.Enable3D = true;
            IncomeInfo.Legends[0].Enabled = true;
        }

        private void GetRecordsExpenseChartInfo()
        {
            DataTable dt = new DataTable();

            conn.Open();

            string selectExpQuery = "SELECT Amount as Price, CategoryName As Category  FROM dbo.Records, dbo.Category WHERE Records.CategoryId = Category.CategoryId AND Records.TransactionTypeId = 2";
            SqlCommand cmd = new SqlCommand(selectExpQuery, conn);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            conn.Close();

            string[] x = new string[dt.Rows.Count];
            int[] y = new int[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                x[i] = dt.Rows[i][1].ToString();
                y[i] = Convert.ToInt32(dt.Rows[i][0]);
            }

            ExpenseInfo.Series[0].Points.DataBindXY(x, y);
            ExpenseInfo.Series[0].ChartType = SeriesChartType.Pie;
            ExpenseInfo.ChartAreas["Expense"].Area3DStyle.Enable3D = true;
            ExpenseInfo.Legends[0].Enabled = true;
        }

        //binding data with the gridview
        protected void gvbind()
        {
            conn.Open();

            string selectQuery = "SELECT TransactionId,TranDate,TransactionTypeName,Type,CategoryName,Amount,Contents,Details FROM Records,TransactionType,PaymentMode,Category WHERE Records.TransactionTypeId = TransactionType.TransactionTypeId AND Records.PaymentModeId = PaymentMode.PaymentModeId AND Records.CategoryId = Category.CategoryId;";
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
            Label lbldeleteid = (Label)row.FindControl("lblID");
            conn.Open();

            string deleteQuery = "DELETE FROM dbo.Records WHERE TransactionId  = '" + Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString()) + "'";
            SqlCommand cmd = new SqlCommand(deleteQuery, conn);

            cmd.ExecuteNonQuery();

            conn.Close();

            gvbind();
            //For Refreshing the page after Deleting the data
            Response.Redirect(Request.RawUrl);
        }


        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            gvbind();

        }


        //Updating Row Vise after selecting the edit button
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int TransactionId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());

            GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];

            Label lblID = (Label)row.FindControl("lblID");
            
            TextBox tbTranDate = (TextBox)row.Cells[0].Controls[0];
            TextBox tbTranType = (TextBox)row.Cells[1].Controls[0];
            TextBox tbPaymentType = (TextBox)row.Cells[2].Controls[0];
            TextBox tbCategory = (TextBox)row.Cells[3].Controls[0];
            TextBox tbContent = (TextBox)row.Cells[4].Controls[0];
            TextBox tbDetails = (TextBox)row.Cells[5].Controls[0];
            TextBox tbAmount = (TextBox)row.Cells[6].Controls[0];

            int Amount = Int32.Parse(tbAmount.Text);

            GridView1.EditIndex = -1;

            conn.Open();

            //SqlCommand cmd = new SqlCommand("SELECT * FROM detail", conn);  
            string updateQuery = "UPDATE dbo.Records SET TranDate = '"+tbTranDate.Text+"',TransactionTypeId = (SELECT TransactionTypeId FROM dbo.TransactionType WHERE TransactionTypeName = '"+tbTranType.Text+"'),PaymentModeId = (SELECT PaymentModeId FROM dbo.PaymentMode WHERE Type = '"+tbPaymentType.Text+"'),CategoryId = (SELECT CategoryId FROM dbo.Category WHERE CategoryName = '"+tbCategory.Text+"'),Amount = '"+Amount+"',Contents = '"+tbContent.Text+"',Details = '"+tbDetails.Text+"' WHERE TransactionId = '"+TransactionId+"'; ";
            SqlCommand cmd = new SqlCommand(updateQuery, conn);
            cmd.ExecuteNonQuery();

            conn.Close();

            gvbind();
            //For Refreshing the page after Updating the data
            Response.Redirect(Request.RawUrl);
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