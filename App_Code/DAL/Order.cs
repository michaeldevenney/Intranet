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
	/// Strongly-typed collection for the Order class.
	/// </summary>
    [Serializable]
	public partial class OrderCollection : ActiveList<Order, OrderCollection>
	{	   
		public OrderCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>OrderCollection</returns>
		public OrderCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                Order o = this[i];
                foreach (SubSonic.Where w in this.wheres)
                {
                    bool remove = false;
                    System.Reflection.PropertyInfo pi = o.GetType().GetProperty(w.ColumnName);
                    if (pi.CanRead)
                    {
                        object val = pi.GetValue(o, null);
                        switch (w.Comparison)
                        {
                            case SubSonic.Comparison.Equals:
                                if (!val.Equals(w.ParameterValue))
                                {
                                    remove = true;
                                }
                                break;
                        }
                    }
                    if (remove)
                    {
                        this.Remove(o);
                        break;
                    }
                }
            }
            return this;
        }
		
		
	}
	/// <summary>
	/// This is an ActiveRecord class which wraps the S_Orders table.
	/// </summary>
	[Serializable]
	public partial class Order : ActiveRecord<Order>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public Order()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public Order(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public Order(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public Order(string columnName, object columnValue)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByParam(columnName,columnValue);
		}
		
		protected static void SetSQLProps() { GetTableSchema(); }
		
		#endregion
		
		#region Schema and Query Accessor	
		public static Query CreateQuery() { return new Query(Schema); }
		public static TableSchema.Table Schema
		{
			get
			{
				if (BaseSchema == null)
					SetSQLProps();
				return BaseSchema;
			}
		}
		
		private static void GetTableSchema() 
		{
			if(!IsSchemaInitialized)
			{
				//Schema declaration
				TableSchema.Table schema = new TableSchema.Table("S_Orders", TableType.Table, DataService.GetInstance("VeritasInfo"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarId = new TableSchema.TableColumn(schema);
				colvarId.ColumnName = "ID";
				colvarId.DataType = DbType.Int32;
				colvarId.MaxLength = 0;
				colvarId.AutoIncrement = true;
				colvarId.IsNullable = false;
				colvarId.IsPrimaryKey = true;
				colvarId.IsForeignKey = false;
				colvarId.IsReadOnly = false;
				colvarId.DefaultSetting = @"";
				colvarId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarId);
				
				TableSchema.TableColumn colvarOrderNumber = new TableSchema.TableColumn(schema);
				colvarOrderNumber.ColumnName = "OrderNumber";
				colvarOrderNumber.DataType = DbType.AnsiString;
				colvarOrderNumber.MaxLength = 50;
				colvarOrderNumber.AutoIncrement = false;
				colvarOrderNumber.IsNullable = true;
				colvarOrderNumber.IsPrimaryKey = false;
				colvarOrderNumber.IsForeignKey = false;
				colvarOrderNumber.IsReadOnly = false;
				colvarOrderNumber.DefaultSetting = @"";
				colvarOrderNumber.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOrderNumber);
				
				TableSchema.TableColumn colvarProjectID = new TableSchema.TableColumn(schema);
				colvarProjectID.ColumnName = "ProjectID";
				colvarProjectID.DataType = DbType.Int32;
				colvarProjectID.MaxLength = 0;
				colvarProjectID.AutoIncrement = false;
				colvarProjectID.IsNullable = true;
				colvarProjectID.IsPrimaryKey = false;
				colvarProjectID.IsForeignKey = false;
				colvarProjectID.IsReadOnly = false;
				colvarProjectID.DefaultSetting = @"";
				colvarProjectID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarProjectID);
				
				TableSchema.TableColumn colvarSummary = new TableSchema.TableColumn(schema);
				colvarSummary.ColumnName = "Summary";
				colvarSummary.DataType = DbType.AnsiString;
				colvarSummary.MaxLength = -1;
				colvarSummary.AutoIncrement = false;
				colvarSummary.IsNullable = true;
				colvarSummary.IsPrimaryKey = false;
				colvarSummary.IsForeignKey = false;
				colvarSummary.IsReadOnly = false;
				colvarSummary.DefaultSetting = @"";
				colvarSummary.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSummary);
				
				TableSchema.TableColumn colvarNumberOfPackages = new TableSchema.TableColumn(schema);
				colvarNumberOfPackages.ColumnName = "NumberOfPackages";
				colvarNumberOfPackages.DataType = DbType.Int32;
				colvarNumberOfPackages.MaxLength = 0;
				colvarNumberOfPackages.AutoIncrement = false;
				colvarNumberOfPackages.IsNullable = true;
				colvarNumberOfPackages.IsPrimaryKey = false;
				colvarNumberOfPackages.IsForeignKey = false;
				colvarNumberOfPackages.IsReadOnly = false;
				colvarNumberOfPackages.DefaultSetting = @"";
				colvarNumberOfPackages.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNumberOfPackages);
				
				TableSchema.TableColumn colvarWeight = new TableSchema.TableColumn(schema);
				colvarWeight.ColumnName = "Weight";
				colvarWeight.DataType = DbType.Decimal;
				colvarWeight.MaxLength = 0;
				colvarWeight.AutoIncrement = false;
				colvarWeight.IsNullable = true;
				colvarWeight.IsPrimaryKey = false;
				colvarWeight.IsForeignKey = false;
				colvarWeight.IsReadOnly = false;
				colvarWeight.DefaultSetting = @"";
				colvarWeight.ForeignKeyTableName = "";
				schema.Columns.Add(colvarWeight);
				
				TableSchema.TableColumn colvarAdditionalInformation = new TableSchema.TableColumn(schema);
				colvarAdditionalInformation.ColumnName = "AdditionalInformation";
				colvarAdditionalInformation.DataType = DbType.AnsiString;
				colvarAdditionalInformation.MaxLength = 255;
				colvarAdditionalInformation.AutoIncrement = false;
				colvarAdditionalInformation.IsNullable = true;
				colvarAdditionalInformation.IsPrimaryKey = false;
				colvarAdditionalInformation.IsForeignKey = false;
				colvarAdditionalInformation.IsReadOnly = false;
				colvarAdditionalInformation.DefaultSetting = @"";
				colvarAdditionalInformation.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAdditionalInformation);
				
				TableSchema.TableColumn colvarExpectedShipDate = new TableSchema.TableColumn(schema);
				colvarExpectedShipDate.ColumnName = "ExpectedShipDate";
				colvarExpectedShipDate.DataType = DbType.DateTime;
				colvarExpectedShipDate.MaxLength = 0;
				colvarExpectedShipDate.AutoIncrement = false;
				colvarExpectedShipDate.IsNullable = true;
				colvarExpectedShipDate.IsPrimaryKey = false;
				colvarExpectedShipDate.IsForeignKey = false;
				colvarExpectedShipDate.IsReadOnly = false;
				colvarExpectedShipDate.DefaultSetting = @"";
				colvarExpectedShipDate.ForeignKeyTableName = "";
				schema.Columns.Add(colvarExpectedShipDate);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["VeritasInfo"].AddSchema("S_Orders",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("Id")]
		[Bindable(true)]
		public int Id 
		{
			get { return GetColumnValue<int>(Columns.Id); }
			set { SetColumnValue(Columns.Id, value); }
		}
		  
		[XmlAttribute("OrderNumber")]
		[Bindable(true)]
		public string OrderNumber 
		{
			get { return GetColumnValue<string>(Columns.OrderNumber); }
			set { SetColumnValue(Columns.OrderNumber, value); }
		}
		  
		[XmlAttribute("ProjectID")]
		[Bindable(true)]
		public int? ProjectID 
		{
			get { return GetColumnValue<int?>(Columns.ProjectID); }
			set { SetColumnValue(Columns.ProjectID, value); }
		}
		  
		[XmlAttribute("Summary")]
		[Bindable(true)]
		public string Summary 
		{
			get { return GetColumnValue<string>(Columns.Summary); }
			set { SetColumnValue(Columns.Summary, value); }
		}
		  
		[XmlAttribute("NumberOfPackages")]
		[Bindable(true)]
		public int? NumberOfPackages 
		{
			get { return GetColumnValue<int?>(Columns.NumberOfPackages); }
			set { SetColumnValue(Columns.NumberOfPackages, value); }
		}
		  
		[XmlAttribute("Weight")]
		[Bindable(true)]
		public decimal? Weight 
		{
			get { return GetColumnValue<decimal?>(Columns.Weight); }
			set { SetColumnValue(Columns.Weight, value); }
		}
		  
		[XmlAttribute("AdditionalInformation")]
		[Bindable(true)]
		public string AdditionalInformation 
		{
			get { return GetColumnValue<string>(Columns.AdditionalInformation); }
			set { SetColumnValue(Columns.AdditionalInformation, value); }
		}
		  
		[XmlAttribute("ExpectedShipDate")]
		[Bindable(true)]
		public DateTime? ExpectedShipDate 
		{
			get { return GetColumnValue<DateTime?>(Columns.ExpectedShipDate); }
			set { SetColumnValue(Columns.ExpectedShipDate, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varOrderNumber,int? varProjectID,string varSummary,int? varNumberOfPackages,decimal? varWeight,string varAdditionalInformation,DateTime? varExpectedShipDate)
		{
			Order item = new Order();
			
			item.OrderNumber = varOrderNumber;
			
			item.ProjectID = varProjectID;
			
			item.Summary = varSummary;
			
			item.NumberOfPackages = varNumberOfPackages;
			
			item.Weight = varWeight;
			
			item.AdditionalInformation = varAdditionalInformation;
			
			item.ExpectedShipDate = varExpectedShipDate;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varId,string varOrderNumber,int? varProjectID,string varSummary,int? varNumberOfPackages,decimal? varWeight,string varAdditionalInformation,DateTime? varExpectedShipDate)
		{
			Order item = new Order();
			
				item.Id = varId;
			
				item.OrderNumber = varOrderNumber;
			
				item.ProjectID = varProjectID;
			
				item.Summary = varSummary;
			
				item.NumberOfPackages = varNumberOfPackages;
			
				item.Weight = varWeight;
			
				item.AdditionalInformation = varAdditionalInformation;
			
				item.ExpectedShipDate = varExpectedShipDate;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn OrderNumberColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn ProjectIDColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn SummaryColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn NumberOfPackagesColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn WeightColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn AdditionalInformationColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn ExpectedShipDateColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string Id = @"ID";
			 public static string OrderNumber = @"OrderNumber";
			 public static string ProjectID = @"ProjectID";
			 public static string Summary = @"Summary";
			 public static string NumberOfPackages = @"NumberOfPackages";
			 public static string Weight = @"Weight";
			 public static string AdditionalInformation = @"AdditionalInformation";
			 public static string ExpectedShipDate = @"ExpectedShipDate";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
