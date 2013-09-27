using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using Shared;
using System.Collections.Specialized;
using System.Net.Mail;

public partial class pm_RFI_rfiView : System.Web.UI.Page
{
    Project currProj;
    User currentUser;

    public enum RFIOperation
    {
        Update,
        Delete
    }

    #region CONTROL EVENTS

    protected void cmdSubmitAdd_Click(object sender, EventArgs e)
    {
        CreateRFI();        
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Label lblHeading;
            lblHeading = (Label)Master.FindControl("lblPageHeading");
            lblHeading.Text = "Veritas - Project Management";

            // databind all dropdown lists
            ddlFilterProject.DataSource = GetActiveProjects();
            ddlFilterProject.DataValueField = "ID";
            ddlFilterProject.DataTextField = "DisplayName";
            ddlFilterProject.DataBind();
            ddlFilterProject.Items.Insert(0, "All Projects");

            ddlProjectAdd.DataSource = GetActiveProjects();
            ddlProjectAdd.DataValueField = "ID";
            ddlProjectAdd.DataTextField = "DisplayName";
            ddlProjectAdd.DataBind();

            ddlPMAssigned.DataBind();
            ddlPMAssigned.Items.Insert(0, "Select PM");

            sdsRFI.FilterExpression = "1=0";
            sdsRFI.FilterParameters.Clear();

            gvRFIList.DataBind();

            lblStatus.Visible = false;

            // if an RFI ID was passed to the page, fetch that RFI from the database and load the form
            NameValueCollection coll = Request.QueryString;
            if (!string.IsNullOrEmpty(coll["id"]))
            {
                LoadForm(coll["id"]);
                Session["RFI"] = coll["id"];
            }
                       
            ddlProjectAdd.DataBind();

            // set PM for initial project
            Project proj = new Project(int.Parse(ddlProjectAdd.SelectedItem.Value.ToString()));
            Session["PMAssigned"] = proj.PMUserID;
        }
    }

    protected void rdoLeadProject_SelectedIndexChanged(object sender, EventArgs e)
    {
        FilterLeadProjectDDL();
    }

    protected void rdoActiveAll_SelectedIndexChanged(object sender, EventArgs e)
    {
        FilterLeadProjectDDL();
    }

    protected void cmdApplyFilter_Click(object sender, EventArgs e)
    {
        User usr = Data.GetUserFromLogin(User.Identity.Name);

        try
        {
            if (rdoRFIOwnerFilter.SelectedItem.Value == "Mine")
            {
                // USER WANTS THEIR RFI LIST
                sdsRFI.FilterParameters.Clear();

                if (usr.Position == "Project Manager")
                {
                    sdsRFI.FilterExpression = "PMUserID = {0}";
                    sdsRFI.FilterParameters.Add("UserID", Data.GetUserIDFromLogin(User.Identity.Name).ToString());

                    if (!ddlFilterProject.Items[0].Selected)
                    {
                        sdsRFI.FilterExpression = "SubmittedByID = {0} AND ProjectID = {1}";
                        sdsRFI.FilterParameters.Add("ProjectID", ddlFilterProject.SelectedItem.Value);
                    }
                }
                else
                {

                    sdsRFI.FilterExpression = "SubmittedByID = {0}";
                    sdsRFI.FilterParameters.Add("UserID", Data.GetUserIDFromLogin(User.Identity.Name).ToString());

                    if (!ddlFilterProject.Items[0].Selected)
                    {
                        sdsRFI.FilterExpression = "SubmittedByID = {0} AND ProjectID = {1}";
                        sdsRFI.FilterParameters.Add("ProjectID", ddlFilterProject.SelectedItem.Value);
                    }
                }
            }
            else
            {
                //USER WANTS ALL RFIs
                sdsRFI.FilterParameters.Clear();

                if (!ddlFilterProject.Items[0].Selected)
                {
                    sdsRFI.FilterExpression = "ProjectID = {0}";
                    sdsRFI.FilterParameters.Add("ProjectID", ddlFilterProject.SelectedItem.Value);
                }
            }

            // Are we going to show closed RFIs?
            int x = sdsRFI.FilterParameters.Count;

            if (!chkClosedFilter.Checked)
            {
                // only need the AND if there is already another filter parameter defined
                if (sdsRFI.FilterExpression.Length > 5)
                    sdsRFI.FilterExpression += " AND ";

                sdsRFI.FilterExpression += "[Closed] = 'Open'";
            }

            Session["ProjID"] = (ddlFilterProject.Items.Count > 0 ? ddlFilterProject.SelectedItem.Value : 0.ToString());

            gvRFIList.DataBind();
            return;

        }
        catch (Exception ex)
        {
            lblFilterInfo.Text = ex.Message;
        }
    }

    protected void cmdSave_Click(object sender, EventArgs e)
    {
        SaveForm();
    }

    protected void cmdDelete_Click(object sender, EventArgs e)
    {
        DeleteRFI();
    }

    protected void gvRFIList_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataKey key = gvRFIList.DataKeys[gvRFIList.SelectedRow.RowIndex];
        string RFI = key.Value.ToString();
        Session["RFI"] = RFI;

        LoadForm(RFI);
    }

    protected void ddlProjectADD_SelectedIndexChanged(object sender, EventArgs e)
    {
        Project proj = new Project(int.Parse(ddlProjectAdd.SelectedItem.Value.ToString()));
        Session["PMAssigned"] = proj.PMUserID;

        txtSubject.Focus();
    }

    #endregion

    #region DATAACCESS

    public ProjectCollection GetActiveProjects()
    {
        return Data.GetProjectsByStatus(Data.ProjectStatus.Active);
    }

    public UserCollection GetPMs()
    {
        return Data.GetUsersByTitle("Project Manager");
    }

    #endregion

    #region HELPER METHODS

    private void CreateRFI()
    {
        Rfi req = new Rfi();

        User currentUser = Data.GetUserFromLogin(User.Identity.Name);        
        User PM = Data.GetUserByID(int.Parse(Session["PMAssigned"].ToString()));

        req.ProjectID = int.Parse(ddlProjectAdd.SelectedItem.Value.ToString());
        req.ProjectName = ddlProjectAdd.SelectedItem.Text;
        req.Subject = txtSubjectAdd.Text;
        req.Priority = ddlPriorityAdd.SelectedItem.Text;
        req.Request = txtRequestAdd.Text;
        req.Suggestion = txtSuggestAdd.Text;
        req.RefDrawingNumber = txtRefDrawingNumberAdd.Text;
        req.RefLocation = txtRefLocationAdd.Text;
        req.RefSpecSection = txtRefSpecSectionAdd.Text;
        req.RefOther = txtRefOtherAdd.Text;

        req.Submitted = DateTime.Now;
        req.SubmittedBy = currentUser.Name;
        req.SubmittedByID = currentUser.Id;

        req.PMUserID = PM.Id;
        req.PMAssigned = PM.Name;
        req.Closed = "Open";

        req.Save();

        this.lblStatus.Text = "RFI has been submitted to Project Management";

        NotifyPM(req);
        ClearFields();
    }

    private void NotifyPM(Rfi inRFI)
    {
        if (Session["PMAssigned"] != null)
        {
            User PM = Data.GetUserByID(int.Parse(Session["PMAssigned"].ToString()));

            MailMessage msg = new MailMessage();
            msg.To.Add(new MailAddress(PM.Email));
            msg.CC.Add(new MailAddress("john.brooks@veritas-medicalsolutions.com"));
            msg.CC.Add(new MailAddress("michael.devenney@veritas-medicalsolutions.com"));
            msg.From = new MailAddress("RFIs@veritas-medicalsolutions.com");
            msg.Subject = "New RFI generated for the " + ddlProjectAdd.SelectedItem.Text + " project";
            msg.Body = "The RFI has was created by " + inRFI.SubmittedBy + " and entitled " + inRFI.Subject + ".\r\n\n" +
                "Request: " + inRFI.Request + "\r\n\n" +
                "Suggestion:" + inRFI.Suggestion + "\r\n\n" +
                "If you are in the office you can click this link to be taken directly to the RFI: http://intranet/apps/rfi/RFIView.aspx?ID=" + inRFI.Id + "\r\n\n";

            SmtpClient client = new SmtpClient("ver-sbs-01");
            client.Send(msg);
        }
    }
    
    private void ClearFields()
    {
        ddlProjectAdd.ClearSelection();
        ddlPriorityAdd.ClearSelection();

        txtSubjectAdd.Text = "";
        txtRequestAdd.Text = "";
        txtSuggestAdd.Text = "";
        txtRefDrawingNumberAdd.Text = "";
        txtRefLocationAdd.Text = "";
        txtRefSpecSectionAdd.Text = "";
        txtRefOtherAdd.Text = "";
    }

    private void ClearEditingFields()
    {
        txtProject.Text = "";
        ddlPriority.ClearSelection();
        ddlPMAssigned.ClearSelection();

        txtCoreconID.Text = "";
        txtSubject.Text = "";
        txtRequest.Text = "";
        txtSuggest.Text = "";
        txtRefDrawingNumber.Text = "";
        txtRefLocation.Text = "";
        txtRefSpecSection.Text = "";
        txtRefOther.Text = "";
        txtResponse.Text = "";
        ddlClosed.SelectedValue = "Open";
    }

    private void NotifyUsers(Rfi currentRFI, User currentUser, RFIOperation operation)
    {
        // create message, decide who gets it below
        MailMessage msg = new MailMessage();

        string subject = (operation == RFIOperation.Update ? "updated" : "deleted");

        if (currentRFI.SubmittedByID == currentUser.Id)
        {
            // current user is submitter, notify PM
            int id = int.Parse(currentRFI.PMUserID.ToString());
            User PM = Data.GetUserByID(id);

            msg.To.Add(new MailAddress(PM.Email));
            msg.Subject = "The submitter has " + subject + " an RFI assigned to you";
        }
        else
        {
            if (currentRFI.PMUserID == currentUser.Id)
            {
                // current user is PM, notify submitter
                int id = int.Parse(currentRFI.SubmittedByID.ToString());
                User Submitter = Data.GetUserByID(id);

                msg.To.Add(new MailAddress(Submitter.Email));
                msg.Subject = "The assigned PM has " + subject + " an RFI you created";
            }
            else
            {
                //current user isn't the submitter or the PM, notify both
                int id = int.Parse(currentRFI.PMUserID.ToString());
                User PM = Data.GetUserByID(id);
                id = int.Parse(currentRFI.SubmittedByID.ToString());
                User Submitter = Data.GetUserByID(id);

                msg.To.Add(new MailAddress(PM.Email));
                msg.To.Add(new MailAddress(Submitter.Email));
                msg.Subject = "An RFI for the " + currentRFI.ProjectName + " project was " + subject + " by " + currentUser.Name;
            }
        }

        // all msgs will be cc'ed to Mike D for a test period
        msg.CC.Add(new MailAddress("michael.devenney@veritas-medicalsolutions.com"));
        msg.CC.Add(new MailAddress("john.brooks@veritas-medicalsolutions.com"));
        msg.From = new MailAddress("RFIs@veritas-medicalsolutions.com");
        msg.Body = "Please login to the intranet site to view the full details. http://intranet/pm/RFI/RFIView.aspx?ID=" + currentRFI.Id.ToString() + "\r\n" +
            "Project/Lead: " + currentRFI.ProjectName + "\r\n" +
            "Created by: " + currentRFI.SubmittedBy + " on " + currentRFI.Submitted.ToString() + "\r\n" +
            "Last Updated by: " + currentRFI.UpdatedBy + " on " + currentRFI.Updated.ToString() + "\r\n" +
            "Subject: " + currentRFI.Subject + "\r\n" +
            "Request: " + currentRFI.Request + "\r\n" +
            "Suggestion: " + currentRFI.Suggestion + "\r\n" +
            "Assigned PM: " + currentRFI.PMAssigned + "\r\n";

        SmtpClient client = new SmtpClient("ver-sbs-01");
        client.Send(msg);

    }

    private void LoadForm(string RFI)
    {
        Rfi currentRFI = Data.GetRFIByID(RFI);

        ddlPMAssigned.SelectedValue = currentRFI.PMUserID.ToString();
        txtProject.Text = currentRFI.ProjectName;
        txtProject.Enabled = false;
        //ddlProject.SelectedValue = currentRFI.ProjectID.ToString();
        txtSubject.Text = currentRFI.Subject;
        ddlPriority.SelectedValue = currentRFI.Priority;
        txtRefDrawingNumber.Text = currentRFI.RefDrawingNumber;
        txtRefLocation.Text = currentRFI.RefLocation;
        txtRefSpecSection.Text = currentRFI.RefSpecSection;
        txtRefOther.Text = currentRFI.RefOther;
        txtRequest.Text = currentRFI.Request;
        txtSuggest.Text = currentRFI.Suggestion;
        txtResponse.Text = currentRFI.Response;
        txtCoreconID.Text = currentRFI.CoreconID;
        ddlClosed.SelectedValue = currentRFI.Closed;

    }

    private void SaveForm()
    {
        string RFI = Session["RFI"].ToString();

        User currentUser = Data.GetUserFromLogin(User.Identity.Name);
        Rfi currentRFI = Data.GetRFIByID(RFI);

        //currentRFI.ProjectID = int.Parse(ddlProject.SelectedItem.Value.ToString());
        //currentRFI.ProjectName = ddlProject.SelectedItem.Text;
        currentRFI.Subject = txtSubject.Text;
        currentRFI.Priority = ddlPriority.SelectedValue.ToString();
        currentRFI.RefDrawingNumber = txtRefDrawingNumber.Text;
        currentRFI.RefLocation = txtRefLocation.Text;
        currentRFI.RefSpecSection = txtRefSpecSection.Text;
        currentRFI.RefOther = txtRefOther.Text;
        currentRFI.Request = txtRequest.Text;
        currentRFI.Suggestion = txtSuggest.Text;
        currentRFI.Response = txtResponse.Text;
        currentRFI.PMAssigned = ddlPMAssigned.SelectedItem.Text;
        currentRFI.PMUserID = int.Parse(ddlPMAssigned.SelectedValue);
        currentRFI.CoreconID = txtCoreconID.Text;

        currentRFI.Updated = DateTime.Now;
        currentRFI.UpdatedBy = currentUser.Name;
        currentRFI.UpdatedByID = currentUser.Id;

        currentRFI.Closed = ddlClosed.SelectedValue;

        currentRFI.Save();

        lblStatus.Text = "RFI has been updated and the assigned PM has been notified of the change.";
        lblStatus.Visible = true;

        NotifyUsers(currentRFI, currentUser, RFIOperation.Update);
        gvRFIList.DataBind();
    }

    private void DeleteRFI()
    {
        string RFIID = Session["RFI"].ToString();

        User currentUser = Data.GetUserFromLogin(User.Identity.Name);
        Rfi currentRFI = Data.GetRFIByID(RFIID);

        NotifyUsers(currentRFI, currentUser, RFIOperation.Delete);

        Rfi.Delete(RFIID);

        gvRFIList.DataBind();
    }

    private void FilterLeadProjectDDL()
    {
        if (rdoLeadProject.SelectedValue == "Projects")
        {
            if (rdoActiveAll.SelectedValue == "Active")
            {
                ddlProjectAdd.DataSource = Data.GetProjectsByStatus(Data.ProjectStatus.Active);
                ddlFilterProject.DataSource = Data.GetProjectsByStatus(Data.ProjectStatus.Active);                
            }
            else
            {
                ddlProjectAdd.DataSource = Data.GetAllProjects();
                ddlFilterProject.DataSource = Data.GetAllProjects();
            }

            ddlProjectAdd.DataValueField = "ID";
            ddlProjectAdd.DataTextField = "DisplayName";
            
            lblProject.Text = "Project: ";
            lblProjectAdd.Text = "Project: ";                        
            lblProjectLeadHeader.Text = "Project Request For Information (RFI)";
            lblFilterProjectLead.Text = "Select Project: ";
            
            ddlFilterProject.DataValueField = "ID";
            ddlFilterProject.DataTextField = "DisplayName";
            ddlFilterProject.DataBind();
            ddlFilterProject.Items.Insert(0, "All Projects");
        }
        else
        {
            if (rdoActiveAll.SelectedValue == "Active")
            {
                ddlProjectAdd.DataSource = Data.GetLeadsByStatus(Data.ProjectStatus.Active);
                ddlFilterProject.DataSource = Data.GetLeadsByStatus(Data.ProjectStatus.Active);
            }
            else
            {
                ddlProjectAdd.DataSource = Data.GetAllLeads();
                ddlFilterProject.DataSource = Data.GetAllLeads();
            }


            ddlProjectAdd.DataValueField = "ID";
            ddlProjectAdd.DataTextField = "DisplayName";
            
            lblProject.Text = "Lead: ";
            lblProjectAdd.Text = "Lead: ";
            lblProjectLeadHeader.Text = "Lead Request For Information (RFI)";
            lblFilterProjectLead.Text = "Select Lead: ";

            ddlFilterProject.DataValueField = "ID";
            ddlFilterProject.DataTextField = "DisplayName";
            ddlFilterProject.DataBind();
            ddlFilterProject.Items.Insert(0, "All Leads");
        }


        ddlProjectAdd.DataBind();        
        
        // should be set on the filter button on click event, not here.
        //Session["ProjID"] = (ddlFilterProject.Items.Count > 0 ? ddlFilterProject.SelectedItem.Value : 0.ToString());

        if (ddlFilterProject.Items.Count > 0)
        {
            currProj = new Project(Session["ProjID"]);            
        }
    }
    
    #endregion
    
}