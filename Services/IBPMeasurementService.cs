using EunmiKim_Assignment1.Entities;

namespace EunmiKim_Assignment1.Services
{
	public interface IBPMeasurementService
	{
		public ICollection<string> GetAllPositions();
		public List<BpMeasurement> GetAllBpMeasurements();

		public int AddBpMeasurement(BpMeasurement measurement);

		public BpMeasurement GetBpMeasurement(int id);

		public int UpdateBpMeasurement(BpMeasurement bpMeasurement);

		public int DeleteBpMeasurement(BpMeasurement bpMeasurement);
	}
}
