<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="website.Login" %>


<html>
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=1080, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <title>Filters Sets</title>
    <link href="resources/basis.css" rel="stylesheet" />
    <link href="resources/login-style.css" rel="stylesheet" />

 </head>
    <body>
    <div class="container-fluid general-background login-wrapper" style="top:0 !important;">
        <div class="col-xs-offset-3 col-xs-6 general-login-box" style="padding-left:200px;top:30% !important;">
            <div class="col-xs-8">
                     <form action="#" runat="server">
                        <div   class="form-group">
                            
                            <h1>Log In</h1>
                            <label> User Name</label> 
                            <asp:TextBox runat="server" ID="UserName" type="text" cssclass="form-control" placeholder="User name"></asp:TextBox>
                            <br />
                            <label> Password</label> 
                            <asp:TextBox ID="Password" type="password" runat="server" cssclass="form-control" placeholder="Password"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <div>
                                <asp:Button runat="server" CssClass="btn btn-primary btn-round btn-block btn-login" Text="Sign In" OnClick="Send_Click"  />
                            </div>
                            <a class="col-xs-12 text-center" href="Register.aspx">Don't have an account? Register</a>
                            <div>
                                <a class="col-xs-12 text-center" href="ForgotPassword.aspx">Forgot password</a>
                            </div>
                            
                        </div>
                        </form>
                </div>
               
            </div>
            
        </div>
    
    
</body>
</html>
