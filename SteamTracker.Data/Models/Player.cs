using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SteamTracker.Data.Models
{
	public class Player
	{
		[Key]
		public string Id { get; set; }

		[Required]
		public int GameCount { get; set; }
		
		public IEnumerable<OwnerShip> Owns { get; set; }
	}
}
