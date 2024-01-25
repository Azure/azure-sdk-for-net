// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Monitor.OpenTelemetry.Exporter.Internals.Diagnostics;
using Azure.Monitor.OpenTelemetry.Exporter.Tests.CommonTestFramework;
using Xunit;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests
{
    public class AzureMonitorExporterEventSourceTests
    {
        /// <summary>
        /// This test uses reflection to invoke every Event method in our EventSource class.
        /// This validates that parameters are logged and helps to confirm that EventIds are correct.
        /// </summary>
        [Fact]
        public void EventSourceTest_AzureMonitorExporterEventSource()
        {
            EventSourceTestHelper.MethodsAreImplementedConsistentlyWithTheirAttributes(AzureMonitorExporterEventSource.Log);
        }
    }
}
