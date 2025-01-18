
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
}
