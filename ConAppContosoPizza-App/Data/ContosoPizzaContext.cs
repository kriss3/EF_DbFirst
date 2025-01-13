using ConAppContosoPizza_App.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConAppContosoPizza_App.Data;
public class ContosoPizzaContext : DbContext
{
	public DbSet<Customer> Customers { get; set; } = null!;
	public DbSet<Order> Orders { get; set; } = null!;
	public DbSet<Product> Products { get; set; } = null!;
	public DbSet<OrderDetails> OrderDetails { get; set; } = null!;
}
