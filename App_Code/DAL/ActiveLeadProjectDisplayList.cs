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
namespace DAL{
    /// <summary>
    /// Strongly-typed collection for the ActiveLeadProjectDisplayList class.
    /// </summary>
    [Serializable]
    public partial class ActiveLeadProjectDisplayListCollection : ReadOnlyList<ActiveLeadProjectDisplayList, ActiveLeadProjectDisplayListCollection>
    {        
        public ActiveLeadProjectDisplayListCollection() {}
    }
    /// <summary>
    /// This is  Read-only wrapper class for the ActiveLeadProjectDisplayList view.
    /// </summary>
    [Serializable]
    public partial class ActiveLeadProjectDisplayList : ReadOnlyRecord<ActiveLeadProjectDisplayList>, IReadOnlyRecord
    {
    
	    #region Default Settings
	    protected static void SetSQLProps() 
	    {
		    GetTableSchema();
	    }
	    #endregion
        #region Schema Accessor
	    public static TableSchema.Table Schema
        {
            get
            {
                if (BaseSchema == null)
                {
                    SetSQLProps();
                }
                return BaseSchema;
            }
        }
    	
        private static void GetTableSchema() 
        {
            if(!IsSchemaInitialized)
            {
                //Schema declaration
                TableSchema.Table schema = new TableSchema.Table("ActiveLeadProjectDisplayList", TableType.View, DataService.GetInstance("VeritasInfo"));
                schema.Columns = new TableSchema.TableColumnCollection();
                schema.SchemaName = @"dbo";
                //columns
                
                TableSchema.TableColumn colvarProject = new TableSchema.TableColumn(schema);
                colvarProject.ColumnName = "Project";
                colvarProject.DataType = DbType.AnsiString;
                colvarProject.MaxLength = 203;
                colvarProject.AutoIncrement = false;
                colvarProject.IsNullable = false;
                colvarProject.IsPrimaryKey = false;
                colvarProject.IsForeignKey = false;
                colvarProject.IsReadOnly = false;
                
                schema.Columns.Add(colvarProject);
                
                
                BaseSchema = schema;
                //add this schema to the provider
                //so we can query it later
                DataService.Providers["VeritasInfo"].AddSchema("ActiveLeadProjectDisplayList",schema);
            }
        }
        #endregion
        
        #region Query Accessor
	    public static Query CreateQuery()
	    {
		    return new Query(Schema);
	    }
	    #endregion
	    
	    #region .ctors
	    public ActiveLeadProjectDisplayList()
	    {
            SetSQLProps();
            SetDefaults();
            MarkNew();
        }
        public ActiveLeadProjectDisplayList(bool useDatabaseDefaults)
	    {
		    SetSQLProps();
		    if(useDatabaseDefaults)
		    {
				ForceDefaults();
			}
			MarkNew();
	    }
	    
	    public ActiveLeadProjectDisplayList(object keyID)
	    {
		    SetSQLProps();
		    LoadByKey(keyID);
	    }
    	 
	    public ActiveLeadProjectDisplayList(string columnName, object columnValue)
        {
            SetSQLProps();
            LoadByParam(columnName,columnValue);
        }
        
	    #endregion
	    
	    #region Props
	    
          
        [XmlAttribute("Project")]
        [Bindable(true)]
        public string Project 
	    {
		    get
		    {
			    return GetColumnValue<string>("Project");
		    }
            set 
		    {
			    SetColumnValue("Project", value);
            }
        }
	    
	    #endregion
    
	    #region Columns Struct
	    public struct Columns
	    {
		    
		    
            public static string Project = @"Project";
            
	    }
	    #endregion
	    
	    
	    #region IAbstractRecord Members
        public new CT GetColumnValue<CT>(string columnName) {
            return base.GetColumnValue<CT>(columnName);
        }
        public object GetColumnValue(string columnName) {
            return base.GetColumnValue<object>(columnName);
        }
        #endregion
	    
    }
}
