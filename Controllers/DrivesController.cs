using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Graph;
using Microsoft.Identity.Web;
using Project.ViewModels;


namespace Project.Controllers
{
	[Authorize]
	[AuthorizeForScopes]
	public class DrivesController : Controller
	{
		private readonly GraphServiceClient _client;
		
		
		public DrivesController(GraphServiceClient client)
		{
			_client = client;
		}

		public async Task<IActionResult> Index()
		{
			var drives = await _client.Me.Drives.Request().GetAsync();
			var models = drives.Select(drive => new DriveViewModel(drive));
			return View(models);
		}
	}
}