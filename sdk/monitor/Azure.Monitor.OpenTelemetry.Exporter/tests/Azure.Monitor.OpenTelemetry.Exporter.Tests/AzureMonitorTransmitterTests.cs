// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Monitor.OpenTelemetry.Exporter.Internals;
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

        [Fact]
        public void VerifyConnectionString_ThrowsExceptionWhenInvalid()
        {
            Assert.Throws<InvalidOperationException>(() => new AzureMonitorTransmitter(new AzureMonitorExporterOptions { ConnectionString = null }, new MockPlatform()));
        }

        [Fact]
        public void VerifyConnectionString_ThrowsExceptionWhenMissingInstrumentationKey()
        {
            var testEndpoint = "https://www.bing.com/";

            Assert.Throws<InvalidOperationException>(() => new AzureMonitorTransmitter(new AzureMonitorExporterOptions { ConnectionString = $"IngestionEndpoint={testEndpoint}" }, new MockPlatform()));
        }
    }
}
