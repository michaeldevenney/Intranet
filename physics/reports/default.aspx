<%@ Page Language="C#" AutoEventWireup="true" CodeFile="default.aspx.cs" Inherits="physics_reports_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link rel="stylesheet" href="~/styles/menu_style.css" type="text/css" media="screen" />
    <link rel="stylesheet" href="~/styles/site.css" type="text/css" media="screen" />
    <link rel="shortcut icon" href="~/images/favicon.ico" />
    <title>Veritas - Physics Reports</title>
</head>
<body style="background-color: Gray;">
    <form id="form1" runat="server">
    <%-- Menu--%>
    <div style="background-color: Silver; margin-left: auto; margin-right: auto; width: 1000px; border: 1px solid Black;">
        <ul id="menu">
            <li><a href="../../Default.aspx" title="">Home</a></li>             
            <li><a href="../../admin/default.aspx">Admin</a></li>
            <li><a href="../../marketing/Default.aspx">Marketing</a></li>
            <li><a href="../../default.aspx">PM</a></li>
            <li><a href="../default.aspx" class="current">Physics</a></li>
        </ul>
    </div>
    <%--Form--%>
    <div style="background-color: Silver; margin-left: auto; margin-right: auto; width: 1000px; border: 1px solid Black;">
        <div class="heading">
            <asp:Label ID="Label5" runat="server" Text="Physics Report Status"></asp:Label>
        </div>        
    </div>
    </form>
</body>
</html>
