using LaptopStore.Data.Base;
using LaptopStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaptopStore.Data.Services
{
	public interface ILaptopsService : IEntityBaseRepository<Laptop>
	{
		Task<Laptop> GetLaptopByIdAsync(int id);
		Task AddNewLaptopAsync(NewLaptopMV data);
		Task UpdateLaptopAsync(NewLaptopMV data);

	}
}
