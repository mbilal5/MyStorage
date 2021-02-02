using Microsoft.Graph;
using MyStorage.Data.Tests.Factories;

namespace MyStorage.Data.Tests.Fixtures
{
	public class GraphServiceClientFixture
	{
		public GraphServiceClient GraphServiceClient { get; private set; }

		public GraphServiceClientFixture()
		{
			var azureConfig = Configuration.Instance.GetSection("AzureAd");
			var clientId = azureConfig["ClientId"];
			var clientSecret = Configuration.Instance["ClientSecret"];
			var tenantId = azureConfig["TenantId"];
			var authority = azureConfig["Authority"];
			var clientApplication = ClientApplicationFactory.CreateConfidentialClient(clientId, clientSecret, tenantId);
			GraphServiceClient = GraphServiceClientFactory.Create(clientApplication);
		}
	}
}