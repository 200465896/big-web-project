using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Diagnostics;
using System.Collections;
namespace website

{
    public partial class SearchSpecificWord : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.UrlReferrer != null)
                ViewState["PreviousPageUrl"] = Request.UrlReferrer.ToString();
        }
    }

    protected void Send_Click(object sender, EventArgs e)
    {

            Hashtable prms = new Hashtable();
            addFileToServer(prms);
            CheckFile();
            string path = @"C:\Users\tomer\Desktop\project\tom_website\website\maping3\FastApproximateMatchmaster\trunc\Sources\FamCpp\SeqsToSearch.txt";
            System.IO.File.WriteAllText(path, WordSize.Text);
            System.Threading.Thread.Sleep(8000);
           
            string res = "";
             if (Request.Params["filepath"] != null)
             {
            res = GlobalFunctions.createSpecialFileFormatForProcess(Request.Params["filepath"]);
          }
            string str = string.Concat(res, " ", WordSize.Text);
            string algorithmPath = Server.MapPath("/maping3/FastApproximateMatchmaster/trunc/Sources/Debug/FamCpp.exe");
            //string str = string.Concat(WordSize.Text, " ", WordSize.Text, " ", WordSize.Text, " ", pathToSave);
            Directory.SetCurrentDirectory(@"C:\\Users\\tomer\\Desktop\\project\\tom_website\\website\\maping3\\FastApproximateMatchmaster\\trunc\\Sources\\FamCpp");
            Process.Start(algorithmPath);

            
        }

    void CheckFile()
    {
        string filePathFromPrevPages = string.Empty;
        FileInfo fileFromPrevPages = null;
        if (Request.Params["filepath"] != null)
            filePathFromPrevPages = Request.Params["filepath"];
        if (File.Exists(Server.MapPath("~" + filePathFromPrevPages)))
            fileFromPrevPages = new FileInfo(Server.MapPath("~" + filePathFromPrevPages));

    }

    protected void Back_Click(object sender, EventArgs e)
    {
        if (ViewState["PreviousPageUrl"] != null && !string.IsNullOrEmpty(ViewState["PreviousPageUrl"].ToString()))
        {
            try
            {
                string prevPageFullPath = ViewState["PreviousPageUrl"].ToString();
                int startpos = prevPageFullPath.LastIndexOf(@"/");
                Response.Redirect(prevPageFullPath);
            }
            catch { }
        }
    }

    protected void Close_Click(object sender, EventArgs e) // User click on back button
    {

        Response.Redirect(@"/SearchSpecificWord.aspx");
    }


        private void addFileToServer(Hashtable prms)
        {

            if (fu_addnewset.PostedFile != null && fu_addnewset.PostedFile.FileName != "")
            {
                string fullDestPath = Server.MapPath("~/" + GlobalConsts.document_files + fu_addnewset.PostedFile.FileName);
                string relativeDestPath = GlobalConsts.document_files + fu_addnewset.PostedFile.FileName;
                fu_addnewset.PostedFile.SaveAs(fullDestPath);
            }
        }


    }

}