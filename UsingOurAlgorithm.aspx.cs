using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Diagnostics;
using System.Web.UI.WebControls;
using System.IO;

namespace website
{
    public partial class UsingOurAlgorithm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.UrlReferrer != null)
                    ViewState["PreviousPageUrl"] = Request.UrlReferrer.ToString();
            }
        }

        protected void Send_Click(object sender, EventArgs e) // User click on send button
        {


            if (MCS.Text == "")
            {
                Response.Write("<script>alert('MCS is mandatory. Please fill it and click Send again');</script>");
                return;
            }


            if (AmmountOfMatch.Text == "")
            {
                Response.Write("<script>alert('AmmountOfMatch is mandatory. Please fill it and click Send again');</script>");
                return;
            }

            if (WordSize.Text == "")
            {
                Response.Write("<script>alert('WordSize is mandatory. Please fill it and click Send again');</script>");
                return;
            }

            int z= Convert.ToInt32(MCS.Text);
            int x = Convert.ToInt32(AmmountOfMatch.Text);
            int y = Convert.ToInt32(WordSize.Text);
            double w = (double) x / y;
            if (w < 0.6) 
            {

                Response.Write("<script>alert('(AmmountOfMatch/WordSize) *100 < 60, Please fill it and click Send again');</script>");
                return;
            }
            if (z>x)
            {

                Response.Write("<script>alert('MCS > AmmountOfMatch, Please fill it and click Send again');</script>");
                return;
            }


            string algorithmPath = Server.MapPath("/BasicAlgorithm/Release/main.exe");
            string relativePath = "/SetFiles/forms_" + DateTime.Now.ToString("yyyyMMddHHmmssffff");
        string pathToSave = Server.MapPath(relativePath);

            ///  if (MCS.Text == " ")
            /// {
            //  (MCS.Text = "4";

            ///  }
     //string pathToSave = Server.MapPath("/SetFiles/forms_" + DateTime.Now.ToString("yyyyMMddHHmmssffff"));
           

            string str = string.Concat(WordSize.Text, " ", AmmountOfMatch.Text, " ", MCS.Text, " ", pathToSave);
            // string str = "20 12 5 path";

            Process.Start(algorithmPath, str);//////לקחת את הקובץ הפעלה של זכריה ולא של לבנת!!!!
            //Console.ReadKey();

            //להמתין עד ליצירת הקובץ. בודקים כל 8 שניות
            while (!File.Exists(pathToSave))
            {
                System.Threading.Thread.Sleep(8000);
            }

            float speedPerformance = 50;
            int memoryPerformance = 60;
            float percentageOfCovered = 22;
            int sizeOfWord = 3;
            int amountOfMatch = 5;
            bool readSuccess = GlobalFunctions.readSetFile(pathToSave, out sizeOfWord, out amountOfMatch, out speedPerformance, out memoryPerformance, out percentageOfCovered);

            if (readSuccess)
            {
                dbHandler dbh = new dbHandler();
                dbh.insertNewSet(sizeOfWord, amountOfMatch, speedPerformance, memoryPerformance, percentageOfCovered, relativePath);
                Response.Redirect(@"/PerformanceSetOfFilters.aspx?amountOfMatch=" + amountOfMatch + "&speedPerformance=" + speedPerformance + "&memoryPerformance=" + memoryPerformance + "&percentageOfCovered=" + percentageOfCovered + "&sizeOfWord=" + sizeOfWord + "&filepath=" + relativePath); // עדיין אין מסך כזה - ליצור את המסך הזה
            }
            else
            {
                File.Delete(pathToSave);
            }




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

            Response.Redirect(@"/UsingOurAlgorithm.aspx");
        }
    }
}