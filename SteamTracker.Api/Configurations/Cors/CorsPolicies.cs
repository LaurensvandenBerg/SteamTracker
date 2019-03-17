namespace SteamTracker.Api.Configurations.Cors
{
	/// <summary>
	/// Class containing static Cors policies.
	/// </summary>
	public static class CorsPolicies
	{
		/// <summary>
		/// Policy to allow all external origins
		/// </summary>
		public const string AllowAllOrigins = "AllowAllOrigins";

		/// <summary>
		/// Policy to only allow a specific set of external origins
		/// </summary>
		public const string AllowSpecificOrigins = "AllowSpecificOrigins";
	}
}
