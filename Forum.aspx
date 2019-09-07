<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Forum.aspx.cs" Inherits="website.Forum" %>
<%--<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>--%>

<asp:Content runat="server" ContentPlaceHolderID="contentBody">
    <link href="resources/basis.css" rel="stylesheet" />
    <link href="resources/main-page-style.css" rel="stylesheet" />
    <script src="Scripts/myScripts.js"></script>

    <asp:UpdatePanel ID="upForum" runat="server">
        <Triggers>
            <asp:PostBackTrigger ControlID="forumTable" />
        </Triggers>
        <ContentTemplate>
            <link href="resources/basis.css" rel="stylesheet" />
            <div class="col-xs-12 general-wrapper">
                <div class="col-xs-offset-3 col-xs-6">
                    <div class="col-xs-12">
                        <div class="col-xs-12 text-center">
                            <span class="pill-left search-title">Forum</span>
                           <!-- <span class="pull-right question-mark" data-toggle="modal" data-target="#explanations">
                                <i class="far fa-question-circle"></i>
                            </span>-->
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-xs-offset-1 col-xs-10">
                <asp:Table ID="forumTable" CssClass="table table-hover forum" runat="server"></asp:Table>

                <div class="col-xs-12">
                    <div class="col-xs-offset-3 col-xs-6">
                        <asp:Button CssClass="btn btn-default btn-round btn-back" runat="server" Text="Back" ID="UploadOK" OnClick="Back_Click" />
                        <button id="btnNewTopic" class="btn btn-primary btn-round btn-1-2-long" data-toggle="modal"  data-target="#newTopicDIV">Add New Topic</button>
                        <button id="btnNewMsg" class="btn btn-primary btn-round btn-1-2-long" data-toggle="modal"  data-target="#newMessageDIV">Add New Message</button>
                    </div>
                </div>
            </div>
            
            <!-- New Topic Modal -->
            <div id="newTopicDIV" class="modal fade" role="dialog">
                <div class="modal-dialog">

                    <!-- Modal content-->
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                            <h4 class="modal-title">Add New Topic</h4>
                        </div>
                        <div class="modal-body">
                            <p><textarea id="txtNewTopic" style="width:100%;" placeholder="Write your new topic here..."></textarea></p>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-default" data-dismiss="modal" onclick="saveNewTopic();">Save</button>
                            <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                        </div>
                    </div>

                </div>
            </div>

            <!-- New Message Modal -->
            <div id="newMessageDIV" class="modal fade" role="dialog">
                <div class="modal-dialog">

                    <!-- Modal content-->
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                            <h4 class="modal-title">Add New Message</h4>
                        </div>
                        <div class="modal-body">
                            <p><textarea id="txtNewMessage" style="width:100%;" placeholder="Write your new message here..."></textarea></p>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-default" data-dismiss="modal" onclick="saveNewMessage();">Save</button>
                            <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                        </div>
                    </div>

                </div>
            </div>

            <script type="text/javascript">
                $(document).ready(function () {
                    var currTopicID = getQSParameterByName("tid");
                    if (currTopicID==null || currTopicID == "")
                    {
                        //Forum Messages View
                        $("#btnNewTopic").show();
                        $("#btnNewMsg").hide();
                    }
                    else
                    {
                        //Forum Topics view
                        $("#btnNewMsg").show();
                        $("#btnNewTopic").hide();
                    }
                });
                function saveNewTopic()
                {
                    var $ = jQuery.noConflict();
                    var uri = 'api/projectAPI/saveNewTopic';
                    $.ajax({
                        url: uri,
                        dataType: 'json',
                        type: "Get",
                        data: { topicSTR: $("#txtNewTopic").val() },
                        async: false,
                        success: function (data) {
                            window.open("Forum.aspx","_self");
                        },
                        error: function (request, status, error) {
                            alert("Ërror");
                        }
                    });
                }
                function saveNewMessage()
                {
                    var $ = jQuery.noConflict();
                    var currTopicID = getQSParameterByName("tid");
                    if (currTopicID != "") {
                        var uri = 'api/projectAPI/saveNewMessage';
                        $.ajax({
                            url: uri,
                            dataType: 'json',
                            type: "Get",
                            data: { msgSTR: $("#txtNewMessage").val(), topicID: currTopicID },
                            async: false,
                            success: function (data) {
                                window.open("Forum.aspx", "_self");
                            },
                            error: function (request, status, error) {
                                alert("Ërror");
                            }
                        });
                    }
                }
            </script>
            

            <%--<cc1:ModalPopupExtender BackgroundCssClass="background" ID="ModalPopupExtender1" TargetControlID="explain" PopupControlID="Panel1" runat="server"></cc1:ModalPopupExtender>--%>
            <script src="resources/jquery/jquery-1.10.2.js" type="text/javascript"></script>
            <script src="resources/assets/js/jquery-ui-1.10.4.custom.min.js" type="text/javascript"></script>
            <script src="resources/bootstrap3/js/bootstrap.js" type="text/javascript"></script>
            <script src="resources/assets/js/gsdk-checkbox.js"></script>
            <script src="resources/assets/js/gsdk-radio.js"></script>
            <script src="resources/assets/js/gsdk-bootstrapswitch.js"></script>
            <script src="resources/assets/js/get-shit-done.js"></script>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
