﻿using ConAppContosoPizza_App.Data;
using ConAppContosoPizza_App.Models;

namespace ConAppContosoPizza_App.Services;

public interface IEfOperationsService
{
	void AddCustomer(Customer customer);
	void AddProduct(Product product);
	void AddOrder(Order order);
	void AddOrderDetails(OrderDetails orderDetails);
	
	List<Customer> GetCustomers();
	List<Product> GetProducts();
	List<Order> GetOrders();
	List<OrderDetails> GetOrderDetails();
}

public class EfOperationsService(ContosoPizzaContext context) : IEfOperationsService
{
	private readonly ContosoPizzaContext _context = context;


	public void AddCustomer(Customer customer)
	{
		_context.Customers.Add(customer);
		_context.SaveChanges();
	}
	public void AddProduct(Product product)
	{
		_context.Products.Add(product);
		_context.SaveChanges();
	}
	public void AddOrder(Order order)
	{
		_context.Orders.Add(order);
		_context.SaveChanges();
	}
	public void AddOrderDetails(OrderDetails orderDetails)
	{
		_context.OrderDetails.Add(orderDetails);
		_context.SaveChanges();
	}


	public List<Customer> GetCustomers()
	{
		return [.. _context.Customers];
	}
	public List<Product> GetProducts()
	{
		return [.. _context.Products];
	}
	public List<Order> GetOrders()
	{
		return [.. _context.Orders];
	}
	public List<OrderDetails> GetOrderDetails()
	{
		return [.. _context.OrderDetails];
	}
}

