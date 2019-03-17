using Dapper;
using SteamTracker.Api.Infrastructure.Database.DAL;
using SteamTracker.Data.Models;
using SteamTracker.Domain.Interfaces;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace SteamTracker.Domain.Repositories
{
	public class GameRepository : IGameRepository
	{
		private readonly IMySqlConnection mySqlConnection;

		public GameRepository(IMySqlConnection mySqlConnection)
		{
			this.mySqlConnection = mySqlConnection;
		}

		public async Task<Game> GetBy(int id)
		{
			const string sql = "[stm].[p_game_get_by_id]";
			var param = new
			{
				game_id = id
			};
			using (var connection = await mySqlConnection.GetAsync())
			{
				var result = await connection.QuerySingleAsync<Game>(sql, param, commandType: CommandType.StoredProcedure);
				return result;
			}
		}

		public async Task StoreInformationOf(Game game)
		{
			const string sql = "[stm].[p_game_create]";
			var param = new
			{
				game_id = game.Id
			};
			using (var connection = await mySqlConnection.GetAsync())
			{
				await connection.ExecuteAsync(sql, param, commandType: CommandType.StoredProcedure);
			}
		}

		public async Task<IEnumerable<Game>> GetAll()
		{
			const string sql = "[stm].[p_game_get_all]";

			using (var connection = await mySqlConnection.GetAsync())
			{
				var result = await connection.QueryAsync<Game>(sql, commandType: CommandType.StoredProcedure);
				return result;
			}
		}
	}
}
