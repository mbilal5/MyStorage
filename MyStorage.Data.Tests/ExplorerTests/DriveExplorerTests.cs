using System;
using System.Threading.Tasks;
using Microsoft.Graph;
using MyStorage.Data.Tests.Fixtures;
using Xunit;
using Xunit.Abstractions;

namespace MyStorage.Data.Tests.ExplorerTests
{
	public class DriveExplorerTests : IClassFixture<GraphServiceClientFixture>
	{
		private readonly GraphServiceClient _client;
		
		
		public DriveExplorerTests(GraphServiceClientFixture fixture)
		{
			_client = fixture.GraphServiceClient;
		}
		
		[Fact]
		public async Task GetDrivesReturnsNonEmptyCollection()
		{
			var drives = await _client.Drives.Request().GetAsync();
			Assert.True(drives.Count > 0);
		}
	}
}