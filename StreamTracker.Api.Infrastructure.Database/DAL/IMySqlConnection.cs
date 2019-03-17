using System.Data;
using System.Threading.Tasks;

namespace SteamTracker.Api.Infrastructure.Database.DAL
{
	public interface IMySqlConnection
	{
		Task<IDbConnection> GetAsync();
	}
}
