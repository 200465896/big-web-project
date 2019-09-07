using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

namespace website
{
    public partial class AddingNewSet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.UrlReferrer != null)
                    ViewState["PreviousPageUrl"] = Request.UrlReferrer.ToString();

                ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
                scriptManager.RegisterPostBackControl(UploadOK);
                Page.Form.Attributes.Add("enctype", "multipart/form-data");
            }
        }
        protected void Send_Click(object sender, EventArgs e) // User click on send button
        {

          
            /*
             * בדיקה שהקובץ הוא קובץ readme
             * קריאה של הקובץ ניתוח הפילטרים ובדיקת תקינות 
             * קריאה לפונקציה שמחשבת ביצועי מהירות
             * קריאה לפונקציה שמחשבת ביצועי זיכרון
             * בדיקה של אחוז כיסוי ובדיקת תקינות לפי לוסלס ולוסלי
             * אם הכל תקין להודיע למשתמש שהסט הוסף בהצלחה ולהוסיף אותו למסד הנתונים
             * אם לא הכל תקין אז להודיע על הודעת שגיאה מתאימה
             */
            Hashtable prms = new Hashtable();
            addFileToServer(prms);
            string qs = "";
            
            foreach(DictionaryEntry qsParam in prms)
            {
                if (qs == "")
                    qs = "?" + qsParam.Key + "=" + qsParam.Value;
                else
                    qs = qs + "&" + qsParam.Key + "=" + qsParam.Value;
            }

            //if(prms.Count>0)
            //    qs= "?speedPerformance=" + Math.Round(double.Parse(prms["speedPerformance"].ToString())) + "&memoryPerformance=" + Math.Round(double.Parse(prms["memoryPerformance"].ToString())) + "&percentageOfCovered=" + Math.Round(double.Parse(prms["percentageOfCovered"].ToString())) + "&sizeOfWord=" + prms["sizeOfWord"].ToString();

            //if(fileRelativePath!="")
            //{
            //    if (qs != "")
            //        qs += "&filepath=" + fileRelativePath;
            //}
            Response.Redirect(@"/PerformanceSetOfFilters.aspx" + qs);
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

        private void addFileToServer(Hashtable prms)
        {
           
            if (fu_addnewset.PostedFile!=null && fu_addnewset.PostedFile.FileName!="")
            {
                string fullDestPath = Server.MapPath("~/" + GlobalConsts.setsFolder + fu_addnewset.PostedFile.FileName);
                string relativeDestPath = GlobalConsts.setsFolder + fu_addnewset.PostedFile.FileName;
                fu_addnewset.PostedFile.SaveAs(fullDestPath);
                float speedPerformance = 50;
                int memoryPerformance = 60;
                float percentageOfCovered = 22;
                int sizeOfWord = 3;
                int amountOfMatch = 5;
                bool readSuccess = GlobalFunctions.readSetFile(fullDestPath, out sizeOfWord, out amountOfMatch, out speedPerformance, out memoryPerformance, out percentageOfCovered);
                
                if (readSuccess)
                {
                    dbHandler dbh = new dbHandler();
                    dbh.insertNewSet(sizeOfWord, amountOfMatch, speedPerformance, memoryPerformance, percentageOfCovered, relativeDestPath);
                    prms.Add("speedPerformance", speedPerformance);//speedPerformance,memoryPerformance,percentageOfCovered
                    prms.Add("memoryPerformance", memoryPerformance);
                    prms.Add("percentageOfCovered", percentageOfCovered);
                    prms.Add("sizeOfWord", sizeOfWord);
                    prms.Add("amountOfMatch", amountOfMatch);
                    prms.Add("filepath", relativeDestPath);
                }
                else
                {
                    File.Delete(fullDestPath);
                }
            }
        }
        

        protected void Explain_Click(object sender, EventArgs e) // User click on send button
        {



        }

        protected void Close_Click(object sender, EventArgs e) // User click on back button
        {
            Response.Redirect(@"/AddingNewSet.aspx");
        }
    }
}