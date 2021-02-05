using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Graph;
using MyStorage.Data.Services.Explorers;
using MyStorage.Data.Tests.Fixtures;
using Xunit;
using Xunit.Abstractions;

namespace MyStorage.Data.Tests.ExplorerTests
{
	public class OneDriveExplorerTests : IClassFixture<GraphServiceClientFixture>
	{
		private readonly GraphServiceClient _client;
		private readonly OneDriveExplorer _explorer;

		public OneDriveExplorerTests(GraphServiceClientFixture fixture)
		{
			_client = fixture.GraphServiceClient;
			_explorer = new OneDriveExplorer(_client);
		}
		
		[Fact]
		public async Task GetDrivesReturnsNonEmptyCollection()
		{
			var drives = await _explorer.GetDrives();
			Assert.True(drives.Count() > 0);
		}

		[Fact]
		public async Task GetDriveByIdReturnsDrive()
		{
			// Id of a known OneDrive drive in my developer tenant.
			string driveId = "b!wI6hmZwqZkS8M88Bsgbp5uwhD_Lv9Y9OiyhZIqo2y9RPgzYZ8aH4Rrh64WbIs-1P";
			
			var drive = await _explorer.GetDrive(driveId);
			
			Assert.Equal(driveId, drive.Id);
		}
		
		[Fact]
		public async Task GetDriveByNameReturnsNamedDrive()
		{
			string driveId = "b!wI6hmZwqZkS8M88Bsgbp5uwhD_Lv9Y9OiyhZIqo2y9RPgzYZ8aH4Rrh64WbIs-1P";
			var drive = await _explorer.GetDrive(driveId);

			var result = await _explorer.GetDriveByName(drive.Name);

			Assert.Equal(drive.Name, result.Name);
			Assert.Equal(drive.Id, result.Id);
		}
	}
}