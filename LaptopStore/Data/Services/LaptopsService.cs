using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LaptopStore.Data.Base;
using LaptopStore.Models;
using Microsoft.EntityFrameworkCore;

namespace LaptopStore.Data.Services
{
	public class LaptopsService : EntityBaseRepository<Laptop>, ILaptopsService
	{
		private readonly AppDbContext _context;
		public LaptopsService(AppDbContext context) :base(context)
		{
			_context = context;
		}

		public async Task AddNewLaptopAsync(NewLaptopMV data)
		{
			var newLaptop= new Laptop()
			{
				ProductName = data.ProductName,
				Description = data.Description,
				Price = data.Price,
				ImageUrl = data.ImageUrl
			};
			await _context.Laptops.AddAsync(newLaptop);
			await _context.SaveChangesAsync();
		}

		public async Task<Laptop> GetLaptopByIdAsync(int id)
		{
			var LaptopDetails = await _context.Laptops
				.FirstOrDefaultAsync(n => n.Id == id);
			return  LaptopDetails;
		}

		public async Task UpdateLaptopAsync(NewLaptopMV data)
		{
			var dbLaptop = await _context.Laptops.FirstOrDefaultAsync(n => n.Id == data.Id);

			{
				if (dbLaptop != null)
					dbLaptop.ProductName = data.ProductName;
					dbLaptop.Description = data.Description;
					dbLaptop.Price = data.Price;
					dbLaptop.ImageUrl = data.ImageUrl;
					await _context.SaveChangesAsync();
				}
			
		}
	}
}
