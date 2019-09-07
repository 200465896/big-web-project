<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="UsingOurAlgorithm.aspx.cs" Inherits="website.UsingOurAlgorithm" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content runat="server" ContentPlaceHolderID="contentBody">

    <link href="resources/basis.css" rel="stylesheet" />

    <div class="col-xs-12 general-wrapper">
        <div class="col-xs-offset-3 col-xs-6">
            <div class="col-xs-12">
                <div class="col-xs-12 text-center">
                    <span class="pill-left search-title">Use Algorithm</span>
                    <span class="pull-right question-mark" data-toggle="modal" data-target="#explanations">
                        <i class="far fa-question-circle"></i>
                    </span>
                </div>
                <div class="col-xs-offset-1 col-xs-10">
                    <form action="#">
                        <div class="form-group">

                            <label>Word Size</label>
                            <asp:TextBox ID="WordSize" CssClass="form-control" type="number" min="0" max="100" runat="server" placeholder="Words size"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>Amount Of Match</label>
                            <asp:TextBox ID="AmmountOfMatch" CssClass="form-control" type="number" min="0" max="100" runat="server" placeholder="Amount of words"></asp:TextBox>
                        </div>
                        <label>MCS</label>
                        <asp:TextBox ID="MCS" CssClass="form-control" type="number" min="0" max="100" runat="server" placeholder="Words size"></asp:TextBox>
                </div>
                <div class="form-group">


                    <div>

                        <asp:Button runat="server" CssClass="btn btn-default btn-round btn-back" Text="Back" type="button" OnClick="Back_Click"></asp:Button>
                        <asp:Button runat="server" CssClass="btn btn-primary btn-round btn-3-4-long" Text="Send" type="button" OnClick="Send_Click"></asp:Button>
                    </div>
                </div>
                </form>
            </div>
        </div>
    </div>
    </div>
    
       

    <!-- ############# -->
    <!-- Modal Content -->
    <!-- ############# -->

    <div class="modal fade" tabindex="-1" role="dialog" id="explanations">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <p>
                Here you need to fill in word size, amount of matches and MCS in order to call the Basic Algorithm.
                        Word size can be up to 20 characters.
                        Word size and amount of matches must be at least 60% accurate.
                        MCS (Minimal Configuration Set) is the number of matches per filter and it must lower or equal to the amount of matches.
                    </p>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default btn-round" data-dismiss="modal">Close</button>
                </div>
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
