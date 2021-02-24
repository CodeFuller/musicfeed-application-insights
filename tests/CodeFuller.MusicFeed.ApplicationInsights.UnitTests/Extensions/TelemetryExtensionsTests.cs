using CodeFuller.MusicFeed.ApplicationInsights.Extensions;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeFuller.MusicFeed.ApplicationInsights.UnitTests.Extensions
{
	[TestClass]
	public class TelemetryExtensionsTests
	{
		[TestMethod]
		public void Enrich_CloudRoleNameIsConfigured_EnrichesTelemetryWithCloudRoleName()
		{
			// Arrange

			var settings = new ApplicationInsightsSettings
			{
				CloudRoleName = "Some Role",
			};

			var telemetry = new TraceTelemetry();

			// Act

			telemetry.Enrich(settings);

			// Assert

			Assert.AreEqual("Some Role", telemetry.Context.Cloud.RoleName);
		}

		[DataRow(null)]
		[DataRow("")]
		[DataRow(" ")]
		[DataTestMethod]
		public void Enrich_CloudRoleNameIsNotConfigured_DoesNotEnrichTelemetryWithCloudRoleName(string missingValue)
		{
			// Arrange

			var settings = new ApplicationInsightsSettings
			{
				CloudRoleName = missingValue,
			};

			var telemetry = new TraceTelemetry();

			// Act

			telemetry.Enrich(settings);

			// Assert

			Assert.IsNull(telemetry.Context.Cloud.RoleName);
		}
	}
}
