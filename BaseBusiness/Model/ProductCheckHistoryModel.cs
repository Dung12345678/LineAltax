
using System;
namespace BMS.Model
{
	public class ProductCheckHistoryModel : BaseModel
	{
		private int iD;
		private string qRCode;
		private int productID;
		private string orderCode;
		private string productCode;
		private DateTime? dateLR;
		private string createdBy;
		private DateTime? createdDate;
		private string updatedBy;
		private DateTime? updatedDate;
		private string salesOrder;
		public int ID
		{
			get { return iD; }
			set { iD = value; }
		}
	
		public string QRCode
		{
			get { return qRCode; }
			set { qRCode = value; }
		}
	
		public int ProductID
		{
			get { return productID; }
			set { productID = value; }
		}
	
		public string OrderCode
		{
			get { return orderCode; }
			set { orderCode = value; }
		}
	
		public string ProductCode
		{
			get { return productCode; }
			set { productCode = value; }
		}
	
		public DateTime? DateLR
		{
			get { return dateLR; }
			set { dateLR = value; }
		}
	
		public string CreatedBy
		{
			get { return createdBy; }
			set { createdBy = value; }
		}
	
		public DateTime? CreatedDate
		{
			get { return createdDate; }
			set { createdDate = value; }
		}
	
		public string UpdatedBy
		{
			get { return updatedBy; }
			set { updatedBy = value; }
		}
	
		public DateTime? UpdatedDate
		{
			get { return updatedDate; }
			set { updatedDate = value; }
		}
	
		public string SalesOrder
		{
			get { return salesOrder; }
			set { salesOrder = value; }
		}
	
	}
}
	