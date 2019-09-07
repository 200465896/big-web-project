using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using website.models;

namespace website
{
    public partial class welcome2_ : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                if (Session["userInformation"] != null)
                {
                    clsUser currUser = (clsUser)Session["userInformation"];
                    if (!currUser.IsManager)
                        Response.Redirect(@"welcome!.aspx");
                }
            }
        }
    }

 
}