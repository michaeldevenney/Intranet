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
	/// Strongly-typed collection for the Shipping class.
	/// </summary>
    [Serializable]
	public partial class ShippingCollection : ActiveList<Shipping, ShippingCollection>
	{	   
		public ShippingCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>ShippingCollection</returns>
		public ShippingCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                Shipping o = this[i];
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
	/// This is an ActiveRecord class which wraps the S_Shipping table.
	/// </summary>
	[Serializable]
	public partial class Shipping : ActiveRecord<Shipping>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public Shipping()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public Shipping(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public Shipping(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public Shipping(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("S_Shipping", TableType.Table, DataService.GetInstance("VeritasInfo"));
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
				
				TableSchema.TableColumn colvarBolid = new TableSchema.TableColumn(schema);
				colvarBolid.ColumnName = "BOLID";
				colvarBolid.DataType = DbType.Int32;
				colvarBolid.MaxLength = 0;
				colvarBolid.AutoIncrement = false;
				colvarBolid.IsNullable = true;
				colvarBolid.IsPrimaryKey = false;
				colvarBolid.IsForeignKey = false;
				colvarBolid.IsReadOnly = false;
				colvarBolid.DefaultSetting = @"";
				colvarBolid.ForeignKeyTableName = "";
				schema.Columns.Add(colvarBolid);
				
				TableSchema.TableColumn colvarProjectID = new TableSchema.TableColumn(schema);
				colvarProjectID.ColumnName = "ProjectID";
				colvarProjectID.DataType = DbType.Int32;
				colvarProjectID.MaxLength = 0;
				colvarProjectID.AutoIncrement = false;
				colvarProjectID.IsNullable = false;
				colvarProjectID.IsPrimaryKey = false;
				colvarProjectID.IsForeignKey = false;
				colvarProjectID.IsReadOnly = false;
				colvarProjectID.DefaultSetting = @"";
				colvarProjectID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarProjectID);
				
				TableSchema.TableColumn colvarShipFrom = new TableSchema.TableColumn(schema);
				colvarShipFrom.ColumnName = "ShipFrom";
				colvarShipFrom.DataType = DbType.Int32;
				colvarShipFrom.MaxLength = 0;
				colvarShipFrom.AutoIncrement = false;
				colvarShipFrom.IsNullable = true;
				colvarShipFrom.IsPrimaryKey = false;
				colvarShipFrom.IsForeignKey = false;
				colvarShipFrom.IsReadOnly = false;
				colvarShipFrom.DefaultSetting = @"";
				colvarShipFrom.ForeignKeyTableName = "";
				schema.Columns.Add(colvarShipFrom);
				
				TableSchema.TableColumn colvarBOLNumber = new TableSchema.TableColumn(schema);
				colvarBOLNumber.ColumnName = "BOLNumber";
				colvarBOLNumber.DataType = DbType.AnsiString;
				colvarBOLNumber.MaxLength = 25;
				colvarBOLNumber.AutoIncrement = false;
				colvarBOLNumber.IsNullable = true;
				colvarBOLNumber.IsPrimaryKey = false;
				colvarBOLNumber.IsForeignKey = false;
				colvarBOLNumber.IsReadOnly = false;
				colvarBOLNumber.DefaultSetting = @"";
				colvarBOLNumber.ForeignKeyTableName = "";
				schema.Columns.Add(colvarBOLNumber);
				
				TableSchema.TableColumn colvarShipTo = new TableSchema.TableColumn(schema);
				colvarShipTo.ColumnName = "ShipTo";
				colvarShipTo.DataType = DbType.Int32;
				colvarShipTo.MaxLength = 0;
				colvarShipTo.AutoIncrement = false;
				colvarShipTo.IsNullable = true;
				colvarShipTo.IsPrimaryKey = false;
				colvarShipTo.IsForeignKey = false;
				colvarShipTo.IsReadOnly = false;
				colvarShipTo.DefaultSetting = @"";
				colvarShipTo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarShipTo);
				
				TableSchema.TableColumn colvarShippingDate = new TableSchema.TableColumn(schema);
				colvarShippingDate.ColumnName = "ShippingDate";
				colvarShippingDate.DataType = DbType.DateTime;
				colvarShippingDate.MaxLength = 0;
				colvarShippingDate.AutoIncrement = false;
				colvarShippingDate.IsNullable = true;
				colvarShippingDate.IsPrimaryKey = false;
				colvarShippingDate.IsForeignKey = false;
				colvarShippingDate.IsReadOnly = false;
				colvarShippingDate.DefaultSetting = @"";
				colvarShippingDate.ForeignKeyTableName = "";
				schema.Columns.Add(colvarShippingDate);
				
				TableSchema.TableColumn colvarCarrier = new TableSchema.TableColumn(schema);
				colvarCarrier.ColumnName = "Carrier";
				colvarCarrier.DataType = DbType.Int32;
				colvarCarrier.MaxLength = 0;
				colvarCarrier.AutoIncrement = false;
				colvarCarrier.IsNullable = true;
				colvarCarrier.IsPrimaryKey = false;
				colvarCarrier.IsForeignKey = false;
				colvarCarrier.IsReadOnly = false;
				colvarCarrier.DefaultSetting = @"";
				colvarCarrier.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCarrier);
				
				TableSchema.TableColumn colvarContainerNumber = new TableSchema.TableColumn(schema);
				colvarContainerNumber.ColumnName = "ContainerNumber";
				colvarContainerNumber.DataType = DbType.AnsiString;
				colvarContainerNumber.MaxLength = 25;
				colvarContainerNumber.AutoIncrement = false;
				colvarContainerNumber.IsNullable = true;
				colvarContainerNumber.IsPrimaryKey = false;
				colvarContainerNumber.IsForeignKey = false;
				colvarContainerNumber.IsReadOnly = false;
				colvarContainerNumber.DefaultSetting = @"";
				colvarContainerNumber.ForeignKeyTableName = "";
				schema.Columns.Add(colvarContainerNumber);
				
				TableSchema.TableColumn colvarBookingNumber = new TableSchema.TableColumn(schema);
				colvarBookingNumber.ColumnName = "BookingNumber";
				colvarBookingNumber.DataType = DbType.AnsiString;
				colvarBookingNumber.MaxLength = 25;
				colvarBookingNumber.AutoIncrement = false;
				colvarBookingNumber.IsNullable = true;
				colvarBookingNumber.IsPrimaryKey = false;
				colvarBookingNumber.IsForeignKey = false;
				colvarBookingNumber.IsReadOnly = false;
				colvarBookingNumber.DefaultSetting = @"";
				colvarBookingNumber.ForeignKeyTableName = "";
				schema.Columns.Add(colvarBookingNumber);
				
				TableSchema.TableColumn colvarCabNumber = new TableSchema.TableColumn(schema);
				colvarCabNumber.ColumnName = "CabNumber";
				colvarCabNumber.DataType = DbType.AnsiString;
				colvarCabNumber.MaxLength = 25;
				colvarCabNumber.AutoIncrement = false;
				colvarCabNumber.IsNullable = true;
				colvarCabNumber.IsPrimaryKey = false;
				colvarCabNumber.IsForeignKey = false;
				colvarCabNumber.IsReadOnly = false;
				colvarCabNumber.DefaultSetting = @"";
				colvarCabNumber.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCabNumber);
				
				TableSchema.TableColumn colvarSealNumber = new TableSchema.TableColumn(schema);
				colvarSealNumber.ColumnName = "SealNumber";
				colvarSealNumber.DataType = DbType.AnsiString;
				colvarSealNumber.MaxLength = 25;
				colvarSealNumber.AutoIncrement = false;
				colvarSealNumber.IsNullable = true;
				colvarSealNumber.IsPrimaryKey = false;
				colvarSealNumber.IsForeignKey = false;
				colvarSealNumber.IsReadOnly = false;
				colvarSealNumber.DefaultSetting = @"";
				colvarSealNumber.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSealNumber);
				
				TableSchema.TableColumn colvarDriverCellNumber = new TableSchema.TableColumn(schema);
				colvarDriverCellNumber.ColumnName = "DriverCellNumber";
				colvarDriverCellNumber.DataType = DbType.AnsiString;
				colvarDriverCellNumber.MaxLength = 25;
				colvarDriverCellNumber.AutoIncrement = false;
				colvarDriverCellNumber.IsNullable = true;
				colvarDriverCellNumber.IsPrimaryKey = false;
				colvarDriverCellNumber.IsForeignKey = false;
				colvarDriverCellNumber.IsReadOnly = false;
				colvarDriverCellNumber.DefaultSetting = @"";
				colvarDriverCellNumber.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDriverCellNumber);
				
				TableSchema.TableColumn colvarContactName = new TableSchema.TableColumn(schema);
				colvarContactName.ColumnName = "ContactName";
				colvarContactName.DataType = DbType.AnsiString;
				colvarContactName.MaxLength = 25;
				colvarContactName.AutoIncrement = false;
				colvarContactName.IsNullable = true;
				colvarContactName.IsPrimaryKey = false;
				colvarContactName.IsForeignKey = false;
				colvarContactName.IsReadOnly = false;
				colvarContactName.DefaultSetting = @"";
				colvarContactName.ForeignKeyTableName = "";
				schema.Columns.Add(colvarContactName);
				
				TableSchema.TableColumn colvarContactCell = new TableSchema.TableColumn(schema);
				colvarContactCell.ColumnName = "ContactCell";
				colvarContactCell.DataType = DbType.AnsiString;
				colvarContactCell.MaxLength = 15;
				colvarContactCell.AutoIncrement = false;
				colvarContactCell.IsNullable = true;
				colvarContactCell.IsPrimaryKey = false;
				colvarContactCell.IsForeignKey = false;
				colvarContactCell.IsReadOnly = false;
				colvarContactCell.DefaultSetting = @"";
				colvarContactCell.ForeignKeyTableName = "";
				schema.Columns.Add(colvarContactCell);
				
				TableSchema.TableColumn colvarFreightChargePre = new TableSchema.TableColumn(schema);
				colvarFreightChargePre.ColumnName = "FreightChargePre";
				colvarFreightChargePre.DataType = DbType.Boolean;
				colvarFreightChargePre.MaxLength = 0;
				colvarFreightChargePre.AutoIncrement = false;
				colvarFreightChargePre.IsNullable = true;
				colvarFreightChargePre.IsPrimaryKey = false;
				colvarFreightChargePre.IsForeignKey = false;
				colvarFreightChargePre.IsReadOnly = false;
				colvarFreightChargePre.DefaultSetting = @"";
				colvarFreightChargePre.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFreightChargePre);
				
				TableSchema.TableColumn colvarFreightChargeCol = new TableSchema.TableColumn(schema);
				colvarFreightChargeCol.ColumnName = "FreightChargeCol";
				colvarFreightChargeCol.DataType = DbType.Boolean;
				colvarFreightChargeCol.MaxLength = 0;
				colvarFreightChargeCol.AutoIncrement = false;
				colvarFreightChargeCol.IsNullable = true;
				colvarFreightChargeCol.IsPrimaryKey = false;
				colvarFreightChargeCol.IsForeignKey = false;
				colvarFreightChargeCol.IsReadOnly = false;
				colvarFreightChargeCol.DefaultSetting = @"";
				colvarFreightChargeCol.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFreightChargeCol);
				
				TableSchema.TableColumn colvarFreightCharge3rd = new TableSchema.TableColumn(schema);
				colvarFreightCharge3rd.ColumnName = "FreightCharge3rd";
				colvarFreightCharge3rd.DataType = DbType.Boolean;
				colvarFreightCharge3rd.MaxLength = 0;
				colvarFreightCharge3rd.AutoIncrement = false;
				colvarFreightCharge3rd.IsNullable = true;
				colvarFreightCharge3rd.IsPrimaryKey = false;
				colvarFreightCharge3rd.IsForeignKey = false;
				colvarFreightCharge3rd.IsReadOnly = false;
				colvarFreightCharge3rd.DefaultSetting = @"";
				colvarFreightCharge3rd.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFreightCharge3rd);
				
				TableSchema.TableColumn colvarMasterBOL = new TableSchema.TableColumn(schema);
				colvarMasterBOL.ColumnName = "MasterBOL";
				colvarMasterBOL.DataType = DbType.Boolean;
				colvarMasterBOL.MaxLength = 0;
				colvarMasterBOL.AutoIncrement = false;
				colvarMasterBOL.IsNullable = true;
				colvarMasterBOL.IsPrimaryKey = false;
				colvarMasterBOL.IsForeignKey = false;
				colvarMasterBOL.IsReadOnly = false;
				colvarMasterBOL.DefaultSetting = @"";
				colvarMasterBOL.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMasterBOL);
				
				TableSchema.TableColumn colvarValueAmt = new TableSchema.TableColumn(schema);
				colvarValueAmt.ColumnName = "ValueAmt";
				colvarValueAmt.DataType = DbType.Currency;
				colvarValueAmt.MaxLength = 0;
				colvarValueAmt.AutoIncrement = false;
				colvarValueAmt.IsNullable = true;
				colvarValueAmt.IsPrimaryKey = false;
				colvarValueAmt.IsForeignKey = false;
				colvarValueAmt.IsReadOnly = false;
				colvarValueAmt.DefaultSetting = @"";
				colvarValueAmt.ForeignKeyTableName = "";
				schema.Columns.Add(colvarValueAmt);
				
				TableSchema.TableColumn colvarValueUnit = new TableSchema.TableColumn(schema);
				colvarValueUnit.ColumnName = "ValueUnit";
				colvarValueUnit.DataType = DbType.AnsiString;
				colvarValueUnit.MaxLength = 25;
				colvarValueUnit.AutoIncrement = false;
				colvarValueUnit.IsNullable = true;
				colvarValueUnit.IsPrimaryKey = false;
				colvarValueUnit.IsForeignKey = false;
				colvarValueUnit.IsReadOnly = false;
				colvarValueUnit.DefaultSetting = @"";
				colvarValueUnit.ForeignKeyTableName = "";
				schema.Columns.Add(colvarValueUnit);
				
				TableSchema.TableColumn colvarCODAmount = new TableSchema.TableColumn(schema);
				colvarCODAmount.ColumnName = "CODAmount";
				colvarCODAmount.DataType = DbType.Currency;
				colvarCODAmount.MaxLength = 0;
				colvarCODAmount.AutoIncrement = false;
				colvarCODAmount.IsNullable = true;
				colvarCODAmount.IsPrimaryKey = false;
				colvarCODAmount.IsForeignKey = false;
				colvarCODAmount.IsReadOnly = false;
				colvarCODAmount.DefaultSetting = @"";
				colvarCODAmount.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCODAmount);
				
				TableSchema.TableColumn colvarFeeTermsColl = new TableSchema.TableColumn(schema);
				colvarFeeTermsColl.ColumnName = "FeeTermsColl";
				colvarFeeTermsColl.DataType = DbType.Boolean;
				colvarFeeTermsColl.MaxLength = 0;
				colvarFeeTermsColl.AutoIncrement = false;
				colvarFeeTermsColl.IsNullable = true;
				colvarFeeTermsColl.IsPrimaryKey = false;
				colvarFeeTermsColl.IsForeignKey = false;
				colvarFeeTermsColl.IsReadOnly = false;
				colvarFeeTermsColl.DefaultSetting = @"";
				colvarFeeTermsColl.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFeeTermsColl);
				
				TableSchema.TableColumn colvarFeeTermsPre = new TableSchema.TableColumn(schema);
				colvarFeeTermsPre.ColumnName = "FeeTermsPre";
				colvarFeeTermsPre.DataType = DbType.Boolean;
				colvarFeeTermsPre.MaxLength = 0;
				colvarFeeTermsPre.AutoIncrement = false;
				colvarFeeTermsPre.IsNullable = true;
				colvarFeeTermsPre.IsPrimaryKey = false;
				colvarFeeTermsPre.IsForeignKey = false;
				colvarFeeTermsPre.IsReadOnly = false;
				colvarFeeTermsPre.DefaultSetting = @"";
				colvarFeeTermsPre.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFeeTermsPre);
				
				TableSchema.TableColumn colvarFeeTermsCust = new TableSchema.TableColumn(schema);
				colvarFeeTermsCust.ColumnName = "FeeTermsCust";
				colvarFeeTermsCust.DataType = DbType.Boolean;
				colvarFeeTermsCust.MaxLength = 0;
				colvarFeeTermsCust.AutoIncrement = false;
				colvarFeeTermsCust.IsNullable = true;
				colvarFeeTermsCust.IsPrimaryKey = false;
				colvarFeeTermsCust.IsForeignKey = false;
				colvarFeeTermsCust.IsReadOnly = false;
				colvarFeeTermsCust.DefaultSetting = @"";
				colvarFeeTermsCust.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFeeTermsCust);
				
				TableSchema.TableColumn colvarEnteredBy = new TableSchema.TableColumn(schema);
				colvarEnteredBy.ColumnName = "EnteredBy";
				colvarEnteredBy.DataType = DbType.AnsiString;
				colvarEnteredBy.MaxLength = 50;
				colvarEnteredBy.AutoIncrement = false;
				colvarEnteredBy.IsNullable = true;
				colvarEnteredBy.IsPrimaryKey = false;
				colvarEnteredBy.IsForeignKey = false;
				colvarEnteredBy.IsReadOnly = false;
				colvarEnteredBy.DefaultSetting = @"";
				colvarEnteredBy.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEnteredBy);
				
				TableSchema.TableColumn colvarEnteredDate = new TableSchema.TableColumn(schema);
				colvarEnteredDate.ColumnName = "EnteredDate";
				colvarEnteredDate.DataType = DbType.DateTime;
				colvarEnteredDate.MaxLength = 0;
				colvarEnteredDate.AutoIncrement = false;
				colvarEnteredDate.IsNullable = true;
				colvarEnteredDate.IsPrimaryKey = false;
				colvarEnteredDate.IsForeignKey = false;
				colvarEnteredDate.IsReadOnly = false;
				colvarEnteredDate.DefaultSetting = @"";
				colvarEnteredDate.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEnteredDate);
				
				TableSchema.TableColumn colvarProcessed = new TableSchema.TableColumn(schema);
				colvarProcessed.ColumnName = "Processed";
				colvarProcessed.DataType = DbType.Boolean;
				colvarProcessed.MaxLength = 0;
				colvarProcessed.AutoIncrement = false;
				colvarProcessed.IsNullable = true;
				colvarProcessed.IsPrimaryKey = false;
				colvarProcessed.IsForeignKey = false;
				colvarProcessed.IsReadOnly = false;
				colvarProcessed.DefaultSetting = @"";
				colvarProcessed.ForeignKeyTableName = "";
				schema.Columns.Add(colvarProcessed);
				
				TableSchema.TableColumn colvarAdditionalEmailAddress = new TableSchema.TableColumn(schema);
				colvarAdditionalEmailAddress.ColumnName = "AdditionalEmailAddress";
				colvarAdditionalEmailAddress.DataType = DbType.AnsiString;
				colvarAdditionalEmailAddress.MaxLength = 50;
				colvarAdditionalEmailAddress.AutoIncrement = false;
				colvarAdditionalEmailAddress.IsNullable = true;
				colvarAdditionalEmailAddress.IsPrimaryKey = false;
				colvarAdditionalEmailAddress.IsForeignKey = false;
				colvarAdditionalEmailAddress.IsReadOnly = false;
				colvarAdditionalEmailAddress.DefaultSetting = @"";
				colvarAdditionalEmailAddress.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAdditionalEmailAddress);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["VeritasInfo"].AddSchema("S_Shipping",schema);
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
		  
		[XmlAttribute("Bolid")]
		[Bindable(true)]
		public int? Bolid 
		{
			get { return GetColumnValue<int?>(Columns.Bolid); }
			set { SetColumnValue(Columns.Bolid, value); }
		}
		  
		[XmlAttribute("ProjectID")]
		[Bindable(true)]
		public int ProjectID 
		{
			get { return GetColumnValue<int>(Columns.ProjectID); }
			set { SetColumnValue(Columns.ProjectID, value); }
		}
		  
		[XmlAttribute("ShipFrom")]
		[Bindable(true)]
		public int? ShipFrom 
		{
			get { return GetColumnValue<int?>(Columns.ShipFrom); }
			set { SetColumnValue(Columns.ShipFrom, value); }
		}
		  
		[XmlAttribute("BOLNumber")]
		[Bindable(true)]
		public string BOLNumber 
		{
			get { return GetColumnValue<string>(Columns.BOLNumber); }
			set { SetColumnValue(Columns.BOLNumber, value); }
		}
		  
		[XmlAttribute("ShipTo")]
		[Bindable(true)]
		public int? ShipTo 
		{
			get { return GetColumnValue<int?>(Columns.ShipTo); }
			set { SetColumnValue(Columns.ShipTo, value); }
		}
		  
		[XmlAttribute("ShippingDate")]
		[Bindable(true)]
		public DateTime? ShippingDate 
		{
			get { return GetColumnValue<DateTime?>(Columns.ShippingDate); }
			set { SetColumnValue(Columns.ShippingDate, value); }
		}
		  
		[XmlAttribute("Carrier")]
		[Bindable(true)]
		public int? Carrier 
		{
			get { return GetColumnValue<int?>(Columns.Carrier); }
			set { SetColumnValue(Columns.Carrier, value); }
		}
		  
		[XmlAttribute("ContainerNumber")]
		[Bindable(true)]
		public string ContainerNumber 
		{
			get { return GetColumnValue<string>(Columns.ContainerNumber); }
			set { SetColumnValue(Columns.ContainerNumber, value); }
		}
		  
		[XmlAttribute("BookingNumber")]
		[Bindable(true)]
		public string BookingNumber 
		{
			get { return GetColumnValue<string>(Columns.BookingNumber); }
			set { SetColumnValue(Columns.BookingNumber, value); }
		}
		  
		[XmlAttribute("CabNumber")]
		[Bindable(true)]
		public string CabNumber 
		{
			get { return GetColumnValue<string>(Columns.CabNumber); }
			set { SetColumnValue(Columns.CabNumber, value); }
		}
		  
		[XmlAttribute("SealNumber")]
		[Bindable(true)]
		public string SealNumber 
		{
			get { return GetColumnValue<string>(Columns.SealNumber); }
			set { SetColumnValue(Columns.SealNumber, value); }
		}
		  
		[XmlAttribute("DriverCellNumber")]
		[Bindable(true)]
		public string DriverCellNumber 
		{
			get { return GetColumnValue<string>(Columns.DriverCellNumber); }
			set { SetColumnValue(Columns.DriverCellNumber, value); }
		}
		  
		[XmlAttribute("ContactName")]
		[Bindable(true)]
		public string ContactName 
		{
			get { return GetColumnValue<string>(Columns.ContactName); }
			set { SetColumnValue(Columns.ContactName, value); }
		}
		  
		[XmlAttribute("ContactCell")]
		[Bindable(true)]
		public string ContactCell 
		{
			get { return GetColumnValue<string>(Columns.ContactCell); }
			set { SetColumnValue(Columns.ContactCell, value); }
		}
		  
		[XmlAttribute("FreightChargePre")]
		[Bindable(true)]
		public bool? FreightChargePre 
		{
			get { return GetColumnValue<bool?>(Columns.FreightChargePre); }
			set { SetColumnValue(Columns.FreightChargePre, value); }
		}
		  
		[XmlAttribute("FreightChargeCol")]
		[Bindable(true)]
		public bool? FreightChargeCol 
		{
			get { return GetColumnValue<bool?>(Columns.FreightChargeCol); }
			set { SetColumnValue(Columns.FreightChargeCol, value); }
		}
		  
		[XmlAttribute("FreightCharge3rd")]
		[Bindable(true)]
		public bool? FreightCharge3rd 
		{
			get { return GetColumnValue<bool?>(Columns.FreightCharge3rd); }
			set { SetColumnValue(Columns.FreightCharge3rd, value); }
		}
		  
		[XmlAttribute("MasterBOL")]
		[Bindable(true)]
		public bool? MasterBOL 
		{
			get { return GetColumnValue<bool?>(Columns.MasterBOL); }
			set { SetColumnValue(Columns.MasterBOL, value); }
		}
		  
		[XmlAttribute("ValueAmt")]
		[Bindable(true)]
		public decimal? ValueAmt 
		{
			get { return GetColumnValue<decimal?>(Columns.ValueAmt); }
			set { SetColumnValue(Columns.ValueAmt, value); }
		}
		  
		[XmlAttribute("ValueUnit")]
		[Bindable(true)]
		public string ValueUnit 
		{
			get { return GetColumnValue<string>(Columns.ValueUnit); }
			set { SetColumnValue(Columns.ValueUnit, value); }
		}
		  
		[XmlAttribute("CODAmount")]
		[Bindable(true)]
		public decimal? CODAmount 
		{
			get { return GetColumnValue<decimal?>(Columns.CODAmount); }
			set { SetColumnValue(Columns.CODAmount, value); }
		}
		  
		[XmlAttribute("FeeTermsColl")]
		[Bindable(true)]
		public bool? FeeTermsColl 
		{
			get { return GetColumnValue<bool?>(Columns.FeeTermsColl); }
			set { SetColumnValue(Columns.FeeTermsColl, value); }
		}
		  
		[XmlAttribute("FeeTermsPre")]
		[Bindable(true)]
		public bool? FeeTermsPre 
		{
			get { return GetColumnValue<bool?>(Columns.FeeTermsPre); }
			set { SetColumnValue(Columns.FeeTermsPre, value); }
		}
		  
		[XmlAttribute("FeeTermsCust")]
		[Bindable(true)]
		public bool? FeeTermsCust 
		{
			get { return GetColumnValue<bool?>(Columns.FeeTermsCust); }
			set { SetColumnValue(Columns.FeeTermsCust, value); }
		}
		  
		[XmlAttribute("EnteredBy")]
		[Bindable(true)]
		public string EnteredBy 
		{
			get { return GetColumnValue<string>(Columns.EnteredBy); }
			set { SetColumnValue(Columns.EnteredBy, value); }
		}
		  
		[XmlAttribute("EnteredDate")]
		[Bindable(true)]
		public DateTime? EnteredDate 
		{
			get { return GetColumnValue<DateTime?>(Columns.EnteredDate); }
			set { SetColumnValue(Columns.EnteredDate, value); }
		}
		  
		[XmlAttribute("Processed")]
		[Bindable(true)]
		public bool? Processed 
		{
			get { return GetColumnValue<bool?>(Columns.Processed); }
			set { SetColumnValue(Columns.Processed, value); }
		}
		  
		[XmlAttribute("AdditionalEmailAddress")]
		[Bindable(true)]
		public string AdditionalEmailAddress 
		{
			get { return GetColumnValue<string>(Columns.AdditionalEmailAddress); }
			set { SetColumnValue(Columns.AdditionalEmailAddress, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int? varBolid,int varProjectID,int? varShipFrom,string varBOLNumber,int? varShipTo,DateTime? varShippingDate,int? varCarrier,string varContainerNumber,string varBookingNumber,string varCabNumber,string varSealNumber,string varDriverCellNumber,string varContactName,string varContactCell,bool? varFreightChargePre,bool? varFreightChargeCol,bool? varFreightCharge3rd,bool? varMasterBOL,decimal? varValueAmt,string varValueUnit,decimal? varCODAmount,bool? varFeeTermsColl,bool? varFeeTermsPre,bool? varFeeTermsCust,string varEnteredBy,DateTime? varEnteredDate,bool? varProcessed,string varAdditionalEmailAddress)
		{
			Shipping item = new Shipping();
			
			item.Bolid = varBolid;
			
			item.ProjectID = varProjectID;
			
			item.ShipFrom = varShipFrom;
			
			item.BOLNumber = varBOLNumber;
			
			item.ShipTo = varShipTo;
			
			item.ShippingDate = varShippingDate;
			
			item.Carrier = varCarrier;
			
			item.ContainerNumber = varContainerNumber;
			
			item.BookingNumber = varBookingNumber;
			
			item.CabNumber = varCabNumber;
			
			item.SealNumber = varSealNumber;
			
			item.DriverCellNumber = varDriverCellNumber;
			
			item.ContactName = varContactName;
			
			item.ContactCell = varContactCell;
			
			item.FreightChargePre = varFreightChargePre;
			
			item.FreightChargeCol = varFreightChargeCol;
			
			item.FreightCharge3rd = varFreightCharge3rd;
			
			item.MasterBOL = varMasterBOL;
			
			item.ValueAmt = varValueAmt;
			
			item.ValueUnit = varValueUnit;
			
			item.CODAmount = varCODAmount;
			
			item.FeeTermsColl = varFeeTermsColl;
			
			item.FeeTermsPre = varFeeTermsPre;
			
			item.FeeTermsCust = varFeeTermsCust;
			
			item.EnteredBy = varEnteredBy;
			
			item.EnteredDate = varEnteredDate;
			
			item.Processed = varProcessed;
			
			item.AdditionalEmailAddress = varAdditionalEmailAddress;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varId,int? varBolid,int varProjectID,int? varShipFrom,string varBOLNumber,int? varShipTo,DateTime? varShippingDate,int? varCarrier,string varContainerNumber,string varBookingNumber,string varCabNumber,string varSealNumber,string varDriverCellNumber,string varContactName,string varContactCell,bool? varFreightChargePre,bool? varFreightChargeCol,bool? varFreightCharge3rd,bool? varMasterBOL,decimal? varValueAmt,string varValueUnit,decimal? varCODAmount,bool? varFeeTermsColl,bool? varFeeTermsPre,bool? varFeeTermsCust,string varEnteredBy,DateTime? varEnteredDate,bool? varProcessed,string varAdditionalEmailAddress)
		{
			Shipping item = new Shipping();
			
				item.Id = varId;
			
				item.Bolid = varBolid;
			
				item.ProjectID = varProjectID;
			
				item.ShipFrom = varShipFrom;
			
				item.BOLNumber = varBOLNumber;
			
				item.ShipTo = varShipTo;
			
				item.ShippingDate = varShippingDate;
			
				item.Carrier = varCarrier;
			
				item.ContainerNumber = varContainerNumber;
			
				item.BookingNumber = varBookingNumber;
			
				item.CabNumber = varCabNumber;
			
				item.SealNumber = varSealNumber;
			
				item.DriverCellNumber = varDriverCellNumber;
			
				item.ContactName = varContactName;
			
				item.ContactCell = varContactCell;
			
				item.FreightChargePre = varFreightChargePre;
			
				item.FreightChargeCol = varFreightChargeCol;
			
				item.FreightCharge3rd = varFreightCharge3rd;
			
				item.MasterBOL = varMasterBOL;
			
				item.ValueAmt = varValueAmt;
			
				item.ValueUnit = varValueUnit;
			
				item.CODAmount = varCODAmount;
			
				item.FeeTermsColl = varFeeTermsColl;
			
				item.FeeTermsPre = varFeeTermsPre;
			
				item.FeeTermsCust = varFeeTermsCust;
			
				item.EnteredBy = varEnteredBy;
			
				item.EnteredDate = varEnteredDate;
			
				item.Processed = varProcessed;
			
				item.AdditionalEmailAddress = varAdditionalEmailAddress;
			
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
        
        
        
        public static TableSchema.TableColumn BolidColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn ProjectIDColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn ShipFromColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn BOLNumberColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn ShipToColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn ShippingDateColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn CarrierColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn ContainerNumberColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn BookingNumberColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn CabNumberColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        public static TableSchema.TableColumn SealNumberColumn
        {
            get { return Schema.Columns[11]; }
        }
        
        
        
        public static TableSchema.TableColumn DriverCellNumberColumn
        {
            get { return Schema.Columns[12]; }
        }
        
        
        
        public static TableSchema.TableColumn ContactNameColumn
        {
            get { return Schema.Columns[13]; }
        }
        
        
        
        public static TableSchema.TableColumn ContactCellColumn
        {
            get { return Schema.Columns[14]; }
        }
        
        
        
        public static TableSchema.TableColumn FreightChargePreColumn
        {
            get { return Schema.Columns[15]; }
        }
        
        
        
        public static TableSchema.TableColumn FreightChargeColColumn
        {
            get { return Schema.Columns[16]; }
        }
        
        
        
        public static TableSchema.TableColumn FreightCharge3rdColumn
        {
            get { return Schema.Columns[17]; }
        }
        
        
        
        public static TableSchema.TableColumn MasterBOLColumn
        {
            get { return Schema.Columns[18]; }
        }
        
        
        
        public static TableSchema.TableColumn ValueAmtColumn
        {
            get { return Schema.Columns[19]; }
        }
        
        
        
        public static TableSchema.TableColumn ValueUnitColumn
        {
            get { return Schema.Columns[20]; }
        }
        
        
        
        public static TableSchema.TableColumn CODAmountColumn
        {
            get { return Schema.Columns[21]; }
        }
        
        
        
        public static TableSchema.TableColumn FeeTermsCollColumn
        {
            get { return Schema.Columns[22]; }
        }
        
        
        
        public static TableSchema.TableColumn FeeTermsPreColumn
        {
            get { return Schema.Columns[23]; }
        }
        
        
        
        public static TableSchema.TableColumn FeeTermsCustColumn
        {
            get { return Schema.Columns[24]; }
        }
        
        
        
        public static TableSchema.TableColumn EnteredByColumn
        {
            get { return Schema.Columns[25]; }
        }
        
        
        
        public static TableSchema.TableColumn EnteredDateColumn
        {
            get { return Schema.Columns[26]; }
        }
        
        
        
        public static TableSchema.TableColumn ProcessedColumn
        {
            get { return Schema.Columns[27]; }
        }
        
        
        
        public static TableSchema.TableColumn AdditionalEmailAddressColumn
        {
            get { return Schema.Columns[28]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string Id = @"ID";
			 public static string Bolid = @"BOLID";
			 public static string ProjectID = @"ProjectID";
			 public static string ShipFrom = @"ShipFrom";
			 public static string BOLNumber = @"BOLNumber";
			 public static string ShipTo = @"ShipTo";
			 public static string ShippingDate = @"ShippingDate";
			 public static string Carrier = @"Carrier";
			 public static string ContainerNumber = @"ContainerNumber";
			 public static string BookingNumber = @"BookingNumber";
			 public static string CabNumber = @"CabNumber";
			 public static string SealNumber = @"SealNumber";
			 public static string DriverCellNumber = @"DriverCellNumber";
			 public static string ContactName = @"ContactName";
			 public static string ContactCell = @"ContactCell";
			 public static string FreightChargePre = @"FreightChargePre";
			 public static string FreightChargeCol = @"FreightChargeCol";
			 public static string FreightCharge3rd = @"FreightCharge3rd";
			 public static string MasterBOL = @"MasterBOL";
			 public static string ValueAmt = @"ValueAmt";
			 public static string ValueUnit = @"ValueUnit";
			 public static string CODAmount = @"CODAmount";
			 public static string FeeTermsColl = @"FeeTermsColl";
			 public static string FeeTermsPre = @"FeeTermsPre";
			 public static string FeeTermsCust = @"FeeTermsCust";
			 public static string EnteredBy = @"EnteredBy";
			 public static string EnteredDate = @"EnteredDate";
			 public static string Processed = @"Processed";
			 public static string AdditionalEmailAddress = @"AdditionalEmailAddress";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
