using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace MyStorage
{
	public class Program
	{
		public static void Main(string[] args)
		{
			IHost host = Host.CreateDefaultBuilder(args)
				.ConfigureWebHostDefaults(builder =>
				{
					builder.UseStartup<Startup>();
				})
				.Build();

			host.Run();
		}
	}
}
