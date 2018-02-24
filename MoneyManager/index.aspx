<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="MoneyManager.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta name="description" content="Keeping track of money usage" />
    <meta name="author" content="Parth Shah" />

    <title>The Money Manager</title>

    <!-- Bootstrap core CSS -->
    <link href="css/bootstrap.css" rel="stylesheet" />
    <!--external css-->
    <link href="font-awesome/css/font-awesome.css" rel="stylesheet" />
        
    <!-- Custom styles for this template -->
    <link href="css/style.css" rel="stylesheet" />
    <link href="css/style-responsive.css" rel="stylesheet" />
</head>
<body>
    <div id="login-page">
	  	<div class="container">
	  	
		      <form class="form-login" id="form1" runat="server">
		        <h2 class="form-login-heading">Login</h2>
		        <div class="login-wrap">
                    <asp:TextBox ID="tbuname" runat="server" class="form-control" placeholder="User ID"></asp:TextBox>
		            <br />
                    <asp:TextBox ID="tbpwd" runat="server" class="form-control" placeholder="Password" TextMode="Password"></asp:TextBox>
		            <br />
                    <asp:Button ID="btnlogin" runat="server" Text="LOGIN" class="btn btn-theme btn-block" OnClick="btnlogin_Click"  />
                    <br />
		        </div>
		      </form>
	  	</div>
	  </div>

     <!-- js placed at the end of the document so the pages load faster -->
    <script src="assets/js/jquery.js"></script>
    <script src="assets/js/bootstrap.min.js"></script>

    <!--BACKSTRETCH-->
    <!-- You can use an image of whatever size. This script will stretch to fit in any screen size.-->
    <script type="text/javascript" src="assets/js/jquery.backstretch.min.js"></script>
    <script>
        //$.backstretch("assets/img/login-bg.jpg", {speed: 500});
    </script>
</body>
</html>
