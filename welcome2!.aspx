<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="welcome2!.aspx.cs" Inherits="website.welcome2_" %>

<asp:Content runat="server" ContentPlaceHolderID="contentBody">

    <link href="resources/basis.css" rel="stylesheet" />
    <link href="resources/main-page-style.css" rel="stylesheet" />


    <div class="col-xs-12 welcome-screen general-background">
        <div class="col-xs-offset-1 col-xs-10">
            <div class="col-xs-3">
                <div class="welcome-icon">
                    <i class="fas fa-plus"></i>
                </div>
                <h4 class="welcome-title">ADD NEW SET</h4>
                <p>
                   In case you wish to add a new set of filters, check its eligibility and to see evaluation of speed and memory performances and percentage covered by your set - choose this option. In addition, you can search a word using your new set and to compare its performance to all exiting sets in the public collection.
                    <br>
                    <br>
                    <br>
                    <a href="AddingNewSet.aspx" class="btn btn-primary btn-block btn-round">Adding New Set</a>
                </p>
            </div>
            <div class="col-xs-3">
                <div class="welcome-icon">
                    <i class="far fa-hand-pointer"></i>
                </div>
                <h4 class="welcome-title">Choose Exist Set</h4>
                <p>
                   Here you can see all speed and memory performances and percentage covered by all exisiting sets of filters in the site's public collection. In addition, you can search a word with the most suitable set.
                    <br>
                    <br>
                    <br>
                    <br>
                    <br>
                    <br>
                    <a href="ChooseExistSetOfFilters.aspx" class="btn btn-primary btn-block btn-round">Choose Exist Set of Filters</a>
                </p>
            </div>
            <div class="col-xs-3">
                <div class="welcome-icon">
                    <i class="fas fa-magic"></i>
                </div>
                <h4 class="welcome-title">Use Algorithm</h4>
                <p>
                  This option allows you to use the site's algorithm (Basic Algorithm) in order to create a recommended set of filters. You can see the set's speed and memory performances and percentage covered by it, to compare them with other sets in the public collection, and to search using the chosen set.
                    <br>
                    <br>
                    <br>
                    <br>
                    <a href="UsingOurAlgorithm.aspx" class="btn btn-primary btn-block btn-round">Use Our Algorithm</a>
                </p>
            </div>
             <div class="col-xs-3">
                <div class="welcome-icon">
                    <i class="fas fa-magic"></i>
                </div>
                <h4 class="welcome-title"> Managment </h4>
                <p>
                    Here you can manage all users, overview their activity, to block or unblock users and to delete users.
                    <br>
                    <br>
                    <a href="ManageUsers.aspx" class="btn btn-primary btn-block btn-round">Manage Users</a>
                </p>
                 <br>
                 <p>
                    Here you can manage all sets of filters, overview them, and to delete them.
                    <br>
                     <br>
                     
                    <a href="ManageSets.aspx" class="btn btn-primary btn-block btn-round">Manage Sets</a>
                </p>   


            </div>
        </div>
    </div>

    <script src="resources/jquery/jquery-1.10.2.js" type="text/javascript"></script>
    <script src="resources/assets/js/jquery-ui-1.10.4.custom.min.js" type="text/javascript"></script>
    <script src="resources/bootstrap3/js/bootstrap.js" type="text/javascript"></script>
    <script src="resources/assets/js/gsdk-checkbox.js"></script>
    <script src="resources/assets/js/gsdk-radio.js"></script>
    <script src="resources/assets/js/gsdk-bootstrapswitch.js"></script>
    <script src="resources/assets/js/get-shit-done.js"></script>

</asp:Content>
