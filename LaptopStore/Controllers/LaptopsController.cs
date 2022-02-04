using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LaptopStore.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LaptopStore.Data.Services;
using LaptopStore.Models;

namespace LaptopStore.Controllers
{
	public class LaptopsController : Controller
	{

		private readonly ILaptopsService _service;
		public LaptopsController(ILaptopsService service)
		{
			_service = service;
		}
		public async Task<IActionResult> Index()
		{
			var AllLaptops = await _service.GetAllAsync();
			return View(AllLaptops);
		}

		public async Task<IActionResult> Filter(string searchString)
		{
			var allLaptops = await _service.GetAllAsync();

			if (!string.IsNullOrEmpty(searchString))
			{
				
				var filteredResultNew = allLaptops.Where(n => string.Equals(n.ProductName, searchString, StringComparison.CurrentCultureIgnoreCase) || string.Equals(n.Description, searchString, StringComparison.CurrentCultureIgnoreCase)).ToList();

				return View("Index", filteredResultNew);
			}

			return View("Index", allLaptops);
		}

		public async Task<IActionResult> Details(int id)
		{
			var LaptopDetial = await _service.GetLaptopByIdAsync(id);
			return View(LaptopDetial);

		}

		public async Task<IActionResult> Create()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(NewLaptopMV laptop)
		{
			if (!ModelState.IsValid)
			{
				return View(laptop);
			}
			await _service.AddNewLaptopAsync(laptop);
			return RedirectToAction(nameof(Index));
		}

    public async Task<IActionResult> Edit(int id)
    {
        var LaptopDetial = await _service.GetLaptopByIdAsync(id);
			if (LaptopDetial == null) return View();

        var response = new NewLaptopMV()
		{
            ProductName = LaptopDetial.ProductName,
            Description = LaptopDetial.Description,
            Price = LaptopDetial.Price,
            ImageUrl = LaptopDetial.ImageUrl
		};

        return View(response);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, NewLaptopMV laptop)
    {
    
        await _service.UpdateLaptopAsync(laptop);
        return RedirectToAction(nameof(Index));
    }
}
}
