using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;

namespace website
{
    public partial class PerformanceOfAllSets : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.UrlReferrer != null)
                    ViewState["PreviousPageUrl"] = Request.UrlReferrer.ToString();

                Hashtable whereParams = new Hashtable();
                int ws, aom, f, t;

                if (Request.QueryString["sizeOfWord"] != null && int.TryParse(Request.QueryString["sizeOfWord"], out ws))
                {
                    if (ws <= GlobalConsts.maxSizeOfWord)
                        whereParams.Add("Size_Word", Request.QueryString["sizeOfWord"].ToString());
                }

                if (Request.QueryString["amountOfMatch"] != null && int.TryParse(Request.QueryString["amountOfMatch"], out aom))
                {
                    if (aom <= GlobalConsts.maxSizeOfMatch)
                        whereParams.Add("Amount_Of_Mismatch", Request.QueryString["amountOfMatch"].ToString());
                }

                if (Request.QueryString["CoveredFrom"] != null && int.TryParse(Request.QueryString["CoveredFrom"], out f))
                {
                    if (f > 0 && f <= 100)
                        whereParams.Add("CoveredFrom", Request.QueryString["CoveredFrom"].ToString());
                }

                if (Request.QueryString["CoveredTo"] != null && int.TryParse(Request.QueryString["CoveredTo"], out t))
                {
                    if (t > 0 && t <= 100)
                        whereParams.Add("CoveredTo", Request.QueryString["CoveredTo"].ToString());
                }

                Session["currSearch"] = whereParams;
                makedatatable(false, whereParams);
            }
        }

        protected void Sort_Click(object sender, EventArgs e) // User click on Sort button
        {
            makedatatable(true,(Hashtable)Session["currSearch"]);
        }

        protected void Search_Click(object sender, EventArgs e) // User click on Search button
        {
            /*
             צריך להעביר את הנתונים של הסט לדף הבא שנוכל לחפש בעזרת הסט פילטרים שנבחר
             */
            if (Request.QueryString.ToString() != "")
                Response.Redirect(@"/SearchSpecificWord.aspx?" + Request.QueryString.ToString());
            else
                Response.Redirect(@"/SearchSpecificWord.aspx");

        }

        protected void Back_Click(object sender, EventArgs e) // User click on back button
        {
            if (ViewState["PreviousPageUrl"] != null && !string.IsNullOrEmpty(ViewState["PreviousPageUrl"].ToString()))
            {
                try
                {
                    string prevPageFullPath = ViewState["PreviousPageUrl"].ToString();
                    int startpos = prevPageFullPath.LastIndexOf(@"/");
                    //Response.Redirect(@"/" + prevPageFullPath.Substring(startpos + 1, prevPageFullPath.Length - startpos - 1));
                    Response.Redirect(prevPageFullPath);
                }
                catch { }
            }
        }

        private void makedatatable(bool useSession,Hashtable whereParams)
        {
            DataTable tbl = null;
            
            dbHandler dbh = new dbHandler();
            tbl = dbh.getSets(whereParams, sort.SelectedValue);

            if (tbl != null)
            {
                Session["allSets"] = tbl;
            }
            dbh = null;
            GC.Collect();

            StringBuilder sb_html = new StringBuilder();
            sb_html.Append("<table class='table table - hover'>");

            //Build the column names according to the data came from dB
            sb_html.Append("<thead><tr>");
            foreach (DataColumn col in tbl.Columns)
                sb_html.Append("<th>" + col.ColumnName + "</th>");
            sb_html.Append("<th>Search</th>");
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
                            sb_html.Append("<td><button type='button' class='btn btn-info btn-lg' data-toggle='modal' " + str + " data -target='#myModal'>View</button></td>");
                        }
                    }
                    sb_html.Append("<td><a href='SearchSpecificWord.aspx?sizeOfWord=" + row["Size_Word"].ToString() + "&filepath=" + row["ViewFile"].ToString() + "' class='btn btn-info btn-lg'>Perform Search</a></td>");
                    sb_html.Append("</tr>");
                }
                sb_html.Append("</tbody>");
            }
            sb_html.Append("</table>");
            tableContainer.Text = sb_html.ToString();
        }

        private void makedatatable_old()
        {
            //dbHandler dbh = new dbHandler();
            //List<List<string>> result = dbh.getSets_old(int.Parse(hf_SizeOfWord.Value), int.Parse(hf_AmountOfMatch.Value), int.Parse(hf_CoveredFrom.Value), int.Parse(hf_CoveredTo.Value),sort.SelectedValue);
            //TableRow row = new TableRow();
            //foreach(List<string> set in result)
            //{
            //    row = new TableRow();
            //    TableCell cell = new TableCell();
            //    cell.Text = set[0];
            //    row.Cells.Add(cell);
            //     cell = new TableCell();
            //    cell.Text = set[1];
            //    row.Cells.Add(cell);
            //     cell = new TableCell();
            //    cell.Text = set[2]+"KB per 1KB of file size";
            //    row.Cells.Add(cell);
            //     cell = new TableCell();
            //    cell.Text = set[3];
            //    row.Cells.Add(cell);
            //     cell = new TableCell();
            //    cell.Text = set[4];
            //    row.Cells.Add(cell);
            //    setsTable.Rows.Add(row);
            //}

            //if (result.Count <= 0)
            //{
            //    Response.Write("<script>alert('No sets found, please go back and try other parameters!');</script>");
            //}

        }

    }
}