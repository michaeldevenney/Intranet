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
    /// Controller class for A_Addresses
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class AddressController
    {
        // Preload our schema..
        Address thisSchemaLoad = new Address();
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
        public AddressCollection FetchAll()
        {
            AddressCollection coll = new AddressCollection();
            Query qry = new Query(Address.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public AddressCollection FetchByID(object Id)
        {
            AddressCollection coll = new AddressCollection().Where("ID", Id).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public AddressCollection FetchByQuery(Query qry)
        {
            AddressCollection coll = new AddressCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Id)
        {
            return (Address.Delete(Id) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Id)
        {
            return (Address.Destroy(Id) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int AddressTypeID,int? ProjectID,string Description,string Line1,string Line2,string Line3,string Line4,string Line5)
	    {
		    Address item = new Address();
		    
            item.AddressTypeID = AddressTypeID;
            
            item.ProjectID = ProjectID;
            
            item.Description = Description;
            
            item.Line1 = Line1;
            
            item.Line2 = Line2;
            
            item.Line3 = Line3;
            
            item.Line4 = Line4;
            
            item.Line5 = Line5;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int Id,int AddressTypeID,int? ProjectID,string Description,string Line1,string Line2,string Line3,string Line4,string Line5)
	    {
		    Address item = new Address();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.Id = Id;
				
			item.AddressTypeID = AddressTypeID;
				
			item.ProjectID = ProjectID;
				
			item.Description = Description;
				
			item.Line1 = Line1;
				
			item.Line2 = Line2;
				
			item.Line3 = Line3;
				
			item.Line4 = Line4;
				
			item.Line5 = Line5;
				
	        item.Save(UserName);
	    }
    }
}
