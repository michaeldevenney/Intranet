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
	/// Strongly-typed collection for the Literature class.
	/// </summary>
    [Serializable]
	public partial class LiteratureCollection : ActiveList<Literature, LiteratureCollection>
	{	   
		public LiteratureCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>LiteratureCollection</returns>
		public LiteratureCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                Literature o = this[i];
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
	/// This is an ActiveRecord class which wraps the mkt_Literature table.
	/// </summary>
	[Serializable]
	public partial class Literature : ActiveRecord<Literature>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public Literature()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public Literature(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public Literature(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public Literature(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("mkt_Literature", TableType.Table, DataService.GetInstance("VeritasInfo"));
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
				
				TableSchema.TableColumn colvarDisplayName = new TableSchema.TableColumn(schema);
				colvarDisplayName.ColumnName = "DisplayName";
				colvarDisplayName.DataType = DbType.AnsiString;
				colvarDisplayName.MaxLength = 200;
				colvarDisplayName.AutoIncrement = false;
				colvarDisplayName.IsNullable = true;
				colvarDisplayName.IsPrimaryKey = false;
				colvarDisplayName.IsForeignKey = false;
				colvarDisplayName.IsReadOnly = false;
				colvarDisplayName.DefaultSetting = @"";
				colvarDisplayName.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDisplayName);
				
				TableSchema.TableColumn colvarDocumentLink = new TableSchema.TableColumn(schema);
				colvarDocumentLink.ColumnName = "DocumentLink";
				colvarDocumentLink.DataType = DbType.AnsiString;
				colvarDocumentLink.MaxLength = 300;
				colvarDocumentLink.AutoIncrement = false;
				colvarDocumentLink.IsNullable = true;
				colvarDocumentLink.IsPrimaryKey = false;
				colvarDocumentLink.IsForeignKey = false;
				colvarDocumentLink.IsReadOnly = false;
				colvarDocumentLink.DefaultSetting = @"";
				colvarDocumentLink.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDocumentLink);
				
				TableSchema.TableColumn colvarShortenedLink = new TableSchema.TableColumn(schema);
				colvarShortenedLink.ColumnName = "ShortenedLink";
				colvarShortenedLink.DataType = DbType.AnsiString;
				colvarShortenedLink.MaxLength = 50;
				colvarShortenedLink.AutoIncrement = false;
				colvarShortenedLink.IsNullable = true;
				colvarShortenedLink.IsPrimaryKey = false;
				colvarShortenedLink.IsForeignKey = false;
				colvarShortenedLink.IsReadOnly = false;
				colvarShortenedLink.DefaultSetting = @"";
				colvarShortenedLink.ForeignKeyTableName = "";
				schema.Columns.Add(colvarShortenedLink);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["VeritasInfo"].AddSchema("mkt_Literature",schema);
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
		  
		[XmlAttribute("DisplayName")]
		[Bindable(true)]
		public string DisplayName 
		{
			get { return GetColumnValue<string>(Columns.DisplayName); }
			set { SetColumnValue(Columns.DisplayName, value); }
		}
		  
		[XmlAttribute("DocumentLink")]
		[Bindable(true)]
		public string DocumentLink 
		{
			get { return GetColumnValue<string>(Columns.DocumentLink); }
			set { SetColumnValue(Columns.DocumentLink, value); }
		}
		  
		[XmlAttribute("ShortenedLink")]
		[Bindable(true)]
		public string ShortenedLink 
		{
			get { return GetColumnValue<string>(Columns.ShortenedLink); }
			set { SetColumnValue(Columns.ShortenedLink, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varDisplayName,string varDocumentLink,string varShortenedLink)
		{
			Literature item = new Literature();
			
			item.DisplayName = varDisplayName;
			
			item.DocumentLink = varDocumentLink;
			
			item.ShortenedLink = varShortenedLink;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varId,string varDisplayName,string varDocumentLink,string varShortenedLink)
		{
			Literature item = new Literature();
			
				item.Id = varId;
			
				item.DisplayName = varDisplayName;
			
				item.DocumentLink = varDocumentLink;
			
				item.ShortenedLink = varShortenedLink;
			
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
        
        
        
        public static TableSchema.TableColumn DisplayNameColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn DocumentLinkColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn ShortenedLinkColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string Id = @"ID";
			 public static string DisplayName = @"DisplayName";
			 public static string DocumentLink = @"DocumentLink";
			 public static string ShortenedLink = @"ShortenedLink";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
