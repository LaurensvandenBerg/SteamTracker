using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;

namespace SteamTracker.Api.Configurations.Mvc
{
	/// <summary>
	/// Extension for all Mvc behaviour
	/// </summary>
	public static class MvcExtensions
	{
		/// <summary>
		/// Add Mvc settings to the service collection
		/// </summary>
		/// <param name="services">service collection to which the mvc settings will be added</param>
		/// <returns>service collection with mvc settings</returns>
		public static IServiceCollection AddMyMvc(this IServiceCollection services)
		{
			services
				.AddMvc()
				.SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
				.AddJsonOptions(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver())
				.AddFluentValidation();
			return services;
		}
	}
}
