using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace website
{
    public partial class PerformanceSetOfFilters : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.UrlReferrer != null)
                    ViewState["PreviousPageUrl"] = Request.UrlReferrer.ToString();

                int memoryPerformance;
                float percentageOfCovered, speedPerformance;


                if (Request.Params["speedPerformance"] != null)
                {

                    if (float.TryParse(Request.Params["speedPerformance"], out speedPerformance))
                        lbl_SpeedPerformance.Text = Request.Params["speedPerformance"];
                }
                if (Request.Params["memoryPerformance"] != null)
                {
                    if (int.TryParse(Request.Params["memoryPerformance"], out memoryPerformance))
                        lbl_MemoryPerformance.Text = Request.Params["memoryPerformance"];
                }
                if (Request.Params["percentageOfCovered"] != null)
                {
                    if (float.TryParse(Request.Params["percentageOfCovered"], out percentageOfCovered))
                        lbl_PercentageOfCoverd.Text = Request.Params["percentageOfCovered"];
                }
            }
        }
        protected void Search_Click(object sender, EventArgs e) // User click on send button
        {
            //צריך להעביר את הנתונים של הסט לדף הבא שנוכל לחפש בעזרת הסט פילטרים שנבחר
            if (Request.QueryString.ToString() != "")
                Response.Redirect(@"/SearchSpecificWord.aspx?" + Request.QueryString.ToString());
            else
                Response.Redirect(@"/SearchSpecificWord.aspx");
        }

        protected void Compere_Click(object sender, EventArgs e) // User click on back button
        {
            Response.Redirect(@"/PerformanceOfAllSets.aspx" + Request.Url.Query);
            // צריך להעביר למסך הבא את גודל המילה,מספר טעויות וגודל הקובץ כדי שנגיע לטבלה של הסטי פילטרים המתאימה
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