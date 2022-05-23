<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Bills.aspx.cs" Inherits="UI.Bills" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:HyperLink NavigateUrl="Folder.aspx" runat="server">Folders</asp:HyperLink>

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
                    <%--DataFormatString="{dd/MM/yy}"--%>
                    <asp:TextBox ID="txtDateIssueUpdate" Text='<%# Bind("DateIssue") %>' runat="server"></asp:TextBox>
                    <%--<asp:TextBox ID="txtDateIssueUpdate" runat="server" Text='<%# Bind("DateIssue") %>'></asp:TextBox>--%>
                </EditItemTemplate>

                <FooterTemplate>
                    <%--<asp:TextBox ID="txtDateIssueInsert" runat="server"></asp:TextBox>--%>
                    <%--DataFormatString="{dd/MM/yyyy}"--%>
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
                        <asp:ListItem Text="Unpaid" Value="Unpaid"></asp:ListItem>
                        <asp:ListItem Text="Paid" Value="Paid"></asp:ListItem>
                    </asp:DropDownList>
                </EditItemTemplate>

                <FooterTemplate>
                    <%--<asp:DropDownList ID="ddlStatusInsert" runat="server"></asp:DropDownList>--%>
                    <asp:DropDownList ID="ddlStatusInsert" runat="server">
                        <asp:ListItem Text="Unpaid" Value="Unpaid"></asp:ListItem>
                        <asp:ListItem Text="Paid" Value="Paid"></asp:ListItem>
                    </asp:DropDownList>
                </FooterTemplate>

                <ItemTemplate>
                    <asp:Label ID="lblStatus" runat="server" Text='<%# Bind("Status") %>'></asp:Label>
                </ItemTemplate>

            </asp:TemplateField>
            <%--Status--%>

            <%--Document--%>
            <asp:TemplateField HeaderText="Bill">

                <EditItemTemplate>
                    <%--Text='<%# Bind("Document") %>' Placeholder=" ..."--%>
                    <asp:TextBox ID="txtBillUpdate" runat="server" Placeholder=" ..."></asp:TextBox>
                    <asp:Button ID="btnUploadUpdate" CommandArgument="<%# Container.DataItemIndex %>" CommandName="btnUploadUpdate" runat="server" Text=" Select Bill "></asp:Button>
                </EditItemTemplate>

                <FooterTemplate>
                    <asp:TextBox ID="txtBillInsert" runat="server" Placeholder=" ..."></asp:TextBox>
                    <asp:Button ID="btnUpload" CommandArgument="<%# Container.DataItemIndex %>" CommandName="btnUpload" runat="server" Text=" Select Bill "></asp:Button>
                </FooterTemplate>

                <ItemTemplate>
                    <%--Text='<%# Bind("Document") %>'--%>
                    <asp:Label ID="lblBillDelete" runat="server" Text='<%# Bind("IsDocument") %>'></asp:Label>
                </ItemTemplate>

            </asp:TemplateField>
            <%--Document--%>

            <%--Actions--%>
            <asp:TemplateField HeaderText="Actions">
                <ItemTemplate>
                    <asp:Button ID="btnView" runat="server" Text=" View " CommandName="btnView" CommandArgument="<%# Container.DataItemIndex %>" />
                    <asp:LinkButton ID="btnCancel" runat="server" Text="Cancel" CommandName="btnCancel" />
                    <asp:LinkButton ID="btnEdit" runat="server" Text="Edit" CommandName="btnEdit" />
                    <asp:Button ID="btnUpdate" runat="server" Text=" Update " CommandName="btnUpdate" CommandArgument="<%# Container.DataItemIndex %>" />
                    <asp:Button ID="btnDelete" runat="server" Text=" Delete " CommandName="btnDelete" CommandArgument="<%# Container.DataItemIndex %>" />
                </ItemTemplate>

                <FooterTemplate>
                    <asp:Button ID="btnAdd" runat="server" Text=" Add " CommandName="btnAdd" CausesValidation="True" />
                </FooterTemplate>

            </asp:TemplateField>
            <%--Actions--%>
        </Columns>

    </asp:GridView>

    <%--Image Modal--%>
    <%--<div id="image" class="modal fade" tabindex="-1" role="dialog" aria-hidden="true">

        <div class="modal-dialog" role="document">

            <div class="modal-content">

                <div class="modal-body">
                    <table>
                        <tr>
                            <asp:Image ID="imgBill" runat="server" />
                        </tr>
                    </table>
                </div>

                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                </div>

            </div>

        </div>
    </div>--%>
    <%--Image Modal--%>
</asp:Content>
