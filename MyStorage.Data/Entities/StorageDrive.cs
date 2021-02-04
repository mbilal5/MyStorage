using Microsoft.Graph;

namespace MyStorage.Data.Entities
{
	public class StorageDrive
	{
		public string Id { get; set; }
		public string Name { get; set; }
		
		public StorageDrive() { }
		
		public StorageDrive(Drive drive)
		{
			Id = drive.Id;
			Name = drive.Name;
		}
	}
}