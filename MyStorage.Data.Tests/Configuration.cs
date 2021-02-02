using System;
using System.IO;
using Microsoft.Extensions.Configuration;


namespace MyStorage.Data.Tests
{
	public class Configuration
	{
		private static IConfigurationRoot _configuration;
		public static IConfigurationRoot Instance { get => _configuration; }
		
		
		static Configuration()
		{
			_configuration = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json", false, false)
				.AddUserSecrets(typeof(Configuration).Assembly)
				.Build();
		}
		
	}
}