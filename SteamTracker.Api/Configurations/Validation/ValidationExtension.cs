using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace SteamTracker.Api.Configurations.Validation
{
	/// <summary>
	/// Collection of extension methods used for validators
	/// </summary>
	public static class ValidationExtension
	{
		/// <summary>
		/// Append validator services to the service collection
		/// </summary>
		/// <param name="services">Target service collection for the validator service</param>
		/// <returns>Service collection containing the validator service</returns>
		public static IServiceCollection RegisterValidators(this IServiceCollection services)
		{
			var assembly = Assembly.GetExecutingAssembly();
			var scanner = AssemblyScanner.FindValidatorsInAssembly(assembly);
			scanner.ForEach(x => services.AddSingleton(x.InterfaceType, x.ValidatorType));
			return services;
		}
	}
}
