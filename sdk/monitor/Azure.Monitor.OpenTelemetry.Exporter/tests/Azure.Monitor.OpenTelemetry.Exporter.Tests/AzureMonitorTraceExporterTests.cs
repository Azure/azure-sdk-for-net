// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable // TODO: remove and fix errors

using OpenTelemetry.Trace;
using System;
using System.Reflection;

using Azure.Monitor.OpenTelemetry.Exporter.Internals.ConnectionString;

using Xunit;
using Azure.Monitor.OpenTelemetry.Exporter.Internals;

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

            GetInternalFields(exporter, out string ikey, out string endpoint);
            Assert.Equal(testIkey, ikey);
            Assert.Equal(testEndpoint, endpoint);
        }

        [Fact]
        public void VerifyConnectionString_CorrectlySetsDefaultEndpoint()
        {
            var testIkey = "test_ikey";

            var exporter = new AzureMonitorTraceExporter(new AzureMonitorExporterOptions { ConnectionString = $"InstrumentationKey={testIkey};" });

            GetInternalFields(exporter, out string ikey, out string endpoint);
            Assert.Equal(testIkey, ikey);
            Assert.Equal(Constants.DefaultIngestionEndpoint, endpoint);
        }

        [Fact]
        public void VerifyConnectionString_ThrowsExceptionWhenInvalid()
        {
            Assert.Throws<InvalidOperationException>(() => new AzureMonitorTraceExporter(new AzureMonitorExporterOptions { ConnectionString = null }));
        }

        [Fact]
        public void VerifyConnectionString_ThrowsExceptionWhenMissingInstrumentationKey()
        {
            var testEndpoint = "https://www.bing.com/";

            Assert.Throws<InvalidOperationException>(() => new AzureMonitorTraceExporter(new AzureMonitorExporterOptions { ConnectionString = $"IngestionEndpoint={testEndpoint}" }));
        }

        [Fact]
        public void AzureMonitorExporter_BadArgs()
        {
            TracerProviderBuilder builder = null;
            Assert.Throws<ArgumentNullException>(() => builder.AddAzureMonitorTraceExporter());
        }

        private void GetInternalFields(AzureMonitorTraceExporter exporter, out string ikey, out string endpoint)
        {
            // TODO: NEED A BETTER APPROACH FOR TESTING. WE DECIDED AGAINST MAKING FIELDS "internal".
            // instrumentationKey: AzureMonitorTraceExporter.AzureMonitorTransmitter.instrumentationKey
            // endpoint: AzureMonitorTraceExporter.AzureMonitorTransmitter.ServiceRestClient.endpoint

            ikey = typeof(AzureMonitorTraceExporter)
                .GetField("_instrumentationKey", BindingFlags.Instance | BindingFlags.NonPublic)
                .GetValue(exporter)
                .ToString();

            var transmitter = typeof(AzureMonitorTraceExporter)
                .GetField("_transmitter", BindingFlags.Instance | BindingFlags.NonPublic)
                .GetValue(exporter);

            var serviceRestClient = typeof(AzureMonitorTransmitter)
                .GetField("_applicationInsightsRestClient", BindingFlags.Instance | BindingFlags.NonPublic)
                .GetValue(transmitter);

            endpoint = typeof(ApplicationInsightsRestClient)
                .GetField("_host", BindingFlags.Instance | BindingFlags.NonPublic)
                .GetValue(serviceRestClient)
                .ToString();
        }
    }
}
