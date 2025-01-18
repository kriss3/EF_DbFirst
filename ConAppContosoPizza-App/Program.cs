﻿
using ConAppContosoPizza_App.Data;
using ConAppContosoPizza_App.Models;
using ConAppContosoPizza_App.Services;
using static System.Console;

namespace ConAppContosoPizza_App;

internal class Program
{
	static void Main()
	{
		WriteLine("Contoso Pizza. EF Core - Code First.");

		using var myContosoSvc = new ContosoPizzaContext();

		var services = new EfOperationsService(myContosoSvc);

		if (services.GetProducts().Count == 0)
		{
			CreateProducts(services);
		}

		IOrderedEnumerable<Product> products = GetProducts(services);
		ShowProductDetails(products);

	}

	private static void ShowProductDetails(IOrderedEnumerable<Product> products)
	{
		foreach (var product in products)
		{
			WriteLine($"Id:			{product.Id}");
			WriteLine($"Name:		{product.Name}");
			WriteLine($"Price		{product.Price}");
			WriteLine(new string('-', 20));
		}
	}

	private static IOrderedEnumerable<Product> GetProducts(EfOperationsService services)
	{
		return services.GetProducts()
					.Where(p => p.Price > 10.00M)
					.OrderBy(p => p.Name);
	}

	private static void CreateProducts(EfOperationsService services)
	{
		services.AddProduct(new Product { Name = "Pizza Margherita", Price = 12.50m });
		services.AddProduct(new Product { Name = "Pizza Pepperoni", Price = 15.50m });
		services.AddProduct(new Product { Name = "Pizza Capricciosa", Price = 14.50m });
	}

	private static void CreateCustomers(EfOperationsService services)
	{
		var customers = new List<Customer>
			{
				new() { FirstName = "John", LastName = "Doe", Address = "123 Main St", Phone = "555-1234", Email = "john.doe@example.com" },
				new() { FirstName = "Jane", LastName = "Smith", Address = "456 Elm St", Phone = "555-5678", Email = "jane.smith@example.com" },
				new() { FirstName = "Michael", LastName = "Johnson", Address = "789 Oak St", Phone = "555-8765", Email = "michael.johnson@example.com" },
				new() { FirstName = "Emily", LastName = "Davis", Address = "321 Pine St", Phone = "555-4321", Email = "emily.davis@example.com" },
				new() { FirstName = "David", LastName = "Brown", Address = "654 Maple St", Phone = "555-6789", Email = "david.brown@example.com" },
				new() { FirstName = "Sarah", LastName = "Wilson", Address = "987 Cedar St", Phone = "555-9876", Email = "sarah.wilson@example.com" },
				new() { FirstName = "Chris", LastName = "Lee", Address = "159 Birch St", Phone = "555-1597", Email = "chris.lee@example.com" },
				new() { FirstName = "Jessica", LastName = "Taylor", Address = "753 Spruce St", Phone = "555-7531", Email = "jessica.taylor@example.com" },
				new() { FirstName = "Daniel", LastName = "Anderson", Address = "852 Fir St", Phone = "555-8524", Email = "daniel.anderson@example.com" },
				new() { FirstName = "Laura", LastName = "Thomas", Address = "951 Willow St", Phone = "555-9513", Email = "laura.thomas@example.com" }
			};
	}

}
