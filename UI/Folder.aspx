<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Folder.aspx.cs" Inherits="UI.Folder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <table class="body">
        <%--Folders--%>
        <tr>
            <td><asp:ImageButton ID="ibtnCable" runat="server" ImageUrl="Assets/Images/Cable.png"/> 
            <td><asp:ImageButton ID="ibtnElectricity" runat="server" ImageUrl="Assets/Images/Electricity.png"/> 
            <td><asp:ImageButton ID="ibtnGas" runat="server" ImageUrl="Assets/Images/Gas.png"/>  
            <td><asp:ImageButton ID="ibtnMobilePhone" runat="server" ImageUrl="Assets/Images/Mobile Phone.png"/>  
            <td><asp:ImageButton ID="ibtnWater" runat="server" ImageUrl="Assets/Images/Water.png"/> 
        </tr>
        
        <%--Names--%>
        <tr>
            <td>Cable</td> 
            <td>Electricity</td> 
            <td>Gas</td> 
            <td>Mobile Phone</td> 
            <td>Water</td>
        </tr>
    </table>

</asp:Content>
