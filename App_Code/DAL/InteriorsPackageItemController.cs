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
    /// Controller class for InteriorsPackageItems
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class InteriorsPackageItemController
    {
        // Preload our schema..
        InteriorsPackageItem thisSchemaLoad = new InteriorsPackageItem();
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
        public InteriorsPackageItemCollection FetchAll()
        {
            InteriorsPackageItemCollection coll = new InteriorsPackageItemCollection();
            Query qry = new Query(InteriorsPackageItem.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public InteriorsPackageItemCollection FetchByID(object Id)
        {
            InteriorsPackageItemCollection coll = new InteriorsPackageItemCollection().Where("ID", Id).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public InteriorsPackageItemCollection FetchByQuery(Query qry)
        {
            InteriorsPackageItemCollection coll = new InteriorsPackageItemCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Id)
        {
            return (InteriorsPackageItem.Delete(Id) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Id)
        {
            return (InteriorsPackageItem.Destroy(Id) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int PackageID,int PackageLevelID,int CategoryID,int ItemID,DateTime? LastUpdated,string UpdatedBy,bool? DefaultItem,bool? SalesSummary,decimal? Qty)
	    {
		    InteriorsPackageItem item = new InteriorsPackageItem();
		    
            item.PackageID = PackageID;
            
            item.PackageLevelID = PackageLevelID;
            
            item.CategoryID = CategoryID;
            
            item.ItemID = ItemID;
            
            item.LastUpdated = LastUpdated;
            
            item.UpdatedBy = UpdatedBy;
            
            item.DefaultItem = DefaultItem;
            
            item.SalesSummary = SalesSummary;
            
            item.Qty = Qty;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int Id,int PackageID,int PackageLevelID,int CategoryID,int ItemID,DateTime? LastUpdated,string UpdatedBy,bool? DefaultItem,bool? SalesSummary,decimal? Qty)
	    {
		    InteriorsPackageItem item = new InteriorsPackageItem();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.Id = Id;
				
			item.PackageID = PackageID;
				
			item.PackageLevelID = PackageLevelID;
				
			item.CategoryID = CategoryID;
				
			item.ItemID = ItemID;
				
			item.LastUpdated = LastUpdated;
				
			item.UpdatedBy = UpdatedBy;
				
			item.DefaultItem = DefaultItem;
				
			item.SalesSummary = SalesSummary;
				
			item.Qty = Qty;
				
	        item.Save(UserName);
	    }
    }
}
