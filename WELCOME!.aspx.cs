using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace website
{
    public partial class WELCOME : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                if (Request.UrlReferrer != null)
                    ViewState["PreviousPageUrl"] = Request.UrlReferrer.ToString();
            }
        }
        protected void Send_Click(object sender, EventArgs e) // User click on send button
        {
            /*
             if user choose "add new set
            Response.Redirect(@"/AddingNewSet.aspx");

            if user choose "use exist set of filters"
            Response.Redirect(@"/ChooseExistSetOfFilters.aspx");

            if user choose " using our algorithm"
            Response.Redirect(@"/UsingOurAlgorithm.aspx");
        */
        }

        protected void Back_Click(object sender, EventArgs e) // User click on back button
        {
            if (ViewState["PreviousPageUrl"] != null && !string.IsNullOrEmpty(ViewState["PreviousPageUrl"].ToString()))
            {
                try
                {
                    string prevPageFullPath = ViewState["PreviousPageUrl"].ToString();
                    int startpos = prevPageFullPath.LastIndexOf(@"/");
                    Response.Redirect(@"/" + prevPageFullPath.Substring(startpos + 1, prevPageFullPath.Length - startpos - 1));
                }
                catch { }
            }
        }
    }
}