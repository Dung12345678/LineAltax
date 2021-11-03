
using System;
namespace BMS.Model
{
	public class ProductModel : BaseModel
	{
		private int iD;
		private int productGroupID;
		private string productGroupCode;
		private int productTypeID;
		private string maVanBan;
		private string productCode;
		private string productName;
		private string ratioCode;
		private string slowSpeedShaftDimesion;
		private string doDao;
		private string mURATA;
		private string motorCode;
		private string mauSon;
		private string giamTocTong;
		private string tiengOn;
		private string pinNumber;
		private string loaiMo;
		private decimal luongMo;
		private DateTime? mEDEDAY;
		private string coilCode;
		private string lucCheckGearMotor;
		private string lucCheckGear;
		private string huongHopCau;
		private string unitMotor;
		private string loai2TrucCoChan;
		private DateTime? productDate;
		private string createdBy;
		private DateTime? createdDate;
		private string updatedBy;
		private DateTime? updatedDate;
		private string maSungLuc;
		private decimal lucCheckGearMin;
		private decimal lucCheckGearMax;
		private decimal lucCheckGearMotorMin;
		private decimal lucCheckGearMotorMax;
		private int gunNumber;
		private int jobNumber;
		private int qtyOcBanGa;
		private int qtyOcBanThat;
		private string productTypeCode;
		private int buLongNumber;
		private int shootNumber;
		private int setForce;
		private string pinNumberIN;
		private decimal sizeSSSMin;
		private decimal sizeSSSMax;
		private decimal doDao1Min;
		private decimal doDao1Max;
		private decimal doDao2Min;
		private decimal doDao2Max;
		private decimal doDao3Min;
		private decimal doDao3Max;
		private decimal doDao4Min;
		private decimal doDao4Max;
		private decimal luongMo1Min;
		private decimal luongMo1Max;
		private decimal luongMo2Min;
		private decimal luongMo2Max;
		private decimal luongMo3Min;
		private decimal luongMo3Max;
		private decimal luongMo4Min;
		private decimal luongMo4Max;
		private decimal luongMo5Min;
		private decimal luongMo5Max;
		private decimal luongMo6Min;
		private decimal luongMo6Max;
		private decimal luongMo7Min;
		private decimal luongMo7Max;
		private decimal spaceCenterMin;
		private decimal spaceCenterMax;
		private decimal dienAp;
		private decimal tanSo;
		private decimal dongDienMin;
		private decimal dongDienMax;
		private decimal nhapLucMin;
		private decimal nhapLucMax;
		private decimal vongQuayMin;
		private decimal vongQuayMax;
		private decimal tiengOnMin;
		private decimal tiengOnMax;
		private decimal doRungFFTMin;
		private decimal doRungFFTMax;
		private decimal spaceCycloidDiskMin;
		private decimal spaceCycloidDiskMax;
		private decimal differenceMin;
		private decimal differenceMax;
		private decimal lucCheck3Min;
		private decimal lucCheck3Max;
		private decimal lucCheck4Min;
		private decimal lucCheck4Max;
		private decimal lucCheck5Max;
		private decimal lucCheck5Min;
		private string sSS;
		private string cARRIER;
		private string cYCLODISK;
		private string rGH;
		private string bEFORECOVER;
		private string aFTERCOVER;
		private string sSS2;
		private string cARRIER2;
		private string cYCLODISK2;
		private string rGH2;
		private string bEFORECOVER2;
		private string aFTERCOVER2;
		private string goal;
		private double engineWeightMin;
		private double engineWeightMax;
		private double engineWeight;
		public int ID
		{
			get { return iD; }
			set { iD = value; }
		}
	
		public int ProductGroupID
		{
			get { return productGroupID; }
			set { productGroupID = value; }
		}
	
		public string ProductGroupCode
		{
			get { return productGroupCode; }
			set { productGroupCode = value; }
		}
	
		public int ProductTypeID
		{
			get { return productTypeID; }
			set { productTypeID = value; }
		}
	
		public string MaVanBan
		{
			get { return maVanBan; }
			set { maVanBan = value; }
		}
	
