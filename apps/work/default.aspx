<%@ Page Title="PM - Work Tracking" Language="C#" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="true" CodeFile="default.aspx.cs" Inherits="apps_work_default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="titleContent" runat="Server">
    PM - Work Tracking
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="headContent" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="mainContent" runat="Server">
    <%--ENTRY FORM--%>
    <asp:Table ID="Table1" runat="server" Width="100%">
        <asp:TableRow>
            <asp:TableCell ColumnSpan="2" HorizontalAlign="Right">
                <asp:HyperLink ID="hlReport" Style="float: right;" NavigateUrl="http://veritas15/reports?/Project%20Management/ProjectWorkSummary"
                    runat="server">View Summary Report</asp:HyperLink>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow VerticalAlign="Top">
            <asp:TableCell>
                <asp:Calendar ID="calDateWorked" runat="server" Height="120px" Width="149px" OnSelectionChanged="calDateWorked_Changed" SelectedDayStyle-BackColor="#FBA349" />
            </asp:TableCell>
            <asp:TableCell Width="70%">
                <asp:Table ID="Table2" runat="server" Width="100%">
                    <asp:TableRow>
                        <asp:TableCell ColumnSpan="4" HorizontalAlign="Center" BackColor="Gray">
                            <asp:Label ID="lblDateSelected" runat="server" Text="" style="font-size:large; font-weight:bolder; color:#FBA349" />
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow Style="font-weight: bold; font-size: medium;">
                        <asp:TableCell>Project</asp:TableCell>
                        <asp:TableCell>Description</asp:TableCell>
                        <asp:TableCell>Hrs</asp:TableCell>
                        <asp:TableCell>Comments</asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:DropDownList ID="ddlProject1" runat="server" Style="float: right;" DataSource=' <%# GetActiveProjects() %>'
                                DataTextField="DisplayName" DataValueField="ID" OnSelectedIndexChanged="ddlProject1_SelectedIndexChanged" AutoPostBack="true" />
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="txtDescription1" runat="server"></asp:TextBox>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="txtHours1" runat="server" Width="25px"></asp:TextBox>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="txtComments1" runat="server"></asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:DropDownList ID="ddlProject2" runat="server" Style="float: right;" DataSource=' <%# GetActiveProjects() %>'
                                DataTextField="DisplayName" DataValueField="ID" OnSelectedIndexChanged="ddlProject2_SelectedIndexChanged" AutoPostBack="true" />
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="txtDescription2" runat="server"></asp:TextBox>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="txtHours2" runat="server" Width="25px"></asp:TextBox>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="txtComments2" runat="server"></asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:DropDownList ID="ddlProject3" runat="server" Style="float: right;" DataSource=' <%# GetActiveProjects() %>'
                                DataTextField="DisplayName" DataValueField="ID" OnSelectedIndexChanged="ddlProject3_SelectedIndexChanged" AutoPostBack="true" />
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="txtDescription3" runat="server"></asp:TextBox>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="txtHours3" runat="server" Width="25px"></asp:TextBox>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="txtComments3" runat="server"></asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:DropDownList ID="ddlProject4" runat="server" Style="float: right;" DataSource=' <%# GetActiveProjects() %>'
                                DataTextField="DisplayName" DataValueField="ID" OnSelectedIndexChanged="ddlProject4_SelectedIndexChanged" AutoPostBack="true" />
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="txtDescription4" runat="server"></asp:TextBox>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="txtHours4" runat="server" Width="25px"></asp:TextBox>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="txtComments4" runat="server"></asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell></asp:TableCell><asp:TableCell HorizontalAlign="left">
                <asp:Button ID="cmdSave" runat="server" class="datafield" Text="Save Entry" OnClick="cmdSave_Clicked" />
            </asp:TableCell></asp:TableRow>
    </asp:Table>
</asp:Content>
