using Microsoft.Graph;

namespace Project.ViewModels
{
	public class FolderViewModel : DriveItemViewModel
	{
		public Microsoft.Graph.Folder Folder { get; set; }
		
		
		public FolderViewModel(DriveItem item)
		{
			Id = item.Id;
			Name = item.Name;
			ParentReference = item.ParentReference;
			LastModifiedDateTime = item.LastModifiedDateTime;
			Folder = item.Folder;
			ItemType = ItemType.Folder;
		}
	}
}