		public string ProductCode
		{
			get { return productCode; }
			set { productCode = value; }
		}
	
		public string ProductName
		{
			get { return productName; }
			set { productName = value; }
		}
	
		public string RatioCode
		{
			get { return ratioCode; }
			set { ratioCode = value; }
		}
	
		public string SlowSpeedShaftDimesion
		{
			get { return slowSpeedShaftDimesion; }
			set { slowSpeedShaftDimesion = value; }
		}
	
		public string DoDao
		{
			get { return doDao; }
			set { doDao = value; }
		}
	
		public string MURATA
		{
			get { return mURATA; }
			set { mURATA = value; }
		}
	
		public string MotorCode
		{
			get { return motorCode; }
			set { motorCode = value; }
		}
	
		public string MauSon
		{
			get { return mauSon; }
			set { mauSon = value; }
		}
	
		public string GiamTocTong
		{
			get { return giamTocTong; }
			set { giamTocTong = value; }
		}
	
		public string TiengOn
		{
			get { return tiengOn; }
			set { tiengOn = value; }
		}
	
		public string PinNumber
		{
			get { return pinNumber; }
			set { pinNumber = value; }
		}
	
		public string LoaiMo
		{
			get { return loaiMo; }
			set { loaiMo = value; }
		}
	
		public decimal LuongMo
		{
			get { return luongMo; }
			set { luongMo = value; }
		}
	
		public DateTime? MEDEDAY
		{
			get { return mEDEDAY; }
			set { mEDEDAY = value; }
		}
	
		public string CoilCode
		{
			get { return coilCode; }
			set { coilCode = value; }
		}
	
		public string LucCheckGearMotor
		{
			get { return lucCheckGearMotor; }
			set { lucCheckGearMotor = value; }
		}
	
		public string LucCheckGear
		{
			get { return lucCheckGear; }
			set { lucCheckGear = value; }
		}
	
		public string HuongHopCau
		{
			get { return huongHopCau; }
			set { huongHopCau = value; }
		}
	
		public string UnitMotor
		{
			get { return unitMotor; }
			set { unitMotor = value; }
		}
	
		public string Loai2TrucCoChan
		{
			get { return loai2TrucCoChan; }
			set { loai2TrucCoChan = value; }
		}
	
