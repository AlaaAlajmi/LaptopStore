using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LaptopStore.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace LaptopStore.Data
{
	public class AppDbInitializer
	{
		public static void Seed(IApplicationBuilder applicationBuilder)
		{
			using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
			{
				var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
				context.Database.EnsureCreated();
				if (!context.Laptops.Any())
				{
					context.Laptops.AddRange(new List<Laptop>()
					{
						new Laptop()
						{
							ProductName = "Huawei Matebook D14",
							Description ="Intel Core i5 10th Gen, RAM 8GB, 512 SSD, 14-inch Laptop",
							Price =  219 ,
							ImageUrl = "https://m.xcite.com/media/catalog/product/cache/1/thumbnail/700x700/9df78eab33525d08d6e5fb8d27136e95/h/u/huawei-matebook-d14-laptop-grey_1.jpg"

						},
						new Laptop()
						{
							ProductName = "Lenovo V14",
							Description ="Intel Core i3, 4GB RAM, 1TB HDD, 14-inch Laptop",
							Price =  134 ,
							ImageUrl = "https://m.xcite.com/media/catalog/product/cache/1/thumbnail/700x700/9df78eab33525d08d6e5fb8d27136e95/l/a/laptop-lenovo-grey-14-inch-v14-1.jpg"
						},
						new Laptop()
						{
							ProductName = "Microsoft Surface Pro 7",
							Description ="Core i5 Ram 8GB SSD 128GB 12.3-inch Touchscreen Convertible Laptop",
							Price =  319,
							ImageUrl ="https://m.xcite.com/media/catalog/product/cache/1/thumbnail/700x700/9df78eab33525d08d6e5fb8d27136e95/1/1/1112021-1warranty625219_1.jpg"
						},
						new Laptop()
						{
							ProductName = "HP Pavilion x360 14",
							Description ="Intel Core i7 11th Gen. 16GB RAM 512GB SSD 14-inch Convertible Laptop",
							Price =  319 ,
							ImageUrl= "https://m.xcite.com/media/catalog/product/cache/1/thumbnail/700x700/9df78eab33525d08d6e5fb8d27136e95/h/p/hp-pavilion-convertible-laptop-silver_5__1.jpg"
						  }
					});
					context.SaveChanges();
				}
			}
		}
	}
}

	//All the sources are from the link attached below:
	//https://www.xcite.com/computers-tablet/notebooks/windows.html?p=4


