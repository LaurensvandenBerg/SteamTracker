using SteamTracker.Common.Settings;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace SteamTracker.Api.Infrastructure.Database.DAL
{
	public class MySqlConnectionProvider : IMySqlConnection
	{
		private readonly IMySqlSettings databaseSettings;

		public MySqlConnectionProvider(IMySqlSettings databaseSettings)
		{
			this.databaseSettings = databaseSettings;
		}

		public async Task<IDbConnection> GetAsync()
		{
			return await GetConnectionAsync(databaseSettings.ConnectionString);
		}

		private async Task<IDbConnection> GetConnectionAsync(string connectionString)
		{
			if (connectionString == null) throw new ArgumentNullException(nameof(connectionString));
			var connection = new SqlConnection(connectionString);
			await connection.OpenAsync();
			return connection;
		}
	}
}
