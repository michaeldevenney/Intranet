<%@ Page Title="RFI Tracking" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="rfiView.aspx.cs" Inherits="pm_RFI_rfiView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="titleContent" runat="Server">
    Veritas - Project Management - RFIs
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="headContent" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="mainContent" runat="Server">
    <%--New RFI Entry Form--%>
    <div id="fuzz1">
        <div class="newRFI">
            <div class="heading">
                <asp:Label ID="lblHeading" runat="server" Text="Enter New RFI"></asp:Label>
                <img style="height: 20px; width: 20px;" alt="Close" class="close1" src="../../images/error.png" />
            </div>
            <div class="datarow">
                <asp:Label ID="lblProjectAdd" runat="server" Text="Project:" />
                <asp:DropDownList ID="ddlProjectAdd" runat="server" class="datafield" OnSelectedIndexChanged="ddlProjectADD_SelectedIndexChanged" />
            </div>
            <div class="datarow">
                <asp:Label ID="Label12" runat="server" Text="Subject:"></asp:Label>&nbsp;&nbsp;
                <asp:TextBox ID="txtSubjectAdd" Width="300px" class="datafield" runat="server"></asp:TextBox>
            </div>
            <div class="datarow">
                <asp:Label ID="Label13" runat="server" Text="Priority: "></asp:Label>
                <asp:DropDownList ID="ddlPriorityAdd" class="datafield" runat="server">
                    <asp:ListItem Selected="True">(Select Priority)</asp:ListItem>
                    <asp:ListItem>Low - 1 week turnaround</asp:ListItem>
                    <asp:ListItem>Medium - 3 day turnaround</asp:ListItem>
                    <asp:ListItem>High - 1 day turnaround</asp:ListItem>
                    <asp:ListItem>RUSH - Work halted until resolved.</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="heading">
                References</div>
            <div class="datarow">
                <asp:Label ID="Label14" runat="server" Text="Drawing #:"></asp:Label>&nbsp;&nbsp;
                <asp:TextBox ID="txtRefDrawingNumberAdd" Width="300px" class="datafield" runat="server"></asp:TextBox>
            </div>
            <div class="datarow">
                <asp:Label ID="Label15" runat="server" Text="Location:"></asp:Label>&nbsp;&nbsp;
                <asp:TextBox ID="txtRefLocationAdd" Width="300px" class="datafield" runat="server"></asp:TextBox>
            </div>
            <div class="datarow">
                <asp:Label ID="Label16" runat="server" Text="Specification Section:"></asp:Label>&nbsp;&nbsp;
                <asp:TextBox ID="txtRefSpecSectionAdd" Width="300px" class="datafield" runat="server"></asp:TextBox>
            </div>
            <div class="datarow">
                <asp:Label ID="Label17" runat="server" Text="Other:"></asp:Label>&nbsp;&nbsp;
                <asp:TextBox ID="txtRefOtherAdd" Width="300px" class="datafield" runat="server"></asp:TextBox>
            </div>
            <div class="heading">
                Request</div>
            <div class="extdatarow" >
                <asp:TextBox CssClass="multiline" ID="txtRequestAdd" Wrap="true" Rows="4" Style="margin-right: 2%;"
                    Width="98%" runat="server" TextMode="MultiLine" />
            </div>
            <div class="heading">
                Suggestion</div>
            <div class="extdatarow" >
                <asp:TextBox CssClass="multiline" ID="txtSuggestAdd" Wrap="true" Rows="4" Style="margin-right: 2%;"
                    Width="98%" runat="server" TextMode="MultiLine" />
            </div>
            <div class="datarow">
                <asp:Label ID="Label18" runat="server" Style="color: Red;" Text="" Visible="false" />
                <asp:Button ID="cmdSubmitAdd" Style="float: right;" runat="server" Text="Submit RFI to PM"
                    OnClick="cmdSubmitAdd_Click" />
            </div>
        </div>
    </div>
    <%--RFI View--%>
    <div style="position: relative;">
        <asp:Table runat="server" ID="filterTable" HorizontalAlign="Center" GridLines="Vertical">
            <asp:TableRow BackColor="#FBA349" HorizontalAlign="Center" Font-Bold="True" ForeColor="Black">
                <asp:TableCell>Owner</asp:TableCell>
                <asp:TableCell ColumnSpan="2">Lead/Project</asp:TableCell>
                <asp:TableCell>Show Closed RFIs</asp:TableCell>
                <asp:TableCell></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:RadioButtonList ID="rdoRFIOwnerFilter" runat="server" AutoPostBack="false">
                        <asp:ListItem Text="All" Value="All" />
                        <asp:ListItem Text="Mine" Value="Mine" />
                    </asp:RadioButtonList>
                </asp:TableCell>                
                <asp:TableCell>
                    <asp:Label ID="lblFilterProjectLead" runat="server" Text="Select Project:" />
                    <asp:DropDownList ID="ddlFilterProject" runat="server" />
                </asp:TableCell><asp:TableCell HorizontalAlign="Left">
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
                </asp:TableCell><asp:TableCell HorizontalAlign="Center">
                    <asp:CheckBox ID="chkClosedFilter" runat="server" />
                </asp:TableCell><asp:TableCell HorizontalAlign="Center">
                    <asp:Button ID="cmdApplyFilter" runat="server" Text="Show RFI List" OnClick="cmdApplyFilter_Click" />
                </asp:TableCell></asp:TableRow></asp:Table><asp:Image ID="imgAdd" runat="server" class="alert1" ImageUrl="~/images/Add.png"
            ToolTip="Create New RFI" Style="position: absolute; top: 5px; right: 10px; height: 20px;
            width: 20px; vertical-align: middle;" />
    </div>
    <br />
    <asp:Label ID="lblFilterInfo" Style="color: Red;" runat="server" Text=" "></asp:Label><asp:GridView ID="gvRFIList" runat="server" DataSourceID="sdsRFI" AutoGenerateColumns="False"
        DataKeyNames="ID" EnableModelValidation="True" Style="margin-left: 5px; margin-right: 5px; margin-bottom:5px;"
        OnSelectedIndexChanged="gvRFIList_SelectedIndexChanged">
        <Columns>
            <asp:CommandField ButtonType="Image" SelectImageUrl="~/images/edit.jpg" ShowSelectButton="True"
                EditImageUrl="~/images/delete.jpg"></asp:CommandField>
            <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" SortExpression="ID"
                Visible="False" />
            <asp:BoundField DataField="ProjectID" HeaderText="ProjectID" SortExpression="ProjectID"
                Visible="False" />
            <asp:BoundField DataField="Subject" HeaderText="Subject" SortExpression="Subject" />
            <asp:BoundField DataField="Request" HeaderText="Request" SortExpression="Request" />
            <asp:BoundField DataField="PMAssigned" HeaderText="PMAssigned" SortExpression="PMAssigned" />
            <asp:BoundField 
                    DataField="SubmittedBy" HeaderText="Submitted By" 
                    SortExpression="SubmittedBy" /></Columns>
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#FBA349" Font-Bold="True" ForeColor="Black" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#E2DED6" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#F7F6F3" ForeColor="#333333" />
    </asp:GridView>
    <%--Form--%>
    <div class="heading">
        <asp:Label ID="lblProjectLeadHeader" runat="server" Text="Project Request For Information"></asp:Label></div><div class="datarow">
        <asp:Label ID="lblProject" runat="server" Text="Project:"></asp:Label>&nbsp;&nbsp; <asp:TextBox ID="txtProject" runat="server" CssClass="datafield" Width="300px" />
        <%--<asp:DropDownList ID="ddlProject" runat="server" class="datafield" DataSource=' <%# GetActiveProjects() %>'
            DataTextField="ProjectName" DataValueField="ID" />--%>
    </div>
    <div class="datarow">
        <asp:Label ID="Label2" runat="server" Text="Subject:"></asp:Label>&nbsp;&nbsp; <asp:TextBox ID="txtSubject" Width="300px" class="datafield" runat="server"></asp:TextBox></div><div class="datarow">
        <asp:Label ID="Label3" runat="server" Text="Priority"></asp:Label><asp:DropDownList ID="ddlPriority" class="datafield" runat="server">
            <asp:ListItem Selected="True">(Select Priority)</asp:ListItem><asp:ListItem>Low - 1 week turnaround</asp:ListItem><asp:ListItem>Medium - 3 day turnaround</asp:ListItem><asp:ListItem>High - 1 day turnaround</asp:ListItem><asp:ListItem>RUSH - Work halted until resolved.</asp:ListItem></asp:DropDownList></div><div class="datarow">
        <asp:Label ID="Label4" runat="server" Text="PM Assigned:"></asp:Label>&nbsp;&nbsp; <asp:DropDownList ID="ddlPMAssigned" runat="server" class="datafield" DataSource=' <%# GetPMs() %>'
            DataTextField="Name" DataValueField="ID">
        </asp:DropDownList>
    </div>
    <div class="heading">
        References: What or where in the job does the RFI refer to?</div><div class="datarow">
        <asp:Label ID="Label6" runat="server" Text="Drawing #:"></asp:Label>&nbsp;&nbsp; <asp:TextBox ID="txtRefDrawingNumber" Width="300px" class="datafield" runat="server"></asp:TextBox></div><div class="datarow">
        <asp:Label ID="Label7" runat="server" Text="Location:"></asp:Label>&nbsp;&nbsp; <asp:TextBox ID="txtRefLocation" Width="300px" class="datafield" runat="server"></asp:TextBox></div><div class="datarow">
        <asp:Label ID="Label8" runat="server" Text="Specification Section:"></asp:Label>&nbsp;&nbsp; <asp:TextBox ID="txtRefSpecSection" Width="300px" class="datafield" runat="server"></asp:TextBox></div><div class="datarow">
        <asp:Label ID="Label9" runat="server" Text="Other:"></asp:Label>&nbsp;&nbsp; <asp:TextBox ID="txtRefOther" Width="300px" class="datafield" runat="server"></asp:TextBox></div><div class="heading">
        Request</div><div class="extdatarow">
        <asp:TextBox CssClass="multiline" ID="txtRequest" Wrap="true" Rows="4" Style="margin-right: 2%;"
            Width="98%" runat="server" TextMode="MultiLine" />
    </div>
    <div class="heading">
        Suggestion</div><div class="extdatarow">
        <asp:TextBox CssClass="multiline" ID="txtSuggest" Wrap="true" Rows="4" Style="margin-right: 2%;"
            Width="98%" runat="server" TextMode="MultiLine" />
    </div>
    <div class="heading">
        PM Section</div><div class="datarow">
        <asp:Label ID="Label5" runat="server" Text="Corecon RFI #:"></asp:Label>&nbsp;&nbsp; <asp:TextBox ID="txtCoreconID" class="datafield" runat="server"></asp:TextBox></div><div class="extdatarow" style="height: 90px;">
        <asp:Label ID="Label10" runat="server" Text="Response:"></asp:Label>&nbsp;&nbsp;<br />
        <asp:TextBox CssClass="multiline" ID="txtResponse" Wrap="true" Rows="4" Style="margin-right: 2%;"
            Width="98%" runat="server" TextMode="MultiLine" />
    </div>
    <div class="datarow" style="height: 35px;">
        <asp:Button ID="cmdUpdate" Style="float: right;" runat="server" Text="Update RFI"
            OnClick="cmdSave_Click" />
        <asp:Button ID="cmdDelete" Style="float: right;" runat="server" Text="Delete RFI"
            OnClick="cmdDelete_Click" />
        <asp:Label ID="Label11" runat="server" Style="float: left;" Text="RFI Closed" />
        <asp:DropDownList ID="ddlClosed" runat="server">
            <asp:ListItem Text="Closed" Value="Closed" />
            <asp:ListItem Selected="True" Text="Open" Value="Open" />
        </asp:DropDownList>
    </div>
    <div class="datarow">
        <asp:Label ID="lblStatus" runat="server" Style="color: Red;" Text="" Visible="false" />
    </div>
    <asp:SqlDataSource ID="sdsRFI" runat="server" ConnectionString="<%$ ConnectionStrings:VeritasInfo %>"
        SelectCommand="SELECT * FROM [PM_RFI]"></asp:SqlDataSource>
</asp:Content>
