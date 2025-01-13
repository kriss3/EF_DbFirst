using System.ComponentModel.DataAnnotations.Schema;

namespace ConAppContosoPizza_App.Models;
public class Product
{
	public int Id { get; set; }
	public string? Name { get; set; } = null;

	[Column(TypeName = "decimal(6, 1)")]
	public decimal Price { get; set; }
}
