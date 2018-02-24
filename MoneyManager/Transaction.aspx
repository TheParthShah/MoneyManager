<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="Transaction.aspx.cs" Inherits="MoneyManager.Transaction" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    
    <asp:Table ID="Table1" runat="server" Width="100%" Height="100%">
        <asp:TableHeaderRow>
            <asp:TableHeaderCell Font-Bold="true" Font-Size="X-Large" ColumnSpan="4">Record Transactions</asp:TableHeaderCell>
        </asp:TableHeaderRow>


        <asp:TableRow><asp:TableCell><hr /></asp:TableCell></asp:TableRow>

        <asp:TableRow>
            <asp:TableHeaderCell ColumnSpan="2"><span>Date</span></asp:TableHeaderCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell ColumnSpan="2">
                <cc1:CalendarExtender ID="TranDate" Enabled="true" Format="dd/MMM/yyyy" TargetControlID="tbTranDate" runat="server"></cc1:CalendarExtender>
                <asp:TextBox ID="tbTranDate" runat="server" class="form-control" Width="152px" ></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>


        <asp:TableRow><asp:TableCell><br /></asp:TableCell></asp:TableRow>
        
        <asp:TableRow>
            <asp:TableHeaderCell ColumnSpan="2"><span>Transaction Type</span></asp:TableHeaderCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell ColumnSpan="2">
                <asp:RadioButtonList ID="rblTranType" runat="server" RepeatDirection="Horizontal" CssClass="rbl" Enabled="true" >
                    <asp:ListItem Text="Income" Value=" Income">Income&nbsp;&nbsp;&nbsp;</asp:ListItem>
                    <asp:ListItem Selected="True" Text=" Expense" Value="Expense">Expense&nbsp;&nbsp;&nbsp;</asp:ListItem>
                    <asp:ListItem Text="Transfer" Value=" Transfer">Transfer&nbsp;&nbsp;&nbsp;</asp:ListItem>
                </asp:RadioButtonList>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow><asp:TableCell><br /></asp:TableCell></asp:TableRow>
        
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="Label1" runat="server" Text="Payment Mode" >Payment Mode</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="Label2" runat="server" Text="Category" >Category</asp:Label>
            </asp:TableCell>
        </asp:TableRow>


        <asp:TableRow>
            <asp:TableCell>
                <cc1:DropDownExtender ID="ddePayMode" runat="server" Enabled="true" TargetControlID="tbPayMode"></cc1:DropDownExtender>
                <cc1:AutoCompleteExtender ID="acePayMode" runat="server" Enabled="true" ServiceMethod="PaymentMode" MinimumPrefixLength="0" EnableCaching="false" CompletionInterval="100" CompletionSetCount="10" TargetControlID="tbPayMode" FirstRowSelected="false"></cc1:AutoCompleteExtender>
                <asp:TextBox ID="tbPayMode" runat="server" class="form-control" Width="152px" ></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>
                <cc1:DropDownExtender ID="ddeTranCategory" runat="server" Enabled="true" TargetControlID="tbTranCategory"></cc1:DropDownExtender>
                <cc1:AutoCompleteExtender ID="aceTranCategory" runat="server" Enabled="true" ServiceMethod="Categories" MinimumPrefixLength="0" EnableCaching="false" CompletionInterval="100" CompletionSetCount="10" TargetControlID="tbTranCategory" FirstRowSelected="false"></cc1:AutoCompleteExtender>
                <asp:TextBox ID="tbTranCategory" runat="server" class="form-control" Width="252px"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>


        <asp:TableRow><asp:TableCell><br /></asp:TableCell></asp:TableRow>
        
        <asp:TableRow>
            <asp:TableHeaderCell ColumnSpan="2"><span>Transaction Name</span></asp:TableHeaderCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell ColumnSpan="2">
                <asp:TextBox ID="tbTranNAme" runat="server" class="form-control" ></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>

        
        <asp:TableRow><asp:TableCell><br /></asp:TableCell></asp:TableRow>
        
        <asp:TableRow>
            <asp:TableHeaderCell ColumnSpan="2"><span>Details</span></asp:TableHeaderCell>
         </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell ColumnSpan="2">
                <asp:TextBox ID="tbDetails" runat="server" class="form-control"  TextMode="MultiLine" ></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow><asp:TableCell><br /></asp:TableCell></asp:TableRow>
        
        <asp:TableRow>
            <asp:TableHeaderCell ColumnSpan="2"><span>Amount</span></asp:TableHeaderCell>
         </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell ColumnSpan="2">
                <asp:TextBox ID="tbAmout" runat="server" class="form-control" Width="152px" ></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow><asp:TableCell><br /></asp:TableCell></asp:TableRow>
        
        <asp:TableRow>
            <asp:TableCell ColumnSpan="2">
                <asp:Button ID="btnRecord" runat="server" Text="Record" class="btn btn-theme btn-block" OnClick="btnRecord_Click" />
            </asp:TableCell>
        </asp:TableRow>


    </asp:Table>

</asp:Content>
