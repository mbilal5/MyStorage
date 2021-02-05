using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyStorage.Data.Entities;

namespace MyStorage.Data.Services.Explorers
{
	public interface IDriveExplorer
	{
		Task<StorageDrive> GetDrive(string id);
		Task<StorageDrive> GetUserDrive();
		Task<StorageDrive> GetUserDrive(string id);
		Task<StorageDrive> GetDriveByName(string name);
		Task<IEnumerable<StorageDrive>> GetDrives();
	}
}