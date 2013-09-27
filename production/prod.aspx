<%@ Page Language="C#" AutoEventWireup="true" CodeFile="prod.aspx.cs" Inherits="prod" %>

<%@ Register Namespace="CustomParameters" TagPrefix="ver" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="styles/menu_style.css" type="text/css" media="screen" />
    <link rel="stylesheet" href="styles/site.css" type="text/css" media="screen" />
    <link rel="shortcut icon" href="images/favicon.ico" />
    <title>Production</title>
</head>
<body style="background-color: Gray;">
    <form id="form1" runat="server">
    <%-- Menu--%><asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div style="background-color: Silver; margin-left: auto; margin-right: auto; width: 1000px;
        border: 1px solid Black;">
        <ul id="menu">
            <li><a href="prod.aspx" title="" class="current">Production</a></li>
            <li><a href="ship.aspx" title="">Shipping</a></li>
            <li><a href="summary.aspx" title="">Summary</a></li>
        </ul>
    </div>
    <%--Form--%>
    <div style="background-color: Silver; margin-left: auto; margin-right: auto; width: 1000px;
        border: 1px solid Black;">
        <div class="heading">
            <asp:Label ID="Label5" runat="server" Text="Production Date"></asp:Label>
        </div>
        <asp:Calendar CssClass="standard" ID="calProductionDate" runat="server" BackColor="White"
            BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana"
            Font-Size="8pt" ForeColor="Black" Height="180px" Width="200px" OnSelectionChanged="calProductionDate_SelectionChanged">
            <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
            <NextPrevStyle VerticalAlign="Bottom" />
            <OtherMonthDayStyle ForeColor="#808080" />
            <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
            <SelectorStyle BackColor="#CCCCCC" />
            <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
            <WeekendDayStyle BackColor="#FBA349" />
        </asp:Calendar>
        <!-- KILNED SECTION -->
        <div class="heading">
            <asp:Label ID="Label1" runat="server" Text="Block Kilned"></asp:Label>
        </div>
        <div class="datarow">
            <asp:Label runat="server" ID="lbl1" Text="V250: " />
            <asp:TextBox CssClass="datafield" ID="txtV250K" runat="server"></asp:TextBox><br />
            <asp:RequiredFieldValidator ValidationGroup="Saving" Display="None" ControlToValidate="txtV250K"
                ID="RequiredFieldValidator1" runat="server" ErrorMessage="A value is required for # of V250 kilned today.  Enter 0 if none."></asp:RequiredFieldValidator>
        </div>
        <div class="datarow">
            <asp:Label runat="server" ID="Label2" Text="V300: " />
            <asp:TextBox CssClass="datafield" ID="txtV300K" runat="server"></asp:TextBox><br />
            <asp:RequiredFieldValidator ValidationGroup="Saving" Display="None" ControlToValidate="txtV300K"
                ID="RequiredFieldValidator2" runat="server" ErrorMessage="A value is required for # of V300 kilned today.  Enter 0 if none."></asp:RequiredFieldValidator>
        </div>
        <!-- YARDED SECTION -->
        <div class="heading">
            <asp:Label ID="Label4" runat="server" Text="Block Yarded"></asp:Label>
        </div>
        <asp:Table ID="Table1" runat="server">
            <asp:TableHeaderRow>
                <asp:TableHeaderCell>Block Type</asp:TableHeaderCell>
                <asp:TableHeaderCell>Count</asp:TableHeaderCell>
                <asp:TableHeaderCell>Project</asp:TableHeaderCell>
                <asp:TableHeaderCell>Comment</asp:TableHeaderCell>
                <asp:TableHeaderCell></asp:TableHeaderCell>
            </asp:TableHeaderRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:DropDownList ID="ddlBlockIns" runat="server" CssClass="datafield" DataTextField="LookupValue"
                            DataSource='<%# GetLookupList("Block") %>' />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtCountIns" runat="server" Style="width: 100px;"></asp:TextBox>
                    <asp:RequiredFieldValidator ValidationGroup="Inserting" Display="None" ControlToValidate="txtCountIns"
                        ID="rfvCount" runat="server" ErrorMessage="Count is required"></asp:RequiredFieldValidator>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList ID="ddlProjectIns" runat="server" CssClass="datafield" DataTextField="ProjectName"
                        DataValueField="ID" />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtCommentIns" runat="server" Style="width: 150px;"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Button ID="cmdInsert" CausesValidation="true" ValidationGroup="Inserting" runat="server"
                        Text="Add" OnClick="cmdInsert_Click" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <asp:Label ID="lblDateValidation" Style="color: Red;" runat="server" Visible="false"
            Text="Please select the production date."></asp:Label>
        <asp:ValidationSummary ID="vsInserting" ValidationGroup="Inserting" runat="server" />
        <asp:GridView ID="gvYardedBlock" runat="server" AutoGenerateColumns="False" EnableModelValidation="True"
            AllowSorting="True" DataSourceID="SqlDataSource1" DataKeyNames="ID" CellPadding="4"
            ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ButtonType="Image"
                    CancelImageUrl="~/images/cancel.JPG" DeleteImageUrl="~/images/delete.jpg" EditImageUrl="~/images/edit.jpg"
                    InsertImageUrl="~/images/insert.png" NewImageUrl="~/images/insert.png" UpdateImageUrl="~/images/update.JPG" />
                <asp:BoundField DataField="BlockType" HeaderText="BlockType" SortExpression="BlockType" />
                <asp:BoundField DataField="Count" HeaderText="Count" SortExpression="Count" />
                <asp:TemplateField HeaderText="Project">
                    <EditItemTemplate>
                        <asp:DropDownList ID="ddlProjectEdit" runat="server" CssClass="datafield" DataTextField="ProjectName"
                            DataValueField="ID" DataSource='<%# GetActiveProjects() %>' SelectedValue='<%# Bind("ProjectID") %>' />
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblProjectName" runat="server" Text='<%# Bind("ProjectName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" Visible="False" />
                <asp:BoundField DataField="ProjectID" HeaderText="ProjectID" SortExpression="ProjectID"
                    Visible="False" />
                <asp:BoundField DataField="Comment" HeaderText="Comment" />
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#FBA349" Font-Bold="True" ForeColor="Black" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        </asp:GridView>
        <!-- MISC SECTION -->
        <div class="heading">
            <asp:Label ID="Label11" runat="server" Text="Other Information"></asp:Label>
        </div>
        <div class="datarow">
            <asp:Label runat="server" ID="Label13" Text="Downtime (minutes): " />
            <asp:RequiredFieldValidator ValidationGroup="Saving" Display="None" ControlToValidate="txtDowntime"
                ID="RequiredFieldValidator3" runat="server" ErrorMessage="A value is required for minutes of Downtime today.  Enter 0 if none."></asp:RequiredFieldValidator>
            <asp:TextBox CssClass="datafield" ID="txtDowntime" runat="server"></asp:TextBox><br />
        </div>
        <div class="extdatarow">
            <asp:Label runat="server" ID="Label14" Text="Downtime Comments: " />
            <asp:TextBox CssClass="multiline" ID="txtDowntimeComments" runat="server"></asp:TextBox><br />
        </div>
        <hr />
        <div class="datarow">
            <asp:Label runat="server" ID="Label15" Text="Injuries: " />
            <asp:RequiredFieldValidator ValidationGroup="Saving" Display="None" ControlToValidate="txtInjuries"
                ID="RequiredFieldValidator4" runat="server" ErrorMessage="A value is required for # of injuries today.  Enter 0 if none."></asp:RequiredFieldValidator>
            <asp:TextBox CssClass="datafield" ID="txtInjuries" runat="server"></asp:TextBox><br />
        </div>
        <div class="extdatarow">
            <asp:Label runat="server" ID="Label27" Text="Injury Comments: " />
            <asp:TextBox CssClass="multiline" ID="txtInjuryComments" runat="server"></asp:TextBox><br />
        </div>
        <hr />
        <div class="datarow">
            <asp:Button ID="Button1" runat="server" Text="Submit Report" CausesValidation="true"
                ValidationGroup="Saving" OnClick="Button1_Click" />
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="Saving"
                ShowMessageBox="true" ShowSummary="false" />
        </div>
    </div>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:VeritasInfo %>"
        DeleteCommand="DELETE FROM [A_Production] WHERE [ID] = @ID" InsertCommand="INSERT INTO [A_Production] ([ProjectID], [ProductionDate], [BlockType], [Action], [Count], [EnteredDate], [EnteredBy], [Comment], [ProjectName]) VALUES (@ProjectID, @ProductionDate, @BlockType, @Action, @Count, @EnteredDate, @EnteredBy, @Comment, @ProjectName)"
        SelectCommand="SELECT * FROM [A_Production] WHERE ([ProductionDate] = @ProductionDate)"
        UpdateCommand="UPDATE [A_Production] SET [ProjectID] = @ProjectID, [ProductionDate] = @ProductionDate, [BlockType] = @BlockType, [Action] = @Action, [Count] = @Count, [EnteredDate] = @EnteredDate, [EnteredBy] = @EnteredBy, [Comment] = @Comment, [ProjectName] = @ProjectName WHERE [ID] = @ID"
        OnDeleting="sdsDeleting" OnUpdating="sdsUpdating">
        <DeleteParameters>
            <asp:Parameter Name="ID" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:ControlParameter Name="ProjectID" Type="Int32" ControlID="ddlProjectIns" PropertyName="SelectedValue" />
            <asp:ControlParameter Name="ProductionDate" Type="DateTime" ControlID="calProductionDate"
                PropertyName="SelectedDate" />
            <asp:ControlParameter Name="BlockType" Type="String" ControlID="ddlBlockIns" PropertyName="SelectedValue" />
            <asp:Parameter Name="Action" Type="String" DefaultValue="Yarded" />
            <asp:ControlParameter Name="Count" Type="Decimal" ControlID="txtCountIns" PropertyName="Text" />
            <asp:ControlParameter Name="Comment" Type="String" ControlID="txtCommentIns" PropertyName="Text" />
            <asp:ControlParameter Name="ProjectName" Type="String" ControlID="ddlProjectIns"
                PropertyName="SelectedItem.Text" />
            <ver:CurrentUserParameter Name="EnteredBy" Type="String" />
            <ver:DayParameter Name="EnteredDate" DaySetting="Today" Type="DateTime" />
        </InsertParameters>
        <SelectParameters>
            <asp:ControlParameter ControlID="calProductionDate" Name="ProductionDate" PropertyName="SelectedDate"
                Type="DateTime" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="ProjectID" Type="Int32" />
            <asp:Parameter Name="ProductionDate" Type="DateTime" />
            <asp:Parameter Name="BlockType" Type="String" />
            <asp:Parameter Name="Action" Type="String" />
            <asp:Parameter Name="Count" Type="Decimal" />
            <asp:Parameter Name="EnteredBy" Type="String" />
            <asp:Parameter Name="EnteredDate" Type="DateTime" />
            <asp:Parameter Name="Comment" Type="String" />
            <asp:Parameter Name="ProjectName" Type="String" />
            <asp:Parameter Name="ID" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
    </form>
</body>
</html>
