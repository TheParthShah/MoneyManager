using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MoneyManager
{
    public partial class Template : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblname.Text = Session["name"].ToString();
        }

        protected void btnlogout_Click(object sender, EventArgs e)
        {
            Page.Cache.Remove(Response.Cookies.Keys.ToString());
            Session.RemoveAll();
            Session.Abandon();
            Session.Clear();
            Response.Cache.SetAllowResponseInBrowserHistory(false);
            Response.Cache.SetNoServerCaching();
            Response.Cache.SetNoStore();
            Response.Cache.SetNoTransforms();
            Response.Clear();
            Response.Cache.SetExpires(DateTime.Now);
            Response.Cookies.Clear();
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Page.Dispose();
            Page.Items.Clear();
            Response.Redirect("index.aspx");
        }
    }
}