<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="apps_schedules_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="titleContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="headContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="mainContent" Runat="Server">
    File Name: <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <asp:Button ID="Button1" runat="server" Text="..." tooltip="Browse for file"/>
    <br />
    Task Name: <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <br />
    Start Date: 
    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
    <br />
    End Date: 
    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
    <br />
    <asp:Button ID="Button2" runat="server" Text="Save" />
</asp:Content>

