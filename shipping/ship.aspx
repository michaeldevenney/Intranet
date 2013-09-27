<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ship.aspx.cs" Inherits="ship"
    MaintainScrollPositionOnPostback="true" %>

<%@ Register Namespace="CustomParameters" TagPrefix="ver" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link rel="stylesheet" href="../styles/menu_style.css" type="text/css" media="screen" />
    <link rel="stylesheet" href="../styles/site.css" type="text/css" media="screen" />
    <link rel="shortcut icon" href="../images/favicon.ico" />
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
    <title>Shipping</title>
</head>
<body style="background-color: Gray;">
    <form id="form1" runat="server">
    <div id="fuzz1">
        <div class="newAddr">
            <%--New Address--%>
            <div class="heading-popup">
                <asp:Label ID="lblNewAddress" runat="server" Text="Enter New Address for "></asp:Label>
                <img style="height: 20px; width: 20px;" class="close1" src="../images/Error.png"
                    alt="Cancel" />
            </div>
            <div class="datarow">
                <asp:Label ID="Label15" runat="server" Text="Address Type"></asp:Label>
                <asp:DropDownList ID="ddlAddrType" runat="server">
                    <asp:ListItem Text="Ship To" Value="105" />
                    <asp:ListItem Text="Ship From" Value="106" />
                </asp:DropDownList>
            </div>
            <div class="datarow" style="height: 50px;">
                <asp:Label ID="Label16" runat="server" Text="Address Description"></asp:Label>
                <br />
                <asp:TextBox ID="txtAddrDescription" runat="server" Style="width: 95%;"></asp:TextBox>
            </div>
            <div class="datarow">
                <asp:Label ID="Label25" runat="server" Text="Line 1"></asp:Label>
                <asp:TextBox ID="txtAddrLine1" CssClass="datafield-ext" runat="server"></asp:TextBox>
            </div>
            <div class="datarow">
                <asp:Label ID="Label27" runat="server" Text="Line 2"></asp:Label>
                <asp:TextBox ID="txtAddrLine2" CssClass="datafield-ext" runat="server"></asp:TextBox>
            </div>
            <div class="datarow">
                <asp:Label ID="Label28" runat="server" Text="Line 3"></asp:Label>
                <asp:TextBox ID="txtAddrLine3" CssClass="datafield-ext" runat="server"></asp:TextBox>
            </div>
            <div class="datarow">
                <asp:Label ID="Label29" runat="server" Text="Line 4"></asp:Label>
                <asp:TextBox ID="txtAddrLine4" CssClass="datafield-ext" runat="server"></asp:TextBox>
            </div>
            <div class="datarow">
                <asp:Label ID="Label30" runat="server" Text="Line 5"></asp:Label>
                <asp:TextBox ID="txtAddrLine5" CssClass="datafield-ext" runat="server"></asp:TextBox>
            </div>
            <div class="datarow">
                <asp:Button ID="cmdAddAddress" runat="server" CssClass="datafield" Text="Add Address"
                    OnClick="cmdAddAddress_Click" />
            </div>
        </div>
    </div>
    <div id="fuzz2">
        <div class="newCarrier">
            <%--New Carrier Entry Form--%>
            <div class="heading-popup">
                <asp:Label ID="Label31" runat="server" Text="Enter New Carrier"></asp:Label>
                <img style="height: 20px; width: 20px;" class="close2" src="../images/error.png"
                    alt="Close" />
            </div>
            <div class="datarow">
                <asp:Label ID="Label32" runat="server" Text="Carrier Name"></asp:Label>
                <asp:TextBox ID="txtCarrierName" class="datafield-ext" runat="server"></asp:TextBox>
            </div>
            <div class="datarow">
                <asp:Label ID="Label33" runat="server" Text="Carrier Contact"></asp:Label>
                <asp:TextBox ID="txtCarrierContact" class="datafield" runat="server"></asp:TextBox>
            </div>
            <div class="datarow">
                <asp:Label ID="Label34" runat="server" Text="Carrier Contact Phone #"></asp:Label>
                <asp:TextBox ID="txtCarrierContactPhone" class="datafield" runat="server"></asp:TextBox>
            </div>
            <div class="datarow">
                <asp:Button ID="Button1" runat="server" Text="Add Carrier" Style="float: right;"
                    OnClick="cmdAddCarrier_Click" />
            </div>
        </div>
    </div>
    <%--Form--%>
    <div style="background-color: Silver; margin-left: auto; margin-right: auto; width: 1000px;
        border: 1px solid Black;">
        <%--Project Section--%>
        <div class="heading">
            <asp:Label ID="Label23" runat="server" Text="Project Information"></asp:Label>
        </div>
        <div class="datarow">
            <span style="float: left;">
                <asp:Label runat="server" ID="Label24" Text="Select Project: " />&nbsp
                <asp:DropDownList ID="ddlProject" runat="server" DataSource=' <%# GetActiveProjects() %>'
                    DataTextField="ProjectName" DataValueField="ID" OnSelectedIndexChanged="ddlProject_IndexChanged"
                    AutoPostBack="true" />
                &nbsp<asp:Label runat="server" ID="Label26" Text="Enter PO Number: " />
                <asp:TextBox ID="txtPONumber" runat="server"></asp:TextBox>
            </span><span style="float: right;">
                <asp:Button ID="cmdGenBOLNumber" runat="server" Text="Generate BOL #" OnClick="cmdGenBOLNumber_Click" />
            </span>
            <br />
        </div>
        <div class="datarow">
            <asp:Label runat="server" ID="lblBOLNumber" Text="Bill of Lading Number: " />
            <asp:TextBox ID="txtBOLNumber" runat="server"></asp:TextBox>
        </div>
        <!-- ADDRESSES SECTION -->
        <div class="heading">
            <asp:Label ID="Label1" runat="server" Text="Address Information"></asp:Label>
            <asp:Image ID="imgAddRoom" runat="server" class="alert1" ImageUrl="~/images/Add.png"
                ToolTip="Add Address" Style="float: right; height: 20px; width: 20px; vertical-align: middle;" />
        </div>
        <div class="datarow">
            <asp:Label runat="server" ID="lblShipFrom" Text="Ship From: " />
            <asp:DropDownList ID="ddlShipFrom" runat="server" CssClass="datafield" DataSource=' <%# GetShipFrom() %>'
                DataTextField="Description" DataValueField="ID" AutoPostBack="True" OnSelectedIndexChanged="ddlShipFrom_SelectedIndexChanged" />
            <br />
        </div>
        <div class="datarow">
            <asp:Label runat="server" ID="lblShipTo" Text="Ship To: " />
            <asp:DropDownList ID="ddlShipTo" runat="server" CssClass="datafield" DataSource=' <%# GetShipTo() %>'
                DataTextField="Description" DataValueField="ID" AutoPostBack="True" OnSelectedIndexChanged="ddlShipTo_SelectedIndexChanged" />
            <br />
        </div>
        <div class="datarow">
            <asp:Label runat="server" ID="Label10" Text="Contact Name: " />
            <asp:TextBox CssClass="datafield" ID="txtContactName" runat="server"></asp:TextBox><br />
        </div>
        <div class="datarow">
            <asp:Label runat="server" ID="Label11" Text="Contact Phone #: " />
            <asp:TextBox CssClass="datafield" ID="txtContactPhone" runat="server"></asp:TextBox><br />
        </div>
        <!-- SHIPMENT INFO SECTION -->
        <div class="heading">
            <asp:Label ID="Label4" runat="server" Text="Shipment Information"></asp:Label>
            <asp:Image ID="Image2" runat="server" class="alert2" ImageUrl="~/images/Add.png"
                ToolTip="Add Carrier" Style="float: right; height: 20px; width: 20px; vertical-align: middle;" />
        </div>
        <div class="datarow">
            <asp:Label runat="server" ID="Label3" Text="Carrier: " />
            <asp:DropDownList ID="ddlCarrier" runat="server" CssClass="datafield" DataSource=' <%# GetCarriers() %>'
                DataTextField="CarrierName" DataValueField="ID" />
            <br />
        </div>
        <div class="datarow">
            <asp:Label runat="server" ID="Label5" Text="Container #: " />
            <asp:TextBox CssClass="datafield" ID="txtContainerNumber" runat="server"></asp:TextBox><br />
        </div>
        <div class="datarow">
            <asp:Label runat="server" ID="Label6" Text="Booking #: " />
            <asp:TextBox CssClass="datafield" ID="txtBookingNumber" runat="server"></asp:TextBox><br />
        </div>
        <div class="datarow">
            <asp:Label runat="server" ID="Label7" Text="Cab #: " />
            <asp:TextBox CssClass="datafield" ID="txtCabNumber" runat="server"></asp:TextBox><br />
        </div>
        <div class="datarow">
            <asp:Label runat="server" ID="Label8" Text="Seal #: " />
            <asp:TextBox CssClass="datafield" ID="txtSealNumber" runat="server"></asp:TextBox><br />
        </div>
        <div class="datarow">
            <asp:Label runat="server" ID="Label9" Text="Driver Cell: " />
            <asp:TextBox CssClass="datafield" ID="txtDriverCell" runat="server"></asp:TextBox><br />
        </div>
        <%--Freight Charge Terms--%>
        <div class="heading">
            <asp:Label ID="Label12" runat="server" Text="Freight Charge Terms"></asp:Label>
        </div>
        <div class="datarow">
            <asp:Label runat="server" ID="Label13" Text="Freight Charge Terms: " />
            <span style="float: right; margin-right: 5px;">
                <asp:CheckBox ID="chkFreightChargePre" runat="server" Text="Prepaid" />
                <asp:CheckBox ID="chkFreightChargeCol" runat="server" Text="Collect" />
                <asp:CheckBox ID="chkFreightCharge3rd" runat="server" Text="3rd Party" />
            </span>
            <br />
        </div>
        <div class="datarow">
            <asp:Label runat="server" ID="Label18" Text="The agreed or declared value of the property is specifically stated by the shipper not to exceed $" />
            <asp:TextBox ID="txtStatedValueAmt" runat="server" Width="25px" Text="0"></asp:TextBox>
            <asp:Label runat="server" ID="Label20" Text=" per " />
            <asp:TextBox ID="txtStatedValueUnit" runat="server" Width="50px"></asp:TextBox>
        </div>
        <div class="datarow">
            <span style="float: right;">
                <asp:Label runat="server" ID="Label22" Text="Fee Terms:" />
                <asp:CheckBox ID="chkFeeTermsColl" runat="server" Text="Collect" />
                <asp:CheckBox ID="chkFeeTermsPre" runat="server" Text="Prepaid" />
                <asp:CheckBox ID="chkFeeTermsCust" runat="server" Text="Cust Check Acceptable" />
            </span>
        </div>
        <div class="datarow">
            <asp:Label ID="lblSaveNotice" Style="font-style: italic;" runat="server" Text="You must save the Bill of Lading before continuing beyond this point." />
            <span style="float: right;">
                <asp:Button ID="cmdSave" runat="server" OnClick="cmdSave_Click" Text="Save" />
            </span>
        </div>
        <%--Project Management Order Information
        <div class="heading">
            <asp:Label ID="Label14" runat="server" Text="PM Order Information"></asp:Label>
        </div>
        <div class="datarow" style="height: auto;">
            <asp:Label runat="server" ID="Label16" Text="Select Order: " />
            <asp:DropDownList ID="ddlOrders" runat="server" DataSource=' <%# GetOpenPMOrders() %>'
                DataTextField="DisplayText" DataValueField="ID" />
            <br />
            <asp:Button ID="cmdAddOrder" runat="server" Text="Add Order" Visible="false" 
                onclick="cmdAddOrder_Click" />
        </div>
        <asp:GridView ID="gvBOLOrders" runat="server" AutoGenerateColumns="False" EnableModelValidation="True"
            AllowSorting="True" DataSourceID="" DataKeyNames="ID" CellPadding="4" ForeColor="#333333"
            GridLines="None">
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
            <EmptyDataTemplate>
                <asp:Label ID="Label19" runat="server" Text="No information available for selected order, or no order has been selected."></asp:Label>
            </EmptyDataTemplate>
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#FBA349" Font-Bold="True" ForeColor="Black" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        </asp:GridView>--%>
        <%--Carrier Information--%>
        <div class="heading">
            <asp:Label ID="Label17" runat="server" Text="Carrier Information"></asp:Label>
        </div>
        <div class="datarow" style="height: auto;">
            <table width="100%" style="margin-right: 5px;">
                <tr class="heading" style="font-weight: bold;">
                    <td colspan="2">
                        Handling Unit
                    </td>
                    <td colspan="2">
                        Package
                    </td>
                    <td colspan="3">
                        Package Information
                    </td>
                </tr>
                <tr class="heading">
                    <td>
                        Qty
                    </td>
                    <td>
                        Type
                    </td>
                    <td>
                        Qty
                    </td>
                    <td>
                        Type
                    </td>
                    <td>
                        Weight
                    </td>
                    <td>
                        HazMat
                    </td>
                    <td>
                        Commodity Description
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:TextBox ID="txtHUQty" runat="server" Width="25px"></asp:TextBox>
                    </td>
                    <td align="center">
                        <asp:DropDownList ID="ddlHUType" runat="server">
                            <asp:ListItem Selected="True">..Pick One..</asp:ListItem>
                            <asp:ListItem>V250 Block</asp:ListItem>
                            <asp:ListItem>V250 HT Block</asp:ListItem>
                            <asp:ListItem>V300 Block</asp:ListItem>
                            <asp:ListItem>V300 HT Block</asp:ListItem>
                            <asp:ListItem>V250 Grout (lbs)</asp:ListItem>
                            <asp:ListItem>V300 Grout (lbs)</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td align="center">
                        <asp:TextBox ID="txtPkgQty" runat="server" Width="25px"></asp:TextBox>
                    </td>
                    <td align="center">
                        <asp:DropDownList ID="ddlPkgType" runat="server">
                            <asp:ListItem Selected="True">..Pick One..</asp:ListItem>
                            <asp:ListItem>Pallets</asp:ListItem>
                            <asp:ListItem>...</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td align="center">
                        <asp:TextBox ID="txtPkgWt" runat="server" Width="66px"></asp:TextBox>
                    </td>
                    <td align="center">
                        <asp:CheckBox ID="chkHazMat" runat="server" />
                    </td>
                    <td align="center">
                        <asp:DropDownList ID="ddlCommodityDescr" runat="server">
                            <asp:ListItem Selected="True">..Pick One..</asp:ListItem>
                            <asp:ListItem>Concrete Block</asp:ListItem>
                            <asp:ListItem>Grout</asp:ListItem>
                        </asp:DropDownList>
                        <asp:Button ID="cmdAddCarrierInfo" runat="server" Text="Add" OnClick="cmdAddCarrierInfo_Click"
                            Style="text-align: right" />
                    </td>
                </tr>
            </table>
        </div>
        <asp:GridView ID="gvCarrierInfo" runat="server" AutoGenerateColumns="False" EnableModelValidation="True"
            AllowSorting="True" DataSourceID="dsCarrierInfo" DataKeyNames="ID" CellPadding="4"
            ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:CommandField CancelImageUrl="~/images/cancel.JPG" DeleteImageUrl="~/images/delete.jpg"
                    EditImageUrl="~/images/edit.jpg" HeaderText="Edit/Del" InsertImageUrl="~/images/insert.png"
                    NewImageUrl="~/images/insert.png" ShowDeleteButton="True" ShowEditButton="True"
                    UpdateImageUrl="~/images/update.JPG" />
                <asp:BoundField DataField="HandlingUnitQty" HeaderText="Handling Unit Qty" SortExpression="HandlingUnitQty">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="HandlingUnitType" HeaderText="Handling Unit Type" SortExpression="HandlingUnitType">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="PackageQty" HeaderText="Package Qty" SortExpression="PackageQty">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="PackageType" HeaderText="Package Type" SortExpression="PackageType">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="PackageWeight" HeaderText="Weight" SortExpression="PackageWeight">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:CheckBoxField DataField="HazMat" HeaderText="Haz Mat?" SortExpression="HazMat">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:CheckBoxField>
                <asp:BoundField DataField="CommodityDescription" HeaderText="Commodity Description"
                    SortExpression="CommodityDescription">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" InsertVisible="False"
                    ReadOnly="True" Visible="False" />
                <asp:BoundField DataField="BOLID" HeaderText="BOLID" SortExpression="BOLID" Visible="False" />
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <EmptyDataTemplate>
                <asp:Label ID="Label19" runat="server" Text="This section not used yet."></asp:Label>
            </EmptyDataTemplate>
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#FBA349" Font-Bold="True" ForeColor="Black" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        </asp:GridView>
        <%--Generate BOL--%>
        <div class="heading">
            <asp:Label ID="Label21" runat="server" Text="Generate Bill Of Lading"></asp:Label>
        </div>
        <div class="datarow" style="height: 400px;">
            <asp:Label ID="Label14" runat="server" Text="Select Veritas staff to recieve a copy of this bill of lading via email.  To select multiple recipients hold CTRL key while clicking on all names"></asp:Label>
            <br />
            <asp:ListBox ID="ListBox1" runat="server" DataSource=' <%# GetUsers() %>' DataTextField="Name"
                DataValueField="Email" Height="33px" SelectionMode="Multiple" Width="145px" Rows="10">
            </asp:ListBox>
        </div>
        <div class="datarow">
            <span style="float: right;">
                <asp:Label ID="lblNoPrint" runat="server" Visible="false" Text="Please select at least one recipient from the list to the left."
                    Style="color: #FF3300; font-weight: 700"></asp:Label>
                <asp:Button ID="cmdPrintBOL" runat="server" Text="Generate BOL" OnClick="cmdPrintBOL_Click" />
            </span>
        </div>
        <%--End of Form Div--%>
    </div>
    <asp:SqlDataSource ID="dsCarrierInfo" runat="server" ConnectionString="<%$ ConnectionStrings:VeritasInfo %>"
        SelectCommand="SELECT * FROM [S_BOLCarrierInfo] WHERE ([BOLID] = @BOLID)" DeleteCommand="DELETE FROM [S_BOLCarrierInfo] WHERE [ID] = @ID"
        InsertCommand="INSERT INTO [S_BOLCarrierInfo] ([BOLID], [HandlingUnitQty], [HandlingUnitType], [PackageQty], [PackageType], [PackageWeight], [HazMat], [CommodityDescription]) VALUES (@BOLID, @HandlingUnitQty, @HandlingUnitType, @PackageQty, @PackageType, @PackageWeight, @HazMat, @CommodityDescription)"
        UpdateCommand="UPDATE [S_BOLCarrierInfo] SET [BOLID] = @BOLID, [HandlingUnitQty] = @HandlingUnitQty, [HandlingUnitType] = @HandlingUnitType, [PackageQty] = @PackageQty, [PackageType] = @PackageType, [PackageWeight] = @PackageWeight, [HazMat] = @HazMat, [CommodityDescription] = @CommodityDescription WHERE [ID] = @ID">
        <DeleteParameters>
            <asp:Parameter Name="ID" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:SessionParameter Name="BOLID" Type="Int32" SessionField="BOLID" />
            <asp:ControlParameter Name="HandlingUnitQty" Type="Decimal" ControlID="txtHUQty"
                PropertyName="Text" />
            <asp:ControlParameter Name="HandlingUnitType" Type="String" ControlID="ddlHUType"
                PropertyName="SelectedValue" />
            <asp:ControlParameter Name="PackageQty" Type="Decimal" ControlID="txtPkgQty" PropertyName="Text" />
            <asp:ControlParameter Name="PackageType" Type="String" ControlID="ddlPkgType" PropertyName="SelectedValue" />
            <asp:ControlParameter Name="PackageWeight" Type="Decimal" ControlID="txtPkgWt" PropertyName="Text" />
            <asp:ControlParameter Name="HazMat" Type="Boolean" ControlID="chkHazMat" PropertyName="Checked" />
            <asp:ControlParameter Name="CommodityDescription" Type="String" ControlID="ddlCommodityDescr"
                PropertyName="SelectedValue" />
        </InsertParameters>
        <SelectParameters>
            <asp:SessionParameter Name="BOLID" SessionField="BOLID" Type="Int32" />
        </SelectParameters>
        <UpdateParameters>
            <asp:SessionParameter Name="BOLID" SessionField="BOLID" Type="Int32" />
            <asp:Parameter Name="HandlingUnitQty" Type="Decimal" />
            <asp:Parameter Name="HandlingUnitType" Type="String" />
            <asp:Parameter Name="PackageQty" Type="Decimal" />
            <asp:Parameter Name="PackageType" Type="String" />
            <asp:Parameter Name="PackageWeight" Type="Decimal" />
            <asp:Parameter Name="HazMat" Type="Boolean" />
            <asp:Parameter Name="CommodityDescription" Type="String" />
            <asp:Parameter Name="ID" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
    </form>
</body>
</html>
