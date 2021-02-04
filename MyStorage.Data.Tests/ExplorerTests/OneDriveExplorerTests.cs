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
	}
}