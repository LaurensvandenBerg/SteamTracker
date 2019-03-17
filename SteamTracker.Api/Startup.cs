using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SteamTracker.Api.Configurations.Cors;
using SteamTracker.Api.Configurations.Injector;
using SteamTracker.Api.Configurations.Mvc;
using SteamTracker.Api.Configurations.Swagger;

namespace SteamTracker.Api
{
	public class Startup
	{
		/// <summary>
		/// Constructor providing app settings to application
		/// </summary>
		/// <param name="configuration">configuration object providing settings to the application</param>
		public Startup(IConfiguration configuration) => Configuration = configuration;

		/// <summary>
		/// Configuration object containing settings, available throughout the application
		/// </summary>
		public IConfiguration Configuration { get; }

		/// <summary>
		/// Registrator of services provided to the web application
		/// </summary>
		/// <param name="services">services collection containing all the configured services</param>
		public void ConfigureServices(IServiceCollection services)
		{
			services.RegisterAll();

			services.AddCorsPolicies();
			services.AddMyMvc();
			services.AddMySwagger();
		}

		/// <summary>
		/// Add application blocks to the web application
		/// </summary>
		/// <param name="app">Container and provider for the application blocks</param>
		/// <param name="env">Environment information containing build settings</param>
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			app.Use(async (context, next) =>
			{
				context.Request.EnableBuffering();
				await next();
			});
			if (env.IsDevelopment())
				app.UseDeveloperExceptionPage();
			else
				app.UseHsts();

			app.UseStaticFiles();
			app.UseHttpsRedirection();
			app.UseMyCors();
			app.UseMySwagger();
			app.UseMvc();
		}
	}
}
