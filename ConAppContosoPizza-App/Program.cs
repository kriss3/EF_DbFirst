
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

		using var myContosoSvc = new ContosoPizzaContext();

		var services = new EfOperationsService(myContosoSvc);
		CreateProducts(services);

		var products = services.GetProducts()
			.Where(p => p.Price > 10.00M)
			.OrderBy(p => p.Name);

		foreach (var product in products) 
		{
			WriteLine($"Id:			{product.Id}");	
			WriteLine($"Name:		{product.Name}");	
			WriteLine($"Price		{product.Price}");
			WriteLine(new string('-', 20));	
		}

	}

	private static void CreateProducts(EfOperationsService services)
	{
		services.AddProduct(new Product { Name = "Pizza Margherita", Price = 12.50m });
		services.AddProduct(new Product { Name = "Pizza Pepperoni", Price = 15.50m });
		services.AddProduct(new Product { Name = "Pizza Capricciosa", Price = 14.50m });
	}
}
