// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Monitor.OpenTelemetry.Exporter.Internals;
using Azure.Monitor.OpenTelemetry.Exporter.Tests.CommonTestFramework;
using Xunit;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests
{
    public class TransmitterFactoryTests
    {
        /// <summary>
        /// Users may not specify their connection string in the <see cref="AzureMonitorExporterOptions"/>.
        /// In this scenario, the sdk would use the environment variable.
        ///
        /// This test confirms that the factory correctly handles a null value.
        /// </summary>
        [Fact]
        public void VerifyNullConnectionString()
        {
            var factory = new TransmitterFactory();
            var options = new AzureMonitorExporterOptions() { ConnectionString = null };

            var mockPlatform = new MockPlatform();
            mockPlatform.SetEnvironmentVariable("APPLICATIONINSIGHTS_CONNECTION_STRING", "InstrumentationKey=00000000-0000-0000-0000-000000000000;");

            var transmitter = factory.Get(options, mockPlatform);

            Assert.Single(factory._transmitters);
            Assert.True(factory._transmitters.ContainsKey(string.Empty));
        }

        [Fact]
        public void VerifyRepeatedCallsGenerateOnlyOneTransmitter()
        {
            var factory = new TransmitterFactory();
            var options = new AzureMonitorExporterOptions { ConnectionString = "InstrumentationKey=00000000-0000-0000-0000-000000000000;" };

            var transmitter1 = factory.Get(options);
            var transmitter2 = factory.Get(options);

            Assert.Single(factory._transmitters);
            Assert.True(factory._transmitters.ContainsKey(options.ConnectionString));
            Assert.Equal(transmitter1, transmitter2);
        }
    }
}
