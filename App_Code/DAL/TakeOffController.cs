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
    /// Controller class for A_TakeOffs
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class TakeOffController
    {
        // Preload our schema..
        TakeOff thisSchemaLoad = new TakeOff();
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
        public TakeOffCollection FetchAll()
        {
            TakeOffCollection coll = new TakeOffCollection();
            Query qry = new Query(TakeOff.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public TakeOffCollection FetchByID(object Id)
        {
            TakeOffCollection coll = new TakeOffCollection().Where("ID", Id).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public TakeOffCollection FetchByQuery(Query qry)
        {
            TakeOffCollection coll = new TakeOffCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Id)
        {
            return (TakeOff.Delete(Id) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Id)
        {
            return (TakeOff.Destroy(Id) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int ProjectID,DateTime? TakeOffDate,string DrawingsUsed,string Pm,decimal? V250,decimal? V250HT,decimal? V300,decimal? V300HT,decimal? Grout,decimal? Trucks)
	    {
		    TakeOff item = new TakeOff();
		    
            item.ProjectID = ProjectID;
            
            item.TakeOffDate = TakeOffDate;
            
            item.DrawingsUsed = DrawingsUsed;
            
            item.Pm = Pm;
            
            item.V250 = V250;
            
            item.V250HT = V250HT;
            
            item.V300 = V300;
            
            item.V300HT = V300HT;
            
            item.Grout = Grout;
            
            item.Trucks = Trucks;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int Id,int ProjectID,DateTime? TakeOffDate,string DrawingsUsed,string Pm,decimal? V250,decimal? V250HT,decimal? V300,decimal? V300HT,decimal? Grout,decimal? Trucks)
	    {
		    TakeOff item = new TakeOff();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.Id = Id;
				
			item.ProjectID = ProjectID;
				
			item.TakeOffDate = TakeOffDate;
				
			item.DrawingsUsed = DrawingsUsed;
				
			item.Pm = Pm;
				
			item.V250 = V250;
				
			item.V250HT = V250HT;
				
			item.V300 = V300;
				
			item.V300HT = V300HT;
				
			item.Grout = Grout;
				
			item.Trucks = Trucks;
				
	        item.Save(UserName);
	    }
    }
}