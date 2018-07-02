using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace com.udragan.netCore.webApi.Notes
{
	/// <summary>
	/// Startup root.
	/// </summary>
	public class Program
	{
		/// <summary>
		/// Application`s main entry point.
		/// </summary>
		/// <param name="args">The arguments.</param>
		public static void Main(string[] args)
		{
			BuildWebHost(args).Run();
		}

		/// <summary>
		/// Builds the web host.
		/// </summary>
		/// <param name="args">The arguments.</param>
		/// <returns>Configured web host.</returns>
		public static IWebHost BuildWebHost(string[] args) =>
			WebHost.CreateDefaultBuilder(args)
				.UseStartup<Startup>()
				.Build();
	}
}
