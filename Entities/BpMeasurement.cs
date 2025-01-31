using System.ComponentModel.DataAnnotations;
using System.Diagnostics.SymbolStore;

namespace EunmiKim_Assignment1.Entities
{
	public class BpMeasurement
	{
		public int Id { get; set; }

		[Required]
		[Range(20, 400, ErrorMessage = "Systolic values must be positive integers between 20 and 400.")]
		public int SystolicValue { get; set; }

		[Required]
		[Range(10, 300, ErrorMessage = "Diastolic values must be positive integers between 10 and 300.")]
		public int DiastolicValue { get; set; }


		[Required(ErrorMessage = "Please enter date for the measurement")]
		public DateTime? ReadingDate { get; set; }


		[Required (ErrorMessage = "Please choose a position for the measurement")]
		
		public string Position {  get; set; }

		
		public string Category 
		{ 
			get
			{
				if(SystolicValue < 120 && DiastolicValue < 80)
				{
					return "Nomal";
				}
				else if (SystolicValue >= 120 && SystolicValue <= 129 && DiastolicValue < 80)
				{
					return "Elevated";
				}
				else if((SystolicValue >= 130 && SystolicValue <= 139) || (DiastolicValue >= 80 && DiastolicValue <= 89))
				{
					return "Hypertension Stage 1";
				}
				else if (SystolicValue >= 140 || DiastolicValue >= 90)
				{
					return "Hypertension Stage 2";
				}
				else if(SystolicValue >= 180 || DiastolicValue >= 120)
				{
					return "Hypertension Crisis";
				}
				else
				{
					return "Unknown";
				}
				
			} 
		}

	}
}
