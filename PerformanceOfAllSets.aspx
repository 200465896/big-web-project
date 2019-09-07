<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="PerformanceOfAllSets.aspx.cs" Inherits="website.PerformanceOfAllSets" %>
<asp:Content runat="server" ContentPlaceHolderID="contentBody">
            <script type="text/javascript">
                function viewFileData(path)
                {
                    var $ = jQuery.noConflict();
                    var uri = 'api/Files/getTextFileContent';
                    $.ajax({
                        url: uri,
                        dataType: 'json',
                        type: "Get",
                        data: { path: path },
                        async: false,
                        success: function (data) {
                            //alert(data);
                            $("#fileTextBody").html(data);
                            $('#fileContentModal').modal('toggle');
                        },
                        error: function (request, status, error) {
                            //alert(request.responseText);
                            alert("Ërror");
                        }
                    });

                   
                }
            </script>

            <link href="resources/basis.css" rel="stylesheet" />
            
            <%--<asp:HiddenField ID="hf_qsParamOK" runat="server" />
            <asp:HiddenField ID="hf_SizeOfWord" runat="server" />
            <asp:HiddenField ID="hf_AmountOfMatch" runat="server" />
            <asp:HiddenField ID="hf_CoveredFrom" runat="server" />
            <asp:HiddenField ID="hf_CoveredTo" runat="server" />--%>

            <div class="col-xs-12 general-wrapper">
                <div class="col-xs-12 col-md-offset-3 col-md-6">
                    <div class="col-xs-12">
                        <div class="col-xs-12 text-center">
                            <span class="pill-left search-title">Sets Performance Data</span>
                           <!-- <span class="pull-right question-mark" data-toggle="modal" data-target="#explanations">
                                <i class="far fa-question-circle"></i>
                            </span>-->
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-xs-12">
                <div class="col-xs-offset-2 col-xs-8 form-margin">
                        <div class="form-group col-xs-offset-2 col-xs-2 text-center sort-from">
                            <span>Sort By</span>
                        </div>

                        <div class="form-group col-xs-4">

                            <asp:DropDownList ID="sort" runat="server" CssClass="form-control">

                                <asp:ListItem Value="Speed_Performance" Text="Speed Performance"></asp:ListItem>
                                <asp:ListItem Value="Memory_Performance" Text="Memory Performance"></asp:ListItem>
                                <asp:ListItem Value="Percentage_Of_Coverd" Text="Percentage of Coverd"></asp:ListItem>
                            </asp:DropDownList>
                        </div>


                        <div class="form-group col-xs-3">
                            <asp:Button runat="server" Text="Sort" CssClass="btn btn-default btn-round" OnClick="Sort_Click" />
                        </div>
                </div>

                <asp:Literal ID="tableContainer" runat="server">
                </asp:Literal>

                <div class="col-xs-12">
                    <div class="col-xs-offset-3 col-xs-6">
                        <asp:Button runat="server" Text="Back" CssClass="btn btn-default btn-round btn-back" OnClick="Back_Click" />
                        <asp:Button runat="server" Text="Serach" CssClass="btn btn-primary btn-round btn-3-4-long" OnClick="Search_Click" />
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
                        On this page you can overview all sets of filters according to your search requirments and to sort according to speed and memory performance.
                            </p>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-default btn-round" data-dismiss="modal">Close</button>
                        </div>
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

            <%--<script src="resources/jquery/jquery-1.10.2.js" type="text/javascript"></script>--%>
            <script src="resources/assets/js/jquery-ui-1.10.4.custom.min.js" type="text/javascript"></script>
            <script src="resources/bootstrap3/js/bootstrap.js" type="text/javascript"></script>
            <script src="resources/assets/js/gsdk-checkbox.js"></script>
            <script src="resources/assets/js/gsdk-radio.js"></script>
            <script src="resources/assets/js/gsdk-bootstrapswitch.js"></script>
            <script src="resources/assets/js/get-shit-done.js"></script>

  
</asp:Content>


