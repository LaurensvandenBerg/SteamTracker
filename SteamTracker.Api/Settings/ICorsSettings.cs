using System.Collections.Generic;
namespace SteamTracker.Api.Settings
{
	/// <summary>
	/// Universal Cors settings provider
	/// </summary>
	public interface ICorsSettings
	{
		/// <summary>
		/// List of accepted origins
		/// </summary>
		IEnumerable<string> Origins { get; }
	}
}
