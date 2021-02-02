using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Graph;
using Microsoft.Identity.Web;
using MyStorage.Services;
using MyStorage.ViewModels;


namespace MyStorage.Controllers
{
	[Authorize]
	[AuthorizeForScopes]
	public class DrivesController : Controller
	{
		private readonly GraphServiceClient _client;
		private readonly OneDriveExplorer _explorer;
		

		public DrivesController(GraphServiceClient client, OneDriveExplorer explorer)
		{
			_client = client;
			_explorer = explorer;
		}

		public async Task<IActionResult> Index()
		{
			var drives = await _explorer.GetDrives();
			var models = drives.Select(drive => new DriveViewModel(drive));
			return View(models);
		}
		
		[Route("/[controller]/{name}")]
		public async Task<IActionResult> Index(string name)
		{
			var drive = await _explorer.GetDriveByName(name);
			ViewBag.DriveName = name;
			var children = await _explorer.GetDriveRoot(drive.Id);
			var items = children.Select(item => DriveItemViewModel.Create(item, drive.Id));
			return View("Folder", items);
		}
		
		[Route("/[controller]/{name}/{id}")]
		public async Task<IActionResult> Folders(string name, string id)
		{
			var drive = await _explorer.GetDriveByName(name);

			var folderItems = await _client.Me.Drives[drive.Id].Items[id].Children
				.Request()
				.GetAsync();

			var models = folderItems.Select(item => DriveItemViewModel.Create(item, drive.Id));
			return View("Folder", models);
		}

		[Route("/[controller]/download/{driveId}/{fileId}")]
		public async Task<IActionResult> DownloadFile(string driveId, string fileId)
		{
			var file = await _client.Drives[driveId].Items[fileId]
				.Request()
				.GetAsync();
			
			var content = await _client.Drives[driveId].Items[fileId].Content
				.Request()
				.GetAsync();
			
			return File(content, file.File.MimeType, file.Name);
		}
	}
}