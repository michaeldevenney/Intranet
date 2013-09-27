<%@ Page Language="C#" AutoEventWireup="true" CodeFile="default.aspx.cs" Inherits="pm_takeoff_default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link rel="stylesheet" href="~/styles/menu_style.css" type="text/css" media="screen" />
    <link rel="stylesheet" href="~/styles/site.css" type="text/css" media="screen" />
    <link rel="shortcut icon" href="~/images/favicon.ico" />
    <title>Veritas - Project Materials Takeoff</title>
    <script type="text/javascript" src="http://jqueryjs.googlecode.com/files/jquery-1.3.2.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {

            //Adjust height of overlay to fill screen when page loads  
            $("#takeoff").css("height", $(document).height());

            
            //When the link that triggers the message is clicked fade in overlay/msgbox  
            $(".alert").click(function () {
                $("#takeoff").fadeIn();                
                return false;
            });

            //When the message box is closed, fade out
            $(".close").click(function () {
                $("#takeoff").fadeOut();
                return false;
            });

        });
                
        //Adjust height of overlay to fill screen when browser gets resized  
        $(window).bind("resize", function () {
            $("#takeoff").css("height", $(window).height());
        });         
    </script>
</head>
<body style="background-color: Gray;">
    <form id="form1" runat="server">
     <%--Popup forms--%>
    <div id="takeoff">
        <div class="msgbox">
            <%--Room Entry Form Here--%>
            <div class="heading">
                <asp:Label ID="lblNewRoom" runat="server" Text="Enter Takeoff Info"></asp:Label>
                <img style="height: 20px; width: 20px;" class="close" src="../../images/error.png" />
            </div>
            <div class="datarow">
                <asp:Label ID="Label21" runat="server" Text="Block Type"></asp:Label>
                <asp:DropDownList ID="ddlBlockType" TabIndex="1" class="datafield" runat="server" DataSource=' <%# GetLookupList("Block") %>' DataTextField="LookupValue" DataValueField="ID" />                
            </div>
            <div class="datarow">
                <asp:Label ID="Label1" runat="server" Text="Section Description"></asp:Label>
                <asp:TextBox ID="txtDescription" TabIndex="2" style="width:200px;" class="datafield" runat="server"></asp:TextBox>
            </div>
            <div class="datarow">
                <asp:Label ID="Label4" runat="server" Text="Section Length"></asp:Label>
                <asp:Label ID="Label9" style="float:right;" runat="server" Text="Inches" />
                <asp:TextBox ID="txtLengthIn" TabIndex="4" style="width:25px;" class="datafield" runat="server"/>
                <asp:Label ID="Label8" style="float:right;" runat="server" Text="Feet" />
                <asp:TextBox ID="txtLengthFt" TabIndex="3" style="width:25px;" class="datafield" runat="server"/>
            </div>
            <div class="datarow">
                <asp:Label ID="Label6" runat="server" Text="Section Height"></asp:Label>
                <asp:Label ID="Label14" style="float:right;" runat="server" Text="Inches" />
                <asp:TextBox ID="txtHeightIn" TabIndex="6" style="width:25px;" class="datafield" runat="server"/>
                <asp:Label ID="Label12" style="float:right;" runat="server" Text="Feet" />
                <asp:TextBox ID="txtHeightFt" TabIndex="5" style="width:25px;" class="datafield" runat="server"/>
            </div>
            <div class="datarow">
                <asp:Label ID="Label7" runat="server" Text="Wythes of Block"></asp:Label>
                <asp:Label ID="Label16" style="float:right; margin-right:2px;" runat="server" Text="Half" />
                <asp:TextBox ID="txtWythesHT" TabIndex="8" style="width:25px;" class="datafield" runat="server"/>
                <asp:Label ID="Label17" style="float:right;" runat="server" Text="Full" />
                <asp:TextBox ID="txtWythes" TabIndex="7" style="width:25px;" class="datafield" runat="server"/>
            </div>
            <div class="datarow">
                <asp:Label ID="Label10" runat="server" Text="Grout Cells - Vertical"></asp:Label>
                <asp:TextBox ID="txtGroutVert" TabIndex="9" class="datafield" runat="server"></asp:TextBox>
            </div>
            <div class="datarow">
                <asp:Label ID="Label11" runat="server" Text="Grout Cells - Horizontal"></asp:Label>
                <asp:TextBox ID="txtGroutHoriz" TabIndex="10" class="datafield" runat="server"></asp:TextBox>
            </div>
            <div class="datarow">
                <asp:Label ID="Label15" runat="server" Text="Deductions (manual)"></asp:Label>
                <asp:TextBox ID="txtDeductionsManual" TabIndex="11" class="datafield" runat="server"></asp:TextBox>
            </div>            
            <div class="datarow">
                <asp:Label ID="Label13" runat="server" Text="Shifts Override"></asp:Label>
                <asp:TextBox ID="txtShiftsManual" TabIndex="12" class="datafield" runat="server"></asp:TextBox>
            </div>            
            <div class="datarow">                
                <asp:Button ID="cmdAddTakeoff" TabIndex="13" runat="server" Text="Save Takeoff Data" OnClick="cmdAddTakeoff_Click" />
            </div>
        </div>
    </div>
    <%-- Menu--%>
    <div style="background-color: Silver; margin-left: auto; margin-right: auto; width: 1000px;
        border: 1px solid Black;">
        <ul id="menu">
            <li><a href="../../Default.aspx" title="">Home</a></li>
            <li><a href="../../admin/default.aspx">Admin</a></li>
            <li><a href="../../marketing/Default.aspx">Marketing</a></li>
            <li><a href="../default.aspx" class="current">PM</a></li>
            <li><a href="../../physics/default.aspx">Physics</a></li>
        </ul>
    </div>
   
    <%--Form--%>
    <div style="background-color: Silver; margin-left: auto; margin-right: auto; width: 1000px;
        border: 1px solid Black;">
        <div class="heading">
            <asp:Label ID="Label5" runat="server" Text="Select Project"></asp:Label>
             <asp:DropDownList ID="ddlProject" CssClass="datafield" runat="server" DataSource=' <%# GetActiveProjects() %>'
                DataTextField="ProjectName" DataValueField="ID" AutoPostBack="true" OnSelectedIndexChanged="ddlProject_SelectedIndexChanged" />
        </div>
        <div class="datarow">
            <asp:Label ID="Label2" runat="server" Text="Select Takeoff from dropdown or click Create New button"></asp:Label>
           <asp:DropDownList ID="ddlTakeoffs" CssClass="datafield" runat="server" 
                DataTextField="ProjectName" DataValueField="ID" AutoPostBack="true" OnSelectedIndexChanged="ddlProject_SelectedIndexChanged" />
        </div>
        <div class="heading">
            <asp:Label ID="Label3" runat="server" Text="Takeoff Details"></asp:Label>
            <asp:Image ID="imgAddRoom" runat="server" class="alert" ImageUrl="~/images/Add.png" ToolTip="Add Takeoff Information" Style="float: right; height: 20px; width: 20px; vertical-align:middle;" />
        </div>
        <asp:GridView ID="gvTakeoffDetails" Style="margin-right: 5px;" runat="server" AutoGenerateColumns="False"
            DataKeyNames="ID" DataSourceID="sdsTakeoffDetails" EnableModelValidation="True" AllowSorting="True"
            CellPadding="4" ForeColor="#333333" GridLines="None" >
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True"
                    SortExpression="ID" Visible="False" />
                <asp:BoundField DataField="TakeoffID" HeaderText="TakeoffID" 
                    SortExpression="TakeoffID" Visible="False">
                </asp:BoundField>
                <asp:BoundField DataField="BlockType" HeaderText="Block Type" 
                    SortExpression="BlockType">
                </asp:BoundField>
                <asp:BoundField DataField="WallDescription" HeaderText="Description" 
                    SortExpression="WallDescription">
                </asp:BoundField>
                <asp:BoundField DataField="Length" HeaderText="L" 
                    SortExpression="Length">
                </asp:BoundField>
                <asp:BoundField DataField="Height" HeaderText="H" 
                    SortExpression="Height" />
                <asp:BoundField DataField="Wythes" HeaderText="W" 
                    SortExpression="Wythes" />
                <asp:BoundField DataField="BlockCountHalf" HeaderText="Half Block" 
                    SortExpression="BlockCountHalf" />
                <asp:BoundField DataField="BlockCount" HeaderText="Full Block" 
                    SortExpression="BlockCount" />
                <asp:BoundField DataField="GroutCellsVertical" HeaderText="Grout Cells V" 
                    SortExpression="GroutCellsVertical" />
                <asp:BoundField DataField="GroutCellsHorizontal" HeaderText="Grout Cells H" 
                    SortExpression="GroutCellsHorizontal" />
                <asp:BoundField DataField="Deductions" HeaderText="Deducts." 
                    SortExpression="Deductions" />
                <asp:BoundField DataField="Shifts" HeaderText="Shifts" 
                    SortExpression="Shifts" />
                <asp:BoundField DataField="ShiftOverride" HeaderText="Override" 
                    SortExpression="ShiftOverride" />
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#FBA349" Font-Bold="True" ForeColor="Black" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#E2DED6" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        </asp:GridView>
    </div>
    <asp:SqlDataSource ID="sdsTakeoffDetails" runat="server" ConnectionString="<%$ ConnectionStrings:VeritasInfo %>"
        DeleteCommand="DELETE FROM [PM_TakeoffDetail] WHERE [ID] = @ID" InsertCommand="INSERT INTO [PM_TakeoffDetail] ([TakeoffID], [BlockType], [WallDescription], [Length], [Height], [Wythes], [BlockCountHalf], [BlockCount], [GroutCellsVertical], [GroutCellsHorizontal], [Deductions], [Shifts], [ShiftOverride]) VALUES (@TakeoffID, @BlockType, @WallDescription, @Length, @Height, @Wythes, @BlockCountHalf, @BlockCount, @GroutCellsVertical, @GroutCellsHorizontal, @Deductions, @Shifts, @ShiftOverride)"
        
         SelectCommand="SELECT * FROM [PM_TakeoffDetail] WHERE ([TakeoffID] = @TakeoffID)" 
         UpdateCommand="UPDATE [PM_TakeoffDetail] SET [TakeoffID] = @TakeoffID, [BlockType] = @BlockType, [WallDescription] = @WallDescription, [Length] = @Length, [Height] = @Height, [Wythes] = @Wythes, [BlockCountHalf] = @BlockCountHalf, [BlockCount] = @BlockCount, [GroutCellsVertical] = @GroutCellsVertical, [GroutCellsHorizontal] = @GroutCellsHorizontal, [Deductions] = @Deductions, [Shifts] = @Shifts, [ShiftOverride] = @ShiftOverride WHERE [ID] = @ID">
        <DeleteParameters>
            <asp:Parameter Name="ID" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="TakeoffID" Type="Int32" />
            <asp:Parameter Name="BlockType" Type="String" />
            <asp:Parameter Name="WallDescription" Type="String" />
            <asp:Parameter Name="Length" Type="Decimal" />
            <asp:Parameter Name="Height" Type="Decimal" />
            <asp:Parameter Name="Wythes" Type="Decimal" />
            <asp:Parameter Name="BlockCountHalf" Type="Decimal" />
            <asp:Parameter Name="BlockCount" Type="Decimal" />
            <asp:Parameter Name="GroutCellsVertical" Type="Int32" />
            <asp:Parameter Name="GroutCellsHorizontal" Type="Int32" />
            <asp:Parameter Name="Deductions" Type="Decimal" />
            <asp:Parameter Name="Shifts" Type="Int32" />
            <asp:Parameter Name="ShiftOverride" Type="Int32" />
        </InsertParameters>
        <SelectParameters>
            <asp:ControlParameter ControlID="ddlTakeoffs" DefaultValue="0" Name="TakeoffID" 
                PropertyName="SelectedValue" Type="Int32" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="TakeoffID" Type="Int32" />
            <asp:Parameter Name="BlockType" Type="String" />
            <asp:Parameter Name="WallDescription" Type="String" />
            <asp:Parameter Name="Length" Type="Decimal" />
            <asp:Parameter Name="Height" Type="Decimal" />
            <asp:Parameter Name="Wythes" Type="Decimal" />
            <asp:Parameter Name="BlockCountHalf" Type="Decimal" />
            <asp:Parameter Name="BlockCount" Type="Decimal" />
            <asp:Parameter Name="GroutCellsVertical" Type="Int32" />
            <asp:Parameter Name="GroutCellsHorizontal" Type="Int32" />
            <asp:Parameter Name="Deductions" Type="Decimal" />
            <asp:Parameter Name="Shifts" Type="Int32" />
            <asp:Parameter Name="ShiftOverride" Type="Int32" />
            <asp:Parameter Name="ID" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
    </form>
</body>
</html>
