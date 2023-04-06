// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Monitor.OpenTelemetry.Exporter.Internals;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.ConnectionString;
using Azure.Monitor.OpenTelemetry.Exporter.Tests.CommonTestFramework;
using Xunit;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests
{
    public class AzureMonitorTransmitterTests
    {
        [Theory]
        [InlineData("InstrumentationKey=001", null, "001")] // Options Only
        [InlineData(null, "InstrumentationKey=002", "002")] // Env Var Only
        [InlineData("InstrumentationKey=001", "InstrumentationKey=002", "001")] // If both set, Options will be used.
        public void Verify_InitializeConnectionVars(string? optionsConnStr, string? envVarConnStr, string expectedIkey)
        {
            var options = new AzureMonitorExporterOptions();
            if (optionsConnStr != null)
            {
                options.ConnectionString = optionsConnStr;
            }

            var platform = new MockPlatform();
            if (envVarConnStr != null)
            {
                platform.SetEnvironmentVariable("APPLICATIONINSIGHTS_CONNECTION_STRING", envVarConnStr);
            }

            var connectionVars = AzureMonitorTransmitter.InitializeConnectionVars(options, platform);

            Assert.Equal(expectedIkey, connectionVars.InstrumentationKey);
        }

        [Theory]
        [InlineData(false, null, false)] // Disable via Options overrides all other settings.
        [InlineData(false, false, false)] // Disable via Options overrides all other settings.
        [InlineData(false, true, false)] // Disable via Options overrides all other settings.
        [InlineData(true, null, true)]
        [InlineData(true, false, false)] // Enable via Options can be overridden by env var.
        [InlineData(true, true, true)]
        public void Verify_InitializeStatsbeat(bool optionsEnableStatsbeat, bool? enVarEnableStatsbeat, bool shouldInitialize)
        {
            var options = new AzureMonitorExporterOptions
            {
                EnableStatsbeat = optionsEnableStatsbeat,
            };

            var platform = new MockPlatform();
            if (enVarEnableStatsbeat != null)
            {
                platform.SetEnvironmentVariable("APPLICATIONINSIGHTS_STATSBEAT_DISABLED", (bool)enVarEnableStatsbeat ? "false" : "true");
            }

            var connectionVars = new ConnectionVars("0000", "https://westus.test.azure.com", null);
            var statsbeat = AzureMonitorTransmitter.InitializeStatsbeat(options, connectionVars, platform, new MockVmMetadataProvider());

            if (shouldInitialize)
            {
                Assert.NotNull(statsbeat);
            }
            else
            {
                Assert.Null(statsbeat);
            }
        }
    }
}
