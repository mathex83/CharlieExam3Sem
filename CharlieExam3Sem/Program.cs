using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace CharlieExam3Sem
{
	///Udviklet af: Martin Nørholm, Janus B. Reedtz og Frederik M. Nielsen
	public class Program
	{
		public static void Main(string[] args)
		{
			CreateHostBuilder(args).Build().Run();
		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureWebHostDefaults(webBuilder =>
				{
					webBuilder.UseStartup<Startup>();
				});
	}
}
