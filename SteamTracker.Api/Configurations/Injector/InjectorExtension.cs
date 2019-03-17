using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using SteamTracker.Api.Configurations.Validation;
using SteamTracker.Domain.Interfaces;
using SteamTracker.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SteamTracker.Api.Configurations.Injector
{
	/// <summary>
	/// Extensions for the service injector
	/// </summary>
	public static class InjectorExtension
	{
		/// <summary>
		/// Register all namespace types for services
		/// </summary>
		/// <param name="services"></param>
		/// <param name="exclude"></param>
		/// <returns></returns>
		public static IServiceCollection RegisterNamespaceTypes(this IServiceCollection services, params Type[] exclude)
		{
			if (services == null) throw new ArgumentNullException(nameof(services));
			if (exclude == null) throw new ArgumentNullException(nameof(exclude));
			return RegisterAll(services, new HashSet<Type>(exclude));
		}

		/// <summary>
		/// Register all remaining services to the service collection
		/// </summary>
		/// <param name="services">the service collection to which the services will be added</param>
		/// <returns>the servicecollection with the newly added services</returns>
		public static IServiceCollection RegisterAll(this IServiceCollection services)
		{
			//Needed to ensure all assemblies are loaded
			var neededReferences = new List<Type>()
			{
				typeof(GameRepository)
			};
			GetNamespaceAssemblies(services).ToArray();

			return services
				.RegisterNamespaceTypes()
				.RegisterValidators()
				.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
		}

		/// <summary>
		/// Forced loading of all assemblies in namespace to ensure all are instantiated
		/// </summary>
		/// <param name="services">service object which provided the referenced namespace</param>
		/// <returns>nothing, assembly enumerable is to force loading assemblies</returns>
		public static IEnumerable<Assembly> GetNamespaceAssemblies(IServiceCollection services)
		{
			var hashset = new HashSet<string>();
			var executingAssembly = Assembly.GetExecutingAssembly();
			hashset.Add(executingAssembly.FullName);
			foreach (var assemblyName in executingAssembly.GetReferencedAssemblies())
				hashset.Add(assemblyName.FullName);

			foreach (var assemblyName in hashset)
			{
				var prefix = executingAssembly.GetName().Name.Split('.').First();
				if (!assemblyName.StartsWith(prefix)) continue;
				yield return Assembly.Load(assemblyName);
			}
		}

		private static IServiceCollection RegisterAll(IServiceCollection services, ICollection<Type> exclude)
		{
			var prefix = Assembly.GetExecutingAssembly().GetName().Name.Split('.').First();

			var assemblies = (
				from x in AppDomain.CurrentDomain.GetAssemblies()
				where x.GetName().Name.StartsWith(prefix)
				select x
			).ToArray();

			foreach (var assembly in assemblies)
			{
				var concreteTypes = (
					from x in assembly.GetTypes()
					where !exclude.Contains(x)
					where !x.IsInterface
					where x.GetInterfaces().Length > 0
					select x
				).ToArray();

				foreach (var type in concreteTypes)
				{
					var interfaces = (
						from x in type.GetInterfaces()
						where x.Assembly.GetName().Name.StartsWith(prefix)
						where !exclude.Contains(x)
						select x
					).ToArray();
					foreach (var @interface in interfaces) services.AddSingleton(@interface, type);
				}
			}

			return services;
		}
	}
}
