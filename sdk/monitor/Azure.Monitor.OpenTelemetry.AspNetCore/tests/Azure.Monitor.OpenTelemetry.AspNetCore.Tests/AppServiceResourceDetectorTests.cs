// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using OpenTelemetry.Resources;
using OpenTelemetry.Resources.Azure;
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
            string? previousOtelServiceName = Environment.GetEnvironmentVariable(ResourceAttributeConstants.OpenTelemetryServiceNameEnvVar);
            string? previousAppServiceSiteName = Environment.GetEnvironmentVariable(ResourceAttributeConstants.AppServiceSiteNameEnvVar);

            try
            {
                Environment.SetEnvironmentVariable(ResourceAttributeConstants.OpenTelemetryServiceNameEnvVar, otelServiceName);
                Environment.SetEnvironmentVariable(ResourceAttributeConstants.AppServiceSiteNameEnvVar, appServiceSiteName);

                var resource = ResourceBuilder.CreateDefault()
                    .AddDetector(new AppServiceResourceDetector())
                    .Build();

                Assert.Equal(
                    otelServiceName,
                    resource.Attributes.Single(attribute => attribute.Key == "service.name").Value);
                Assert.Contains(
                    resource.Attributes,
                    attribute => attribute.Key == "cloud.platform" &&
                        (string)attribute.Value == ResourceAttributeConstants.AzureAppServicePlatformValue);
            }
            finally
            {
                Environment.SetEnvironmentVariable(ResourceAttributeConstants.OpenTelemetryServiceNameEnvVar, previousOtelServiceName);
                Environment.SetEnvironmentVariable(ResourceAttributeConstants.AppServiceSiteNameEnvVar, previousAppServiceSiteName);
            }
        }
    }
}
