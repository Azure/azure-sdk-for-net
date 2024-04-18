// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Monitor.OpenTelemetry.Exporter.Tests.CommonTestFramework;
using Xunit;
using Azure.Monitor.OpenTelemetry.AspNetCore.LiveMetrics.Diagnostics;

namespace Azure.Monitor.OpenTelemetry.AspNetCore.Tests
{
    public class LiveMetricsExporterEventSourceTests
    {
        /// <summary>
        /// This test uses reflection to invoke every Event method in our EventSource class.
        /// This validates that parameters are logged and helps to confirm that EventIds are correct.
        /// </summary>
        [Fact]
        public void EventSourceTest_LiveMetricsExporterEventSource()
        {
            EventSourceTestHelper.MethodsAreImplementedConsistentlyWithTheirAttributes(LiveMetricsExporterEventSource.Log);
        }
    }
}
