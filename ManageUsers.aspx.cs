using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using website.models;

namespace website
{
    public partial class ManageUsers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userInformation"] != null)
            {
                clsUser currUser = (clsUser)Session["userInformation"];
                if (!currUser.IsManager)
                    Response.Redirect(@"welcome!.aspx");
                else
                {
                    //current user is manager
                    List<List<string>> usersList = new List<List<string>>();
                    dbHandler dbh = new dbHandler();
                    usersList = dbh.getAllUsers();
                    if (usersList != null)
                        showUsersToTable(usersList);
                }
            }
        }

        private void showUsersToTable(List<List<string>> usersList)
        {

            foreach (List<string> user in usersList)
            {
                if (user[6].ToLower().Equals("false"))
                {
                    //show only unmanager users
                    TableRow tr = new TableRow();

                    TableCell tc = new TableCell();
                    tc.Text = user[0];
                    tr.Cells.Add(tc);
                    tc = new TableCell();
                    tc.Text = user[1];
                    tr.Cells.Add(tc);
                    tc = new TableCell();
                    tc.Text = user[2];
                    tr.Cells.Add(tc);
                    tc = new TableCell();
                    tc.Text = user[3];
                    tr.Cells.Add(tc);
                    tc = new TableCell();
                    tc.Text = user[4];

                    if (user[4] == "1")
                    {
                        tc.CssClass = "cellGreen";
                        tc.Text = "Online";
                    }
                    else
                    {
                        tc.CssClass = "cellRed";
                        tc.Text = "Offline";
                    }

                    tr.Cells.Add(tc);
                    tc = new TableCell();
                    tc.Text = user[5];

                    if (user[5] == "1")
                    {
                        tc.CssClass = "cellRed";
                        tc.Text = "Blocked";
                    }
                    else
                    {
                        tc.CssClass = "cellGreen";
                        tc.Text = "Not Blocked";
                    }

                    tr.Cells.Add(tc);

                    tc = new TableCell();
                    Button btn = new Button();
                    btn.Text = ((user[5].ToLower() == "true") ? "Unblock" : "Block");
                    btn.Click += new EventHandler(ChangeUserBlockedStatus);
                    btn.CssClass = "btn btn-default btn-round";
                    btn.Attributes.Add("userName", user[0]);
                    tc.Controls.Add(btn);
                    tr.Cells.Add(tc);

                    tc = new TableCell();
                    btn = new Button();
                    btn.Text = "Delete";
                    btn.CssClass = "btn btn-default btn-round";
                    btn.Click += new EventHandler(deleteUserClick);
                    btn.Attributes.Add("userName", user[0]);
                    tc.Controls.Add(btn);
                    tr.Cells.Add(tc);

                    usersTable.Rows.Add(tr);
                }
            }
        }

        protected void ChangeUserBlockedStatus(object sender, EventArgs e)
        {
            dbHandler dbh = new dbHandler();
            dbh.changeIsBlocked(((Button)sender).Attributes["userName"], (((Button)sender).Text.Equals("Block")) ? 1 : 0);
            Response.Redirect(@"/ManageUsers.aspx");
        }

        protected void deleteUserClick(object sender, EventArgs e)
        {
            dbHandler dbh = new dbHandler();
            dbh.deleteUser(((Button)sender).Attributes["userName"]);
            Response.Redirect(@"/ManageUsers.aspx");
        }
    }
}