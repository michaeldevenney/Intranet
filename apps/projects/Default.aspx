<%@ Page Title="Project Details" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="apps_projects_Default" %>
    <%--<%@ Register TagPrefix="ver" TagName="projectFilter" Src="~/_controls/projectFilter.ascx" %>--%>

<asp:Content ID="Content1" ContentPlaceHolderID="titleContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="headContent" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="mainContent" runat="Server">
    <%--New Lead/Project Entry Form--%>
    <div id="fuzz1">
        <div class="newLeadProj">
            <div class="heading">
                <asp:Label ID="lblHeading" runat="server" Text="Enter New Lead/Project"></asp:Label>
                <img style="height: 20px; width: 20px;" alt="Close" class="close1" src="../../images/error.png" />
            </div>
            <asp:Table ID="Table2" runat="server" Width="100%">
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="Label7" runat="server" Text="This is a new "></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:DropDownList ID="ddlProjectLead" runat="server">
                            <asp:ListItem Text="Lead" Value="Lead" />
                            <asp:ListItem Text="Project" Value="Project" />
                        </asp:DropDownList>
                    </asp:TableCell>
                    <asp:TableCell></asp:TableCell>
                    <asp:TableCell></asp:TableCell>
                    <asp:TableCell></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="Label1" runat="server" Text="Project/Lead Number"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="txtAddProjNumber" runat="server"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell></asp:TableCell>
                    <asp:TableCell>
                        <asp:Label ID="Label2" runat="server" Text="Name"></asp:Label></asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="txtAddProjName" runat="server" Width="250px"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="Label3" runat="server" Text="Activity"></asp:Label>
                        </asp:TableCell>
                    <asp:TableCell>
                        <asp:DropDownList ID="ddlAddProjActivity" runat="server" DataSource=' <%# GetLookupList("Project Activity") %>'
                            DataTextField="LookupValue" DataValueField="LookupValue" />
                    </asp:TableCell>
                    <asp:TableCell></asp:TableCell>
                    <asp:TableCell>
                        <asp:Label ID="Label4" runat="server" Text="Location"></asp:Label></asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="txtAddProjLocation" runat="server"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="Label6" runat="server" Text="Assigned PM"></asp:Label></asp:TableCell>
                    <asp:TableCell>
                        <asp:DropDownList ID="ddlAddProjMgr" runat="server" DataSource=' <%# GetUsersByTitle("Project Manager") %>'
                            DataTextField="Name" DataValueField="ID" />
                    </asp:TableCell>
                    <asp:TableCell></asp:TableCell>
                    <asp:TableCell></asp:TableCell>
                    <asp:TableCell></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell ColumnSpan="5" HorizontalAlign="Center">
                        <asp:Button ID="cmdAddProjLead" runat="server" Text="Create Lead/Project" OnClick="cmdAddProjLead_Click" />                        
                    </asp:TableCell>
                </asp:TableRow>               
            </asp:Table>
        </div>
    </div>
    <%--Dropdown Filter--%>
    <div style="position: relative;">
        <%--<ver:projectFilter runat="server" />--%>
        <asp:Table ID="Table3" runat="server">
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="left">
                    <asp:Label ID="lblProjectLead" runat="server" Text="Select Project:" />
                    <asp:DropDownList ID="ddlProject" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlProject_SelectedIndexChanged" />
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Left">
                    <asp:RadioButtonList RepeatDirection="Horizontal" ID="rdoLeadProject" runat="server"
                        AutoPostBack="true" OnSelectedIndexChanged="rdoLeadProject_SelectedIndexChanged">
                        <asp:ListItem Selected="true" Text="Show Projects" Value="Projects" />
                        <asp:ListItem Text="Show Leads" Value="Leads" />
                    </asp:RadioButtonList>
                    <asp:RadioButtonList RepeatDirection="Horizontal" ID="rdoActiveAll" runat="server"
                        AutoPostBack="true" OnSelectedIndexChanged="rdoActiveAll_SelectedIndexChanged">
                        <asp:ListItem Selected="true" Text="Just Active" Value="Active" />
                        <asp:ListItem Text="Show All" Value="All" />
                    </asp:RadioButtonList>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <asp:Image ID="imgAddRoom" runat="server" class="alert1" ImageUrl="~/images/Add.png"
            ToolTip="Create a new project or lead" Style="position: absolute; top: 5px; right: 10px;
            height: 20px; width: 20px; vertical-align: middle;" />
    </div>
    <hr />
    <asp:Table ID="Table1" runat="server" Width="100%">
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblNumber" runat="server" Text="Project Number"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtProjectNumber" runat="server"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell></asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lblName" runat="server" Text="Project Name"></asp:Label></asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtProjectName" runat="server" Width="250px"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblActivity" runat="server" Text="Project Activity"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:DropDownList ID="ddlProjectActivity" runat="server" DataSource=' <%# GetLookupList("Project Activity") %>'
                    DataTextField="LookupValue" DataValueField="LookupValue" />
            </asp:TableCell>
            <asp:TableCell></asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lblLocation" runat="server" Text="Project Location"></asp:Label></asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtProjectLocation" runat="server"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
            </asp:TableCell>
            <asp:TableCell>
                    
            </asp:TableCell>
            <asp:TableCell></asp:TableCell>
            <asp:TableCell></asp:TableCell>
            <asp:TableCell></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>Assigned PM</asp:TableCell>
            <asp:TableCell>
                <asp:DropDownList ID="ddlAssignedPM" runat="server" DataSource=' <%# GetUsersByTitle("Project Manager") %>'
                    DataTextField="Name" DataValueField="ID" />
            </asp:TableCell>
            <asp:TableCell></asp:TableCell>
            <asp:TableCell></asp:TableCell>
            <asp:TableCell></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell ColumnSpan="5" HorizontalAlign="Center">
                <asp:Button ID="cmdSave" runat="server" Text="Update Project" OnClick="cmdSaveLeadProj_Click" />
                <asp:Button ID="cmdDelete" runat="server" Text="Delete Project" OnClick="cmdDeleteLeadProj_Click" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell ColumnSpan="5">
                <asp:Label ID="lblRecordStatus" runat="server" Style="font-size: xx-small;" Text="" />
            </asp:TableCell></asp:TableRow></asp:Table></asp:Content>