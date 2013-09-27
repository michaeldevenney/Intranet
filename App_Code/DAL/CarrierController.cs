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
    /// Controller class for S_Carriers
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class CarrierController
    {
        // Preload our schema..
        Carrier thisSchemaLoad = new Carrier();
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
        public CarrierCollection FetchAll()
        {
            CarrierCollection coll = new CarrierCollection();
            Query qry = new Query(Carrier.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public CarrierCollection FetchByID(object Id)
        {
            CarrierCollection coll = new CarrierCollection().Where("ID", Id).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public CarrierCollection FetchByQuery(Query qry)
        {
            CarrierCollection coll = new CarrierCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Id)
        {
            return (Carrier.Delete(Id) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Id)
        {
            return (Carrier.Destroy(Id) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string CarrierName,string ContactPhone,string ContactName)
	    {
		    Carrier item = new Carrier();
		    
            item.CarrierName = CarrierName;
            
            item.ContactPhone = ContactPhone;
            
            item.ContactName = ContactName;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int Id,string CarrierName,string ContactPhone,string ContactName)
	    {
		    Carrier item = new Carrier();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.Id = Id;
				
			item.CarrierName = CarrierName;
				
			item.ContactPhone = ContactPhone;
				
			item.ContactName = ContactName;
				
	        item.Save(UserName);
	    }
    }
}
