﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LaptopStore.Models;
using Microsoft.EntityFrameworkCore;

namespace LaptopStore.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions <AppDbContext> options) :base(options)
		{
		}
		
	public DbSet<Laptop> Laptops { get; set; }
	}
}
