// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Azure.Monitor.OpenTelemetry.TelemetryClient.Tests;

public class EventTelemetryClientHttpMockTests : AbstractTelemetryClientHttpMockTest
{
    [Fact]
    public async Task TrackEvent()
    {
        void ClientConsumer(TelemetryClient telemetryClient) => telemetryClient.TrackEvent("TestEvent");
        await VerifyTrackMethod(ClientConsumer, "event/expected-event.json");
    }

    [Fact]
    public async Task TrackEventWithProperties()
    {
        var properties = new Dictionary<string, string> { { "Key1", "Value1" }, { "Key2", "Value2" } };

        void ClientConsumer(TelemetryClient telemetryClient) =>
            telemetryClient.TrackEvent("TestEventWithProperties", properties);

        await VerifyTrackMethod(ClientConsumer, "event/expected-event-with-properties.json");
    }
}
