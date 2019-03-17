using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SteamTracker.Data.Models
{
	public class Game
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public string Name { get; set; }
		
		public IEnumerable<OwnerShip> Players { get; set; }
	}
}
