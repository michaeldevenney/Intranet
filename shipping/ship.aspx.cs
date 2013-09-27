using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using Shared;
using SubSonic;
using Veritas;

public partial class ship : System.Web.UI.Page
{
    public Shipping BOL;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Page.DataBind();
            cmdAddCarrierInfo.Enabled = false;
            chkFeeTermsPre.Checked = true;
            chkFreightChargePre.Checked = true;

            UserCollection test = GetUsers();
            int x = test.Count * 16;
            ListBox1.Height = Unit.Parse(x.ToString() + "px");

            this.lblNewAddress.Text = "Enter New Address for " + ddlProject.SelectedItem.Text;

            UpdateAddressInfo();
        }    


        BOL = Session["BOL"] as Shipping;
        
        if (BOL == null)
            BOL = new Shipping(true);
    }

    #region DATA ACCESS METHODS

    public UserCollection GetUsers()
    {
        return new UserCollection().Load();
    }

    public AddressCollection GetShipFrom()
    {
        // Address Type 106 = Ship From list
        return new AddressCollection().Where("AddressTypeID", SubSonic.Comparison.Equals, 106).Load();
    }

    public AddressCollection GetShipTo()
    {
        int projectID = int.Parse(ddlProject.SelectedItem.Value);

        // Address Type 105 = Ship To list
        return new AddressCollection().Where("AddressTypeID", SubSonic.Comparison.Equals, 105).Where("ProjectID",
            SubSonic.Comparison.Equals, projectID).Load();
    }

    public CarrierCollection GetCarriers()
    {
        return new CarrierCollection().Load();
    }

    public ProjectCollection GetActiveProjects()
    {
        return new ProjectCollection().Where("ProjectPhase", SubSonic.Comparison.Equals, "Active").Load();
    }

    public OrderCollection GetOpenPMOrders()
    {
        string projectID = this.ddlProject.SelectedValue;
        return new OrderCollection().Where("ProjectID", SubSonic.Comparison.Equals, int.Parse(projectID)).Load();
    }

    public string GetNextBOLLoadNumberForProject(string inProjectID)
    {
        ShippingCollection temp = new ShippingCollection().Where("ProjectID", SubSonic.Comparison.Equals, inProjectID).Load();
        return (temp.Count + 1).ToString();
    }

    public static LookupCollection GetLookupList(string inListName)
    {
        return new LookupCollection().Where("LookupList", Comparison.Equals, inListName).Load();
    }
    
    #endregion

    #region CONTROL EVENTS

    protected void ddlProject_IndexChanged(object sender, EventArgs e)
    {
        lblNewAddress.Text = "Enter New Address for " + ddlProject.SelectedItem.Text;
        ddlShipTo.DataBind();
        UpdateAddressInfo();

        //this.ddlOrders.DataBind();
    }
    protected void cmdAddAddress_Click(object sender, EventArgs e)
    {
        int? projectID;

        if (ddlAddrType.SelectedValue == 105.ToString())
        {
            projectID = int.Parse(ddlProject.SelectedItem.Value);
        }
        else
        {
            projectID = null;
        }

        Address addr = new Address();
        addr.ProjectID = projectID;
        addr.AddressTypeID = int.Parse(ddlAddrType.SelectedItem.Value);
        addr.Description = txtAddrDescription.Text;
        addr.Line1 = txtAddrLine1.Text;
        addr.Line2 = txtAddrLine2.Text;
        addr.Line3 = txtAddrLine3.Text;
        addr.Line4 = txtAddrLine4.Text;
        addr.Line5 = txtAddrLine5.Text;

        addr.Save();

        if (addr.AddressTypeID == 105)
        {
            ddlShipTo.DataBind();
            ddlShipTo.SelectedValue = addr.Id.ToString();
        }
        else
        {
            ddlShipFrom.DataBind();
            ddlShipFrom.SelectedValue = addr.Id.ToString();
        }

        txtAddrDescription.Text = "";
        txtAddrLine1.Text = "";
        txtAddrLine2.Text = "";
        txtAddrLine3.Text = "";
        txtAddrLine4.Text = "";
    }
    protected void cmdAddCarrier_Click(object sender, EventArgs e)
    {
        Carrier newCarrier = new Carrier();
        newCarrier.CarrierName = txtCarrierName.Text;
        newCarrier.ContactName = txtContactName.Text;
        newCarrier.ContactPhone = txtContactPhone.Text;

        newCarrier.Save();

        int? carrierID = newCarrier.Id;
        ddlCarrier.DataBind();

        ddlCarrier.SelectedValue = carrierID.ToString();

        txtCarrierName.Text = "";
        txtContactName.Text = "";
        txtContactPhone.Text = "";
        
        UpdateAddressInfo();
    }
    protected void cmdAddCarrierInfo_Click(object sender, EventArgs e)
    {
        string BOLID = Session["BOLID"] as string;

        dsCarrierInfo.Insert();
        gvCarrierInfo.DataBind();

        //reset values in entry fields
        txtHUQty.Text = "";
        ddlHUType.SelectedValue = "..Pick One..";
        txtPkgQty.Text = "";
        txtPkgWt.Text = "";
        chkHazMat.Checked = false;
    }
    protected void cmdSave_Click(object sender, EventArgs e)
    {
        BOL.BOLNumber = txtBOLNumber.Text;
        BOL.ShipFrom = int.Parse(ddlShipFrom.SelectedValue);
        BOL.ShipTo = int.Parse(ddlShipTo.SelectedValue);
        BOL.ShippingDate = DateTime.Now;
        BOL.ContactName = txtContactName.Text;
        BOL.ContactCell = txtContactPhone.Text;
        BOL.Carrier = int.Parse(ddlCarrier.SelectedValue);
        BOL.ContainerNumber = txtContainerNumber.Text;
        BOL.BookingNumber = txtBookingNumber.Text;
        BOL.CabNumber = txtCabNumber.Text;
        BOL.SealNumber = txtSealNumber.Text;
        BOL.DriverCellNumber = txtDriverCell.Text;
        BOL.FreightCharge3rd = chkFreightCharge3rd.Checked;
        BOL.FreightChargeCol = chkFreightChargeCol.Checked;
        BOL.FreightChargePre = chkFreightChargePre.Checked;
        BOL.EnteredBy = Utils.GetFormattedUserNameInternal(User.Identity.Name);
        BOL.EnteredDate = DateTime.Now;
        BOL.ValueAmt = decimal.Parse(txtStatedValueAmt.Text);
        BOL.ValueUnit = txtStatedValueUnit.Text;

        // save to generate ID
        BOL.Save();

        Session["BOLID"] = BOL.Id;
        cmdAddCarrierInfo.Enabled = true;
    }
    protected void cmdGenBOLNumber_Click(object sender, EventArgs e)
    {
        txtBOLNumber.Text = GenerateBOLNumber();

        BOL.ProjectID = int.Parse(ddlProject.SelectedValue);
        BOL.BOLNumber = txtBOLNumber.Text;
        BOL.Save();

        Session["BOL"] = BOL;

        cmdGenBOLNumber.Enabled = false;
        ddlProject.Enabled = false;

        ddlShipFrom.Focus();

    }
    protected void cmdPrintBOL_Click(object sender, EventArgs e)
    {
        List<string> recipients = new List<string>();

        foreach (ListItem recipient in ListBox1.Items)
        {
            if (recipient.Selected)
                recipients.Add(recipient.Value);
        }

        // Let's send this to at least one person
        if (recipients.Count < 1)
        {
            lblNoPrint.Visible = true;
            return;
        }
        BOL.Save();
        Veritas.BOL.Print(BOL.Id, recipients, BOL.ProjectID.ToString(), BOL.BOLNumber);

        Response.Redirect("bolconfirm.aspx");
    }
    protected void cmdAddOrder_Click(object sender, EventArgs e)
    {

    }
    protected void ddlShipFrom_SelectedIndexChanged(object sender, EventArgs e)
    {
        UpdateAddressInfo();
    }
    protected void ddlShipTo_SelectedIndexChanged(object sender, EventArgs e)
    {
        UpdateAddressInfo();
    }

    #endregion
    
    #region HELPER METHODS

    private void UpdateAddressInfo()
    {
        string addrSummaryTo = Data.GetAddressSummaryBlock(ddlShipFrom.SelectedValue);
        ddlShipFrom.ToolTip = addrSummaryTo;
        string addrSummaryFrom = Data.GetAddressSummaryBlock(ddlShipTo.SelectedValue);
        ddlShipTo.ToolTip = addrSummaryFrom;
    }

    protected string GenerateBOLNumber()
    {
        string tempBOL = DateTime.Now.ToString("yyyy") + "-";
        tempBOL += txtPONumber.Text + "-";
        tempBOL += GetNextBOLLoadNumberForProject(ddlProject.SelectedValue);

        return tempBOL;
    }

    #endregion
    
}