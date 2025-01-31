using EunmiKim_Assignment1.Entities;
using EunmiKim_Assignment1.Models;
using EunmiKim_Assignment1.Services;
using Microsoft.AspNetCore.Mvc;


namespace EunmiKim_Assignment1.Controllers
{
	public class BpMeasurementsController : Controller
	{
		private readonly IBPMeasurementService _bpMeasurementService;

		public BpMeasurementsController(IBPMeasurementService bpMeasurementService)
		{
			_bpMeasurementService = bpMeasurementService;
		}


		[HttpGet("/all")]

		public IActionResult AllBpMeasurement()
		{
			var viewModel = new AllBpMeasurementsViewModel()
			{
				AllBpMeasurements = _bpMeasurementService.GetAllBpMeasurements()
			};
			return View("All", viewModel);
		}

		[HttpGet("/add")]

		public IActionResult AddBpMeasurement()
		{
			var viewModel = new AddBpMeasurementsViewModel() 
			{
				NewBpMeasurement = new BpMeasurement(),
				Positions = new List<string> { "Select a measurement position", "Sitting", "Standing", "Lying down" }
			};
			
			return View("Add", viewModel);
		}

		[HttpPost("/add")]

		public IActionResult AddBpMeasurement(AddBpMeasurementsViewModel viewModel)
		{
			if (!ModelState.IsValid)
			{
				viewModel.Positions = new List<string> { "Select a measurement position", "Sitting", "Standing", "Lying down" };
				return View("Add", viewModel);
			}
			else
			{
				_bpMeasurementService.AddBpMeasurement(viewModel.NewBpMeasurement);
				TempData["message"] = $"{viewModel.NewBpMeasurement.SystolicValue}/{viewModel.NewBpMeasurement.DiastolicValue} added successfully!";
				TempData["className"] = "success";
				return RedirectToAction("AllBpMeasurement");
			}
		}

		[HttpGet("/edit/{id}")]

		public IActionResult EditBpMeasurement(int id)
		{
			var viewModel = new EditBpMeasurementViewModel()
			{
				CurrentBpMeasurement = _bpMeasurementService.GetBpMeasurement(id),
				Positions = new List<string> { "Select a measurement position", "Sitting", "Standing", "Lying down" }
			};

			return View("Edit", viewModel);
		}

		[HttpPost("/edit/{id}")]

		public IActionResult EditBpMeasurement(EditBpMeasurementViewModel viewModel)
		{
			if (!ModelState.IsValid)
			{
				return View("Edit", viewModel);
			}
			else
			{
				_bpMeasurementService.UpdateBpMeasurement(viewModel.CurrentBpMeasurement);
				TempData["message"] = $"{viewModel.CurrentBpMeasurement.SystolicValue}/{viewModel.CurrentBpMeasurement.DiastolicValue} updated successfully!";
				TempData["className"] = "info";

				return RedirectToAction("AllBpMeasurement");
			}
		}
		[HttpGet("/delete/{id}")]

		public IActionResult DeleteBpMeasurement(int id)
		{
			var viewModel = new DeleteBpMeasurementViewModel()
			{
				CurrentBpMeasurement = _bpMeasurementService.GetBpMeasurement(id)
			};

			return View("Delete", viewModel);
		}

		[HttpPost("/delete/{id}")]

		public IActionResult DeleteBpMeasurement(DeleteBpMeasurementViewModel viewModel)
		{
			_bpMeasurementService.DeleteBpMeasurement(viewModel.CurrentBpMeasurement);
			TempData["message"] = $"{viewModel.CurrentBpMeasurement.SystolicValue}/{viewModel.CurrentBpMeasurement.DiastolicValue} deleted successfully!";
			TempData["className"] = "info";

			return RedirectToAction("AllBpMeasurement");
		}

        [HttpGet("/information")]
        public IActionResult BpMeasurementInformation()
        {
            return View("BpMeasurementInformation");
        }
    }

}

