using EunmiKim_Assignment1.Entities;

namespace EunmiKim_Assignment1.Models
{
	public class AddBpMeasurementsViewModel
	{
		public List<string> Positions { get; set; } = new List<string>();
		public BpMeasurement NewBpMeasurement { get; set; }

		
	}
}
