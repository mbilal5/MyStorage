using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Identity.Web;
using Project.Extensions;


namespace Project
{
	public class Startup
	{
		private readonly IConfiguration _configuration;


		public Startup(IConfiguration configuration)
		{
			_configuration = configuration;
			var clientSecret = _configuration["ClientSecret"]; // retrieved from SecretsManager
			_configuration.GetSection("AzureAD")["ClientSecret"] = clientSecret;
		}

		public void ConfigureServices(IServiceCollection services)
		{
			var scopes = new[] { "https://graph.microsoft.com/.default" };
			services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
				.AddMicrosoftIdentityWebApp(_configuration)
				.EnableTokenAcquisitionToCallDownstreamApi(initialScopes: scopes)
				.AddInMemoryTokenCaches();

			services.AddGraphServiceClient();
			
			services.AddControllersWithViews(options =>
			{
				var policy = new AuthorizationPolicyBuilder()
					.RequireAuthenticatedUser()
					.Build();
				options.Filters.Add(new AuthorizeFilter(policy));
			})
				.AddRazorRuntimeCompilation();
		}

		public void Configure(IApplicationBuilder app)
		{
			app.UseDeveloperExceptionPage();
			app.UseHttpsRedirection();
			app.UseStaticFiles();
			app.UseRouting();
			app.UseAuthentication();
			app.UseAuthorization();
			app.UseEndpoints(endpoints =>
			{
				endpoints.MapDefaultControllerRoute();
			});
		}
	}
}