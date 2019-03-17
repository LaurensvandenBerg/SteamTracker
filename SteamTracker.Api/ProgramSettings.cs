using Microsoft.Extensions.Configuration;
using SteamTracker.Api.Settings;
using SteamTracker.Common.Settings;
using System.Collections.Generic;
using System.Linq;

namespace SteamTracker.Api
{
	/// <summary>
	/// Settings Collection class
	/// </summary>
	public class ProgramSettings :
		ISwaggerSettings,
		ICorsSettings,
		IMySqlSettings
	{
		private readonly IConfiguration _configuration;

		/// <summary>
		/// Constructor providing configuration object which contains the settings
		/// </summary>
		/// <param name="configuration"> configuration which contains the app settings</param>
		public ProgramSettings(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		IEnumerable<string> ICorsSettings.Origins => GetCorsOrigins();

		bool ISwaggerSettings.EnableSwagger =>
			bool.Parse(_configuration["SteamTracker:Api:EnableSwagger"]);

		private IEnumerable<string> GetCorsOrigins()
		{
			var origins = _configuration["SteamTracker:Api:Cors:Origins"];
			return string.IsNullOrWhiteSpace(origins)
				? new string[0]
				: origins.Split(',').Select(x => x.Trim(' ')).ToArray();
		}

		string IMySqlSettings.ConnectionString =>
			_configuration["SteamTracker:Database:ConnectionString"].ToString();
	}
}
