<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Bills.aspx.cs" Inherits="UI.Bills" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Label ID="lblFolderName" runat="server"></asp:Label>

    <asp:GridView ID="grvFees" runat="server" AutoGenerateColumns="False" ShowFooter="True" OnRowCommand="grvFees_RowCommand">

        <Columns>

            <%--Number--%>
            <asp:TemplateField HeaderText="Number">

                <EditItemTemplate>
                    <asp:TextBox ID="txtNumberUpdate" runat="server" Text='<%# Bind("Number") %>'></asp:TextBox>
                </EditItemTemplate>

                <FooterTemplate>
                    <asp:TextBox ID="txtNumberInsert" runat="server"></asp:TextBox>
                </FooterTemplate>

                <ItemTemplate>
                    <asp:Label ID="lblNumberDelete" runat="server" Text='<%# Bind("Number") %>'></asp:Label>
                </ItemTemplate>

            </asp:TemplateField>
            <%--Number--%>
            
            <%--DateOfIssue--%>
            <asp:TemplateField HeaderText="Date Of Issue">

                <EditItemTemplate>
                    <asp:TextBox ID="txtDateIssueUpdate" runat="server" Text='<%# Bind("DateIssue") %>'></asp:TextBox>
                </EditItemTemplate>

                <FooterTemplate>
                    <asp:TextBox ID="txtDateIssueInsert" runat="server"></asp:TextBox>
                </FooterTemplate>

                <ItemTemplate>
                    <asp:Label ID="lblDateIssueDelete" runat="server" Text='<%# Bind("DateIssue") %>'></asp:Label>
                </ItemTemplate>

            </asp:TemplateField>
            <%--DateOfIssue--%>
            
            <%--Expiring Date--%>
            <asp:TemplateField HeaderText="Expiring Date">

                <EditItemTemplate>
                    <asp:TextBox ID="txtExpiringDateUpdate" runat="server" Text='<%# Bind("ExpiringDate") %>'></asp:TextBox>
                </EditItemTemplate>

                <FooterTemplate>
                    <asp:TextBox ID="txtExpiringDateInsert" runat="server"></asp:TextBox>
                </FooterTemplate>

                <ItemTemplate>
                    <asp:Label ID="lblExpiringDateDelete" runat="server" Text='<%# Bind("ExpiringDate") %>'></asp:Label>
                </ItemTemplate>

            </asp:TemplateField>
            <%--ExpiringDate--%>
            
            <%--TotalPay--%>
            <asp:TemplateField HeaderText="Total To Pay">

                <EditItemTemplate>
                    <asp:TextBox ID="txtTotalPayUpdate" runat="server" Text='<%# Bind("TotalPay") %>'></asp:TextBox>
                </EditItemTemplate>

                <FooterTemplate>
                    <asp:TextBox ID="txtTotalPayInsert" runat="server"></asp:TextBox>
                </FooterTemplate>

                <ItemTemplate>
                    <asp:Label ID="lblTotalPayDelete" runat="server" Text='<%# Bind("TotalPay") %>'></asp:Label>
                </ItemTemplate>

            </asp:TemplateField>
            <%--TotalPay--%>
            
            <%--Status--%>
            <asp:TemplateField HeaderText="Status">
                        
                <EditItemTemplate>
                    <%--<asp:DropDownList ID="ddlStatusUpdate"  runat="server"></asp:DropDownList>--%>
                    <asp:DropDownList ID="ddlStatusUpdate" runat="server">
                        <asp:ListItem Text="Unpaid" Value="Inpaid"></asp:ListItem>
                        <asp:ListItem Text="Paid" Value="Paid"></asp:ListItem>
                    </asp:DropDownList>
                </EditItemTemplate>
                
                <FooterTemplate>
                    <%--<asp:DropDownList ID="ddlStatusInsert" runat="server"></asp:DropDownList>--%>
                    <asp:DropDownList ID="ddlStatusInsert" runat="server">
                        <asp:ListItem Text="Unpaid" Value="Inpaid"></asp:ListItem>
                        <asp:ListItem Text="Paid" Value="Paid"></asp:ListItem>
                    </asp:DropDownList>
                </FooterTemplate>

                <ItemTemplate >
                    <asp:Label ID="lblStatus"  runat="server" Text='<%# Bind("Status") %>' ></asp:Label>
                </ItemTemplate>
                
            </asp:TemplateField>
            <%--Status--%>
            
            <%--Actions--%>
            <asp:TemplateField HeaderText="Actions">
                <ItemTemplate>
                    <asp:Button ID="btnView" runat="server" Text="View" CommandName="btnView" CommandArgument="<%# Container.DataItemIndex %>" />
                    <asp:LinkButton ID="btnCancel" runat="server" Text="Cancel" CommandName="btnCancel" />
                    <asp:LinkButton ID="btnEdit" runat="server" Text="Edit" CommandName="btnEdit" />
                    <asp:Button ID="btnUpdate" runat="server" Text="Update" CommandName="btnUpdate" CommandArgument="<%# Container.DataItemIndex %>" />
                    <asp:Button ID="btnDelete" runat="server" Text="Delete" CommandName="btnDelete" CommandArgument="<%# Container.DataItemIndex %>"/>
                </ItemTemplate>
                        
                <FooterTemplate>
                    <asp:Button ID="btnAdd" runat="server" Text="Add" CommandName="btnAdd" CausesValidation="True"/>
                </FooterTemplate>
              
            </asp:TemplateField>
            <%--Actions--%>

        </Columns>

    </asp:GridView>

</asp:Content>
