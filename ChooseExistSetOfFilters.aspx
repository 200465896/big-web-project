<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ChooseExistSetOfFilters.aspx.cs" Inherits="website.ChooseExistSetOfFilters" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content runat="server" ContentPlaceHolderID="contentBody">

    <link href="resources/basis.css" rel="stylesheet" />

    <div style="text-align: center">


        <div class="col-xs-12 general-wrapper">
            <div class="col-xs-offset-3 col-xs-6">
                <div class="col-xs-12">
                    <div class="col-xs-12 text-center">
                        <span class="pill-left search-title">Use Existing set of filters</span>
                        <span class="pull-right question-mark" data-toggle="modal" data-target="#explanations">
                            <i class="far fa-question-circle"></i>
                        </span>
                    </div>
                    <div class="col-xs-offset-1 col-xs-10">
                        <form action="#">
                            <div class="form-group">




                                <label for="wordsize">Words size</label>
                                <asp:TextBox ID="WordSize" type="text" CssClass="form-control" runat="server" min="0" max="100" placeholder="Words size"></asp:TextBox>
                            </div>

                            <div class="form-group">
                                <label for="amountofwords">Amount of Matches</label>
                                <asp:TextBox ID="AmountOfMatches" type="number" runat="server" CssClass="form-control" min="0" max="100" placeholder="Amount of words"></asp:TextBox>
                            </div>

                            <div class="form-group">
                                Coverage from
                                <asp:TextBox ID="from" type="number" min="0" max="100" runat="server" CssClass="form-control form-control-percent"></asp:TextBox>%  
                    to
                                <asp:TextBox ID="to" type="number" min="0" max="100" runat="server" CssClass="form-control form-control-percent"></asp:TextBox>%
                            </div>





                            <div class="form-group">
                                <asp:Button runat="server" CssClass="btn btn-default btn-round btn-back" Text="Back" type="button" OnClick="Back_Click"></asp:Button>
                                <asp:Button runat="server" CssClass="btn btn-primary btn-round btn-3-4-long" Text="Send" type="button" OnClick="Send_Click"></asp:Button>
                            </div>
                        </form>
                    </div>
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
                    On this page you can filter sets from public collection by defining a word size, amount of matches and a range of percentage covered.
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
