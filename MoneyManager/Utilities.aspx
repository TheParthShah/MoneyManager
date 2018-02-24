<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="Utilities.aspx.cs" Inherits="MoneyManager.Utilities" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <link rel="stylesheet" href="cc.css" />
    <script src="JQuery/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="JQuery/ccGOOG.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:Table ID="Table1" runat="server">

        <asp:TableHeaderRow >
            <asp:TableHeaderCell ColumnSpan="4" Font-Bold="true" Font-Size="X-Large">Current Currency Exchange Rate</asp:TableHeaderCell>
        </asp:TableHeaderRow>
        
        <asp:TableRow><asp:TableCell ColumnSpan="4"><hr /></asp:TableCell></asp:TableRow>

        <asp:TableRow><asp:TableCell><br /></asp:TableCell></asp:TableRow>
        <asp:TableRow>
            <%--<asp:TableCell HorizontalAlign="right">Enter Amount:</asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="tbAmount"  class="form-control" runat="server" Text="1" MaxLength="12"></asp:TextBox>
            </asp:TableCell>--%>
        </asp:TableRow>

        <asp:TableRow><asp:TableCell><br /></asp:TableCell></asp:TableRow>
        

        <asp:TableRow>
            <asp:TableHeaderCell >Base Currency :</asp:TableHeaderCell>
            <asp:TableCell>
                <asp:Label ID="Label2" runat="server" Font-Bold="true" Text="US Dollars"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow><asp:TableCell><br /></asp:TableCell></asp:TableRow>

        <asp:TableRow>
            <asp:TableHeaderCell>To :</asp:TableHeaderCell>
            <asp:TableCell>
                <asp:DropDownList ID="drpTo" runat="server" class="form-control">
                    <asp:ListItem Value="INR" Selected="True">Indian Rupee</asp:ListItem>
                    <asp:ListItem Value="USD">US Dollar</asp:ListItem>
                    <asp:ListItem Value="AED">United Arab Emirates Dirham</asp:ListItem>
                    <asp:ListItem Value="JPY">Japanese Yen</asp:ListItem>
                    <asp:ListItem Value="CNY">Chinese Yuan</asp:ListItem>
                </asp:DropDownList>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow><asp:TableCell><br /></asp:TableCell></asp:TableRow>
        
        <asp:TableRow>
            <asp:TableCell ColumnSpan="2">
                <asp:Button id="ExchangeRate"  runat="server" Text="Check Rate" class="btn btn-theme btn-block" OnClick="ExchangeRate_Click"  />
            </asp:TableCell>
        </asp:TableRow>
        
         <asp:TableRow><asp:TableCell><br /></asp:TableCell></asp:TableRow>
         <asp:TableRow><asp:TableCell><br /></asp:TableCell></asp:TableRow>

        <asp:TableRow HorizontalAlign="Center">
            <asp:TableCell id="results" HorizontalAlign="Center">
                Result : <asp:Label ID="Label1" Font-Bold="true" Font-Size="Large" runat="server" Text=""></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
         
    </asp:Table>
</asp:Content>
