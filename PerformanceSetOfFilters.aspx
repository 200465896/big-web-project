<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="PerformanceSetOfFilters.aspx.cs" Inherits="website.PerformanceSetOfFilters" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content runat="server" ContentPlaceHolderID="contentBody">

    <link href="resources/basis.css" rel="stylesheet" />

    <div class="col-xs-12 general-wrapper">
        <div class="col-xs-offset-3 col-xs-6">
            <div class="col-xs-12">
                <div class="col-xs-12 text-center">
                    <span class="pill-left search-title">Performance Set of Filters</span>
                    <span class="pull-right question-mark" data-toggle="modal" data-target="#explanations">
                        <i class="far fa-question-circle"></i>
                    </span>
                </div>

                <div class="col-xs-offset-1 col-xs-10">
                    <div class="form-group">
                        <span>Speed Performance</span>
                        <asp:Label ID="lbl_SpeedPerformance" CssClass="form-control" runat="server"></asp:Label>
                        <span>Memory Performance </span>
                        <asp:Label ID="lbl_MemoryPerformance" CssClass="form-control" runat="server"></asp:Label>
                        <span>Percentage of Coverd </span>
                        <asp:Label ID="lbl_PercentageOfCoverd" CssClass="form-control" runat="server"></asp:Label>
                    </div>

                    <div class="form-group">
                        <asp:button class="btn btn-default btn-round btn-back" onclick ="Back_Click" runat="server" Text="Back"></asp:button>
                        <asp:button class="btn btn-default btn-round btn-back" onclick ="Compere_Click" Text="Compere With Anoter Set" runat="server"></asp:button>
                        <asp:button class="btn btn-default btn-round btn-back" onclick ="Search_Click" Text="Search" runat="server"></asp:button>

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
                On this page you can watch speed and memory performances and covered percentages of the new set. You can search with it and compare it to other sets.
                        The memory performance calculation is calculated when the size of the file is multiplied by the number of filters in the set = #of filters in the set  per 1 KB.
                        Speed performance Calculated as follows: = o((n #of filters in the set)/(#of charcters in  the abc)^i )
                        I - #of match in filter
                        Speed performance of the naive algorithm: o(n)
                        We present the improvement in proportion between speed performances for all set of filters to naive algorithm.
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