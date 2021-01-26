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
			var models = new List<DriveViewModel>();
			var drives = await _client.Drives.Request().GetAsync();
			var drive = await _client.Me.Drive.Request().GetAsync();
			models.AddRange(drives.Select(drive => new DriveViewModel(drive)));
			models.Add(new DriveViewModel(drive));
			return View(models);
		}
	}
}