		public DateTime? ProductDate
		{
			get { return productDate; }
			set { productDate = value; }
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
	
		public string MaSungLuc
		{
			get { return maSungLuc; }
			set { maSungLuc = value; }
		}
	
		public decimal LucCheckGearMin
		{
			get { return lucCheckGearMin; }
			set { lucCheckGearMin = value; }
		}
	
		public decimal LucCheckGearMax
		{
			get { return lucCheckGearMax; }
			set { lucCheckGearMax = value; }
		}
	
		public decimal LucCheckGearMotorMin
		{
			get { return lucCheckGearMotorMin; }
			set { lucCheckGearMotorMin = value; }
		}
	
		public decimal LucCheckGearMotorMax
		{
			get { return lucCheckGearMotorMax; }
			set { lucCheckGearMotorMax = value; }
		}
	
		public int GunNumber
		{
			get { return gunNumber; }
			set { gunNumber = value; }
		}
	
		public int JobNumber
		{
			get { return jobNumber; }
			set { jobNumber = value; }
		}
	
		public int QtyOcBanGa
		{
			get { return qtyOcBanGa; }
			set { qtyOcBanGa = value; }
		}
	
		public int QtyOcBanThat
		{
			get { return qtyOcBanThat; }
			set { qtyOcBanThat = value; }
		}
	
		public string ProductTypeCode
		{
			get { return productTypeCode; }
			set { productTypeCode = value; }
		}
	
		public int BuLongNumber
		{
			get { return buLongNumber; }
			set { buLongNumber = value; }
		}
	
		public int ShootNumber
		{
			get { return shootNumber; }
			set { shootNumber = value; }
		}
	
		public int SetForce
		{
			get { return setForce; }
			set { setForce = value; }
		}
	
		public string PinNumberIN
		{
			get { return pinNumberIN; }
			set { pinNumberIN = value; }
		}
	
		public decimal SizeSSSMin
		{
			get { return sizeSSSMin; }
			set { sizeSSSMin = value; }
		}
	
		public decimal SizeSSSMax
		{
			get { return sizeSSSMax; }
			set { sizeSSSMax = value; }
		}
	
		public decimal DoDao1Min
		{
			get { return doDao1Min; }
			set { doDao1Min = value; }
		}
	
		public decimal DoDao1Max
		{
			get { return doDao1Max; }
			set { doDao1Max = value; }
		}
	
		public decimal DoDao2Min
		{
			get { return doDao2Min; }
			set { doDao2Min = value; }
		}
	
		public decimal DoDao2Max
		{
			get { return doDao2Max; }
			set { doDao2Max = value; }
		}
	
		public decimal DoDao3Min
		{
			get { return doDao3Min; }
			set { doDao3Min = value; }
		}
	
		public decimal DoDao3Max
		{
			get { return doDao3Max; }
			set { doDao3Max = value; }
		}
	
		public decimal DoDao4Min
		{
			get { return doDao4Min; }
			set { doDao4Min = value; }
		}
	
		public decimal DoDao4Max
		{
			get { return doDao4Max; }
			set { doDao4Max = value; }
		}
	
		public decimal LuongMo1Min
		{
			get { return luongMo1Min; }
			set { luongMo1Min = value; }
		}
	
		public decimal LuongMo1Max
		{
			get { return luongMo1Max; }
			set { luongMo1Max = value; }
		}
	
		public decimal LuongMo2Min
		{
			get { return luongMo2Min; }
			set { luongMo2Min = value; }
		}
	
		public decimal LuongMo2Max
		{
			get { return luongMo2Max; }
			set { luongMo2Max = value; }
		}
	
		public decimal LuongMo3Min
		{
			get { return luongMo3Min; }
			set { luongMo3Min = value; }
		}
	
		public decimal LuongMo3Max
		{
			get { return luongMo3Max; }
			set { luongMo3Max = value; }
		}
	
		public decimal LuongMo4Min
		{
			get { return luongMo4Min; }
			set { luongMo4Min = value; }
		}
	
		public decimal LuongMo4Max
		{
			get { return luongMo4Max; }
			set { luongMo4Max = value; }
		}
	
		public decimal LuongMo5Min
		{
			get { return luongMo5Min; }
			set { luongMo5Min = value; }
		}
	
		public decimal LuongMo5Max
		{
			get { return luongMo5Max; }
			set { luongMo5Max = value; }
		}
	
		public decimal LuongMo6Min
		{
			get { return luongMo6Min; }
			set { luongMo6Min = value; }
		}
	
		public decimal LuongMo6Max
		{
			get { return luongMo6Max; }
			set { luongMo6Max = value; }
		}
	
		public decimal LuongMo7Min
		{
			get { return luongMo7Min; }
			set { luongMo7Min = value; }
		}
	
		public decimal LuongMo7Max
		{
			get { return luongMo7Max; }
			set { luongMo7Max = value; }
		}
	
		public decimal SpaceCenterMin
		{
			get { return spaceCenterMin; }
			set { spaceCenterMin = value; }
		}
	
		public decimal SpaceCenterMax
		{
			get { return spaceCenterMax; }
			set { spaceCenterMax = value; }
		}
	
		public decimal DienAp
		{
			get { return dienAp; }
			set { dienAp = value; }
		}
	
		public decimal TanSo
		{
			get { return tanSo; }
			set { tanSo = value; }
		}
	
		public decimal DongDienMin
		{
			get { return dongDienMin; }
			set { dongDienMin = value; }
		}
	
		public decimal DongDienMax
		{
			get { return dongDienMax; }
			set { dongDienMax = value; }
		}
	
		public decimal NhapLucMin
		{
			get { return nhapLucMin; }
			set { nhapLucMin = value; }
		}
	
		public decimal NhapLucMax
		{
			get { return nhapLucMax; }
			set { nhapLucMax = value; }
		}
	
		public decimal VongQuayMin
		{
			get { return vongQuayMin; }
			set { vongQuayMin = value; }
		}
	
		public decimal VongQuayMax
		{
			get { return vongQuayMax; }
			set { vongQuayMax = value; }
		}
	
		public decimal TiengOnMin
		{
			get { return tiengOnMin; }
			set { tiengOnMin = value; }
		}
	
		public decimal TiengOnMax
		{
			get { return tiengOnMax; }
			set { tiengOnMax = value; }
		}
	
		public decimal DoRungFFTMin
		{
			get { return doRungFFTMin; }
			set { doRungFFTMin = value; }
		}
	
		public decimal DoRungFFTMax
		{
			get { return doRungFFTMax; }
			set { doRungFFTMax = value; }
		}
	
		public decimal SpaceCycloidDiskMin
		{
			get { return spaceCycloidDiskMin; }
			set { spaceCycloidDiskMin = value; }
		}
	
		public decimal SpaceCycloidDiskMax
		{
			get { return spaceCycloidDiskMax; }
			set { spaceCycloidDiskMax = value; }
		}
	
		public decimal DifferenceMin
		{
			get { return differenceMin; }
			set { differenceMin = value; }
		}
	
		public decimal DifferenceMax
		{
			get { return differenceMax; }
			set { differenceMax = value; }
		}
	
		public decimal LucCheck3Min
		{
			get { return lucCheck3Min; }
			set { lucCheck3Min = value; }
		}
	
		public decimal LucCheck3Max
		{
			get { return lucCheck3Max; }
			set { lucCheck3Max = value; }
		}
	
		public decimal LucCheck4Min
		{
			get { return lucCheck4Min; }
			set { lucCheck4Min = value; }
		}
	
		public decimal LucCheck4Max
		{
			get { return lucCheck4Max; }
			set { lucCheck4Max = value; }
		}
	
		public decimal LucCheck5Max
		{
			get { return lucCheck5Max; }
			set { lucCheck5Max = value; }
		}
	
		public decimal LucCheck5Min
		{
			get { return lucCheck5Min; }
			set { lucCheck5Min = value; }
		}
	
		public string SSS
		{
			get { return sSS; }
			set { sSS = value; }
		}
	
		public string CARRIER
		{
			get { return cARRIER; }
			set { cARRIER = value; }
		}
	
		public string CYCLODISK
		{
			get { return cYCLODISK; }
			set { cYCLODISK = value; }
		}
	
		public string RGH
		{
			get { return rGH; }
			set { rGH = value; }
		}
	
		public string BEFORECOVER
		{
			get { return bEFORECOVER; }
			set { bEFORECOVER = value; }
		}
	
		public string AFTERCOVER
		{
			get { return aFTERCOVER; }
			set { aFTERCOVER = value; }
		}
	
		public string SSS2
		{
			get { return sSS2; }
			set { sSS2 = value; }
		}
	
		public string CARRIER2
		{
			get { return cARRIER2; }
			set { cARRIER2 = value; }
		}
	
		public string CYCLODISK2
		{
			get { return cYCLODISK2; }
			set { cYCLODISK2 = value; }
		}
	
		public string RGH2
		{
			get { return rGH2; }
			set { rGH2 = value; }
		}
	
		public string BEFORECOVER2
		{
			get { return bEFORECOVER2; }
			set { bEFORECOVER2 = value; }
		}
	
		public string AFTERCOVER2
		{
			get { return aFTERCOVER2; }
			set { aFTERCOVER2 = value; }
		}
	
		public string Goal
		{
			get { return goal; }
			set { goal = value; }
		}
	
		public double EngineWeightMin
		{
			get { return engineWeightMin; }
			set { engineWeightMin = value; }
		}
	
		public double EngineWeightMax
		{
			get { return engineWeightMax; }
			set { engineWeightMax = value; }
		}
	
		public double EngineWeight
		{
			get { return engineWeight; }
			set { engineWeight = value; }
		}
	
	}
}
	