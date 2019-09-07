<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ManageSets.aspx.cs" Inherits="website.ManageSets" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentBody" runat="server">
    <asp:UpdatePanel ID="updpnl" runat="server">
        <ContentTemplate>
    <script type="text/javascript">
        function viewFileData(path) {
            var $ = jQuery.noConflict();
            var uri = 'api/Files/getTextFileContent';
            $.ajax({
                url: uri,
                dataType: 'json',
                type: "Get",
                data: { path: path },
                async: false,
                success: function (data) {
                    $("#fileTextBody").html(data);
                    $('#fileContentModal').modal('toggle');
                },
                error: function (request, status, error) {
                    alert("Ërror");
                }
            });


        }
        function deleteSet(Set_Id) {
            var $ = jQuery.noConflict();
            alert(Set_Id);
            var uri = 'api/projectAPI/DeleteSet';
            $.ajax({
                url: uri,
                dataType: 'json',
                type: "Get",
                data: { Set_Id: Set_Id },
                async: false,
                success: function (data) {
                    window.open("ManageSets.aspx","_self");
                },
                error: function (request, status, error) {
                    alert("Ërror");
                }
            });


        }
    </script>

    <link href="resources/basis.css" rel="stylesheet" />
    <div class="col-xs-12 general-wrapper">
        <div class="col-xs-12 col-md-offset-3 col-md-6">
            <div class="col-xs-12">
                <div class="col-xs-12 text-center">
                    <span class="pill-left search-title">Manage Sets</span>
                   <!-- <span class="pull-right question-mark" data-toggle="modal" data-target="#explanations">
                        <i class="far fa-question-circle"></i>
                    </span>-->
                </div>
            </div>
        </div>
    </div>
    <div class="col-xs-12">
        <div style="width:100%;text-align:center;float:left;padding:20px;">
            <asp:TextBox ID="txtWordSize" runat="server" placeholder="Word Size"></asp:TextBox>&nbsp;
            <asp:TextBox ID="txtNumOfMatches" runat="server" placeholder="Number Of Matches"></asp:TextBox>&nbsp;
            <asp:Button ID="btnFilter" runat="server" Text="Filter" CssClass="btn btn-default" OnClick="btnFilter_Click" />&nbsp;
            <asp:Button ID="btnClearFilters" runat="server" Text="Clear Filters" CssClass="btn btn-default" OnClick="btnClearFilters_Click" />
        </div>
        <asp:Literal ID="tableContainer" runat="server"></asp:Literal>

        <div class="col-xs-12">
            <div class="col-xs-offset-3 col-xs-6">
                <asp:Button runat="server" Text="Back" CssClass="btn btn-default btn-round btn-back" OnClick="Back_Click" />
            </div>
        </div>
    </div>

            
            <!-- Specific File Data popup -->
            <div id="fileContentModal" class="modal fade" role="dialog">
              <div class="modal-dialog">

                <!-- Modal content-->
                <div class="modal-content">
                   <%-- <asp:Literal ID="viewFileLiteral" runat="server"></asp:Literal>--%>
                  <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">File Content</h4>
                  </div>
                  <div class="modal-body">
                    <p id="fileTextBody"></p>
                  </div>
                  <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                  </div>
                </div>

              </div>
            </div>



    <script src="resources/assets/js/jquery-ui-1.10.4.custom.min.js" type="text/javascript"></script>
    <script src="resources/bootstrap3/js/bootstrap.js" type="text/javascript"></script>
    <script src="resources/assets/js/gsdk-checkbox.js"></script>
    <script src="resources/assets/js/gsdk-radio.js"></script>
    <script src="resources/assets/js/gsdk-bootstrapswitch.js"></script>
    <script src="resources/assets/js/get-shit-done.js"></script>
            </ContentTemplate>
        </asp:UpdatePanel>
</asp:Content>
