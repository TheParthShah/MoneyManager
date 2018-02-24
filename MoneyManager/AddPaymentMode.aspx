<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="AddPaymentMode.aspx.cs" Inherits="MoneyManager.AddPaymentMode" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:Table ID="Table1" runat="server" Width="100%" CellPadding="10" CellSpacing="10">
                    <asp:TableHeaderRow >
                        <asp:TableHeaderCell  Font-Bold="true" Font-Size="X-Large" ColumnSpan="4">Add Payment Mode</asp:TableHeaderCell>
                    </asp:TableHeaderRow> 
                    
                    <asp:TableRow><asp:TableCell ColumnSpan="4"><hr /></asp:TableCell></asp:TableRow>
        
                    <asp:TableRow>
                        <asp:TableHeaderCell ColumnSpan="2"><span>Payment Mode Type</span></asp:TableHeaderCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell ColumnSpan="2">
                            <asp:TextBox ID="tbPaymentModeType" runat="server" class="form-control"></asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>
                    
                    <asp:TableRow><asp:TableCell><br /></asp:TableCell></asp:TableRow>
        
                    <asp:TableRow>
                        <asp:TableCell Width="152px">
                            <asp:Button ID="btnAddPayMode" runat="server" Text="Add" class="btn btn-theme btn-block" OnClick="btnAddPayMode_Click" />
                        </asp:TableCell>
                        
                    </asp:TableRow>
                </asp:Table>
</asp:Content>
