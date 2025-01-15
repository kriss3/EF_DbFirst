using ConAppContosoPizza_App.Data;
using ConAppContosoPizza_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConAppContosoPizza_App.Services;
public class EfOperationsService(ContosoPizzaContext context)
{
	private readonly ContosoPizzaContext _context = context;

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
}

