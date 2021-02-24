using System;
using CodeFuller.MusicFeed.ApplicationInsights.Extensions;
using Microsoft.ApplicationInsights.Channel;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.Extensions.Options;

namespace CodeFuller.MusicFeed.ApplicationInsights.Internal
{
	internal class CloudRoleNameTelemetryInitializer : ITelemetryInitializer
	{
		private readonly ApplicationInsightsSettings settings;

		public CloudRoleNameTelemetryInitializer(IOptions<ApplicationInsightsSettings> options)
		{
			this.settings = options?.Value ?? throw new ArgumentNullException(nameof(options));
		}

		public void Initialize(ITelemetry telemetry)
		{
			telemetry.Enrich(settings);
		}
	}
}
