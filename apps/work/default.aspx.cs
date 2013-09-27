using System;
using System.Web.UI.WebControls;
using DAL;
using Shared;

public partial class apps_work_default : System.Web.UI.Page
{
    DAL.User currentUser;

    protected void Page_Load(object sender, EventArgs e)
    {
        currentUser = Data.GetUserFromLogin(User.Identity.Name);

        if (!Page.IsPostBack)
        {
            ddlProject1.DataBind();
            ddlProject2.DataBind();
            ddlProject3.DataBind();
            ddlProject4.DataBind();

            Label lblHeading;
            lblHeading = (Label)Master.FindControl("lblPageHeading");
            lblHeading.Text = "Veritas - Project Work Tracking";

            calDateWorked.SelectedDate = DateTime.Now;
            lblDateSelected.Text = "Entering Time for " + calDateWorked.SelectedDate.ToString("d");
        }
    }

    #region CONTROL EVENTS

    protected void calDateWorked_Changed(object sender, EventArgs e)
    {
        lblDateSelected.Text = "Entering Time for: " + calDateWorked.SelectedDate.ToString("d");
    }

    protected void cmdSave_Clicked(object sender, EventArgs e)
    {
        if (txtDescription1.Text.Length > 1)
        {
            WorkTracking temp1 = new WorkTracking();
            temp1.Person = currentUser.Name;
            temp1.Hours = decimal.Parse(txtHours1.Text);
            temp1.Description = txtDescription1.Text;
            temp1.Comments = txtComments1.Text;
            temp1.DateWorked = calDateWorked.SelectedDate;

            temp1.Save();
        }

        if (txtDescription2.Text.Length > 1)
        {
            WorkTracking temp2 = new WorkTracking();
            temp2.Person = currentUser.Name;
            temp2.Hours = decimal.Parse(txtHours2.Text);
            temp2.Description = txtDescription2.Text;
            temp2.Comments = txtComments2.Text;
            temp2.DateWorked = calDateWorked.SelectedDate;

            temp2.Save();
        }

        if (txtDescription3.Text.Length > 1)
        {
            WorkTracking temp3 = new WorkTracking();
            temp3.Person = currentUser.Name;
            temp3.Hours = decimal.Parse(txtHours3.Text);
            temp3.Description = txtDescription3.Text;
            temp3.Comments = txtComments3.Text;
            temp3.DateWorked = calDateWorked.SelectedDate;

            temp3.Save();
        }
        if (txtDescription4.Text.Length > 1)
        {
            WorkTracking temp4 = new WorkTracking();
            temp4.Person = currentUser.Name;
            temp4.Hours = decimal.Parse(txtHours4.Text);
            temp4.Description = txtDescription4.Text;
            temp4.Comments = txtComments4.Text;
            temp4.DateWorked = calDateWorked.SelectedDate;

            temp4.Save();
        }

        calDateWorked.SelectedDate = DateTime.Now;
        
        ClearFields();
    }

    protected void ClearFields()
    {
        txtDescription1.Text = "";
        txtComments1.Text = "";
        txtHours1.Text = "";

        txtDescription2.Text = "";
        txtComments2.Text = "";
        txtHours2.Text = "";

        txtDescription3.Text = "";
        txtComments3.Text = "";
        txtHours3.Text = "";

        txtDescription4.Text = "";
        txtComments4.Text = "";
        txtHours4.Text = "";
    }

    protected void ddlProject1_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtDescription1.Text = ddlProject1.SelectedItem.Text;
    }

    protected void ddlProject2_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtDescription2.Text = ddlProject2.SelectedItem.Text;
    }

    protected void ddlProject3_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtDescription3.Text = ddlProject3.SelectedItem.Text;
    }

    protected void ddlProject4_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtDescription4.Text = ddlProject4.SelectedItem.Text;
    }



    #endregion

    #region DATA ACCESS

    public ProjectCollection GetActiveProjects()
    {
        return Data.GetProjectsByStatus(Data.ProjectStatus.Active);
    }

    #endregion
}