<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="SearchSpecificWord.aspx.cs" Inherits="website.SearchSpecificWord" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content runat="server" ContentPlaceHolderID="contentBody">
    &nbsp;<link href="resources/basis.css" rel="stylesheet" /><div class="col-xs-12 general-wrapper">
        <div class="col-xs-offset-3 col-xs-6">
            <div class="col-xs-12">
                <div class="col-xs-12 text-center">
                    <span class="pill-left search-title">Search With Your Set of Filters</span>
                    <span class="pull-right question-mark" data-toggle="modal" data-target="#explanations">
                        <i class="far fa-question-circle"></i>
                    </span>
                </div>
                <div class="col-xs-offset-1 col-xs-10">
                    <form action="#">
                        <div class="form-group">
                            <label>Enter Word</label>
                            <asp:TextBox ID="WordSize" CssClass="form-control" runat="server" placeholder="Words size"></asp:TextBox>
                        </div>
                        <div class="form-group">

                            <%--<label for="file" class="btn btn-default btn-round btn-block">
                                <i class="fas fa-cloud-upload-alt"></i>Upload file to search</label>
                            <input type="file" class="form-control" id="file" placeholder="Upload file">--%>
                            <label for="<%: fu_addnewset.ClientID%>" class="btn btn-default btn-round btn-block"><i class="fas fa-cloud-upload-alt"></i>Upload file to search</label>
                            <input name="fu_addnewset" type="file" runat="server" class="form-control" id="fu_addnewset" />
                        </div>
                        <br>



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
                        On this page you enter the word you want to search in the document with the search properties you selected in the previous pages,
                            then, you upload the document, on which you want to perform the search of the word.
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
