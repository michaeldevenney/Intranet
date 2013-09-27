using System; 
using System.Text; 
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration; 
using System.Xml; 
using System.Xml.Serialization;
using SubSonic; 
using SubSonic.Utilities;
// <auto-generated />
namespace DAL
{
    /// <summary>
    /// Controller class for Reports
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class ReportController
    {
        // Preload our schema..
        Report thisSchemaLoad = new Report();
        private string userName = String.Empty;
        protected string UserName
        {
            get
            {
				if (userName.Length == 0) 
				{
    				if (System.Web.HttpContext.Current != null)
    				{
						userName=System.Web.HttpContext.Current.User.Identity.Name;
					}
					else
					{
						userName=System.Threading.Thread.CurrentPrincipal.Identity.Name;
					}
				}
				return userName;
            }
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public ReportCollection FetchAll()
        {
            ReportCollection coll = new ReportCollection();
            Query qry = new Query(Report.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public ReportCollection FetchByID(object Id)
        {
            ReportCollection coll = new ReportCollection().Where("ID", Id).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public ReportCollection FetchByQuery(Query qry)
        {
            ReportCollection coll = new ReportCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Id)
        {
            return (Report.Delete(Id) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Id)
        {
            return (Report.Destroy(Id) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string ReportName,string LinkPath,bool Active,string List)
	    {
		    Report item = new Report();
		    
            item.ReportName = ReportName;
            
            item.LinkPath = LinkPath;
            
            item.Active = Active;
            
            item.List = List;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int Id,string ReportName,string LinkPath,bool Active,string List)
	    {
		    Report item = new Report();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.Id = Id;
				
			item.ReportName = ReportName;
				
			item.LinkPath = LinkPath;
				
			item.Active = Active;
				
			item.List = List;
				
	        item.Save(UserName);
	    }
    }
}
