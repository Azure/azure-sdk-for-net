// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;

using Xunit;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests
{
    /// <summary>
    /// These tests depend on the <see cref="AzureMonitorExporterEventListener"/> to subscribe to the <see cref="AzureMonitorExporterEventSource"/> and write events to the <see cref="TelemetryDebugWriter"/>.
    /// </summary>
    public class AzureMonitorExporterEventSourceTests
    {
        [Fact]
        public void VerifyEventSource_Critical() => Test(writeAction: AzureMonitorExporterEventSource.Log.WriteCritical, expectedId: 1, expectedName: "WriteCritical");

        [Fact]
        public void VerifyEventSource_Error() => Test(writeAction: AzureMonitorExporterEventSource.Log.WriteError, expectedId: 2, expectedName: "WriteError");

        [Fact]
        public void VerifyEventSource_Warning() => Test(writeAction: AzureMonitorExporterEventSource.Log.WriteWarning, expectedId: 3, expectedName: "WriteWarning");

        [Fact]
        public void VerifyEventSource_Informational() => Test(writeAction: AzureMonitorExporterEventSource.Log.WriteInformational, expectedId: 4, expectedName: "WriteInformational");

        [Fact]
        public void VerifyEventSource_Verbose() => Test(writeAction: AzureMonitorExporterEventSource.Log.WriteVerbose, expectedId: 5, expectedName: "WriteVerbose");

        private void Test(Action<string> writeAction, int expectedId, string expectedName)
        {
            try
            {
                // Normally our Listener will write to the Debugger.
                // Here, we override the behavior of the TelemetryDebugWriter to intercept messages.
                var writer = new TestWriter();
                TelemetryDebugWriter.Writer = writer;

                writeAction("hello world");

                var test = writer.Messages.Single();
                Assert.Equal($"OpenTelemetry-AzureMonitor-Exporter - EventId: [{expectedId}], EventName: [{expectedName}], Message: [hello world]", test);
            }
            finally
            {
                // Reset singleton to not affect other tests.
                TelemetryDebugWriter.Writer = new TelemetryDebugWriter();
            }
        }

        private class TestWriter : IDebugWritter
        {
            public List<string> Messages = new();

            public void WriteMessage(string message)
            {
                Messages.Add(message);
            }

            public void WriteTelemetry(NDJsonWriter content)
            {
                // no-op
            }
        }
    }
}
