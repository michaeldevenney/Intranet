using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SubSonic;
using DAL;
using Shared;

public partial class apps_estimating_Default : System.Web.UI.Page
{
    Estimate currentEstimate;
    Project currentProspect;
    User currentSalesperson;
    User currentEstimator;

    #region CONTROL EVENTS

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Label lblHeading;
            lblHeading = (Label)Master.FindControl("lblPageHeading");
            lblHeading.Text = "Veritas - Estimating - Estimate Tracking";

            BindControls();
        }
        else
        {
            if (currentEstimate == null)
                currentEstimate = new Estimate(lstEstimates.SelectedValue);
        }
    }

    public void lstEstimates_SelectedIndexChanged(object sender, EventArgs e)
    {
        int? estID = int.Parse(lstEstimates.SelectedItem.Value);

        currentEstimate = new Estimate(estID);
        currentProspect = new Project(currentEstimate.JobName);
        currentSalesperson = new User(currentProspect.SalespersonID);
        currentEstimator = new User(currentEstimate.Estimator);

        FillForm();
    }

    public void cmdSave_Click(object sender, EventArgs e)
    {
        // Prospect/Estimate Information
        currentEstimate.EstimateNumber = txtEstimateNumber.Text;
        currentEstimate.Contact = txtClientContact.Text;
        currentEstimate.ContactEmail = txtContactEmail.Text;
        //currentEstimator.Name = txtEstimator.Text;
        currentEstimate.Received = DateTime.Parse(txtReceived.Text);

        // Estimate Dates
        currentEstimate.MoreInfoNeeded = chkMoreInfo.Checked;
        if (txtMoreInfoNeededDate.Text.Length > 5)
            currentEstimate.MoreInfoDate = DateTime.Parse(txtMoreInfoNeededDate.Text);
        currentEstimate.InitialDrawing = chkInitialDrawing.Checked;
        if (txtInitialDrawingDate.Text.Length > 5)
            currentEstimate.InitialDrawingDate = DateTime.Parse(txtInitialDrawingDate.Text);
        currentEstimate.Thicknesses = chkThicknesses.Checked;
        if (txtThicknessesDate.Text.Length > 5)
            currentEstimate.ThicknessesDate = DateTime.Parse(txtThicknessesDate.Text);
        currentEstimate.AutoCAD = chkAutoCAD.Checked;
        if (txtAutoCADDate.Text.Length > 5)
            currentEstimate.AutoCADDate = DateTime.Parse(txtAutoCADDate.Text);
        currentEstimate.Takeoff = chkTakeOff.Checked;
        if (txtTakeoffDate.Text.Length > 5)
            currentEstimate.TakeoffDate = DateTime.Parse(txtTakeoffDate.Text);
        currentEstimate.EstimateCompleted = chkEstimateCompleted.Checked;
        if (txtEstimateCompletedDate.Text.Length > 5)
            currentEstimate.EstimateCompletedDate = DateTime.Parse(txtEstimateCompletedDate.Text);
        currentEstimate.EstimateReview = chkEstimateReviewed.Checked;
        if (txtEstimateReviewedDate.Text.Length > 5)
            currentEstimate.EstimateReviewDate = DateTime.Parse(txtEstimateReviewedDate.Text);
        currentEstimate.EstimateSent = chkEstimateSent.Checked;
        if (txtEstimateSentDate.Text.Length > 5)
            currentEstimate.EstimateSentDate = DateTime.Parse(txtEstimateSentDate.Text);

        // Financial Information
        currentEstimate.InteriorsTotal = decimal.Parse(txtInteriorsTotal.Text.Replace("$", ""));
        currentEstimate.DoorsTotal = decimal.Parse(txtDoorsTotal.Text.Replace("$", ""));
        currentEstimate.BunkerTotal = decimal.Parse(txtBunkerTotal.Text.Replace("$", ""));
        currentEstimate.EstimateTotal = decimal.Parse(txtEstimatetotal.Text.Replace("$", ""));

        //Filesystem Information
        //currentEstimate.EstimatesDirectory = txtEstimatesDirectory.Text;
        //currentEstimate.ProspectDirectory = txtProspectDirectory.Text;

        currentEstimate.Save();

        currentProspect = new Project(currentEstimate.JobName);
        currentSalesperson = new User(currentProspect.SalespersonID);
        currentEstimator = new User(currentEstimate.Estimator);
    }

    public void cmdDelete_Click(object sender, EventArgs e)
    {
        int? estID = int.Parse(lstEstimates.SelectedItem.Value);
        Estimate.Delete(estID);

        lstEstimates.ClearSelection();
        
        lstEstimates.DataBind();

        lstEstimates.Items[0].Selected = true;
        currentEstimate = new Estimate(int.Parse(lstEstimates.SelectedItem.Value));
        currentProspect = new Project(currentEstimate.JobName);
        currentSalesperson = new User(currentProspect.SalespersonID);
        currentEstimator = new User(currentEstimate.Estimator);

        FillForm();
    }

    protected void cmdAddProjLead_Click(object sender, EventArgs e)
    {
        CreateProject();
    }

    protected void CheckboxClick(object sender, EventArgs e)
    {
        string controlName = ((CheckBox)sender).ID;
        string dateTimeStamp = ((CheckBox)sender).Checked ? DateTime.Now.ToString("d") : string.Empty; 
        
        switch (controlName)
        {
            case "chkMoreInfo":
                txtMoreInfoNeededDate.Text = dateTimeStamp;
                break;
            case "chkInitialDrawing":
                txtInitialDrawingDate.Text = dateTimeStamp;
                break;
            case "chkThicknesses":
                txtThicknessesDate.Text = dateTimeStamp;
                break;
            case "chkAutoCAD":
                txtAutoCADDate.Text = dateTimeStamp;
                break;
            case "chkTakeOff":
                txtTakeoffDate.Text = dateTimeStamp;
                break;
            case "chkEstimateCompleted":
                txtEstimateCompletedDate.Text = dateTimeStamp;
                break;
            case "chkEstimateReviewed":
                txtEstimateReviewedDate.Text = dateTimeStamp;
                break;
            case "chkEstimateSent":
                txtEstimateSentDate.Text = dateTimeStamp;
                break;
            default:
                break;
        }
    }

    #endregion

    #region DATA ACCESS

    public UserCollection GetUsersByTitle(string inTitle)
    {
        return Data.GetUsersByTitle(inTitle);
    }

    public LookupCollection GetLookupList(string inListName)
    {
        return Data.GetLookupList(inListName);
    }

    public ProjectCollection GetActiveProjects()
    {
        return Data.GetProjectsByStatus(Data.ProjectStatus.Active);
    }

    #endregion

    #region HELPER METHODS

    private void CreateProject()
    {
        Project proj = new Project();

        proj.ProjectLead = "Lead";

        proj.ProjectName = txtAddProjName.Text;
        proj.ProjectNumber = txtAddProjNumber.Text;
        proj.PMUserID = int.Parse(ddlAddProjMgr.SelectedItem.Value);
        proj.PMAssigned = ddlAddProjMgr.SelectedItem.Text;
        proj.SalespersonID = int.Parse(ddlSalesperson.SelectedItem.Value);
        proj.ProjectActivity = "Active";
        proj.Created = DateTime.Now;
        proj.CreatedBy = Utils.GetFormattedUserNameInternal(User.Identity.Name);
        proj.Updated = DateTime.Now;
        proj.UpdatedBy = Utils.GetFormattedUserNameInternal(User.Identity.Name);

        proj.Save();

        currentEstimate = new Estimate();
        currentEstimate.JobName = proj.Id;
        currentEstimate.Estimator = Data.GetUserFromLogin(Page.User.Identity.Name).Id;
        currentEstimate.EstimateNumber = proj.Id.ToString() + "-01";
        currentEstimate.Received = DateTime.Now;
        currentEstimate.Save();



        BindControls();
    }

    private void BindControls()
    {
        lstEstimates.DataSource = Estimate.GetAllEstimates();
        lstEstimates.DataTextField = "ProjectName";
        lstEstimates.DataValueField = "EstId";
        lstEstimates.DataBind();

        ddlAddProjMgr.DataBind();

        lstEstimates.Items[0].Selected = true;
        currentEstimate = new Estimate(lstEstimates.SelectedValue);
        currentProspect = new Project(currentEstimate.JobName);
        currentEstimator = new User(currentEstimate.Estimator);
        currentSalesperson = new User(currentProspect.SalespersonID);

        ddlSalesperson.DataBind();

        FillForm();
    }

    private void FillForm()
    {
        txtProspectName.Text = currentProspect.ProjectName;
        txtProspectName.Enabled = false;
        txtSalesPerson.Text = currentSalesperson.Name;
        txtSalesPerson.Enabled = false;

        // Prospect/Estimate Information
        txtEstimateNumber.Text = currentEstimate.EstimateNumber;
        txtClientContact.Text = currentEstimate.Contact;
        txtContactEmail.Text = currentEstimate.ContactEmail;
        txtEstimator.Text = currentEstimator.Name;
        txtReceived.Text = currentEstimate.Received.ToString();

        // Estimate Dates
        chkMoreInfo.Checked = currentEstimate.MoreInfoNeeded;
        txtMoreInfoNeededDate.Text = currentEstimate.MoreInfoDate.ToString();
        chkInitialDrawing.Checked = currentEstimate.InitialDrawing;
        txtInitialDrawingDate.Text = currentEstimate.InitialDrawingDate.ToString();
        chkThicknesses.Checked = currentEstimate.Thicknesses;
        txtThicknessesDate.Text = currentEstimate.ThicknessesDate.ToString();
        chkAutoCAD.Checked = currentEstimate.AutoCAD;
        txtAutoCADDate.Text = currentEstimate.AutoCADDate.ToString();
        chkTakeOff.Checked = currentEstimate.Takeoff;
        txtTakeoffDate.Text = currentEstimate.TakeoffDate.ToString();
        chkEstimateCompleted.Checked = currentEstimate.EstimateCompleted;
        txtEstimateCompletedDate.Text = currentEstimate.EstimateCompletedDate.ToString();
        chkEstimateReviewed.Checked = currentEstimate.EstimateReview;
        txtEstimateReviewedDate.Text = currentEstimate.EstimateReviewDate.ToString();
        chkEstimateSent.Checked = currentEstimate.EstimateSent;
        txtEstimateSentDate.Text = currentEstimate.EstimateSentDate.ToString();

        // Financial Information
        txtInteriorsTotal.Text = currentEstimate.InteriorsTotal.ToString("C2");
        txtDoorsTotal.Text = currentEstimate.DoorsTotal.ToString("C2");
        txtBunkerTotal.Text = currentEstimate.BunkerTotal.ToString("C2");
        txtEstimatetotal.Text = currentEstimate.EstimateTotal.ToString("C2");

        //Filesystem Information
        txtEstimatesDirectory.Text = currentEstimate.EstimatesDirectory;
        txtProspectDirectory.Text = currentEstimate.ProspectDirectory;
    }

    #endregion
}