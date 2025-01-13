
using ConAppContosoPizza_App.Data;
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
		var azConnString = GetConfiguration()["AzureConnectionString"];

		var serviceCollection = new ServiceCollection();
		serviceCollection.AddDbContext<ContosoPizzaContext>(options =>
			options.UseSqlServer(azConnString));
		var serviceProvider = serviceCollection.BuildServiceProvider();

	}

	static IConfiguration GetConfiguration()
	{
		var builder = new ConfigurationBuilder()
			.AddUserSecrets<Program>();
		return builder.Build();
	}
}
