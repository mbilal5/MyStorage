using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Graph;
using MyStorage.Data.Entities;

namespace MyStorage.Data.Services.Explorers
{
	public class OneDriveExplorer : IDriveExplorer
	{
		private readonly GraphServiceClient _client;


		public OneDriveExplorer(GraphServiceClient client)
		{
			_client = client;
		}
		
		public async Task<StorageDrive> GetDrive(string id)
		{
			try
			{
				var drive = await _client.Drives[id]
					.Request()
					.GetAsync();
				var storageDrive = new StorageDrive
				{
					Id = drive.Id,
					Name = drive.Name
				};
				return storageDrive;
			}
			catch (Exception e)
			{
				throw e;
			}
		}
		
		public async Task<IEnumerable<StorageDrive>> GetDrives()
		{
			var drives = await _client.Drives.Request().GetAsync();
			var storageDrives = drives.Select(drive => new StorageDrive(drive));
			return storageDrives;
		}
		
		public async Task<StorageDrive> GetDriveByName(string name)
		{
			var drives = await _client.Drives
				.Request()
				.Filter($"Name eq \'{name}\'")
				.GetAsync();
			
			if (drives.Count > 1)
				throw new ApplicationException($"The given Drive Name: \"{name}\" resolved to multiple drives");
			else if (drives.Count == 0)
				throw new ApplicationException($"No drives were found with a Drive Name: \"{name}\". ");
			
			if (drives[0].Name != name)
				throw new ApplicationException($"Received a faulty response. Requested Drive with Name: \"{name}\" but received drive with Name: \"{drives[0].Name}\"");

			return new StorageDrive(drives[0]);
		}
		
		public async Task<StorageDrive> GetUserDrive()
		{
			var drive = await _client.Me.Drive
				.Request()
				.GetAsync();
			return new StorageDrive(drive);
		}
	}
}