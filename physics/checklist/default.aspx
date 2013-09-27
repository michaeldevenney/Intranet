<%@ Page Language="C#" AutoEventWireup="true" CodeFile="default.aspx.cs" Inherits="physics_checklist_default"
    MaintainScrollPositionOnPostback="true" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link rel="stylesheet" href="~/styles/menu_style.css" type="text/css" media="screen" />
    <link rel="stylesheet" href="~/styles/site.css" type="text/css" media="screen" />
    <link rel="shortcut icon" href="~/images/favicon.ico" />
    <title>Veritas - Physics Checklist</title>
    <script type="text/javascript" src="http://jqueryjs.googlecode.com/files/jquery-1.3.2.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {

            //Adjust height of overlay to fill screen when page loads  
            $("#fuzz1").css("height", $(document).height());

            //When the link that triggers the message is clicked fade in overlay/msgbox  
            $(".alert1").click(function () {
                $("#fuzz1").fadeIn();
                return false;
            });

            //When the message box is closed, fade out
              
            $(".close1").click(function () {
                $("#fuzz1").fadeOut();
                return false;
            });

        });

        $(document).ready(function () {

            //Adjust height of overlay to fill screen when page loads  
            $("#fuzz2").css("height", $(document).height());

            //When the link that triggers the message is clicked fade in overlay/msgbox  
            $(".alert2").click(function () {
                $("#fuzz2").fadeIn();
                return false;
            });

            //When the message box is closed, fade out

            $(".close2").click(function () {
                $("#fuzz2").fadeOut();
                return false;
            });

        });

        //Adjust height of overlay to fill screen when browser gets resized  
        $(window).bind("resize", function () {
            $("#fuzz1").css("height", $(window).height());
        });

        //Adjust height of overlay to fill screen when browser gets resized  
        $(window).bind("resize", function () {
            $("#fuzz2").css("height", $(window).height());
        }); 
