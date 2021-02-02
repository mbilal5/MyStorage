using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Graph;

namespace MyStorage.Services
{
	public class OneDriveExplorer
	{
		private readonly GraphServiceClient _client;
		
		
		public OneDriveExplorer(GraphServiceClient client)
		{
			_client = client;
		}

		public async Task<Drive> GetDrive(string id)
		{
			var drive = await _client.Me.Drives[id]
				.Request()
				.GetAsync();
			return drive;
		}

		public async Task<IEnumerable<Drive>> GetDrives()
		{
			var drives = await _client.Me.Drives
				.Request()
				.GetAsync();

			return drives;
		}
		
		public async Task<Drive> GetDriveByName(string name)
		{
			var drive = await _client.Me.Drives
				.Request()
				.Filter($"name eq '{name}'")
				.GetAsync();
			return drive[0];
		}

		public async Task<IEnumerable<DriveItem>> GetDriveRoot(string id)
		{
			var root = await _client.Me.Drives[id].Root.Children
				.Request()
				.GetAsync();
			return root;
		}

		public async Task<IEnumerable<DriveItem>> GetDriveRootByName(string name)
		{
			var drive = await GetDriveByName(name);
			return await GetDriveRoot(drive.Id);
		}
	}
}