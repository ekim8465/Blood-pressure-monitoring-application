using Microsoft.EntityFrameworkCore;
using EunmiKim_Assignment1.Entities;
using EunmiKim_Assignment1.Services;

namespace EunmiKim_Assignment1
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddControllersWithViews();
			builder.Services.AddScoped<IBPMeasurementService, BPMeasurementService>();

			var connectionString = builder.Configuration.GetConnectionString("BpMeasurementsDb");
			builder.Services.AddDbContext<BpMeasurementsDbContext>(options => options.UseSqlServer(connectionString));


			var app = builder.Build();
			
			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");

			app.Run();
		}
	}
}
