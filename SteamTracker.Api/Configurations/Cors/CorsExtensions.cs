using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using SteamTracker.Api.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SteamTracker.Api.Configurations.Cors
{
	/// <summary>
	/// Extension for all Cors behaviour
	/// </summary>
	public static class CorsExtension
	{
		/// <summary>
		/// Add the available Cors policies to the service collection
		/// </summary>
		/// <param name="services"></param>
		public static void AddCorsPolicies(this IServiceCollection services)
		{
			if (services == null) throw new ArgumentNullException(nameof(services));
			var serviceProvider = services.BuildServiceProvider();
			var corsSettings = serviceProvider.GetService<ICorsSettings>();
			services.AddCors(options =>
			{
				options.AddPolicy(CorsPolicies.AllowAllOrigins,
					builder =>
					{
						builder.AllowAnyOrigin()
							.AllowAnyHeader()
							.AllowAnyMethod();
					});
				options.AddPolicy(CorsPolicies.AllowSpecificOrigins,
					builder =>
					{
						builder
							.WithOrigins(corsSettings.Origins.ToArray())
							.AllowAnyMethod()
							.AllowAnyHeader();
					});
			});
		}

		/// <summary>
		/// Append the Cors settings to the application builder
		/// </summary>
		/// <param name="app">the application builder to which the Cors settings will be appended</param>
		/// <returns>the application builder including the Cors settings.</returns>
		public static IApplicationBuilder UseMyCors(this IApplicationBuilder app)
		{
			var setting = app.ApplicationServices.GetService<ICorsSettings>();
			return app.UseCors(
				!setting.Origins.Any()
					? CorsPolicies.AllowAllOrigins
					: CorsPolicies.AllowSpecificOrigins
			);
		}
	}
}
