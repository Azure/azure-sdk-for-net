﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Moq;
using OpenTelemetry.Trace;
using System;
using System.Diagnostics;
using System.Reflection;

using Xunit;

namespace OpenTelemetry.Exporter.AzureMonitor
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
            Assert.Equal(ConnectionString.Constants.DefaultIngestionEndpoint, endpoint);
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

        private void GetInternalFields(AzureMonitorTraceExporter exporter, out string ikey, out string endpoint)
        {
            // TODO: NEED A BETTER APPROACH FOR TESTING. WE DECIDED AGAINST MAKING FIELDS "internal".
            // instrumentationKey: AzureMonitorTraceExporter.AzureMonitorTransmitter.instrumentationKey
            // endpoint: AzureMonitorTraceExporter.AzureMonitorTransmitter.ServiceRestClient.endpoint

            var transmitter = typeof(AzureMonitorTraceExporter)
                .GetField("AzureMonitorTransmitter", BindingFlags.Instance | BindingFlags.NonPublic)
                .GetValue(exporter);

            ikey = typeof(AzureMonitorTransmitter)
                .GetField("instrumentationKey", BindingFlags.Instance | BindingFlags.NonPublic)
                .GetValue(transmitter)
                .ToString();

            var serviceRestClient = typeof(AzureMonitorTransmitter)
                .GetField("serviceRestClient", BindingFlags.Instance | BindingFlags.NonPublic)
                .GetValue(transmitter);

            endpoint = typeof(ApplicationInsightsRestClient)
                .GetField("endpoint", BindingFlags.Instance | BindingFlags.NonPublic)
                .GetValue(serviceRestClient)
                .ToString();
        }
    }
}
