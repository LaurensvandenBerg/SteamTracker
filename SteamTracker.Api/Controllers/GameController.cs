using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SteamTracker.Data.Models;
using SteamTracker.Domain.Interfaces;

namespace SteamTracker.Api.Controllers
{
	/// <summary>
	/// Controller for all game related information
	/// </summary>
	[Route("api/games")]
    [ApiController]
    public class GameController : ControllerBase
    {
		private readonly IGameRepository games;

		/// <summary>
		/// Constructor used for injecting <see cref="IGameRepository"/>
		/// </summary>
		/// <param name="games">provides a connection to the data layer of <see cref="Game"/></param>
		public GameController(IGameRepository games)
		{
			this.games = games;
		}

		/// <summary>
		/// Get a single <see cref="Game"/> from the SteamTracker database
		/// </summary>
		/// <param name="id">This id serves as a unique identifier for the game search</param>
		/// <returns></returns>
		[HttpGet]
		[Route("{id}")]
		public async Task<Game> GetBy(int id)
		{
			return await games.GetBy(id);
		}
	}
}
