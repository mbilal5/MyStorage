using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Graph;
using Microsoft.Identity.Web;

namespace MyStorage.Controllers
{
	[Authorize]
	[AuthorizeForScopes]
	public class HomeController : Controller
	{
		private readonly GraphServiceClient _client;
		
		
		public HomeController(GraphServiceClient client)
		{
			_client = client;
		}
		
		public async Task<IActionResult> Index()
		{
			var user = await _client.Me.Request().GetAsync();
			return View("Index", user.DisplayName);
		}
	}
}