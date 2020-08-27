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
        public void VerifyConnectionStringSetsEndpoint()
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
        public void VerifyInvalidConnectionStringThrowsException()
        {
            Assert.Throws<Exception>(() => new AzureMonitorTraceExporter(new AzureMonitorExporterOptions { ConnectionString = null }));
        }
    }
}
