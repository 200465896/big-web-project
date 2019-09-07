<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AddingNewSet.aspx.cs" Inherits="website.AddingNewSet" %>

<asp:Content runat="server" ContentPlaceHolderID="contentBody">
    <%--<asp:UpdatePanel ID="up_fileUpload" runat="server" UpdateMode="Always">
        <Triggers>
            <asp:PostBackTrigger ControlID="UploadOK" />
        </Triggers>
        <ContentTemplate>--%>
            <link href="resources/basis.css" rel="stylesheet" />

            <div class="col-xs-12 general-wrapper">
                <div class="col-xs-12 col-md-offset-3 col-md-6">

                    <div class="col-xs-12">
                        <div class="col-xs-12 text-center">
                            <span class="pill-left search-title">Add new set filters</span>
                            <span class="pull-right question-mark" data-toggle="modal" title="click to see example of file structore to be upload" data-target="#explanations">
                                <i class="far fa-question-circle"></i>
                            </span>
                        </div>
                        <div class="col-xs-offset-1 col-xs-10">
                            <div class="form-group">
                                <label for="<%: fu_addnewset.ClientID%>" class="btn btn-default btn-round btn-block"><i class="fas fa-cloud-upload-alt"></i>Select file for new filters set</label>
                                <input name="fu_addnewset" type="file" runat="server" class="form-control" id="fu_addnewset" />
                            </div>
                            <br />

                            <div class="form-group">
                                <div>
                                    <asp:Button CssClass="btn btn-default btn-round btn-back" runat="server" Text="Back" ID="Button1" OnClick="Back_Click" />
                                    <asp:Button CssClass="btn btn-primary btn-round btn-3-4-long" runat="server" Text="Add New Set" ID="UploadOK" OnClick="Send_Click" />

                                </div>
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
                                In this page, you need to upload set of filters like this example:
                            </p> 
                            <p> 
                                Nform1 = 3	form1Size = 7 Nsovp1 = 4 N_2 = 5
                                >0	1 1 1 1 0 0 4 
                                >1	1 1 1 0 1 0 5 
                                >2	1 1 0 1 1 0 5 
                            </p>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-default btn-round" data-dismiss="modal">Close</button>
                        </div>
                    </div>
                </div>
            </div>

            <script type="text/javascript">
                    var $ = jQuery.noConflict();
                    var uri = 'api/Files/getTextFileContent';
                    $.ajax({
                        url: uri,
                        dataType: 'json',
                        type: "Get",
                        data: { path: '/SetFiles/forms.txt' },
                        async: false,
                        success: function (data) {
                            //alert(data);
                            $("#fileExample").html(data);
                            //$('#fileContentModal').modal('toggle');
                        }
                    });
            </script>        

            <script src="resources/jquery/jquery-1.10.2.js" type="text/javascript"></script>
            <script src="resources/assets/js/jquery-ui-1.10.4.custom.min.js" type="text/javascript"></script>
            <script src="resources/bootstrap3/js/bootstrap.js" type="text/javascript"></script>
            <script src="resources/assets/js/gsdk-checkbox.js"></script>
            <script src="resources/assets/js/gsdk-radio.js"></script>
            <script src="resources/assets/js/gsdk-bootstrapswitch.js"></script>
            <script src="resources/assets/js/get-shit-done.js"></script>
        <%--</ContentTemplate>
        
    </asp:UpdatePanel>--%>
</asp:Content>
