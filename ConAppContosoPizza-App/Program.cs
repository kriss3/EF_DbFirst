
using ConAppContosoPizza_App.Data;
using ConAppContosoPizza_App.Models;
using ConAppContosoPizza_App.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using static System.Console;

namespace ConAppContosoPizza_App;

internal class Program
{
	static void Main()
	{
		WriteLine("Contoso Pizza. EF Core - Code First.");

		var services = new EfOperationsService(new ContosoPizzaContext());

		services.AddProduct(new Product { Name = "Pizza Margherita", Price = 12.50m });
		services.AddProduct(new Product { Name = "Pizza Pepperoni", Price = 15.50m });
		services.AddProduct(new Product { Name = "Pizza Capricciosa", Price = 14.50m });
	}
}
