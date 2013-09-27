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
	/// Strongly-typed collection for the Address class.
	/// </summary>
    [Serializable]
	public partial class AddressCollection : ActiveList<Address, AddressCollection>
	{	   
		public AddressCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>AddressCollection</returns>
		public AddressCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                Address o = this[i];
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
	/// This is an ActiveRecord class which wraps the A_Addresses table.
	/// </summary>
	[Serializable]
	public partial class Address : ActiveRecord<Address>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public Address()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public Address(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public Address(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public Address(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("A_Addresses", TableType.Table, DataService.GetInstance("VeritasInfo"));
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
				
				TableSchema.TableColumn colvarAddressTypeID = new TableSchema.TableColumn(schema);
				colvarAddressTypeID.ColumnName = "AddressTypeID";
				colvarAddressTypeID.DataType = DbType.Int32;
				colvarAddressTypeID.MaxLength = 0;
				colvarAddressTypeID.AutoIncrement = false;
				colvarAddressTypeID.IsNullable = false;
				colvarAddressTypeID.IsPrimaryKey = false;
				colvarAddressTypeID.IsForeignKey = false;
				colvarAddressTypeID.IsReadOnly = false;
				colvarAddressTypeID.DefaultSetting = @"";
				colvarAddressTypeID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAddressTypeID);
				
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
				
				TableSchema.TableColumn colvarDescription = new TableSchema.TableColumn(schema);
				colvarDescription.ColumnName = "Description";
				colvarDescription.DataType = DbType.AnsiString;
				colvarDescription.MaxLength = 50;
				colvarDescription.AutoIncrement = false;
				colvarDescription.IsNullable = true;
				colvarDescription.IsPrimaryKey = false;
				colvarDescription.IsForeignKey = false;
				colvarDescription.IsReadOnly = false;
				colvarDescription.DefaultSetting = @"";
				colvarDescription.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDescription);
				
				TableSchema.TableColumn colvarLine1 = new TableSchema.TableColumn(schema);
				colvarLine1.ColumnName = "Line1";
				colvarLine1.DataType = DbType.AnsiString;
				colvarLine1.MaxLength = 50;
				colvarLine1.AutoIncrement = false;
				colvarLine1.IsNullable = true;
				colvarLine1.IsPrimaryKey = false;
				colvarLine1.IsForeignKey = false;
				colvarLine1.IsReadOnly = false;
				colvarLine1.DefaultSetting = @"";
				colvarLine1.ForeignKeyTableName = "";
				schema.Columns.Add(colvarLine1);
				
				TableSchema.TableColumn colvarLine2 = new TableSchema.TableColumn(schema);
				colvarLine2.ColumnName = "Line2";
				colvarLine2.DataType = DbType.AnsiString;
				colvarLine2.MaxLength = 50;
				colvarLine2.AutoIncrement = false;
				colvarLine2.IsNullable = true;
				colvarLine2.IsPrimaryKey = false;
				colvarLine2.IsForeignKey = false;
				colvarLine2.IsReadOnly = false;
				colvarLine2.DefaultSetting = @"";
				colvarLine2.ForeignKeyTableName = "";
				schema.Columns.Add(colvarLine2);
				
				TableSchema.TableColumn colvarLine3 = new TableSchema.TableColumn(schema);
				colvarLine3.ColumnName = "Line3";
				colvarLine3.DataType = DbType.AnsiString;
				colvarLine3.MaxLength = 50;
				colvarLine3.AutoIncrement = false;
				colvarLine3.IsNullable = true;
				colvarLine3.IsPrimaryKey = false;
				colvarLine3.IsForeignKey = false;
				colvarLine3.IsReadOnly = false;
				colvarLine3.DefaultSetting = @"";
				colvarLine3.ForeignKeyTableName = "";
				schema.Columns.Add(colvarLine3);
				
				TableSchema.TableColumn colvarLine4 = new TableSchema.TableColumn(schema);
				colvarLine4.ColumnName = "Line4";
				colvarLine4.DataType = DbType.AnsiString;
				colvarLine4.MaxLength = 50;
				colvarLine4.AutoIncrement = false;
				colvarLine4.IsNullable = true;
				colvarLine4.IsPrimaryKey = false;
				colvarLine4.IsForeignKey = false;
				colvarLine4.IsReadOnly = false;
				colvarLine4.DefaultSetting = @"";
				colvarLine4.ForeignKeyTableName = "";
				schema.Columns.Add(colvarLine4);
				
				TableSchema.TableColumn colvarLine5 = new TableSchema.TableColumn(schema);
				colvarLine5.ColumnName = "Line5";
				colvarLine5.DataType = DbType.AnsiString;
				colvarLine5.MaxLength = 50;
				colvarLine5.AutoIncrement = false;
				colvarLine5.IsNullable = true;
				colvarLine5.IsPrimaryKey = false;
				colvarLine5.IsForeignKey = false;
				colvarLine5.IsReadOnly = false;
				colvarLine5.DefaultSetting = @"";
				colvarLine5.ForeignKeyTableName = "";
				schema.Columns.Add(colvarLine5);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["VeritasInfo"].AddSchema("A_Addresses",schema);
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
		  
		[XmlAttribute("AddressTypeID")]
		[Bindable(true)]
		public int AddressTypeID 
		{
			get { return GetColumnValue<int>(Columns.AddressTypeID); }
			set { SetColumnValue(Columns.AddressTypeID, value); }
		}
		  
		[XmlAttribute("ProjectID")]
		[Bindable(true)]
		public int? ProjectID 
		{
			get { return GetColumnValue<int?>(Columns.ProjectID); }
			set { SetColumnValue(Columns.ProjectID, value); }
		}
		  
		[XmlAttribute("Description")]
		[Bindable(true)]
		public string Description 
		{
			get { return GetColumnValue<string>(Columns.Description); }
			set { SetColumnValue(Columns.Description, value); }
		}
		  
		[XmlAttribute("Line1")]
		[Bindable(true)]
		public string Line1 
		{
			get { return GetColumnValue<string>(Columns.Line1); }
			set { SetColumnValue(Columns.Line1, value); }
		}
		  
		[XmlAttribute("Line2")]
		[Bindable(true)]
		public string Line2 
		{
			get { return GetColumnValue<string>(Columns.Line2); }
			set { SetColumnValue(Columns.Line2, value); }
		}
		  
		[XmlAttribute("Line3")]
		[Bindable(true)]
		public string Line3 
		{
			get { return GetColumnValue<string>(Columns.Line3); }
			set { SetColumnValue(Columns.Line3, value); }
		}
		  
		[XmlAttribute("Line4")]
		[Bindable(true)]
		public string Line4 
		{
			get { return GetColumnValue<string>(Columns.Line4); }
			set { SetColumnValue(Columns.Line4, value); }
		}
		  
		[XmlAttribute("Line5")]
		[Bindable(true)]
		public string Line5 
		{
			get { return GetColumnValue<string>(Columns.Line5); }
			set { SetColumnValue(Columns.Line5, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varAddressTypeID,int? varProjectID,string varDescription,string varLine1,string varLine2,string varLine3,string varLine4,string varLine5)
		{
			Address item = new Address();
			
			item.AddressTypeID = varAddressTypeID;
			
			item.ProjectID = varProjectID;
			
			item.Description = varDescription;
			
			item.Line1 = varLine1;
			
			item.Line2 = varLine2;
			
			item.Line3 = varLine3;
			
			item.Line4 = varLine4;
			
			item.Line5 = varLine5;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varId,int varAddressTypeID,int? varProjectID,string varDescription,string varLine1,string varLine2,string varLine3,string varLine4,string varLine5)
		{
			Address item = new Address();
			
				item.Id = varId;
			
				item.AddressTypeID = varAddressTypeID;
			
				item.ProjectID = varProjectID;
			
				item.Description = varDescription;
			
				item.Line1 = varLine1;
			
				item.Line2 = varLine2;
			
				item.Line3 = varLine3;
			
				item.Line4 = varLine4;
			
				item.Line5 = varLine5;
			
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
        
        
        
        public static TableSchema.TableColumn AddressTypeIDColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn ProjectIDColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn DescriptionColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn Line1Column
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn Line2Column
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn Line3Column
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn Line4Column
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn Line5Column
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string Id = @"ID";
			 public static string AddressTypeID = @"AddressTypeID";
			 public static string ProjectID = @"ProjectID";
			 public static string Description = @"Description";
			 public static string Line1 = @"Line1";
			 public static string Line2 = @"Line2";
			 public static string Line3 = @"Line3";
			 public static string Line4 = @"Line4";
			 public static string Line5 = @"Line5";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
