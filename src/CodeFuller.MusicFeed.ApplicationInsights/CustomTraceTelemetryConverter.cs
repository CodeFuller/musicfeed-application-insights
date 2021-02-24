using System;
using System.Collections.Generic;
using System.Linq;
using CodeFuller.MusicFeed.ApplicationInsights.Extensions;
using Microsoft.ApplicationInsights.Channel;
using Serilog.Events;
using Serilog.Sinks.ApplicationInsights.Sinks.ApplicationInsights.TelemetryConverters;

namespace CodeFuller.MusicFeed.ApplicationInsights
{
	/// <summary>
	/// Wrapper over <see cref="TraceTelemetryConverter"/> for customizing instances of <see cref="ITelemetry"/>.
	/// </summary>
	public class CustomTraceTelemetryConverter : TraceTelemetryConverter
	{
		internal static ApplicationInsightsSettings Settings { get; set; }

		/// <inheritdoc cref="TraceTelemetryConverter.Convert"/>
		public override IEnumerable<ITelemetry> Convert(LogEvent logEvent, IFormatProvider formatProvider)
		{
			// https://stackoverflow.com/questions/64869536/
			// https://github.com/serilog/serilog-aspnetcore/issues/84
			return base.Convert(logEvent, formatProvider)
				.Select(telemetry => Settings != null ? telemetry.Enrich(Settings) : telemetry);
		}
	}
}
