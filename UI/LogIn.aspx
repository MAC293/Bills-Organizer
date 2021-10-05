<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="UI.LogIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Log In</title>
    <link href="Assets/Bootstrap/CSS/bootstrap.css" rel="stylesheet" />
    <link href="Assets/Bootstrap/CSS/bootstrap.min.css" rel="stylesheet" />
    <script src="Assets/Bootstrap/JS/jquery.js"></script>
    <script src="Assets/Bootstrap/JS/bootstrap.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">

        <%--Log In--%>
        <div>
            <table>
                <tr> 
                    <td><asp:TextBox ID="txtUsernameSI" Placeholder="Username" runat="server"></asp:TextBox></td></tr>
                <tr>
                    <td><asp:TextBox ID="txtPasswordSI" Placeholder="Password" runat="server"></asp:TextBox></td></tr>
                <tr>
                    <td><asp:Button ID="btnLogIn" runat="server" Text="Sign In" OnClick="btnLogIn_Click" /></td></tr>
                <tr>
                    <td><asp:LinkButton ID="lbSignUp" runat="server" OnClick="lbSignUp_Click">Sign Up</asp:LinkButton></td></tr>
            </table>
        </div>
        <%--Log In--%>
        
        <%--Modal--%>
        <div id="newUser" class="modal fade" tabindex="-1" role="dialog" aria-hidden="true">

            <div class="modal-dialog" role="document">

                <div class="modal-content">

                    <div class="modal-header">
                        <asp:Label ID="Label1" runat="server" Text="Type Required Information"></asp:Label>
                    </div>
                    
                    
                    <div class="modal-body">
                       <table>
                           <tr>
                               <td><asp:TextBox ID="txtUsernameSU" Placeholder="Username" runat="server"></asp:TextBox></td>
                           </tr>
                           <tr>
                               <td><asp:TextBox ID="txtPasswordSU" Placeholder="Password" runat="server"></asp:TextBox></td>
                           </tr>
                           <tr>
                               <td><asp:TextBox ID="txtDisplayNameSU" Placeholder="Display Name" runat="server"></asp:TextBox></td>
                           </tr>
                       </table>
                    </div>

                    <div class="modal-footer">
                        <%--OnClick="btnCreateEvent_Click"--%>
                        <asp:Button ID="btnRegister" class="btn btn-primary" runat="server" Text="Register"
                                    UseSubmitBehavior="True" />
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                    </div>

                </div>

            </div>
        </div>
        <%--Modal--%>
    </form>
</body>
</html>
