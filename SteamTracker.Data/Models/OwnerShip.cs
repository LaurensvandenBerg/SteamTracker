using System.ComponentModel.DataAnnotations;

namespace SteamTracker.Data.Models
{
	public class OwnerShip
	{
		public string PlayerId { get; set; }
		public Player Player { get; set; }

		public int GameId { get; set; }
		public Game Game { get; set; }

		public int PlayTime { get; set; }
	}
}
