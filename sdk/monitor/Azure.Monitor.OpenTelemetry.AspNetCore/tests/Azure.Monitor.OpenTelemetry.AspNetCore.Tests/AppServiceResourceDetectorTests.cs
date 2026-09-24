// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using Xunit;

namespace Azure.Monitor.OpenTelemetry.AspNetCore.Tests
{
    [Collection("ManipulatesEnvironmentVariable")]
    public class AppServiceResourceDetectorTests
    {
        [Fact]
        public void OtelServiceNameTakesPrecedenceOverAppServiceSiteName()
        {
            const string otelServiceName = "otel-service-name";
            const string appServiceSiteName = "app-service-site-name";
            const string otelServiceNameEnvironmentVariable = "OTEL_SERVICE_NAME";
            const string appServiceSiteNameEnvironmentVariable = "WEBSITE_SITE_NAME";
            string? previousOtelServiceName = Environment.GetEnvironmentVariable(otelServiceNameEnvironmentVariable);
            string? previousAppServiceSiteName = Environment.GetEnvironmentVariable(appServiceSiteNameEnvironmentVariable);

            try
            {
                Environment.SetEnvironmentVariable(otelServiceNameEnvironmentVariable, otelServiceName);
                Environment.SetEnvironmentVariable(appServiceSiteNameEnvironmentVariable, appServiceSiteName);

                var services = new ServiceCollection();
                services.AddOpenTelemetry()
                    .UseAzureMonitor(options =>
                    {
                        options.ConnectionString = "InstrumentationKey=unitTest";
                        options.EnableLiveMetrics = false;
                    });

                using var serviceProvider = services.BuildServiceProvider();
                var tracerProvider = serviceProvider.GetRequiredService<TracerProvider>();
                var resourceProperty = tracerProvider.GetType().GetProperty("Resource", BindingFlags.NonPublic | BindingFlags.Instance);
                var resource = Assert.IsType<Resource>(resourceProperty?.GetValue(tracerProvider));

                Assert.Equal(
                    otelServiceName,
                    resource.Attributes.Single(attribute => attribute.Key == "service.name").Value);
                Assert.Contains(
                    resource.Attributes,
                    attribute => attribute.Key == "cloud.platform" &&
                        (string)attribute.Value == "azure_app_service");
            }
            finally
            {
                Environment.SetEnvironmentVariable(otelServiceNameEnvironmentVariable, previousOtelServiceName);
                Environment.SetEnvironmentVariable(appServiceSiteNameEnvironmentVariable, previousAppServiceSiteName);
            }
        }
    }
}
