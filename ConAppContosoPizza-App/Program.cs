﻿
using ConAppContosoPizza_App.Data;
using ConAppContosoPizza_App.Models;
using ConAppContosoPizza_App.Services;
using static System.Console;

namespace ConAppContosoPizza_App;

public class Program
{
	static void Main()
	{
		WriteLine("Contoso Pizza. EF Core - Code First.");

		using var myContosoSvc = new ContosoPizzaContext();

		var services = new EfOperationsService(myContosoSvc);

		if (services.GetCustomers().Count == 0)
		{
			CreateCustomers(services);
		}

		if (services.GetProducts().Count == 0)
		{
			CreateProducts(services);
		}

		if (services.GetOrders().Count == 0)
		{
			CreateOrders(services);
		}

		if (services.GetOrderDetails().Count == 0)
		{
			CreateOrderDetails(services);
		}

		IOrderedEnumerable<Customer> customers = GetCustomers(services);
		ShowCustomerDetails(customers);

		IOrderedEnumerable<Product> products = GetProducts(services);
		ShowProductDetails(products);

		IOrderedEnumerable<Order> orders = GetOrders(services);
		ShowOrders(orders);

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
		customers.ForEach(c => services.AddCustomer(c));
	}

	private static IOrderedEnumerable<Customer> GetCustomers(EfOperationsService services)
	{
		return services.GetCustomers()
					.OrderBy(c => c.LastName)
					.ThenBy(c => c.FirstName);
	}

	private static void ShowCustomerDetails(IOrderedEnumerable<Customer> customers)
	{
		foreach (var customer in customers)
		{
			WriteLine($"Id:			{customer.Id}");
			WriteLine($"Name:		{customer.FirstName} {customer.LastName}");
			WriteLine($"Address:	{customer.Address}");
			WriteLine($"Phone:		{customer.Phone}");
			WriteLine($"Email:		{customer.Email}");
			WriteLine(new string('-', 20));
		}
	}

	private static void CreateOrders(EfOperationsService services)
	{
		var orders = new List<Order>
			{
				new() { OrderPlaced = DateTime.Now.AddDays(-10), OrderFulfilled = DateTime.Now.AddDays(-5), CustomerId = 1 },
				new() { OrderPlaced = DateTime.Now.AddDays(-8), OrderFulfilled = DateTime.Now.AddDays(-3), CustomerId = 2 },
				new() { OrderPlaced = DateTime.Now.AddDays(-6), OrderFulfilled = DateTime.Now.AddDays(-2), CustomerId = 3 },
				new() { OrderPlaced = DateTime.Now.AddDays(-4), OrderFulfilled = DateTime.Now.AddDays(-1), CustomerId = 4 },
				new() { OrderPlaced = DateTime.Now.AddDays(-2), OrderFulfilled = DateTime.Now, CustomerId = 5 },
				new() { OrderPlaced = DateTime.Now.AddDays(-1), OrderFulfilled = DateTime.Now.AddDays(1), CustomerId = 6 },
				new() { OrderPlaced = DateTime.Now, OrderFulfilled = DateTime.Now.AddDays(2), CustomerId = 7 },
				new() { OrderPlaced = DateTime.Now.AddDays(1), OrderFulfilled = DateTime.Now.AddDays(3), CustomerId = 8 },
				new() { OrderPlaced = DateTime.Now.AddDays(2), OrderFulfilled = DateTime.Now.AddDays(4), CustomerId = 9 },
				new() { OrderPlaced = DateTime.Now.AddDays(3), OrderFulfilled = DateTime.Now.AddDays(5), CustomerId = 10 }
			};
		orders.ForEach(o => services.AddOrder(o));
	}

	private static IOrderedEnumerable<Order> GetOrders(EfOperationsService services)
	{
		return services.GetOrders()
					.OrderBy(o => o.OrderPlaced);
	}

	private static void ShowOrders(IOrderedEnumerable<Order> orders)
	{
		foreach (var order in orders)
		{
			WriteLine($"Id:            {order.Id}");
			WriteLine($"Order Placed:  {order.OrderPlaced}");
			WriteLine($"Order Fulfilled: {order.OrderFulfilled}");
			WriteLine($"Customer Id:   {order.CustomerId}");
			WriteLine(new string('-', 20));
		}
	}

	private static void CreateOrderDetails(EfOperationsService services)
	{
		var orders = services.GetOrders();
		var products = services.GetProducts();
		var random = new Random();

		var orderDetails = new List<OrderDetails>();

		for (int i = 0; i < 10; i++)
		{
			var order = orders[random.Next(orders.Count)];
			var product = products[random.Next(products.Count)];
			var quantity = random.Next(1, 10);

			orderDetails.Add(new OrderDetails
			{
				OrderId = order.Id,
				ProductId = product.Id,
				Quantity = quantity,
				Order = order,
				Product = product
			});
		}

		orderDetails.ForEach(od => services.AddOrderDetails(od));
	}

	private static IOrderedEnumerable<OrderDetails> GetOrderDetails(EfOperationsService services)
	{
		return services.GetOrderDetails()
					.OrderBy(od => od.OrderId);
	}

	private static void ShowOrderDetails(IOrderedEnumerable<OrderDetails> orderDetails)
	{
		foreach (var orderDetail in orderDetails)
		{
			WriteLine($"Order Id:				{orderDetail.OrderId}");
			WriteLine($"Product Id:			{orderDetail.ProductId}");
			WriteLine($"Quantity:				{orderDetail.Quantity}");
			WriteLine($"Product Name:		{orderDetail.Product.Name}");
			WriteLine($"Customer:			{orderDetail.Order.Customer.FirstName}");
			WriteLine(new string('-', 20));
		}
	}

}
