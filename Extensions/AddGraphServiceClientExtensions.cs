using System.Net.Http.Headers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Graph;
using Microsoft.Identity.Web;

namespace Project.Extensions
{
	public static class AddGraphServiceClientExtensions
	{
		public static void AddGraphServiceClient(this IServiceCollection services)
		{
			services.AddScoped<GraphServiceClient>(services =>
			{
				var tokenAcquisition = services.GetService<ITokenAcquisition>();
				var scopes = new[] { "https://graph.microsoft.com/.default" };
				var graphServiceClient = new GraphServiceClient(new DelegateAuthenticationProvider(async request =>
				{
					var token = await tokenAcquisition.GetAuthenticationResultForUserAsync(scopes);
					request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token.AccessToken);
				}));
				return graphServiceClient;
			});
		}
	}
}