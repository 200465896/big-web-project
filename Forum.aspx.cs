using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using website.models;


namespace website
{
    public partial class Forum : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if(Request.UrlReferrer!=null)
                    ViewState["PreviousPageUrl"] = Request.UrlReferrer.ToString();

            }
            fillData();
        }

        void fillData()
        {
            List<List<string>> topicsList = new List<List<string>>();
            List<List<string>> msgsList = new List<List<string>>();
            dbHandler dbh = new dbHandler();

            clsUser currUser = (clsUser)Session["userInformation"];
            if (currUser.UserName == "admin")
                currUser.IsManager = true;


            if (Request.QueryString["tid"] != null && !Request.QueryString["tid"].Equals("") && !Request.QueryString["tid"].Equals(" "))
            {
                msgsList = dbh.getAllMsgs(Request.QueryString["tid"]);
                if (msgsList != null)
                {
                    showMsgsToTable(msgsList, currUser.IsManager);
                }
            }
            else
            {
                topicsList = dbh.getAllTopics();
                if (topicsList != null)
                {
                    showTopicsToTable(topicsList, currUser.IsManager);
                }
            }
        }

        private void showMsgsToTable(List<List<string>> msgsList,Boolean isManager)
        {
            forumTable.Rows.Clear();
            TableRow tr = new TableRow();
            TableCell tc = new TableCell();
            tc.Text = "Message ID";
            tr.Cells.Add(tc);

            tc = new TableCell();
            tc.Text = "Openned by";
            tr.Cells.Add(tc);

            tc = new TableCell();
            tc.Text = "message";
            tc.CssClass = "alignLeft";
            tr.Cells.Add(tc);

            tc = new TableCell();
            tc.Text = "Openned in";
            tr.Cells.Add(tc);

            if (isManager)
            {
                tc = new TableCell();
                tc.Text = "Delete message";
                tr.Cells.Add(tc);

                tc = new TableCell();
                tc.Text = "Approve/Disapprove";
                tr.Cells.Add(tc);
            }

            forumTable.Rows.Add(tr);

            foreach (List<string> msg in msgsList)
            {
                tr = new TableRow();

                tc = new TableCell();
                tc.Text = msg[0];
                tr.Cells.Add(tc);
                tc = new TableCell();
                tc.Text = msg[1];
                tr.Cells.Add(tc);
                tc = new TableCell();
                tc.Text = msg[2];
                tc.CssClass = "alignLeft"; //Message Header text should be align to left
                tr.Cells.Add(tc);
                tc = new TableCell();
                tc.Text = msg[3];
                tr.Cells.Add(tc);


                if (isManager)
                {
                    tc = new TableCell();
                    Button btn = new Button();
                    btn.ID = "btnDeleteMsg_" + msg[0];
                    btn.Text = "Delete";
                    btn.CssClass = "btn btn-default btn-round";
                    btn.Click += new EventHandler(deleteMsgClick);
                    btn.Attributes.Add("ID", msg[0]);
                    tc.Controls.Add(btn);
                    tr.Cells.Add(tc);

                    //==========================================
                    tc = new TableCell();
                    btn = new Button();
                    btn.ID = "btn_Msg" + msg[0] + "_ChangeApproval";
                    btn.Text = (msg[4].Equals("True")) ? "Disapprove" : "Approve";
                    btn.Click += new EventHandler(changeMsgApprovalClick);
                    btn.Attributes.Add("msgID", msg[0]);
                    btn.CssClass = "btn btn-default btn-round";
                    tc.Controls.Add(btn);
                    tr.Cells.Add(tc);
                }

                forumTable.Rows.Add(tr);

            }
        }

        private void showTopicsToTable(List<List<string>> topicsList, bool isManager)
        {
            forumTable.Rows.Clear();
            TableRow tr = new TableRow();
            TableCell tc = new TableCell();
            tc.Text = "Topic ID";
            tr.Cells.Add(tc);

            tc = new TableCell();
            tc.Text = "Openned by";
            tr.Cells.Add(tc);

            tc = new TableCell();
            tc.Text = "Title";
            tc.CssClass = "alignLeft";
            tr.Cells.Add(tc);

            tc = new TableCell();
            tc.Text = "Openned in";
            tr.Cells.Add(tc);

            tc = new TableCell();
            tc.Text = "Is closed";
            tr.Cells.Add(tc);

            tc = new TableCell();
            tc.Text = "Enter discussion";
            tr.Cells.Add(tc);

            if (isManager)
            {
                tc = new TableCell();
                tc.Text = "Approve/Disapprove";
                tr.Cells.Add(tc);
                tc = new TableCell();
                tc.Text = "delete";
                tr.Cells.Add(tc);
            }

            forumTable.Rows.Add(tr);

            foreach (List<string> topic in topicsList)
            {
                if (topic[5].Equals("True") || true)
                {
                    tr = new TableRow();

                    tc = new TableCell();
                    tc.Text = topic[0];
                    tr.Cells.Add(tc);
                    tc = new TableCell();
                    tc.Text = topic[1];
                    tc.CssClass = "alignLeft"; //topic Header text should be align to left
                    tr.Cells.Add(tc);
                    tc = new TableCell();
                    tc.Text = topic[2];
                    tr.Cells.Add(tc);
                    tc = new TableCell();
                    tc.Text = topic[3];
                    tr.Cells.Add(tc);
                    tc = new TableCell();
                    tc.Text = (topic[4].Equals("True") ? "Closed" : "Open");
                    tr.Cells.Add(tc);


                    tc = new TableCell();
                    Button btn = new Button();
                    btn.ID = "btn_Topic" + topic[0] + "_Delete ";
                    btn.Text = "Enter";
                    btn.Click += new EventHandler(enterDiscussionClick);
                    btn.Attributes.Add("topicID", topic[0]);
                    btn.CssClass = "btn btn-default btn-round";
                    tc.Controls.Add(btn);
                    tr.Cells.Add(tc);

                    if (isManager)
                    {
                        tc = new TableCell();
                        btn = new Button();
                        btn.ID = "btn_Topic" + topic[0] + "_ChangeApproval";
                        btn.Text = (topic[5].Equals("True")) ? "Disapprove" : "Approve";
                        btn.Click += new EventHandler(changeApprovalClick);
                        btn.Attributes.Add("topicID", topic[0]);
                        btn.CssClass = "btn btn-default btn-round";
                        tc.Controls.Add(btn);
                        tr.Cells.Add(tc);
                        //////deletebutton
                        tc = new TableCell();
                        Button btn2 = new Button();
                        btn2.ID = "btn_Topic" + topic[0] + "_enterDiscussion";
                        btn2.Text = "Delete";
                        btn2.Click += new EventHandler(deleteTopicClick);
                        btn2.Attributes.Add("ID", topic[0]);
                        btn2.CssClass = "btn btn-default btn-round";
                        tc.Controls.Add(btn2);
                        tr.Cells.Add(tc);
                    }

                    forumTable.Rows.Add(tr);
                }
            }
        }

        protected void enterDiscussionClick(object sender, EventArgs e)
        {
            
            Response.Redirect(@"/Forum.aspx?tid=" + ((Button)sender).Attributes["topicID"]);
        }

        protected void deleteMsgClick(object sender, EventArgs e)
        {
            Button btnDelete = (Button)sender;
            if (btnDelete != null && btnDelete.Attributes != null && btnDelete.Attributes["ID"] != null)
            {
                string msgID = btnDelete.Attributes["ID"].ToString();
                dbHandler dbh = new dbHandler();
                if (dbh.deleteForumMsg(Convert.ToInt32(msgID)))
                {
                    //Succesfully Deleted
                    //refresh data so the deleted row wont be shown anymore
                    fillData();
                }
            }
        }
        protected void deleteTopicClick(object sender, EventArgs e)
        {
            Button btnDelete = (Button)sender;
            if (btnDelete != null && btnDelete.Attributes != null && btnDelete.Attributes["ID"] != null)
            {
                string msgID = btnDelete.Attributes["ID"].ToString();
                dbHandler dbh = new dbHandler();
                if (dbh.deleteForumTopic(Convert.ToInt32(msgID)))
                {
                    //Succesfully Deleted
                    //refresh data so the deleted row wont be shown anymore
                    fillData();
                }
            }
        }
        /// <summary>
        /// This function change approval status the specific TOPIC that been clicked in the table.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void changeApprovalClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn != null && btn.Attributes != null && btn.Attributes["topicID"] != null)
            {
                bool isApproved = true;
                if (btn.Text == "Disapprove")
                    isApproved = false;

                string topicID = btn.Attributes["topicID"].ToString();
                dbHandler dbh = new dbHandler();
                if (dbh.SetForumTopicApproveDisapprove(Convert.ToInt32(topicID), isApproved))
                {
                    //Succesfully change approve/disapproved in db --> change button text
                    btn.Text = (isApproved ? "Disapprove" : "Approve");
                }
                
            }
        }
        /// <summary>
        /// This function change approval status the specific MESSAGE that been clicked in the table.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void changeMsgApprovalClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn != null && btn.Attributes != null && btn.Attributes["msgID"] != null)
            {
                bool isApproved = true;
                if (btn.Text == "Disapprove")
                    isApproved = false;

                string msgID = btn.Attributes["msgID"].ToString();
                dbHandler dbh = new dbHandler();
                if (dbh.SetForumMessageApproveDisapprove(Convert.ToInt32(msgID), isApproved))
                {
                    //Succesfully change approve/disapproved in db --> change button text
                    btn.Text = (isApproved ? "Disapprove" : "Approve");
                }

            }
        }
        protected void Back_Click(object sender, EventArgs e) // User click on back button
        {
            if (ViewState["PreviousPageUrl"]!=null && !string.IsNullOrEmpty(ViewState["PreviousPageUrl"].ToString()))
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


        protected void Close_Click(object sender, EventArgs e) // User click on back button
        {

            Response.Redirect(@"/Forum.aspx");
        }
    }
}