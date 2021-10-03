<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="UI.LogIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Log In</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr> 
                    <td><asp:TextBox ID="txtUsernameLI" placeholder="Username" runat="server"></asp:TextBox></td></tr>
                <tr>
                    <td><asp:TextBox ID="txtPasswordLI" runat="server"></asp:TextBox></td></tr>
                <tr>
                    <td><asp:Button ID="btnLogIn" runat="server" Text="Sign In" OnClick="btnLogIn_Click" /></td></tr>
                <tr>
                    <td><asp:HyperLink ID="hlSignUp" runat="server">SignUp</asp:HyperLink></td></tr>
            </table>
        </div>
    </form>
</body>
</html>
