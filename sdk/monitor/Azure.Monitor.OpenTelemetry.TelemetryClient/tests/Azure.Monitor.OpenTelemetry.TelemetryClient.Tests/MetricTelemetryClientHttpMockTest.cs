// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Azure.Monitor.OpenTelemetry.TelemetryClient.Tests;

public class MetricTelemetryClientHttpMockTest : AbstractTelemetryClientHttpMockTest
{
    [Fact]
    public async Task TrackMetric()
    {
        void ClientConsumer(TelemetryClient telemetryClient) => telemetryClient.TrackMetric("testMetric", 23.56);

        await VerifyTrackMethod(ClientConsumer, "metric/expected-metric.json");
    }

    [Fact]
    public async Task TrackMetricWithProperties()
    {
        var properties = new Dictionary<string, string> { { "Key1", "Value1" }, { "Key2", "Value2" } };

        void ClientConsumer(TelemetryClient telemetryClient) =>
            telemetryClient.TrackMetric("testMetricWithProperties", 37.26, properties);

        await VerifyTrackMethod(ClientConsumer, "metric/expected-metric-with-properties.json");
    }
}
