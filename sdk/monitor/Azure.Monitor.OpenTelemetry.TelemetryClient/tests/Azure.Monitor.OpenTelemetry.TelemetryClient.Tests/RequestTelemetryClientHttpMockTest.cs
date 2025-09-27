// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Xunit;

namespace Azure.Monitor.OpenTelemetry.TelemetryClient.Tests;

public class RequestTelemetryClientHttpMockTests : AbstractTelemetryClientHttpMockTest
{
    [Fact]
    public async Task TrackRequest()
    {
        void ClientConsumer(TelemetryClient telemetryClient)
        {
            TelemetryContext telemetryClientContext = telemetryClient.Context;
            telemetryClientContext.GlobalProperties.Add("global-Key1", "global-Value1");
            telemetryClientContext.GlobalProperties.Add("global-Key2", "global-Value2");

            telemetryClient.TrackRequest("GET /api/orders", DateTimeOffset.Now, TimeSpan.FromMilliseconds(123), "200",
                true);
        }

        await VerifyTrackMethod(ClientConsumer, "request/expected-request.json", IdShouldBeProvidedInBaseData);
    }
}
