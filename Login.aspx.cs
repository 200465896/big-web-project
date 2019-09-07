using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using website.models;

namespace website
{
    public partial class Login : System.Web.UI.Page
    {
        /// private const string DllFilePath = @"C:\Users\slila\source\repos\website\website\Algorithm\main2.dll";

        //[DllImport(DllFilePath, CallingConvention = CallingConvention.StdCall)]
        //private extern static void main(int argc, string[] agrv);

        //public static void Test()
        //{
        //    string[] argv = { "20", "12", "4" };
        //    main(argv.Length, argv);
        //}



        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                
                Algorithms.Test(20, 12, 4, Server.MapPath("~/GeneratedFiles/" + ((DateTime.Now).ToString("yyyyMMddHHmmssffff"))));
            }
        }
        protected void Send_Click(object sender, EventArgs e) // // בדיקה עם המסד נתונים שהסיסמה והיוזר של המשתמש מתאימים
        {
            dbHandler dbh = new dbHandler();
            string checklogininfo = dbh.checkLogin(UserName.Text, Password.Text);
            if(checklogininfo.ToLower()=="ok")
            {
                handleSession();
                if (Session["userInformation"] != null)
                {
                    clsUser currUser = (clsUser)Session["userInformation"];
                    if (currUser.IsBlocked)
                    {
                        Response.Write("<script>alert('user is blocked');</script>");
                        return;
                    }
                    if (currUser.IsManager)
                        Response.Redirect(@"welcome2!.aspx");
                    else
                        Response.Redirect(@"welcome!.aspx");
                }
            }
            else
            {
                Response.Write("<script>alert('" + checklogininfo + "');</script>");
            }
        }

        private void handleSession()
        {
            clsUser currUser = (clsUser)Session["userInformation"];
           dbHandler dbh = new dbHandler();
            dbh.changeIsStatus(currUser.UserName, 1);
            if (UserName.Text=="admin")
                currUser.IsManager = true;
        }
    }
}