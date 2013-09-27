<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="apps_estimating_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="titleContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="headContent" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="mainContent" runat="Server">
    <div id="fuzz1">
        <div class="newLeadProj">
            <div class="heading">
                <asp:Label ID="lblHeading" runat="server" Text="Enter New Lead"></asp:Label>
                <img style="height: 20px; width: 20px;" alt="Close" class="close1" src="../../images/error.png" />
            </div>
            <asp:Table ID="Table4" runat="server" Width="100%">                
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="Label1" runat="server" Text="Lead Number"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="txtAddProjNumber" runat="server"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell></asp:TableCell>
                    <asp:TableCell>
                        <asp:Label ID="Label2" runat="server" Text="Lead Name"></asp:Label></asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="txtAddProjName" runat="server" Width="250px"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell ColumnSpan="5"></asp:TableCell>                    
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="Label6" runat="server" Text="Assigned PM"></asp:Label></asp:TableCell>
                    <asp:TableCell>
                        <asp:DropDownList ID="ddlAddProjMgr" runat="server" DataSource=' <%# GetUsersByTitle("Project Manager") %>'
                            DataTextField="Name" DataValueField="ID" />
                    </asp:TableCell>
                    <asp:TableCell></asp:TableCell>
                    <asp:TableCell><asp:Label ID="Label5" runat="server" Text="Assigned Salesperson" /></asp:TableCell>
                    <asp:TableCell><asp:DropDownList ID="ddlSalesperson" runat="server" DataSource=' <%# GetUsersByTitle("Sales") %>'
                            DataTextField="Name" DataValueField="Id" /></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell ColumnSpan="5" Height="20px"></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell ColumnSpan="5" HorizontalAlign="Center">
                        <asp:Button ID="cmdAddProjLead" runat="server" Text="Create Lead/Project" OnClick="cmdAddProjLead_Click" />
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </div>
    </div>
    <div>
        <asp:Table ID="Table1" runat="server" Width="100%" CellPadding="1">
            <asp:TableRow>
                <asp:TableCell Width="30%" HorizontalAlign="Center" VerticalAlign="Top">
                    <div style="vertical-align:bottom; font-weight: bold; color: White; background-color: Gray; height: 22px;">
                        Estimate List<asp:Image ID="imgAddRoom" runat="server" class="alert1" ImageUrl="~/images/Add.png"
                        ToolTip="Create a new project or lead" Style="height: 20px; width: 20px; vertical-align: middle; float:right;" /></div>
                    <asp:ListBox ID="lstEstimates" runat="server" Rows="26" OnSelectedIndexChanged="lstEstimates_SelectedIndexChanged" AutoPostBack="true" />
                    <br />
                    <br />
                    <asp:Button ID="cmdSave" runat="server" Text="Save" OnClick="cmdSave_Click" />&nbsp;
                    <asp:Button ID="cmdDelete" runat="server" Text="Delete Estimate" OnClick="cmdDelete_Click" />
                </asp:TableCell>
                <asp:TableCell Width="70%" HorizontalAlign="Left" VerticalAlign="Top">                    
                    <asp:Table ID="Table2" runat="server" Width="100%" CellPadding="1">
                        <asp:TableRow>
                            <asp:TableCell>
                                <asp:Table ID="Table3" runat="server" CellPadding="1">
                                    <asp:TableRow>
                                        <asp:TableCell HorizontalAlign="Right" Width="35%">Prospect Name</asp:TableCell>
                                        <asp:TableCell HorizontalAlign="Right">
                                            <asp:TextBox ID="txtProspectName" runat="server" /></asp:TableCell>
                                        <asp:TableCell HorizontalAlign="Right">Salesperson</asp:TableCell>
                                        <asp:TableCell HorizontalAlign="Right">
                                            <asp:TextBox ID="txtSalesPerson" runat="server" /></asp:TableCell>
                                    </asp:TableRow>
                                    <asp:TableRow>
                                        <asp:TableCell HorizontalAlign="Right">Estimate Number</asp:TableCell>
                                        <asp:TableCell HorizontalAlign="Right">
                                            <asp:TextBox ID="txtEstimateNumber" runat="server" /></asp:TableCell>
                                        <asp:TableCell HorizontalAlign="Right">Client Contact</asp:TableCell>
                                        <asp:TableCell HorizontalAlign="Right">
                                            <asp:TextBox ID="txtClientContact" runat="server" /></asp:TableCell>
                                    </asp:TableRow>
                                    <asp:TableRow>
                                        <asp:TableCell HorizontalAlign="Right">Contact Email</asp:TableCell>
                                        <asp:TableCell HorizontalAlign="Right">
                                            <asp:TextBox ID="txtContactEmail" runat="server" /></asp:TableCell>
                                        <asp:TableCell HorizontalAlign="Right">Estimator</asp:TableCell>
                                        <asp:TableCell HorizontalAlign="Right">
                                            <asp:TextBox ID="txtEstimator" runat="server" /></asp:TableCell>
                                    </asp:TableRow>
                                    <asp:TableRow>
                                        <asp:TableCell HorizontalAlign="Right">Received</asp:TableCell>
                                        <asp:TableCell HorizontalAlign="Right">
                                            <asp:TextBox ID="txtReceived" runat="server" /></asp:TableCell>
                                        <asp:TableCell HorizontalAlign="Right"></asp:TableCell>
                                        <asp:TableCell HorizontalAlign="Right"></asp:TableCell>
                                    </asp:TableRow>
                                    <asp:TableRow>
                                        <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" ColumnSpan="4">
                                            <hr />
                                            <div style="font-weight:bold; color:White; background-color:Gray; height:18px;">Estimate Dates</div>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                    <asp:TableRow>
                                        <asp:TableCell HorizontalAlign="Right">More Info Needed</asp:TableCell>
                                        <asp:TableCell HorizontalAlign="Right">
                                            <asp:CheckBox ID="chkMoreInfo" runat="server" OnCheckedChanged="CheckboxClick" AutoPostBack="true" />&nbsp;<asp:TextBox ID="txtMoreInfoNeededDate"
                                                runat="server" /></asp:TableCell>
                                        <asp:TableCell HorizontalAlign="Right">Initial Drawing</asp:TableCell>
                                        <asp:TableCell HorizontalAlign="Right">
                                            <asp:CheckBox ID="chkInitialDrawing" runat="server" OnCheckedChanged="CheckboxClick" AutoPostBack="true" />&nbsp;<asp:TextBox ID="txtInitialDrawingDate"
                                                runat="server" /></asp:TableCell>
                                    </asp:TableRow>
                                    <asp:TableRow>
                                        <asp:TableCell HorizontalAlign="Right">Thickness Calcs</asp:TableCell>
                                        <asp:TableCell HorizontalAlign="Right">
                                            <asp:CheckBox ID="chkThicknesses" runat="server" OnCheckedChanged="CheckboxClick" AutoPostBack="true" />&nbsp;<asp:TextBox ID="txtThicknessesDate"
                                                runat="server" /></asp:TableCell>
                                        <asp:TableCell HorizontalAlign="Right">AutoCAD</asp:TableCell>
                                        <asp:TableCell HorizontalAlign="Right">
                                            <asp:CheckBox ID="chkAutoCAD" runat="server" OnCheckedChanged="CheckboxClick" AutoPostBack="true" />&nbsp;<asp:TextBox ID="txtAutoCADDate"
                                                runat="server" /></asp:TableCell>
                                    </asp:TableRow>
                                    <asp:TableRow>
                                        <asp:TableCell HorizontalAlign="Right">Takeoff</asp:TableCell>
                                        <asp:TableCell HorizontalAlign="Right">
                                            <asp:CheckBox ID="chkTakeOff" runat="server" OnCheckedChanged="CheckboxClick" AutoPostBack="true" />&nbsp;<asp:TextBox ID="txtTakeoffDate"
                                                runat="server" /></asp:TableCell>
                                        <asp:TableCell HorizontalAlign="Right">Completed</asp:TableCell>
                                        <asp:TableCell HorizontalAlign="Right">
                                            <asp:CheckBox ID="chkEstimateCompleted" runat="server" OnCheckedChanged="CheckboxClick" AutoPostBack="true" />&nbsp;<asp:TextBox ID="txtEstimateCompletedDate"
                                                runat="server" /></asp:TableCell>
                                    </asp:TableRow>
                                    <asp:TableRow>
                                        <asp:TableCell HorizontalAlign="Right">Reviewed</asp:TableCell>
                                        <asp:TableCell HorizontalAlign="Right">
                                            <asp:CheckBox ID="chkEstimateReviewed" runat="server" OnCheckedChanged="CheckboxClick" AutoPostBack="true" />&nbsp;<asp:TextBox ID="txtEstimateReviewedDate"
                                                runat="server" /></asp:TableCell>
                                        <asp:TableCell HorizontalAlign="Right">Sent</asp:TableCell>
                                        <asp:TableCell HorizontalAlign="Right">
                                            <asp:CheckBox ID="chkEstimateSent" runat="server" OnCheckedChanged="CheckboxClick" AutoPostBack="true" />&nbsp;<asp:TextBox ID="txtEstimateSentDate"
                                                runat="server" /></asp:TableCell>
                                    </asp:TableRow>
                                    <asp:TableRow>
                                        <asp:TableCell HorizontalAlign="Center" ColumnSpan="4">
                                            <hr />
                                            <div style="font-weight:bold; color:White; background-color:Gray; height:18px;">Financial Information</div>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                    <asp:TableRow>
                                        <asp:TableCell HorizontalAlign="Right">Interiors Total</asp:TableCell>
                                        <asp:TableCell HorizontalAlign="Right">
                                            <asp:TextBox ID="txtInteriorsTotal" runat="server" /></asp:TableCell>
                                        <asp:TableCell HorizontalAlign="Right">Doors Total</asp:TableCell>
                                        <asp:TableCell HorizontalAlign="Right">
                                            <asp:TextBox ID="txtDoorsTotal" runat="server" /></asp:TableCell>
                                    </asp:TableRow>
                                    <asp:TableRow>
                                        <asp:TableCell HorizontalAlign="Right">Bunker Total</asp:TableCell>
                                        <asp:TableCell HorizontalAlign="Right">
                                            <asp:TextBox ID="txtBunkerTotal" runat="server" /></asp:TableCell>
                                        <asp:TableCell HorizontalAlign="Right">Estimate Total</asp:TableCell>
                                        <asp:TableCell HorizontalAlign="Right">
                                            <asp:TextBox ID="txtEstimatetotal" runat="server" /></asp:TableCell>
                                    </asp:TableRow>
                                    <asp:TableRow>
                                        <asp:TableCell HorizontalAlign="Center" ColumnSpan="4">
                                            <hr />
                                            <div style="font-weight:bold; color:White; background-color:Gray; height:18px;">Filesystem Information</div>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                    <asp:TableRow>
                                        <asp:TableCell HorizontalAlign="Left" ColumnSpan="4">
                                            Estimates Directory<br />
                                            <asp:TextBox ID="txtEstimatesDirectory" runat="server" Width="650px" />
                                        </asp:TableCell>
                                    </asp:TableRow>
                                    <asp:TableRow>
                                        <asp:TableCell HorizontalAlign="Left" ColumnSpan="4">
                                            Prospect Directory<br />
                                            <asp:TextBox ID="txtProspectDirectory" runat="server" Width="650px" />
                                        </asp:TableCell>
                                    </asp:TableRow>
                                </asp:Table>
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </div>
</asp:Content>