</script>
</head>
<body style="background-color: Gray;">
    <form id="form1" runat="server">
    
    <div id="fuzz1">
        <div class="msgbox1">
            <%--Room Entry Form Here--%>
            <div class="heading">
                <asp:Label ID="lblNewRoom" runat="server" Text="Enter New Room"></asp:Label> 
                <img style="height:20px; width:20px;" class="close1" src="../../images/error.png" />
            </div>
            <div class="datarow">
                <asp:Label ID="Label21" runat="server" Text="Room Name"></asp:Label>
                <asp:TextBox ID="txtRoomName" class="datafield" runat="server"></asp:TextBox> 
            </div>   
            <div class="datarow">
                <asp:Button ID="cmdAddRoom" runat="server" Text="Add Room" OnClick="cmdAddRoom_Click" />
            </div>              
        </div>       
    </div>

    <div id="fuzz2">
        <div class="msgbox2">
            <%--Survey Point Entry Form Here--%>
            <div class="heading">
                <asp:Label ID="Label22" runat="server" Text="Enter New Survery Point"></asp:Label> 
                <img style="height:20px; width:20px;" class="close2" src="../../images/error.png" />
            </div>
            <div class="datarow">
                <asp:Label ID="Label23" runat="server" Text="Survey Point Name"></asp:Label>
                <asp:TextBox ID="txtSPName" class="datafield" runat="server"></asp:TextBox> 
            </div>   
            <div class="datarow">
                <asp:Label ID="Label24" runat="server" Text="Survey Point Description"></asp:Label>
                <asp:TextBox ID="txtSPDescription" class="datafield" runat="server"></asp:TextBox> 
            </div>   
            <div class="datarow">
                <asp:Button ID="Button1" runat="server" Text="Add Survey Point" OnClick="cmdAddSP_Click" />
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
            <li><a href="../../default.aspx">PM</a></li>
            <li><a href="../default.aspx" class="current">Physics</a></li>
        </ul>
    </div>
    <%--Form--%>
    <div style="background-color: Silver; margin-left: auto; margin-right: auto; width: 1000px;
        border: 1px solid Black;">
        <div class="heading">
            <asp:Label ID="Label5" runat="server" Text="Physics Report Checklist"></asp:Label>
        </div>
        <div class="datarow">
            <asp:Label ID="Label2" runat="server" Text="Select Project"></asp:Label>
            <asp:DropDownList ID="ddlProject" CssClass="datafield" runat="server" DataSource=' <%# GetActiveProjects() %>'
                DataTextField="ProjectName" DataValueField="ID" AutoPostBack="true" OnSelectedIndexChanged="ddlProject_SelectedIndexChanged" />
        </div>        
        <asp:Table ID="table1" runat="server" CellPadding="5" Width="100%">
            <asp:TableRow>
                <asp:TableCell ColumnSpan="2">
                    <div class="heading" id="content">
                        <asp:Label ID="lblRoomSummaryHeading" runat="server" Text="Room Summary Information"></asp:Label>
                        <asp:Image ID="imgAddRoom" runat="server" class="alert1" ImageUrl="~/images/Add.png" ToolTip="Add Room" Style="float: right; height: 20px; width: 20px; vertical-align:middle;" />
                    </div>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell VerticalAlign="Top">
                    <asp:Label ID="Label1" runat="server" Text="Select Room using green checkmark button"></asp:Label><br />
                    <asp:GridView ID="gvRooms" Style="margin-right: 5px;" runat="server" AutoGenerateColumns="False"
                        DataKeyNames="ID" DataSourceID="sdsRooms" EnableModelValidation="True" AllowSorting="True"
                        CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="gvRooms_SelectedIndexChanged">
                        <Columns>
                            <asp:CommandField ButtonType="Image" CancelImageUrl="~/images/cancel.JPG" DeleteImageUrl="~/images/delete.jpg"
                                EditImageUrl="~/images/edit.jpg" ShowDeleteButton="True" ShowEditButton="True"
                                UpdateImageUrl="~/images/update.JPG" SelectImageUrl="~/images/update.JPG" ShowSelectButton="True" />
                            <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True"
                                SortExpression="ID" Visible="False" />
                            <asp:BoundField DataField="ProjectID" HeaderText="ProjectID" SortExpression="ProjectID"
                                Visible="False">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="RoomName" HeaderText="Room Name" SortExpression="RoomName">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Machine" HeaderText="Machine" SortExpression="Machine">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="MachineEnergy" HeaderText="Energy" SortExpression="MachineEnergy">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                        </Columns>
                        <EditRowStyle BackColor="#999999" />
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#FBA349" Font-Bold="True" ForeColor="Black" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#E2DED6" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    </asp:GridView>
                </asp:TableCell>
                <asp:TableCell>
                    <%--Room data--%>
                    <div class="datarow">
                        <asp:Label ID="Label4" runat="server" Text="Code:" />
                        <asp:DropDownList ID="ddlCode" Style="float: right;" DataSource=' <%# GetLookupList("ShieldingCodes") %>'
                            DataTextField="LookupValue" DataValueField="ID" runat="server" />
                    </div>
                    <div class="datarow">
                        <asp:Label ID="Label6" runat="server" Text="Entry Style:" />
                        <asp:TextBox ID="txtEntryStyle" Style="float: right;" runat="server" />
                    </div>
                    <div class="datarow">
                        <asp:Label ID="Label7" runat="server" Text="Workload:" />
                        <asp:TextBox ID="txtWorkload" ToolTip="Gy/day @ isocenter" EnableViewState="true" Style="float: right;" runat="server" />
                    </div>
                    <div class="datarow">
                        <asp:Label ID="Label8" runat="server" Text="Leakage Workload:" />
                        <asp:TextBox ID="txtLeakageWorkLoad" ToolTip="Gy/day @ isocenter" Style="float: right;" runat="server" />
                    </div>
                    <div class="datarow">
                        <asp:Label ID="Label9" runat="server" Text="Machine Energy:" />
                        <asp:TextBox ID="txtMachineEnergy" Style="float: right;" runat="server" />
                    </div>
                    <div class="datarow">
                        <asp:Label ID="Label10" runat="server" Text="Machine Dose Rate:" />
                        <asp:TextBox ID="txtMachineDoseRate" Style="float: right;" runat="server" />
                    </div>
                    <div class="heading">
                        <asp:Label ID="Label11" runat="server" Text="Machine Modality" />
                    </div>
                    <asp:Table ID="tblModality" runat="server" Width="100%">
                        <asp:TableHeaderRow>
                            <asp:TableHeaderCell>Modality</asp:TableHeaderCell>
                            <asp:TableHeaderCell>% Energy</asp:TableHeaderCell>
                            <asp:TableHeaderCell>% of Tx Time</asp:TableHeaderCell>
                        </asp:TableHeaderRow>
                        <asp:TableRow>
                            <asp:TableCell HorizontalAlign="Center" ToolTip="Conventional Use">Conventional</asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center">
                                <asp:TextBox ID="txtConvPctEnergy" Width="25px" runat="server" />
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center">
                                <asp:TextBox ID="txtConvPctTx" Width="25px" runat="server" />
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell HorizontalAlign="Center" ToolTip="Intensity-Modulated Radiation Therapy">
                                IMRT
                                <asp:TextBox ID="txtIMRTFactor" Width="20px" Style="float: right;" runat="server" />
                                <asp:Label ID="labelfactor" runat="server" Text="Factor:" Style="float: right;" />
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center">
                                <asp:TextBox ID="txtIMRTPctEnergy" Width="25px" runat="server" />
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center">
                                <asp:TextBox ID="txtIMRTPctTx" Width="25px" runat="server" />
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell HorizontalAlign="Center" ToolTip="Total Body Irradiation">TBI</asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center">
                                <asp:TextBox ID="txtTBIPctEnergy" Width="25px" runat="server" />
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center">
                                <asp:TextBox ID="txtTBIPctTx" Width="25px" runat="server" />
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell HorizontalAlign="Center">Stereotactic</asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center">
                                <asp:TextBox ID="txtStereoPctEnergy" Width="25px" runat="server" />
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center">
                                <asp:TextBox ID="txtStereoPctTx" Width="25px" runat="server" />
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                    <br />
                    <asp:Button ID="cmdSaveRoom" runat="server" Text="Save Room Details" OnClick="cmdSaveRoom_Click" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <asp:Table ID="table2" runat="server" CellPadding="5" Width="100%">
            <asp:TableRow>
                <asp:TableCell ColumnSpan="2">
                    <div class="heading">
                        <asp:Label ID="lblSurveyPointSummaryHeading" runat="server" Text="Room Survey Point Information"></asp:Label>
                        <asp:Image ID="imgNewSP" runat="server" class="alert2" ImageUrl="~/images/Add.png" ToolTip="Add Survey Point" Style="float: right; height: 20px; width: 20px; vertical-align:middle;" />
                    </div>
                </asp:TableCell></asp:TableRow>
            <asp:TableRow>
                <asp:TableCell VerticalAlign="Top">
                    <br />
                    <asp:Label ID="Label3" runat="server" Text="Room Survey Points"></asp:Label><br />
                    <asp:GridView ID="gvSurveyPoints" DataSourceID="sdsSurveyPoints" runat="server" AutoGenerateColumns="False"
                        Style="margin-right: 5px;" DataKeyNames="ID" EnableModelValidation="True" OnSelectedIndexChanged="gvSurveyPoints_SelectedIndexChanged">
                        <Columns>
                            <asp:CommandField ButtonType="Image" SelectImageUrl="~/images/update.JPG" ShowSelectButton="True" />
                            <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True"
                                SortExpression="ID" Visible="False" />
                            <asp:BoundField DataField="RoomID" HeaderText="RoomID" SortExpression="RoomID" Visible="False" />
                            <asp:BoundField DataField="SPSummary" HeaderText="Survey Point" ReadOnly="True" SortExpression="SPSummary" />
                        </Columns>
                        <EditRowStyle BackColor="#999999" />
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#FBA349" Font-Bold="True" ForeColor="Black" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#E2DED6" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    </asp:GridView>
                </asp:TableCell><asp:TableCell>
                    <%-- Survery point data --%>
                    <div class="datarow">
                        <asp:Label ID="Label13" runat="server" Text="Occupancy Factor:" />
                        <asp:TextBox ID="txtSPOccupancyFactor" Style="float: right;" Width="75px" runat="server" />
                    </div>
                    <div class="datarow">
                        <asp:Label ID="Label14" runat="server" Text="Usage Factor:" />
                        <asp:TextBox ID="txtSPUseFactor" Style="float: right;" Width="75px" runat="server" />
                    </div>
                    <div class="datarow">
                        <asp:Label ID="Label16" runat="server" Text="Distance from ISO:" />
                        <div style="float: right;">
                            <asp:Label ID="Label20" runat="server" Text="Feet: " />
                            <asp:TextBox ID="txtSPDistanceFeet" Width="50px" OnTextChanged="SPDistFeet_Changed"
                                AutoPostBack="true" EnableViewState="true" runat="server" />
                            &nbsp;
                            <asp:Label ID="Label19" runat="server" Text="Meters: " />
                            <asp:TextBox ID="txtSPDistanceMeters" ReadOnly="true" Width="50px" runat="server" />
                        </div>
                    </div>
                    <div class="datarow">
                        <asp:Label ID="Label17" runat="server" ToolTip="Permissable Exposure Level" Text="Permissible Exposure Level:" />
                        <asp:TextBox ID="txtSPExposureLevel" Style="float: right;" Width="75px" ToolTip="Permissable Exposure Level"
                            runat="server" />
                    </div>
                    <div class="datarow">
                        <asp:Label ID="Label18" runat="server" Text="Exposure Level Reading Type:" />
                        <asp:TextBox ID="txtSPExposureLevelReadingType" Style="float: right;" Width="100px"
                            ToolTip="Time Avg Dose Reading (TADR) or Instantaneous Dose Reading (IDR)" runat="server" />
                    </div>
                    <div class="datarow">
                        <asp:Label ID="Label12" runat="server" Text="Existing Sheilding:" />
                        <asp:TextBox ID="txtSPExistingShielding" Style="float: right;" Width="200px" runat="server" />
                    </div>
                    <div class="datarow">
                        <asp:Label ID="Label15" runat="server" Text="Adjacent Buildings:" />
                        <asp:TextBox ID="txtSPAdjacentBuildings" Style="float: right;" Width="200px" runat="server" />
                    </div>
                    <br />
                    <asp:Button ID="cmdSaveSurveyPoint" runat="server" Text="Save Survey Point Details"
                        OnClick="cmdSaveSurveyPoint_Click" />
                </asp:TableCell></asp:TableRow>
        </asp:Table>
    </div>
    </form>
    <asp:SqlDataSource ID="sdsSurveyPoints" runat="server" ConnectionString="<%$ ConnectionStrings:VeritasInfo %>"
        OnSelecting="sdsSurvey_Selecting" DeleteCommand="DELETE FROM [A_RoomSurveyPoints] WHERE [ID] = @ID"
        InsertCommand="INSERT INTO [A_RoomSurveyPoints] ([RoomID], [SurveyPoint], [SurveyPointDesc], [OccupancyFactor], [UseFactor], [PELValue], [PELType], [DistanceFromISO], [ExistingShielding]) VALUES (@RoomID, @SurveyPoint, @SurveyPointDesc, @OccupancyFactor, @UseFactor, @PELValue, @PELType, @DistanceFromISO, @ExistingShielding)"
        SelectCommand="SELECT ID, RoomID, SurveyPoint + ISNULL(' - ' + SurveyPointDesc, ' ') AS SPSummary FROM A_RoomSurveyPoints WHERE (RoomID = @RoomID)"
        UpdateCommand="UPDATE [A_RoomSurveyPoints] SET [RoomID] = @RoomID, [SurveyPoint] = @SurveyPoint, [SurveyPointDesc] = @SurveyPointDesc, [OccupancyFactor] = @OccupancyFactor, [UseFactor] = @UseFactor, [PELValue] = @PELValue, [PELType] = @PELType, [DistanceFromISO] = @DistanceFromISO, [ExistingShielding] = @ExistingShielding WHERE [ID] = @ID">
        <DeleteParameters>
            <asp:Parameter Name="ID" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="RoomID" Type="Int32" />
            <asp:Parameter Name="SurveyPoint" Type="String" />
            <asp:Parameter Name="SurveyPointDesc" Type="String" />
            <asp:Parameter Name="OccupancyFactor" Type="Decimal" />
            <asp:Parameter Name="UseFactor" Type="Decimal" />
            <asp:Parameter Name="PELValue" Type="Decimal" />
            <asp:Parameter Name="PELType" Type="String" />
            <asp:Parameter Name="DistanceFromISO" Type="Decimal" />
            <asp:Parameter Name="ExistingShielding" Type="String" />
        </InsertParameters>
        <SelectParameters>
            <asp:SessionParameter DefaultValue="0" Name="RoomID" SessionField="RoomID" Type="Int32" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="RoomID" Type="Int32" />
            <asp:Parameter Name="SurveyPoint" Type="String" />
            <asp:Parameter Name="SurveyPointDesc" Type="String" />
            <asp:Parameter Name="OccupancyFactor" Type="Decimal" />
            <asp:Parameter Name="UseFactor" Type="Decimal" />
            <asp:Parameter Name="PELValue" Type="Decimal" />
            <asp:Parameter Name="PELType" Type="String" />
            <asp:Parameter Name="DistanceFromISO" Type="Decimal" />
            <asp:Parameter Name="ExistingShielding" Type="String" />
            <asp:Parameter Name="ID" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="sdsRooms" runat="server" ConnectionString="<%$ ConnectionStrings:VeritasInfo %>"
        DeleteCommand="DELETE FROM [A_Rooms] WHERE [ID] = @ID" InsertCommand="INSERT INTO [A_Rooms] ([RoomName], [ProjectID], [EntryType], [Machine], [MachineEnergy], [DoorSize], [DoorHand], [DoorOnly], [WorkloadPrimary], [WorkloadSecondary], [MachineDoseRate], [ModConvPctTime], [ModConvPctEnergy], [ModIMRTPctTime], [ModIMRTPctEnergy], [ModIMRTFactor], [ModTBIPctTime], [ModTBIPctEnergy], [ModStereoPctTime], [ModStereoPctEnergy]) VALUES (@RoomName, @ProjectID, @EntryType, @Machine, @MachineEnergy, @DoorSize, @DoorHand, @DoorOnly, @WorkloadPrimary, @WorkloadSecondary, @MachineDoseRate, @ModConvPctTime, @ModConvPctEnergy, @ModIMRTPctTime, @ModIMRTPctEnergy, @ModIMRTFactor, @ModTBIPctTime, @ModTBIPctEnergy, @ModStereoPctTime, @ModStereoPctEnergy)"
        SelectCommand="SELECT * FROM [A_Rooms] WHERE ([ProjectID] = @ProjectID)" UpdateCommand="UPDATE [A_Rooms] SET [RoomName] = @RoomName, [ProjectID] = @ProjectID, [EntryType] = @EntryType, [Machine] = @Machine, [MachineEnergy] = @MachineEnergy, [DoorSize] = @DoorSize, [DoorHand] = @DoorHand, [DoorOnly] = @DoorOnly, [WorkloadPrimary] = @WorkloadPrimary, [WorkloadSecondary] = @WorkloadSecondary, [MachineDoseRate] = @MachineDoseRate, [ModConvPctTime] = @ModConvPctTime, [ModConvPctEnergy] = @ModConvPctEnergy, [ModIMRTPctTime] = @ModIMRTPctTime, [ModIMRTPctEnergy] = @ModIMRTPctEnergy, [ModIMRTFactor] = @ModIMRTFactor, [ModTBIPctTime] = @ModTBIPctTime, [ModTBIPctEnergy] = @ModTBIPctEnergy, [ModStereoPctTime] = @ModStereoPctTime, [ModStereoPctEnergy] = @ModStereoPctEnergy WHERE [ID] = @ID">
        <DeleteParameters>
            <asp:Parameter Name="ID" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="RoomName" Type="String" />
            <asp:Parameter Name="ProjectID" Type="Int32" />
            <asp:Parameter Name="EntryType" Type="String" />
            <asp:Parameter Name="Machine" Type="String" />
            <asp:Parameter Name="MachineEnergy" Type="String" />
            <asp:Parameter Name="DoorSize" Type="Int32" />
            <asp:Parameter Name="DoorHand" Type="String" />
            <asp:Parameter Name="DoorOnly" Type="Boolean" />
            <asp:Parameter Name="WorkloadPrimary" Type="String" />
            <asp:Parameter Name="WorkloadSecondary" Type="String" />
            <asp:Parameter Name="MachineDoseRate" Type="String" />
            <asp:Parameter Name="ModConvPctTime" Type="Decimal" />
            <asp:Parameter Name="ModConvPctEnergy" Type="Decimal" />
            <asp:Parameter Name="ModIMRTPctTime" Type="Decimal" />
            <asp:Parameter Name="ModIMRTPctEnergy" Type="Decimal" />
            <asp:Parameter Name="ModIMRTFactor" Type="Decimal" />
            <asp:Parameter Name="ModTBIPctTime" Type="Decimal" />
            <asp:Parameter Name="ModTBIPctEnergy" Type="Decimal" />
            <asp:Parameter Name="ModStereoPctTime" Type="Decimal" />
            <asp:Parameter Name="ModStereoPctEnergy" Type="Decimal" />
        </InsertParameters>
        <SelectParameters>
            <asp:ControlParameter ControlID="ddlProject" DefaultValue="100" Name="ProjectID"
                PropertyName="SelectedValue" Type="Int32" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="RoomName" Type="String" />
            <asp:Parameter Name="ProjectID" Type="Int32" />
            <asp:Parameter Name="EntryType" Type="String" />
            <asp:Parameter Name="Machine" Type="String" />
            <asp:Parameter Name="MachineEnergy" Type="String" />
            <asp:Parameter Name="DoorSize" Type="Int32" />
            <asp:Parameter Name="DoorHand" Type="String" />
            <asp:Parameter Name="DoorOnly" Type="Boolean" />
            <asp:Parameter Name="WorkloadPrimary" Type="String" />
            <asp:Parameter Name="WorkloadSecondary" Type="String" />
            <asp:Parameter Name="MachineDoseRate" Type="String" />
            <asp:Parameter Name="ModConvPctTime" Type="Decimal" />
            <asp:Parameter Name="ModConvPctEnergy" Type="Decimal" />
            <asp:Parameter Name="ModIMRTPctTime" Type="Decimal" />
            <asp:Parameter Name="ModIMRTPctEnergy" Type="Decimal" />
            <asp:Parameter Name="ModIMRTFactor" Type="Decimal" />
            <asp:Parameter Name="ModTBIPctTime" Type="Decimal" />
            <asp:Parameter Name="ModTBIPctEnergy" Type="Decimal" />
            <asp:Parameter Name="ModStereoPctTime" Type="Decimal" />
            <asp:Parameter Name="ModStereoPctEnergy" Type="Decimal" />
            <asp:Parameter Name="ID" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
</body>
</html>
