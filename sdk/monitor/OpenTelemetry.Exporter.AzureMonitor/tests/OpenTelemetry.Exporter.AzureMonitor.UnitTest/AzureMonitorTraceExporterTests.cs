// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Reflection;

using NUnit.Framework;

namespace OpenTelemetry.Exporter.AzureMonitor
{
    public class AzureMonitorTraceExporterTests
    {
        [Test]
        public void VerifyConnectionString_CorrectlySetsEndpoint()
        {
            var testIkey = "test_ikey";
            var testEndpoint = "https://www.bing.com/";

            var exporter = new AzureMonitorTraceExporter(new AzureMonitorExporterOptions { ConnectionString = $"InstrumentationKey={testIkey};IngestionEndpoint={testEndpoint}" });

            GetInternalFields(exporter, out string ikey, out string endpoint);
            Assert.AreEqual(testIkey, ikey);
            Assert.AreEqual(testEndpoint, endpoint);
        }

        [Test]
        public void VerifyConnectionString_CorrectlySetsDefaultEndpoint()
        {
            var testIkey = "test_ikey";

            var exporter = new AzureMonitorTraceExporter(new AzureMonitorExporterOptions { ConnectionString = $"InstrumentationKey={testIkey};" });

            GetInternalFields(exporter, out string ikey, out string endpoint);
            Assert.AreEqual(testIkey, ikey);
            Assert.AreEqual(ConnectionString.Constants.DefaultIngestionEndpoint, endpoint);
        }

        [Test]
        public void VerifyConnectionString_ThrowsExceptionWhenInvalid()
        {
            Assert.Throws<InvalidOperationException>(() => new AzureMonitorTraceExporter(new AzureMonitorExporterOptions { ConnectionString = null }));
        }

        [Test]
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

            endpoint = typeof(ServiceRestClient)
                .GetField("endpoint", BindingFlags.Instance | BindingFlags.NonPublic)
                .GetValue(serviceRestClient)
                .ToString();
        }
    }
}
