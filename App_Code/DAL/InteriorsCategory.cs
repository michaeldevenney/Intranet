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
	/// Strongly-typed collection for the InteriorsCategory class.
	/// </summary>
    [Serializable]
	public partial class InteriorsCategoryCollection : ActiveList<InteriorsCategory, InteriorsCategoryCollection>
	{	   
		public InteriorsCategoryCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>InteriorsCategoryCollection</returns>
		public InteriorsCategoryCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                InteriorsCategory o = this[i];
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
	/// This is an ActiveRecord class which wraps the InteriorsCategories table.
	/// </summary>
	[Serializable]
	public partial class InteriorsCategory : ActiveRecord<InteriorsCategory>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public InteriorsCategory()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public InteriorsCategory(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public InteriorsCategory(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public InteriorsCategory(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("InteriorsCategories", TableType.Table, DataService.GetInstance("VeritasInfo"));
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
				
				TableSchema.TableColumn colvarCategoryName = new TableSchema.TableColumn(schema);
				colvarCategoryName.ColumnName = "CategoryName";
				colvarCategoryName.DataType = DbType.AnsiString;
				colvarCategoryName.MaxLength = 50;
				colvarCategoryName.AutoIncrement = false;
				colvarCategoryName.IsNullable = false;
				colvarCategoryName.IsPrimaryKey = false;
				colvarCategoryName.IsForeignKey = false;
				colvarCategoryName.IsReadOnly = false;
				colvarCategoryName.DefaultSetting = @"";
				colvarCategoryName.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCategoryName);
				
				TableSchema.TableColumn colvarDescription = new TableSchema.TableColumn(schema);
				colvarDescription.ColumnName = "Description";
				colvarDescription.DataType = DbType.AnsiString;
				colvarDescription.MaxLength = 500;
				colvarDescription.AutoIncrement = false;
				colvarDescription.IsNullable = true;
				colvarDescription.IsPrimaryKey = false;
				colvarDescription.IsForeignKey = false;
				colvarDescription.IsReadOnly = false;
				colvarDescription.DefaultSetting = @"";
				colvarDescription.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDescription);
				
				TableSchema.TableColumn colvarSpecSection = new TableSchema.TableColumn(schema);
				colvarSpecSection.ColumnName = "SpecSection";
				colvarSpecSection.DataType = DbType.AnsiString;
				colvarSpecSection.MaxLength = 10;
				colvarSpecSection.AutoIncrement = false;
				colvarSpecSection.IsNullable = true;
				colvarSpecSection.IsPrimaryKey = false;
				colvarSpecSection.IsForeignKey = false;
				colvarSpecSection.IsReadOnly = false;
				colvarSpecSection.DefaultSetting = @"";
				colvarSpecSection.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSpecSection);
				
				TableSchema.TableColumn colvarSpecLevel = new TableSchema.TableColumn(schema);
				colvarSpecLevel.ColumnName = "SpecLevel";
				colvarSpecLevel.DataType = DbType.Int32;
				colvarSpecLevel.MaxLength = 0;
				colvarSpecLevel.AutoIncrement = false;
				colvarSpecLevel.IsNullable = true;
				colvarSpecLevel.IsPrimaryKey = false;
				colvarSpecLevel.IsForeignKey = false;
				colvarSpecLevel.IsReadOnly = false;
				colvarSpecLevel.DefaultSetting = @"";
				colvarSpecLevel.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSpecLevel);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["VeritasInfo"].AddSchema("InteriorsCategories",schema);
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
		  
		[XmlAttribute("CategoryName")]
		[Bindable(true)]
		public string CategoryName 
		{
			get { return GetColumnValue<string>(Columns.CategoryName); }
			set { SetColumnValue(Columns.CategoryName, value); }
		}
		  
		[XmlAttribute("Description")]
		[Bindable(true)]
		public string Description 
		{
			get { return GetColumnValue<string>(Columns.Description); }
			set { SetColumnValue(Columns.Description, value); }
		}
		  
		[XmlAttribute("SpecSection")]
		[Bindable(true)]
		public string SpecSection 
		{
			get { return GetColumnValue<string>(Columns.SpecSection); }
			set { SetColumnValue(Columns.SpecSection, value); }
		}
		  
		[XmlAttribute("SpecLevel")]
		[Bindable(true)]
		public int? SpecLevel 
		{
			get { return GetColumnValue<int?>(Columns.SpecLevel); }
			set { SetColumnValue(Columns.SpecLevel, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varCategoryName,string varDescription,string varSpecSection,int? varSpecLevel)
		{
			InteriorsCategory item = new InteriorsCategory();
			
			item.CategoryName = varCategoryName;
			
			item.Description = varDescription;
			
			item.SpecSection = varSpecSection;
			
			item.SpecLevel = varSpecLevel;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varId,string varCategoryName,string varDescription,string varSpecSection,int? varSpecLevel)
		{
			InteriorsCategory item = new InteriorsCategory();
			
				item.Id = varId;
			
				item.CategoryName = varCategoryName;
			
				item.Description = varDescription;
			
				item.SpecSection = varSpecSection;
			
				item.SpecLevel = varSpecLevel;
			
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
        
        
        
        public static TableSchema.TableColumn CategoryNameColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn DescriptionColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn SpecSectionColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn SpecLevelColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string Id = @"ID";
			 public static string CategoryName = @"CategoryName";
			 public static string Description = @"Description";
			 public static string SpecSection = @"SpecSection";
			 public static string SpecLevel = @"SpecLevel";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}