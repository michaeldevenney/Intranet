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
    /// Controller class for mkt_Literature
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class LiteratureController
    {
        // Preload our schema..
        Literature thisSchemaLoad = new Literature();
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
        public LiteratureCollection FetchAll()
        {
            LiteratureCollection coll = new LiteratureCollection();
            Query qry = new Query(Literature.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public LiteratureCollection FetchByID(object Id)
        {
            LiteratureCollection coll = new LiteratureCollection().Where("ID", Id).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public LiteratureCollection FetchByQuery(Query qry)
        {
            LiteratureCollection coll = new LiteratureCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Id)
        {
            return (Literature.Delete(Id) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Id)
        {
            return (Literature.Destroy(Id) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string DisplayName,string DocumentLink,string ShortenedLink)
	    {
		    Literature item = new Literature();
		    
            item.DisplayName = DisplayName;
            
            item.DocumentLink = DocumentLink;
            
            item.ShortenedLink = ShortenedLink;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int Id,string DisplayName,string DocumentLink,string ShortenedLink)
	    {
		    Literature item = new Literature();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.Id = Id;
				
			item.DisplayName = DisplayName;
				
			item.DocumentLink = DocumentLink;
				
			item.ShortenedLink = ShortenedLink;
				
	        item.Save(UserName);
	    }
    }
}