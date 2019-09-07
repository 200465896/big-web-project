using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace website
{
    public partial class ChooseExistSetOfFilters : System.Web.UI.Page
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


            StringBuilder qs = new StringBuilder();
            int ws, aom, f, t;

            if (WordSize.Text != "")
            {
                if (int.TryParse(WordSize.Text, out ws))
                {
                    if(ws<= GlobalConsts.maxSizeOfWord)
                        qs.Append("sizeOfWord=" + WordSize.Text);
                }
            }
            if (AmountOfMatches.Text != "")
            {
                if (int.TryParse(AmountOfMatches.Text, out aom))
                {
                    if(aom <= GlobalConsts.maxSizeOfMatch)
                    {
                        if (qs.ToString() != "")
                            qs.Append("&");
                        qs.Append("AmountOfMatch=" + AmountOfMatches.Text);
                    }    
                }
            }
            if (from.Text != "")
            {
                if (int.TryParse(from.Text, out f))
                {
                    if(f>0 && f<=100)
                    {
                        if (qs.ToString() != "")
                            qs.Append("&");
                        qs.Append("CoveredFrom=" + from.Text);
                    }
                }
            }
            if (to.Text != "")
            {
                if (int.TryParse(to.Text, out t))
                {
                    if (t > 0 && t <= 100)
                    {
                        if (qs.ToString() != "")
                            qs.Append("&");
                        qs.Append("CoveredTo=" + to.Text);
                    }
                }
            }
            //resultAmountOfMatch / (double)resultSizeOfWord) >= 0.6
            
            if (!string.IsNullOrEmpty(qs.ToString()))
                Response.Redirect(@"/PerformanceOfAllSets.aspx?" + qs.ToString());
            else
                Response.Redirect(@"/PerformanceOfAllSets.aspx");
           
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
        protected void Explain_Click(object sender, EventArgs e) // User click on send button
        {



        }

        protected void Close_Click(object sender, EventArgs e) // User click on back button
        {

            Response.Redirect(@"/ChooseExistSetOfFilters.aspx");
        }
    }
}