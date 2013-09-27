using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using Shared;

public partial class admin_CallLog_default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Label lblHeading;
            lblHeading = (Label)Master.FindControl("lblPageHeading");
            lblHeading.Text = "Call Log";

            ddlProject.DataBind();
            ddlCallingFor.DataBind();
            txtCallDate.Text = DateTime.Now.ToString("d");
            ddlProject.Items.Insert(0, "Select Project");            
        }
    }

    #region CONTROL EVENTS

    protected void Button1_Click(object sender, EventArgs e)
    {
        string tmpDate = txtCallDate.Text + " " + txtCallTime.Text;
        DateTime tempDate = DateTime.Parse(tmpDate);

        int projID = ddlProject.SelectedItem.Text == "Select Project" ? 0 : int.Parse(ddlProject.SelectedItem.Value.ToString());

        CallLog call = new CallLog();

        call.CallerCompany = txtCallerCompany.Text;
        call.CallerName = txtCallerName.Text;
        call.CallerNumber = txtCallbackNumber.Text;
        call.CallReceived = tempDate;
        call.Notes = txtCallNotes.Text;
        call.ProjectID = projID;
        call.VeritasEmployee = ddlCallingFor.SelectedItem.Text;
        call.EnteredBy = Utils.GetFormattedUserNameInternal(User.Identity.Name);
        call.EnteredDate = DateTime.Now;
        call.Save();

        txtCallerCompany.Text = string.Empty;
        txtCallerName.Text = string.Empty;
        txtCallbackNumber.Text = string.Empty;
        txtCallTime.Text = string.Empty;
        txtCallNotes.Text = string.Empty;
        foreach (ListItem pers in ddlCallingFor.Items)
        {
            pers.Selected = false;
        }
        foreach (ListItem proj in ddlProject.Items)
        {
            proj.Selected = false;
        }
        ddlCallingFor.Items[0].Selected = true;
        ddlProject.Items[0].Selected = true;

        lblStatus.Text = "Call has been entered.";
        lblStatus.Visible = true;
    }

    #endregion
    
    #region DATA ACCESS

    public ProjectCollection GetActiveProjects()
    {
        return Data.GetProjectsByStatus(Data.ProjectStatus.Active);
    }

    public UserCollection GetActiveUsers()
    {
        return Data.GetUsersByStatus(Data.UserStatus.Active);
    }

    #endregion

    #region HELPER METHODS
    
   

    #endregion

    
}