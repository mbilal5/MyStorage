using System;
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

		public async Task<StorageDrive> GetDriveByName(string name)
		{
			throw new System.NotImplementedException();
		}
		
		public async Task<StorageDrive> GetUserDrive()
		{
			throw new System.NotImplementedException();
		}
	}
}