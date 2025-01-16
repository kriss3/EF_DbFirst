using ConAppContosoPizza_App.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ConAppContosoPizza_App.Data;
public class ContosoPizzaContext : DbContext
{
	public DbSet<Customer> Customers { get; set; } = null!;
	public DbSet<Order> Orders { get; set; } = null!;
	public DbSet<Product> Products { get; set; } = null!;
	public DbSet<OrderDetails> OrderDetails { get; set; } = null!;

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseSqlServer(GetAzConnString());
	}

	private static string GetAzConnString()
	{
		IConfiguration configuration = new ConfigurationBuilder()
			.AddUserSecrets<Program>()
			.Build();
		var azConnString = configuration.GetConnectionString("kws_azdb:azConnString");

		return azConnString ?? "";
	}

}
