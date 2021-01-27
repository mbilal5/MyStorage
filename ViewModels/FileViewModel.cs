using Microsoft.Graph;

namespace Project.ViewModels
{
	public class FileViewModel : DriveItemViewModel
	{
		public Microsoft.Graph.File File { get; set; }

		public FileViewModel(DriveItem item)
		{
			Id = item.Id;
			Name = item.Name;
			ParentReference = item.ParentReference;
			LastModifiedDateTime = item.LastModifiedDateTime;
			File = item.File;
			ItemType = ItemType.File;
		}
	}
}