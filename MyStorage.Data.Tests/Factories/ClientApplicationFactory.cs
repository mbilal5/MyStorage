using System;
using Microsoft.Identity.Client;


namespace MyStorage.Data.Tests.Factories
{
	public class ClientApplicationFactory
	{
		public static IConfidentialClientApplication CreateConfidentialClient(string clientId, string clientSecret, string tenantId)
		{
			var app = ConfidentialClientApplicationBuilder.Create(clientId)
				.WithClientSecret(clientSecret)
				.WithAuthority(AadAuthorityAudience.AzureAdMyOrg)
				.WithTenantId(tenantId)
				.Build();
			
			return app;
		}
	}
}