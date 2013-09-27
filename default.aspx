<%@ Page Title="Veritas Intranet" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="default.aspx.cs" Inherits="_default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="titleContent" runat="Server">
    Veritas Medical Solutions - Intranet Home Page
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="headContent" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="mainContent" runat="Server">    
    <div class="datarow" style="height: auto; margin-bottom: 5px;">
        <asp:Label runat="server" ID="lbl1" Text="Welcome to the Veritas Intranet site." />
    </div>
</asp:Content>
