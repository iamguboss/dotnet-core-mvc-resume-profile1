using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public class Program {
	public static void Main(string[] args) {
		var host = new WebHostBuilder()
			.UseContentRoot(Directory.GetCurrentDirectory())
			.UseUrls("http://+:2000")
			.UseStartup<Startup>()
			.UseKestrel()
			.Build();
		host.Run();
	}
}

class Startup {
	public void ConfigureServices(IServiceCollection service) {
		service.AddMvc();
	}

	public void Configure(IApplicationBuilder app) {
		app.UseStaticFiles();
		app.UseMvcWithDefaultRoute();
	}
}
