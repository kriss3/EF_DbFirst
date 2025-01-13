using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConAppContosoPizza_App.Models;
public class Order
{
	public int Id { get; set; }
	public DateTime OrderPlaced { get; set; }
	public DateTime OrderFulfilled { get; set; }
	public int CustomerId { get; set; }

	public Customer Customer { get; set; } = null!;
	public ICollection<OrderDetails> OrderDetails { get; set; } = null!;
}
