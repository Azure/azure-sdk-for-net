// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using OpenTelemetry.Trace;
using System;
using System.Reflection;

using Azure.Monitor.OpenTelemetry.Exporter.Internals;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.ConnectionString;

using Xunit;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests
{
    public class AzureMonitorTraceExporterTests
    {
        [Fact]
        public void VerifyConnectionString_CorrectlySetsEndpoint()
        {
            var testIkey = "test_ikey";
            var testEndpoint = "https://www.bing.com/";

            var exporter = new AzureMonitorTraceExporter(new AzureMonitorExporterOptions { ConnectionString = $"InstrumentationKey={testIkey};IngestionEndpoint={testEndpoint}" });

            GetInternalFields(exporter, out string? ikey, out string? endpoint);
            Assert.Equal(testIkey, ikey);
            Assert.Equal(testEndpoint, endpoint);
        }

        [Fact]
        public void VerifyConnectionString_CorrectlySetsDefaultEndpoint()
        {
            var testIkey = "test_ikey";

            var exporter = new AzureMonitorTraceExporter(new AzureMonitorExporterOptions { ConnectionString = $"InstrumentationKey={testIkey};" });

            GetInternalFields(exporter, out string? ikey, out string? endpoint);
            Assert.Equal(testIkey, ikey);
            Assert.Equal(Constants.DefaultIngestionEndpoint, endpoint);
        }

        [Fact]
        public void AzureMonitorExporter_BadArgs()
        {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            TracerProviderBuilder builder = null;
            Assert.Throws<ArgumentNullException>(() => builder!.AddAzureMonitorTraceExporter());
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
        }

        private void GetInternalFields(AzureMonitorTraceExporter exporter, out string? ikey, out string? endpoint)
        {
            // TODO: NEED A BETTER APPROACH FOR TESTING. WE DECIDED AGAINST MAKING FIELDS "internal".
            // instrumentationKey: AzureMonitorTraceExporter.AzureMonitorTransmitter.instrumentationKey
            // endpoint: AzureMonitorTraceExporter.AzureMonitorTransmitter.ServiceRestClient.endpoint

            ikey = typeof(AzureMonitorTraceExporter)
                .GetField("_instrumentationKey", BindingFlags.Instance | BindingFlags.NonPublic)
                ?.GetValue(exporter)
                ?.ToString();

            var transmitter = typeof(AzureMonitorTraceExporter)
                .GetField("_transmitter", BindingFlags.Instance | BindingFlags.NonPublic)
                ?.GetValue(exporter);

            var serviceRestClient = typeof(AzureMonitorTransmitter)
                .GetField("_applicationInsightsRestClient", BindingFlags.Instance | BindingFlags.NonPublic)
                ?.GetValue(transmitter);

            endpoint = typeof(ApplicationInsightsRestClient)
                .GetField("_host", BindingFlags.Instance | BindingFlags.NonPublic)
                ?.GetValue(serviceRestClient)
                ?.ToString();
        }
    }
}
