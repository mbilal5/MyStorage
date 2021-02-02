using System.Threading.Tasks;
using MyStorage.Data.Entities;

namespace MyStorage.Data.Services.Explorers
{
	public interface IDriveExplorer
	{
		Task<StorageDrive> GetDrive(string id);
		Task<StorageDrive> GetUserDrive();
		Task<StorageDrive> GetDriveByName(string name);
	}
}