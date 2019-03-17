using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Swashbuckle.AspNetCore.Examples;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.IO;
using System.Reflection;

namespace SteamTracker.Api.Configurations.Swagger
{
	/// <summary>
	/// All extensions for swagger
	/// </summary>
	public static class SwaggerExtensions
	{
		/// <summary>
		/// Add swagger to the service collection
		/// </summary>
		/// <param name="services">the service collection to which swagger will be added</param>
		public static void AddMySwagger(this IServiceCollection services)
		{
			services
				.AddSwaggerGen(c =>
				{
					c.SwaggerDoc("v1", new Info { Title = "SteamTracker.Api", Version = "v1" });

					var filePath = Path.Combine(PlatformServices.Default.Application.ApplicationBasePath,
						$"{Assembly.GetExecutingAssembly().GetName().Name}.xml");
					//c.IncludeXmlComments(filePath);
					c.CustomSchemaIds(type => type.FullName);
					c.OperationFilter<ExamplesOperationFilter>();
					c.EnableAnnotations();
				});
		}

		/// <summary>
		/// Add swagger to the application builder
		/// </summary>
		/// <param name="app">the application builder to which swagger will be added</param>
		public static void UseMySwagger(this IApplicationBuilder app)
		{
			app.UseSwagger()
				.UseSwaggerUI(c =>
				{
					c.RoutePrefix = "swagger";
					c.SwaggerEndpoint("v1/swagger.json", "SteamTracker.Api v1");
					c.DocExpansion(DocExpansion.None);
				});
		}
	}
}
