
using System.Collections;
using BMS.Model;
namespace BMS.Facade
{
	
	public class ProductionPlanFacade : BaseFacade
	{
		protected static ProductionPlanFacade instance = new ProductionPlanFacade(new ProductionPlanModel());
		protected ProductionPlanFacade(ProductionPlanModel model) : base(model)
		{
		}
		public static ProductionPlanFacade Instance
		{
			get { return instance; }
		}
		protected ProductionPlanFacade():base() 
		{ 
		} 
	
	}
}
	