<%@ Page Title="Call Log" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="default.aspx.cs" Inherits="admin_CallLog_default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="titleContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="headContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="mainContent" Runat="Server">
 <%--Entry Section--%>        
        <div class="datarow">
            <asp:Label runat="server" ID="lbl1" Text="Date Call Received " />
            <asp:TextBox CssClass="datafield" ID="txtCallDate" runat="server"></asp:TextBox><br />
            <asp:RegularExpressionValidator ID="valDate" runat="server" ValidationExpression="^\d{1,2}\/\d{1,2}\/\d{4}$" 
            ErrorMessage="Please enter a valid date in this format: dd/mm/yyy." ValidationGroup="submit" ControlToValidate="txtCallDate" />
         </div>
         <div class="datarow">
            <asp:Label runat="server" ID="Label2" Text="Time Call Received " />
            <asp:TextBox CssClass="datafield" ID="txtCallTime" runat="server"></asp:TextBox><br />            
            <asp:RegularExpressionValidator ID="valTime" runat="server" ValidationExpression="^((([0]?[1-9]|1[0-2])(:|\.)[0-5][0-9]((:|\.)[0-5][0-9])?( )?(AM|am|aM|Am|PM|pm|pM|Pm))|(([0]?[0-9]|1[0-9]|2[0-3])(:|\.)[0-5][0-9]((:|\.)[0-5][0-9])?))$"  
            ErrorMessage="Please enter a valid time in this format: HH:MM AM or PM." ValidationGroup="submit" ControlToValidate="txtCallTime" />
        </div>
         <div class="datarow">
            <asp:Label runat="server" ID="Label8" Text="Calling for:" />
            <span style="float:right;">
             <asp:DropDownList ID="ddlCallingFor" runat="server" DataSource=' <%# GetActiveUsers() %>' DataTextField="Name" DataValueField="ID" />
             </span>
        </div>
         <div class="datarow">
            <asp:Label runat="server" ID="Label3" Text="Caller Name: " />
            <asp:TextBox CssClass="datafield" ID="txtCallerName" runat="server"></asp:TextBox><br />            
        </div>
         <div class="datarow">
            <asp:Label runat="server" ID="Label4" Text="Caller Company: " />
            <asp:TextBox CssClass="datafield" ID="txtCallerCompany" runat="server"></asp:TextBox><br />            
        </div>
         <div class="datarow">
            <asp:Label runat="server" ID="Label6" Text="Callback Number: " />
            <asp:TextBox CssClass="datafield" ID="txtCallbackNumber" runat="server"></asp:TextBox><br />            
        </div>
        <div class="extdatarow">
            <asp:Label runat="server" ID="Label22" Text="Call Notes: " />
            <span style="float:right;">
            <asp:TextBox CssClass="multiline" ID="txtCallNotes" Wrap="true" Rows="5" runat="server" TextMode="MultiLine"></asp:TextBox><br />
            </span>
        </div>
         <div class="datarow">
            <asp:Label runat="server" ID="Label7" Text="Project Referenced (optional):" />
            <span style="float:right;">
             <asp:DropDownList ID="ddlProject" runat="server" DataSource=' <%# GetActiveProjects() %>' DataTextField="ProjectName" DataValueField="ID" />
             </span>
        </div>
        <div class="datarow">            
            <asp:Button ID="Button1" runat="server" Text="Save Call" onclick="Button1_Click" CausesValidation="true" ValidationGroup="submit" />
            <asp:Label ID="lblStatus" runat="server" style="color:Red;" Text="" Visible="false"></asp:Label>            
        </div>        
        <%--Calls List--%>
        <div class="heading">
            <asp:Label ID="Label1" runat="server" Text="Calls Listing"></asp:Label>
        </div>
         <%--<asp:GridView ID="gvYardedBlock" runat="server" AutoGenerateColumns="False" EnableModelValidation="True"
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
        </asp:GridView>--%>
</asp:Content>

