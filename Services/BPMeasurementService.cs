using Microsoft.EntityFrameworkCore;
using EunmiKim_Assignment1.Entities;

namespace EunmiKim_Assignment1.Services
{
	public class BPMeasurementService : IBPMeasurementService
	{
		private readonly string[] _positions = ["Select a measurement position", "Sitting", "Standing", "Lying down"];
		private readonly BpMeasurementsDbContext _context;

		public BPMeasurementService(BpMeasurementsDbContext context)
		{
			_context = context;
		}

		public ICollection<string> GetAllPositions()
		{
			return _positions.AsReadOnly();
		}

		public List<BpMeasurement> GetAllBpMeasurements()
		{
			return _context.BpMeasurements.ToList();
		}

		public int AddBpMeasurement(BpMeasurement measurement)
		{
			_context.BpMeasurements.Add(measurement);
			_context.SaveChanges();

			return measurement.Id;
		}

		public BpMeasurement GetBpMeasurement(int id)
		{
			return _context.BpMeasurements.Find(id);
		}

		public int UpdateBpMeasurement(BpMeasurement bpMeasurement)
		{
			_context.BpMeasurements.Update(bpMeasurement);
			_context.SaveChanges();

			return bpMeasurement.Id;
		}

		public int DeleteBpMeasurement(BpMeasurement bpMeasurement)
		{
			_context.BpMeasurements.Remove(bpMeasurement);
			_context.SaveChanges();

			return bpMeasurement.Id;
		}
	}
}