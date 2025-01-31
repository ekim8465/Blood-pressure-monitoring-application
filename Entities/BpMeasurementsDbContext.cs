using Microsoft.EntityFrameworkCore;

namespace EunmiKim_Assignment1.Entities
{
	public class BpMeasurementsDbContext : DbContext
	{
		public BpMeasurementsDbContext(DbContextOptions<BpMeasurementsDbContext> options) : base(options)
		{

		}

		public DbSet<BpMeasurement> BpMeasurements { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<BpMeasurement>().HasData(
				new BpMeasurement { Id = 5, SystolicValue = 181, DiastolicValue = 121, ReadingDate = new DateTime(2008, 02, 07), Position = "Standing" },
				new BpMeasurement { Id = 4, SystolicValue = 142, DiastolicValue = 91, ReadingDate = new DateTime(2005, 12, 29), Position = "Lying down" },
				new BpMeasurement { Id = 3, SystolicValue = 131, DiastolicValue = 85, ReadingDate = new DateTime(2002, 11, 24), Position = "Standing" },
				new BpMeasurement { Id = 2, SystolicValue = 120, DiastolicValue = 79, ReadingDate = new DateTime(1998, 05, 08), Position = "Sitting" },
				new BpMeasurement { Id = 1, SystolicValue = 118, DiastolicValue = 78, ReadingDate = new DateTime(1996, 02, 09), Position = "Sitting" }
				
				);
		}
	}
}
