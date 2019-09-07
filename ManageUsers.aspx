<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ManageUsers.aspx.cs" Inherits="website.ManageUsers" %>
<asp:Content runat="server" ContentPlaceHolderID="contentBody">
    
 <link href="resources/basis.css" rel="stylesheet" />

       
    <div class="col-xs-12 general-wrapper">
        <div class="col-xs-offset-3 col-xs-6">
            <div class="col-xs-12">
                <div class="col-xs-12 text-center">
                    <span class="pill-left search-title">User Managment</span>
                  <!--  <span class="pull-right question-mark" data-toggle="modal" data-target="#explanations">
                        <i class="far fa-question-circle"></i>
                    </span>-->
                </div>
            </div>
        </div>
    </div>    
    <div class="col-xs-offset-1 col-xs-10">

            <asp:Table ID="usersTable" CssClass="table table-hover" runat="server" Width="100%"> 
            <asp:TableRow  CssClass="tableHeader">
                <asp:TableCell >Username</asp:TableCell>
                <asp:TableCell >First Name</asp:TableCell>
                <asp:TableCell >Last Name</asp:TableCell>
                <asp:TableCell >Email</asp:TableCell>
                <asp:TableCell >Is Online</asp:TableCell>
                <asp:TableCell >Is Blocked</asp:TableCell>
                <asp:TableCell >Block/Unblock</asp:TableCell>
                <asp:TableCell >Delete User</asp:TableCell>
            </asp:TableRow>
        </asp:Table>  

        </div>




    <script src="resources/jquery/jquery-1.10.2.js" type="text/javascript"></script>
    <script src="resources/assets/js/jquery-ui-1.10.4.custom.min.js" type="text/javascript"></script>
    <script src="resources/bootstrap3/js/bootstrap.js" type="text/javascript"></script>
    <script src="resources/assets/js/gsdk-checkbox.js"></script>
    <script src="resources/assets/js/gsdk-radio.js"></script>
    <script src="resources/assets/js/gsdk-bootstrapswitch.js"></script>
    <script src="resources/assets/js/get-shit-done.js"></script>
</asp:Content>