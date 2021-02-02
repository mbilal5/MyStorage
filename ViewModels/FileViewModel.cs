using Microsoft.Graph;

namespace MyStorage.ViewModels
{
	public class FileViewModel : DriveItemViewModel
	{
		public Microsoft.Graph.File File { get; set; }
		public string WebUrl { get; set; }

		public FileViewModel(DriveItem item)
		{
			Id = item.Id;
			Name = item.Name;
			ParentReference = item.ParentReference;
			LastModifiedDateTime = item.LastModifiedDateTime;
			File = item.File;
			WebUrl = item.WebUrl;
			ItemType = ItemType.File;
		}

		public FileViewModel(DriveItem item, string driveId) : this(item)
		{
			DriveId = driveId;
		}
	}
}