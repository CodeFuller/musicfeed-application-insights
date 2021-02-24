using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeFuller.MusicFeed.ApplicationInsights.UnitTests
{
	[TestClass]
	public class ServiceCollectionExtensionsTests
	{
		[TestMethod]
		public void AddApplicationInsights_SetsSettingsForCustomTraceTelemetryConverter()
		{
			// Arrange

			var servicesStub = new ServiceCollection();

			// Act

			servicesStub.AddApplicationInsights(settings => settings.CloudRoleName = "Some Role");

			// Assert

			Assert.IsNotNull(CustomTraceTelemetryConverter.Settings);
			Assert.AreEqual("Some Role", CustomTraceTelemetryConverter.Settings.CloudRoleName);
		}
	}
}
