using System.Net.Http.Headers;
using Microsoft.Graph;
using Microsoft.Identity.Client;

namespace MyStorage.Data.Tests.Factories
{
	public class GraphServiceClientFactory
	{
		public static GraphServiceClient Create(IConfidentialClientApplication client)
		{
			var graphClient = new GraphServiceClient(new DelegateAuthenticationProvider(async request =>
			{
				var token = await client.AcquireTokenForClient(new string[] { "https://graph.microsoft.com/.default" })
					.ExecuteAsync();
				request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token.AccessToken);
			}));
			return graphClient;
		}
	}
}