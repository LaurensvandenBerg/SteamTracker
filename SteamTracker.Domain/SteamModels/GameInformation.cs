using SteamTracker.Data.Models;
using System.Collections.Generic;

#pragma warning disable IDE1006 // Naming Styles
namespace SteamTracker.Domain.SteamModels
{
	public class GameInformation
	{
		public string success { get; set; }
		public GameData data { get; set; }

		public Game ToGameEntity() => data.ToGameEntity();
	}

	public class GameData
	{
		public string type { get; set; }
		public string name { get; set; }
		public int steam_appid { get; set; }
		public int required_age { get; set; }
		public bool is_free { get; set; }
		public IEnumerable<int> dlc { get; set; }
		public string detailed_description { get; set; }
		public string about_the_game { get; set; }
		public string short_description { get; set; }
		public string supported_languages { get; set; }
		public string header_image { get; set; }
		public string website { get; set; }
		public PCRequirements pc_requirements { get; set; }
		public MacRequirements mac_requirements { get; set; }
		public LinuxRequirements linux_requirements { get; set; }
		public IEnumerable<string> developers { get; set; }
		public IEnumerable<string> publishers { get; set; }
		public PriceInformation price_overview { get; set; }
		public IEnumerable<int> packages { get; set; }

		public Game ToGameEntity()
		{
			return new Game()
			{
				Id = steam_appid,
				Name = name
			};
		}
	}

	public class PCRequirements
	{
		public string minimum { get; set; }
	}

	public class MacRequirements
	{
		public string minimum { get; set; }
	}

	public class LinuxRequirements
	{
		public string minimum { get; set; }
	}

	public class PriceInformation
	{
		public string currency { get; set; }
		public int initial { get; set; }
		public int final { get; set; }
		public int discount_percent { get; set; }
		public string initial_formatted { get; set; }
		public string final_formatted { get; set; }
	}
}
