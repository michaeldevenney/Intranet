<%@ Page Language="C#" AutoEventWireup="true" CodeFile="bolconfirm.aspx.cs" Inherits="confirm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <link rel="stylesheet" href="styles/menu_style.css" type="text/css" media="screen" />
    <link rel="stylesheet" href="styles/site.css" type="text/css" media="screen" />
    <link rel="shortcut icon" href="images/favicon.ico" />
    <title>BOL Confirmation</title>
</head>
<body>
    <form id="form1" runat="server">
    <%-- Menu--%>
    <div style="background-color: Silver; margin-left: auto; margin-right: auto; width: 1000px; border: 1px solid Black;">
        <ul id="menu">
            <li><a href="prod.aspx" title="">Production</a></li>
            <li><a href="ship.aspx" title="">Shipping</a></li>
            <li><a href="summary.aspx" title="">Summary</a></li>
            <li><a href="" title="" class="current">Confirmation</a></li>
        </ul>
    </div>
    <%--Form--%>
    <div style="background-color: Silver; margin-left: auto; margin-right: auto; width: 1000px;
        border: 1px solid Black;">
        <%--Project Section--%>
        <div class="heading">
            <asp:Label ID="Label23" runat="server" Text="Status"></asp:Label>
        </div>
        <div class="datarow">
            <asp:Label ID="Label1" runat="server" Text="Thanks, your bill of lading has been generated and will arrive at the email address you specified."></asp:Label>
        </div>
    </div>
    </form>
</body>
</html>
