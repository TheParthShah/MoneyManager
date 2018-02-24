<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="MoneyManager.Home" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            margin-right: 137px;
            font-family: Verdana;  
            font-size: 10pt;  
            font-weight: normal;  
            color: black; 
        }
        #chartDiv{
            width : 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>


    <h3>Transaction Record Charts</h3>
    <hr  />

        <div id="chartDiv">
            <%--<asp:DropDownList ID="DropDownList1" runat="server">
                <asp:ListItem Value="01">January</asp:ListItem>
                <asp:ListItem Value="02">Febuary</asp:ListItem>
                <asp:ListItem Value="03">March</asp:ListItem>
                <asp:ListItem Value="04">April</asp:ListItem>
                <asp:ListItem Value="05">May</asp:ListItem>
                <asp:ListItem Value="06">June</asp:ListItem>
                <asp:ListItem Value="07">July</asp:ListItem>
                <asp:ListItem Value="08">August</asp:ListItem>
                <asp:ListItem Value="09">October</asp:ListItem>
                <asp:ListItem Value="10">September</asp:ListItem>
                <asp:ListItem Value="11">November</asp:ListItem>
                <asp:ListItem Value="12">December</asp:ListItem>
            </asp:DropDownList>--%>
            <asp:Chart ID="ExpenseInfo" runat="server" Height="200px" Width="375px" BackColor="#f2f2f2">  
                <Titles>  
                    <asp:Title  Name="Contents" Visible="true" Text="Expense" />  
                </Titles>  
                <Legends>  
                    <asp:Legend Alignment="Center" LegendItemOrder="SameAsSeriesOrder" TableStyle="Tall" TitleSeparator="DotLine" Docking="Left" IsTextAutoFit="true" Name="Default" LegendStyle="Table" />  
                </Legends>  
                <Series>  
                    <asp:Series Name="Expense" />  
                </Series>  
                <ChartAreas>  
                    <asp:ChartArea Name="Expense" BorderWidth="1" BackColor="#f2f2f2" />  
                </ChartAreas>  
            </asp:Chart>  

            <asp:Chart ID="IncomeInfo" runat="server" Height="200px" Width="375px" BackColor="#f2f2f2" >  
                <Titles>  
                    <asp:Title ShadowOffset="0" Name="Contents" Text="Income" Visible="true" />  
                </Titles>  
                <Legends>  
                    <asp:Legend Alignment="Center" LegendItemOrder="SameAsSeriesOrder" TableStyle="Tall" TitleSeparator="DotLine" Docking="Right" IsTextAutoFit="true" Name="Default" LegendStyle="Table" />  
                </Legends>  
                <Series>  
                    <asp:Series Name="Income" />  
                </Series>  
                <ChartAreas>  
                    <asp:ChartArea Name="Income" BorderWidth="1" BackColor="#f2f2f2" />  
                </ChartAreas>  
            </asp:Chart> 
        </div>

    <br /><br />
        <hr  />
        <asp:Table runat="server" ID="totalTable" Width="100%">
            <asp:TableHeaderRow><asp:TableHeaderCell Font-Bold="true" Font-Size="X-Large" ColumnSpan="4">Amount Details</asp:TableHeaderCell></asp:TableHeaderRow>
            <asp:TableRow><asp:TableCell ColumnSpan="4"><hr /></asp:TableCell></asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Exp" runat="server" Text="Expense"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Income" runat="server" Text="Income"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Total" runat="server" Text="Total"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblExpense" runat="server" Text="Expense"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="lblIncome" runat="server" Text="Income"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="lblTotal" runat="server" Text="Total"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            
        </asp:Table>
    <br /><br />
    
    <h3>Daily Transaction Records</h3>
    <hr  />
     <asp:Button ID="btnExport" runat="server" Text="Export To Excel" OnClick = "ExportToExcel" class="btn btn-theme btn-block" />
    <br />
    <div>
    <asp:GridView ID="GridView1" runat="server" EnableSortingAndPagingCallbacks="true" AllowSorting="true" CellSpacing="10" CellPadding="5" CssClass="auto-style1" ForeColor="#333333" GridLines="Both" AutoGenerateColumns="False" DataKeyNames="TransactionId"  Width="100%" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" Height="110px" >
        <AlternatingRowStyle BackColor="White" />
        <RowStyle HorizontalAlign="Left"></RowStyle>
        <Columns>
            <asp:BoundField DataField="TranDate" HeaderText="Date" />
            <asp:BoundField DataField="TransactionTypeName" HeaderText="Transaction Type" />
            <asp:BoundField DataField="Type" HeaderText="Type" />
            <asp:BoundField DataField="CategoryName" HeaderText="Category" />
            <asp:BoundField DataField="Contents" HeaderText="Contents" />
            <asp:BoundField DataField="Details" HeaderText="Details" />
            <asp:BoundField DataField="Amount" HeaderText="Amount" />
            <asp:CommandField ShowEditButton="True" />
            <asp:CommandField ShowDeleteButton="True" />
        </Columns>
        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
        <SortedAscendingCellStyle BackColor="#FDF5AC" />
        <SortedAscendingHeaderStyle BackColor="#4D0000" />
        <SortedDescendingCellStyle BackColor="#FCF6C0" />
        <SortedDescendingHeaderStyle BackColor="#820000" />

    </asp:GridView>
    </div>
</asp:Content>
