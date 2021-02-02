using System;
using Microsoft.Graph;

namespace MyStorage.ViewModels
{
	public class DriveItemViewModel
	{
		public string Id { get; set; }
		public string DriveId { get; set; }
		public string Name { get; set; }
		public ItemReference ParentReference { get; set; }
		public DateTimeOffset? LastModifiedDateTime { get; set; }
		public ItemType ItemType { get; set; }
		
		
		protected DriveItemViewModel() { }

		public static DriveItemViewModel Create(DriveItem item)
		{
			if (item.File != null)
			{
				return new FileViewModel(item);
			}
			else
			{
				return new FolderViewModel(item);
			}

		}

		public static DriveItemViewModel Create(DriveItem item, string driveId)
		{
			var model = Create(item);
			model.DriveId = driveId;
			return model;
		}

	}

	public enum ItemType
	{
		File,
		Folder
	}
}