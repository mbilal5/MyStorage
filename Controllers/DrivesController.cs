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
		
		[Route("/[controller]/{name}")]
		public async Task<IActionResult> Index(string name)
		{
			var drive = await _client.Me.Drives
				.Request()
				.Filter($"name eq '{name}'")
				.GetAsync();
			ViewBag.DriveName = name;
			var children = await _client.Me.Drives[drive[0].Id].Root.Children
				.Request()
				.GetAsync();
			var items = children.Select(item => DriveItemViewModel.Create(item));
			
			return View("Folder", items);
		}
	}
}