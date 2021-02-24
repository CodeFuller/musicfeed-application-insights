using System;
using Microsoft.ApplicationInsights.Channel;

namespace CodeFuller.MusicFeed.ApplicationInsights.Extensions
{
	internal static class TelemetryExtensions
	{
		public static ITelemetry Enrich(this ITelemetry telemetry, ApplicationInsightsSettings settings)
		{
			if (!String.IsNullOrWhiteSpace(settings.CloudRoleName))
			{
				telemetry.Context.Cloud.RoleName = settings.CloudRoleName;
			}

			return telemetry;
		}
	}
}
