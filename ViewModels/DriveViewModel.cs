using Microsoft.Graph;

namespace MyStorage.ViewModels
{
	public class DriveViewModel
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string WebUrl { get; set; }
		public string DriveType { get; set; }

		public DriveViewModel(Drive drive)
		{
			Id = drive.Id;
			Name = drive.Name;
			WebUrl = drive.WebUrl;
			DriveType = drive.DriveType;
			Description = drive.Description;
		}
	}
}