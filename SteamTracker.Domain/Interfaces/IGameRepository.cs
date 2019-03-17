using SteamTracker.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SteamTracker.Domain.Interfaces
{
	public interface IGameRepository
	{
		Task<IEnumerable<Game>> GetAll();
		Task<Game> GetBy(int id);
		Task StoreInformationOf(Game game);
	}
}
