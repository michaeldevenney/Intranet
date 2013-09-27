<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="default.aspx.cs" Inherits="apps_reports_default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="titleContent" runat="Server">
    Veritas - Applications - Reports
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="headContent" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="mainContent" runat="Server">
    <div>Click on the report in the list below to run</div>
    <div class="extdatarow" style="margin-top:5px; height:175px;">        
        <asp:DropDownList ID="ddlReports" runat="server" AutoPostBack="true" 
            onselectedindexchanged="ddlReports_SelectedIndexChanged" />        
    </div>
</asp:Content>
