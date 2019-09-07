<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Guide.aspx.cs" Inherits="website.Guide" %>
<asp:Content runat="server" ContentPlaceHolderID="contentBody">

 <link href="resources/basis.css" rel="stylesheet" />
    <div class="col-xs-12 general-wrapper">
        <div class="col-xs-12 text-center">
            <span class="pill-left search-title">Guide</span>
        </div>
        <div class="col-xs-offset-3 col-xs-6">
            <div id="acordeon">
                <div class="panel-group" id="accordion">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a data-target="#collapseOne" href="#collapseOne" data-toggle="gsdk-collapse">
                                    Add New Set Guide
                                </a>
                            </h4>
                        </div>
                        <div id="collapseOne" class="panel-collapse collapse">
                            <div class="panel-body">

                 In this page, you need to upload set of filters like this example
                            </div>
                        </div>
                    </div>
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a data-target="#collapseTwo" href="#collapseTwo" data-toggle="gsdk-collapse">
                                    Choose Exist Set Guide
                                </a>
                            </h4>
                        </div>
                        <div id="collapseTwo" class="panel-collapse collapse">
                            <div class="panel-body">
                    On this page you can filter sets from public collection by defining a word size, amount of matches and a range of percentage covered.
                            </div>
                        </div>
                    </div>
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a data-toggle="collapse" href="#collapseThree">
                                    Using Our Algorithm Guide
                                </a>
                            </h4>
                        </div>
                        <div id="collapseThree" class="panel-collapse collapse">
                            <div class="panel-body">
                Here you need to fill in word size, amount of matches and MCS in order to call the Basic Algorithm.
                        Word size can be up to 20 characters.
                        Word size and amount of matches must be at least 60% accurate.
                        MCS (Minimal Configuration Set) is the number of matches per filter and it must lower or equal to the amount of matches.
                            </div>
                        </div>
                    </div>


                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a data-target="#collapseFour" href="#collapseFour" data-toggle="gsdk-collapse">
                                  Performance of Set of Filters Guide  
                                </a>
                            </h4>
                        </div>
                        <div id="collapseFour" class="panel-collapse collapse">
                            <div class="panel-body">
                    On this page you can watch speed and memory performances and covered percentages of the new set. You can search with it and compare it to other sets.
                        The memory performance calculation is calculated when the size of the file is multiplied by the number of filters in the set = #of filters in the set  per 1 KB.
                        Speed performance Calculated as follows: = o((n #of filters in the set)/(#of charcters in  the abc)^i )
                        I - #of match in filter
                        Speed performance of the naive algorithm: o(n)
                        We present the improvement in proportion between speed performances for all set of filters to naive algorithm.
                            </div>
                        </div>
                    </div>


                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a data-target="#collapseFive" href="#collapseFive" data-toggle="gsdk-collapse">
                                    Performance of all Set of FIlters Guide
                                </a>
                            </h4>
                        </div>
                        <div id="collapseFive" class="panel-collapse collapse">
                            <div class="panel-body">

          On this page, we can to see and compere that all the set of filters to exist in data base according to your reqirment. 
          The memory performance calculation is calculated when the size of the file is multiplied by the number of filters in the set = #of filters in the set  per 1 KB.           Speed performance Calculated as follows: = o((n #of filters in the set)/(#of charcters in  the abc)^i )
          I - #of match in filter
          Speed performance of the naive algorithm: o(n)
          We present the improvement in proportion between speed performances for all set of filters to naive algorithm.
                            </div>
                            </div>
                        </div>
                    </div>


                                        <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a data-target="#collapseSix" href="#collapseSix" data-toggle="gsdk-collapse">
                                    Search Specific Word Guide
                                </a>
                            </h4>
                        </div>
                        <div id="collapseSix" class="panel-collapse collapse">
                            <div class="panel-body">
                                On this page you enter the word you want to search in the document with the search properties you selected in the previous pages,
                            then, you upload the document, on which you want to perform the search of the word.
                            </div>
                        </div>
                    </div>

                    <div class="form-group">
                          <asp:Button runat="server" CssClass="btn btn-default btn-round btn-back" Text="Back" type="button" Onclick ="Back_Click"></asp:Button>
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
                    </p>
                </div>
                <br>
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