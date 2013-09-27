using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using Shared;

public partial class pm_takeoff_default : System.Web.UI.Page
{
    string roomID;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {                        
            ddlProject.DataBind();
            ddlBlockType.DataBind();
            ddlProject.Items.Insert(0, new ListItem("Select Project", "0"));
            ddlBlockType.Items.Insert(0, new ListItem("Select Block", "0"));                        
        }
        else
        {            
                        
        }
    }

    #region HELPER METHODS

    protected void CalculateTotalBlock(object sender, EventArgs e)
    {
        decimal halfBlock;
        decimal fullBlock;
        int shifts;

    }

    private void FillFormDefaults()
    {
        
    }

    private void ClearForm()
    {       
       
    }

    #endregion

    #region CONTROL EVENT HANDLERS

    protected void cmdAddTakeoff_Click(object sender, EventArgs e)
    {

    }
    
    protected void ddlProject_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["ProjectID"] = ddlProject.SelectedItem.Value;
        ClearForm();
    }

   
    #endregion

    #region DATA ACCESS

    public ProjectCollection GetActiveProjects()
    {
        return Data.GetProjectsByStatus(Data.ProjectStatus.Active);
    }

    public LookupCollection GetLookupList(string inListName)
    {
        return Data.GetLookupList(inListName);
    }

    //public TakeoffCollection GetProjectTakeoffs()
    //{
    //    int projectID;
    //    if (int.TryParse(ddlProject.SelectedItem.Value, out projectID))
    //    {
    //        return Data.GetProjectTakeoffs(projectID);
    //    }
    //    else
    //    {
    //        return null;
    //    }
    //}


    #endregion

}