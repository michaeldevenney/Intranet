using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using Shared;

public partial class apps_reports_default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LoadReports();

            Label lblHeading;
            lblHeading = (Label)Master.FindControl("lblPageHeading");
            lblHeading.Text = "Veritas - Reports";
        }
    }

    private void LoadReports()
    {
        ddlReports.DataSource = GetReports("ALL");
        ddlReports.DataTextField = "ReportName";
        ddlReports.DataValueField = "LinkPath";

        ddlReports.DataBind();
        ddlReports.Items.Insert(0, "Select Report...");
    }

    #region DATA ACCESS

    public ReportCollection GetReports(string inReportList)
    {
        return Report.GetReports("ALL");
    }

    #endregion

    #region CONTROL EVENTS

    protected void ddlReports_SelectedIndexChanged(object sender, EventArgs e)
    {
        for (int i = 0; i < ddlReports.Items.Count; i++)
        {
            if (ddlReports.Items[i].Selected)
            {
                string reportURL = ddlReports.SelectedItem.Value;

                if (reportURL != string.Empty)
                    Response.Redirect(reportURL);
            }
        }
    }
    
    #endregion    
}