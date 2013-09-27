using System;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using Shared;

public partial class prod : System.Web.UI.Page
{
    public ProjectCollection projects;

   protected void Page_Load(object sender, EventArgs e)
    {
        // projects drop down list
        SubSonic.Where filter = new SubSonic.Where();
        filter.TableName = Project.Schema.Name;
        filter.ColumnName = Project.Columns.ProjectPhase;
        filter.Comparison = SubSonic.Comparison.Equals;
        filter.ParameterValue = "Active";

        projects = Session["projects"] as ProjectCollection;

        if (projects == null)
        {
            projects = new ProjectCollection().Where(filter).Load();
            Session["projects"] = projects;
        }
        
        if (!Page.IsPostBack)
        {
            lblDateValidation.Visible = false;
            BindControls();
        }
    }

    private void BindControls()
    {
        ddlProjectIns.DataSource = projects;
        ddlProjectIns.DataBind();
    }

    #region Control Events

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (calProductionDate.SelectedDate == DateTime.Parse("01/01/0001"))
        {
            lblDateValidation.Visible = true;
        }
        else
        {
            lblDateValidation.Visible = true;
            SaveEntry();
            Response.Redirect("confirm.aspx");
        }        
    }

    private void SaveEntry()
    {
        // V250 Kilned
        Production prod1 = new Production();
        prod1.Action = "Kilned";
        prod1.BlockType = "V250";
        prod1.ProductionDate = calProductionDate.SelectedDate;
        prod1.Count = Decimal.Parse(txtV250K.Text);
        prod1.EnteredBy = GetCurrentUser();
        prod1.EnteredDate = DateTime.Now;
        prod1.Save();

        // V300 Kilned
        Production prod2 = new Production();
        prod2.Action = "Kilned";
        prod2.BlockType = "V300";
        prod2.ProductionDate = calProductionDate.SelectedDate;
        prod2.Count = Decimal.Parse(txtV300K.Text);
        prod2.EnteredBy = GetCurrentUser();
        prod2.EnteredDate = DateTime.Now;
        prod2.Save();

        // Downtime
        Production prod3 = new Production();
        prod3.Action = "Downtime";
        prod3.ProductionDate = calProductionDate.SelectedDate;
        prod3.Count = Decimal.Parse(this.txtDowntime.Text);
        prod3.Comment = this.txtDowntimeComments.Text;
        prod3.EnteredBy = GetCurrentUser();
        prod3.EnteredDate = DateTime.Now;
        prod3.Save();

        // Injuries
        Production prod4 = new Production();
        prod4.Action = "Injuries";
        prod4.ProductionDate = calProductionDate.SelectedDate;
        prod4.Count = Decimal.Parse(this.txtInjuries.Text);
        prod4.Comment = this.txtInjuryComments.Text;
        prod4.EnteredBy = GetCurrentUser();
        prod4.EnteredDate = DateTime.Now;
        prod4.Save();
    }

    protected void cmdInsert_Click(object sender, EventArgs e)
    {
        if (calProductionDate.SelectedDate == DateTime.Parse("01/01/0001"))
        {
            lblDateValidation.Visible = true;
        }
        else
        {
            lblDateValidation.Visible = false;
            SqlDataSource1.Insert();
        }
    }

    protected void calProductionDate_SelectionChanged(object sender, EventArgs e)
    {
        txtV250K.Focus();
    }

    #endregion

    #region Private Methods

    
    private string GetCurrentUser()
    {
        
        string tempUser = User.Identity.Name;
        tempUser = tempUser.Replace(".", " ");

        TextInfo UsaTextInfo = new CultureInfo("en-US", false).TextInfo;
        tempUser = UsaTextInfo.ToTitleCase(tempUser);

        return tempUser;
    }
    public ProjectCollection GetActiveProjects()
    { return Data.GetProjectsByStatus(Data.ProjectStatus.Active); }
    public LookupCollection GetLookupList(string listName)
    { return Data.GetLookupList(listName); }

    #endregion    

    protected void sdsDeleting(Object sender, SqlDataSourceCommandEventArgs e)
    {
        string a = e.Command.Parameters["@ID"].Value.ToString();
    }

    protected void sdsUpdating(Object sender, SqlDataSourceCommandEventArgs e)
    {
        int? projectID = null;
        string projectName = "";
        
        for (int i = 0; i < gvYardedBlock.Rows.Count; i++)
        {
            DropDownList ddl = gvYardedBlock.Rows[i].FindControl("ddlProjectEdit") as DropDownList;
            if (ddl != null)
            {
                projectID = int.Parse(ddl.SelectedValue.ToString());
                projectName = ddl.SelectedItem.Text;
            }
        }

        e.Command.Parameters["@ProductionDate"].Value = calProductionDate.SelectedDate;
        e.Command.Parameters["@Action"].Value = "Yarded";
        e.Command.Parameters["@EnteredDate"].Value = DateTime.Now;
        e.Command.Parameters["@EnteredBy"].Value = GetCurrentUser();
        e.Command.Parameters["@ProjectID"].Value = projectID;
        e.Command.Parameters["@ProjectName"].Value = projectName;
        
    }
}