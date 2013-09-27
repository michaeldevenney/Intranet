using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using Shared;

public partial class physics_checklist_default : System.Web.UI.Page
{
    public string roomID;
    public string surveyPointID;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            imgAddRoom.Visible = false;
            imgNewSP.Visible = false;

            ddlProject.DataBind();
            ddlProject.Items.Insert(0, new ListItem("Select Project", "0"));

            ddlCode.DataBind();
            ddlCode.Items.Insert(0,  new ListItem("Select Code"));

            FillFormDefaults();
        }
        else
        {
            if (Session["RoomID"] != null)
                roomID = Session["RoomID"].ToString();

            if (Session["SurveyPointID"] != null)
                surveyPointID = Session["SurveyPointID"].ToString();            
        }
    }

    #region HELPER METHODS

    private void FillFormDefaults()
    {
        txtLeakageWorkLoad.Text = "0";
        txtWorkload.Text = "0";
        txtMachineDoseRate.Text = "0";
        txtMachineEnergy.Text = "0";
        txtConvPctEnergy.Text = "0";
        txtConvPctTx.Text = "0";
        txtIMRTFactor.Text = "0";
        txtIMRTPctEnergy.Text = "0";
        txtIMRTPctTx.Text = "0";
        txtTBIPctEnergy.Text = "0";
        txtTBIPctTx.Text = "0";
        txtStereoPctEnergy.Text = "0";
        txtStereoPctTx.Text = "0";
        txtSPDistanceFeet.Text = "0";
        txtSPDistanceMeters.Text = "0";
        txtSPExposureLevel.Text = "0";
        txtSPOccupancyFactor.Text = "0";
        txtSPUseFactor.Text = "0";
    }

    private void ClearForm()
    {
        // CLEAR VARS
        Session["RoomID"] = 0.ToString();
        Session["SurveyPointID"] = 0.ToString();

        imgAddRoom.Visible = true;
        imgNewSP.Visible = false;

        gvSurveyPoints.DataBind();

        Room currentRoom = Data.GetRoomByID(roomID);

        // CLEAR ROOM FIELDS
        ddlCode.SelectedValue = "Select Code";
        txtEntryStyle.Text = "";
        txtLeakageWorkLoad.Text = "";
        txtWorkload.Text = "";
        txtMachineDoseRate.Text = "";
        txtMachineEnergy.Text = "";
        txtConvPctEnergy.Text = "";
        txtConvPctTx.Text = "";
        txtIMRTPctEnergy.Text = "";
        txtIMRTFactor.Text = "";
        txtIMRTPctTx.Text = "";
        txtTBIPctEnergy.Text = "";
        txtTBIPctTx.Text = "";
        txtStereoPctEnergy.Text = "";
        txtStereoPctTx.Text = "";

        // CLEAR SURVEY POINT FIELDS
        txtSPOccupancyFactor.Text = "";
        txtSPUseFactor.Text = "";
        txtSPDistanceFeet.Text = "";
        txtSPDistanceMeters.Text = "";
        txtSPExposureLevel.Text = "";
        txtSPExposureLevelReadingType.Text = "";
        txtSPExistingShielding.Text = "";
        txtSPAdjacentBuildings.Text = "";
    }

    private int? IntFromControl(string inText)
    {
        int returnVal;

        if (!string.IsNullOrEmpty(inText))
        {

            if (int.TryParse(inText, out returnVal))
            {
                return returnVal;
            }
            else
            {
                return 0;
            }
        }
        else
        {
            return 0;
        }
    }

    private decimal? DecimalFromControl(string inText)
    {
        decimal returnVal;

        if (!string.IsNullOrEmpty(inText))
        {

            if (Decimal.TryParse(inText, out returnVal))
            {
                return returnVal;
            }
            else
            {
                return decimal.Zero;
            }
        }
        else
        {
            return decimal.Zero;
        }
    }

    #endregion   

    #region DATA ACCESS

    public ProjectCollection GetActiveProjects()
    {
        return Data.GetProjectsByStatus(Data.ProjectStatus.Active);
    }

    public ProjectCollection GetAllProjects()
    {
        return Data.GetAllProjects();
    }

    public ProjectCollection GetActiveLeads()
    {
        return Data.GetLeadsByStatus(Data.ProjectStatus.Active);
    }

    public ProjectCollection GetAllLeads()
    {
        return Data.GetAllLeads();
    }

    public LookupCollection GetLookupList(string inListName)
    {
        return Data.GetLookupList(inListName);
    }

    #endregion

    #region CONTROL EVENT HANDLERS

    protected void cmdAddSP_Click(object sender, EventArgs e)
    {
        RoomSurveyPoint newSP = new RoomSurveyPoint();
        newSP.RoomID = int.Parse(Session["RoomID"].ToString());
        newSP.SurveyPoint = txtSPName.Text;
        newSP.SurveyPointDesc = txtSPDescription.Text;
        newSP.Save();

        gvSurveyPoints.DataBind();
    }

    protected void cmdAddRoom_Click(object sender, EventArgs e)
    {
        Room newRoom = new Room();
        newRoom.RoomName = txtRoomName.Text;
        newRoom.ProjectID = int.Parse(ddlProject.SelectedItem.Value);
        newRoom.Save();
        gvRooms.DataBind();

        lblNewRoom.Text += " ... Saved ... ";
    }

    protected void SPDistFeet_Changed(object sender, EventArgs e)
    {
        // Meters to feet = # of meters multiplied by 3.28
        // Feet to meters = # of feet multiplied by 0.3

        decimal calcMeters;
        decimal enteredFeet = decimal.Parse(txtSPDistanceFeet.Text);

        calcMeters = enteredFeet * decimal.Parse("0.3");

        txtSPDistanceMeters.Text = calcMeters.ToString();
        txtSPExposureLevel.Focus();
    }

    protected void gvRooms_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataKey key = gvRooms.DataKeys[gvRooms.SelectedRow.RowIndex];
        roomID = key.Value.ToString();
        Session["RoomID"] = roomID;

        Room currentRoom = Data.GetRoomByID(roomID);

        ddlCode.SelectedValue = currentRoom.Code;
        txtEntryStyle.Text = currentRoom.EntryType;
        txtLeakageWorkLoad.Text = currentRoom.WorkloadSecondary;
        txtWorkload.Text = currentRoom.WorkloadPrimary;
        txtMachineDoseRate.Text = currentRoom.MachineDoseRate;
        txtMachineEnergy.Text = currentRoom.MachineEnergy;
        txtConvPctEnergy.Text = currentRoom.ModConvPctEnergy.ToString();
        txtConvPctTx.Text = currentRoom.ModConvPctTime.ToString();
        txtIMRTPctEnergy.Text = currentRoom.ModIMRTPctEnergy.ToString();
        txtIMRTFactor.Text = currentRoom.ModIMRTFactor.ToString();
        txtIMRTPctTx.Text = currentRoom.ModIMRTPctTime.ToString();
        txtTBIPctEnergy.Text = currentRoom.ModTBIPctEnergy.ToString();
        txtTBIPctTx.Text = currentRoom.ModTBIPctTime.ToString();
        txtStereoPctEnergy.Text = currentRoom.ModStereoPctEnergy.ToString();
        txtStereoPctTx.Text = currentRoom.ModStereoPctTime.ToString();

        this.lblRoomSummaryHeading.Text = "Room Summary Information - " + gvRooms.SelectedRow.Cells[3].Text;
        this.lblSurveyPointSummaryHeading.Text = "Room Survey Point Information for " + gvRooms.SelectedRow.Cells[3].Text;

        gvSurveyPoints.DataBind();
        imgNewSP.Visible = true;
    }

    protected void sdsSurvey_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
    {
        string x = e.Command.CommandText;
    }

    protected void gvSurveyPoints_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataKey key = gvSurveyPoints.DataKeys[gvSurveyPoints.SelectedRow.RowIndex];
        surveyPointID = key.Value.ToString();
        Session["SurveyPointID"] = surveyPointID;

        this.lblSurveyPointSummaryHeading.Text = "Survey Point " +
            gvSurveyPoints.SelectedRow.Cells[3].Text + " in " +
            gvRooms.SelectedRow.Cells[3].Text;

        // FILL FORM FIELDS
        RoomSurveyPoint currentSP = Data.GetSurveyPointByID(surveyPointID);

        txtSPOccupancyFactor.Text = currentSP.OccupancyFactor.ToString();
        txtSPUseFactor.Text = currentSP.UseFactor.ToString();
        txtSPDistanceFeet.Text = currentSP.DistanceFromISOFeet.ToString();
        txtSPDistanceMeters.Text = currentSP.DistanceFromISOMeters.ToString();
        txtSPExposureLevel.Text = currentSP.PELValue.ToString();
        txtSPExposureLevelReadingType.Text = currentSP.PELType;
        txtSPExistingShielding.Text = currentSP.ExistingShielding;
        txtSPAdjacentBuildings.Text = currentSP.AdjacentBuildings;        
    }

    protected void ddlProject_SelectedIndexChanged(object sender, EventArgs e)
    {
        ClearForm();
    }

    protected void cmdSaveRoom_Click(object sender, EventArgs e)
    {
        if (surveyPointID == null)
            return;

        Room currentRoom = Data.GetRoomByID(roomID);

        currentRoom.Code = ddlCode.SelectedValue;
        currentRoom.EntryType = txtEntryStyle.Text;
        currentRoom.WorkloadSecondary = txtLeakageWorkLoad.Text;
        currentRoom.WorkloadPrimary = txtWorkload.Text;
        currentRoom.MachineDoseRate = txtMachineDoseRate.Text;
        currentRoom.MachineEnergy = txtMachineEnergy.Text;
        currentRoom.ModConvPctEnergy = DecimalFromControl(txtConvPctEnergy.Text);
        currentRoom.ModConvPctTime = DecimalFromControl(txtConvPctTx.Text);
        currentRoom.ModIMRTPctEnergy = DecimalFromControl(txtIMRTPctEnergy.Text);
        currentRoom.ModIMRTFactor = DecimalFromControl(txtIMRTFactor.Text);
        currentRoom.ModIMRTPctTime = DecimalFromControl(txtIMRTPctTx.Text);
        currentRoom.ModTBIPctEnergy = DecimalFromControl(txtTBIPctEnergy.Text);
        currentRoom.ModTBIPctTime = DecimalFromControl(txtTBIPctTx.Text);
        currentRoom.ModStereoPctEnergy = DecimalFromControl(txtStereoPctEnergy.Text);
        currentRoom.ModStereoPctTime = DecimalFromControl(txtStereoPctTx.Text);

        currentRoom.Save();
    }

    protected void cmdSaveSurveyPoint_Click(object sender, EventArgs e)
    {
        if (surveyPointID == null)
            return;

        RoomSurveyPoint currentSP = Data.GetSurveyPointByID(surveyPointID);

        currentSP.OccupancyFactor = DecimalFromControl(txtSPOccupancyFactor.Text);
        currentSP.UseFactor = DecimalFromControl(txtSPUseFactor.Text);
        currentSP.DistanceFromISOMeters = DecimalFromControl(txtSPDistanceMeters.Text);
        currentSP.DistanceFromISOFeet = DecimalFromControl(txtSPDistanceFeet.Text);
        currentSP.PELValue = DecimalFromControl(txtSPExposureLevel.Text);
        currentSP.PELType = txtSPExposureLevelReadingType.Text;
        currentSP.ExistingShielding = txtSPExistingShielding.Text;
        currentSP.AdjacentBuildings = txtSPAdjacentBuildings.Text;

        currentSP.Save();
    }

    #endregion
        
}