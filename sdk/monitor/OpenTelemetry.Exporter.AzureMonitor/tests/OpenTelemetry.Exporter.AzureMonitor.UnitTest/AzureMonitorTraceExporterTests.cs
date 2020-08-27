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

            Assert.AreEqual(testIkey, exporter.AzureMonitorTransmitter.ikey);

            // TODO: WHO OWNS THE SWAGGER? CAN WE CHANGE "endpoint" TO BE internal PLEASE?
            FieldInfo field = typeof(ServiceRestClient).GetField("endpoint", BindingFlags.Instance | BindingFlags.NonPublic);
            var serviceRestClientEndpoint = field.GetValue(exporter.AzureMonitorTransmitter.serviceRestClient);
            Assert.AreEqual(testEndpoint, serviceRestClientEndpoint);
        }

        [Test]
        public void VerifyConnectionString_CorrectlySetsDefaultEndpoint()
        {
            var testIkey = "test_ikey";

            var exporter = new AzureMonitorTraceExporter(new AzureMonitorExporterOptions { ConnectionString = $"InstrumentationKey={testIkey};" });

            Assert.AreEqual(testIkey, exporter.AzureMonitorTransmitter.ikey);

            // TODO: WHO OWNS THE SWAGGER? CAN WE CHANGE "endpoint" TO BE internal PLEASE?
            FieldInfo field = typeof(ServiceRestClient).GetField("endpoint", BindingFlags.Instance | BindingFlags.NonPublic);
            var serviceRestClientEndpoint = field.GetValue(exporter.AzureMonitorTransmitter.serviceRestClient);
            Assert.AreEqual(ConnectionString.Constants.DefaultIngestionEndpoint, serviceRestClientEndpoint);
        }

        [Test]
        public void VerifyConnectionString_ThrowsExceptionWhenInvalid()
        {
            Assert.Throws<Exception>(() => new AzureMonitorTraceExporter(new AzureMonitorExporterOptions { ConnectionString = null }));
        }

        [Test]
        public void VerifyConnectionString_ThrowsExceptionWhenMissingInstrumentationKey()
        {
            var testEndpoint = "https://www.bing.com/";

            Assert.Throws<Exception>(() => new AzureMonitorTraceExporter(new AzureMonitorExporterOptions { ConnectionString = $"IngestionEndpoint={testEndpoint}" }));
        }
    }
}
