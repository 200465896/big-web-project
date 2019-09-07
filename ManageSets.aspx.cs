using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data;
using System.Text;
using website.models;

namespace website
{
    public partial class ManageSets : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["userInformation"] != null)
                {
                    clsUser currUser = (clsUser)Session["userInformation"];
                    if (!currUser.IsManager)
                        Response.Redirect(@"welcome!.aspx");
                    else
                    {
                        //current user is manager
                        if (Request.UrlReferrer != null)
                            ViewState["PreviousPageUrl"] = Request.UrlReferrer.ToString();
                        makedatatable(-1, -1); //-1, -1 will get all the sets without filtering by @WordSize or @NumOfMatches
                    }
                }
            }
        }

        //protected void Search_Click(object sender, EventArgs e) // User click on Search button
        //{
        //    /*
        //     צריך להעביר את הנתונים של הסט לדף הבא שנוכל לחפש בעזרת הסט פילטרים שנבחר
        //     */
        //    if (Request.QueryString.ToString() != "")
        //        Response.Redirect(@"/SearchSpecificWord.aspx?" + Request.QueryString.ToString());
        //    else
        //        Response.Redirect(@"/SearchSpecificWord.aspx");

        //}

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

        private void makedatatable(int WordSize, int NumOfMatches)
        {
            DataTable tbl = null;

            //Table data will be taken from Database
            dbHandler dbh = new dbHandler();
            Hashtable prms = new Hashtable();
            prms.Add("WordSize", WordSize);
            prms.Add("NumOfMatches", NumOfMatches);

            DataSet ds = dbh.GetData("usp_GetAllSets", prms);

            if (ds != null && ds.Tables != null)
                tbl = ds.Tables[0];

            //dbh = null;
            GC.Collect();

            StringBuilder sb_html = new StringBuilder();
            sb_html.Append("<table class='table table - hover'>");

            //Build the column names according to the data came from dB
            sb_html.Append("<thead><tr>");
            foreach (DataColumn col in tbl.Columns)
                sb_html.Append("<th>" + col.ColumnName + "</th>");

            sb_html.Append("<th>Operation</th>");
            sb_html.Append("</tr></thead>");

            if (tbl != null)
            {
                //data has been found --> show table to client
                //Build the rows data according to the data came from dB
                sb_html.Append("<tbody>");
                foreach (DataRow row in tbl.Rows)
                {
                    sb_html.Append("<tr>");
                    foreach (DataColumn col in tbl.Columns)
                    {
                        if (col.ColumnName != "ViewFile")
                            sb_html.Append("<td>" + row[col.ColumnName].ToString() + "</td>");
                        else
                        {
                            string str = "onclick=\"viewFileData('" + row[col.ColumnName].ToString().Replace(@"\", "\\\\") + "');\"";
                            sb_html.Append("<td><button type='button' class='btn btn - info btn - lg' data-toggle='modal' " + str + " data -target='#myModal'>View</button></td>");
                        }
                    }
                    string deleteClick = "onclick=\"deleteSet(" + row["Set_Id"].ToString() + ");\"";        
                    sb_html.Append("<td><button type='button' class='btn btn - info btn - lg'" + deleteClick + "'>Delete Set</button></td>");
                    sb_html.Append("</tr>");

                }
                sb_html.Append("</tbody>");
            }
            sb_html.Append("</table>");
            tableContainer.Text = sb_html.ToString();
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            int wordSize = -1;
            int numOfMatches = -1;
            if (txtWordSize.Text != "" || txtNumOfMatches.Text != "")
            {
                try
                {
                    if (txtWordSize.Text != "")
                        wordSize = int.Parse(txtWordSize.Text);
                    try
                    {
                        if (txtNumOfMatches.Text != "")
                            numOfMatches = int.Parse(txtNumOfMatches.Text);
                    }
                    catch
                    {
                        Response.Write("<script>alert('Only numeric values should be insert into [numOfMatches] filter');</script>");
                    }
                }
                catch
                {
                    Response.Write("<script>alert('Only numeric values should be insert into [wordSize] filter');</script>");
                }
            }
            makedatatable(wordSize, numOfMatches);
        }

        protected void btnClearFilters_Click(object sender, EventArgs e)
        {
            txtNumOfMatches.Text = "";
            txtWordSize.Text = "";
            makedatatable(-1, -1);
        }
    }
}