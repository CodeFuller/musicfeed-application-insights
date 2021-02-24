using System;
using CodeFuller.MusicFeed.ApplicationInsights.Internal;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.Extensions.DependencyInjection;

namespace CodeFuller.MusicFeed.ApplicationInsights
{
	/// <summary>
	/// Extension methods for adding Application Insights monitoring.
	/// </summary>
	public static class ServiceCollectionExtensions
	{
		/// <summary>
		/// Adds services required for Application Insights monitoring.
		/// </summary>
		/// <param name="services">The <see cref="IServiceCollection"/> to add the services to.</param>
		/// <param name="setupSettings">A delegate for configuring <see cref="ApplicationInsightsSettings"/>.</param>
		/// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
		public static IServiceCollection AddApplicationInsights(this IServiceCollection services, Action<ApplicationInsightsSettings> setupSettings)
		{
			services.Configure<ApplicationInsightsSettings>(setupSettings);

			services.AddApplicationInsightsTelemetry();
			services.AddApplicationInsightsKubernetesEnricher();
			services.AddSingleton<ITelemetryInitializer, CloudRoleNameTelemetryInitializer>();

			return services;
		}
	}
}
