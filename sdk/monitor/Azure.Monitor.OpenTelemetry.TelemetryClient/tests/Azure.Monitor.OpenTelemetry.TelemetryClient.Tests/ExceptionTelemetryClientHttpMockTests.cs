// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Xunit;

namespace Azure.Monitor.OpenTelemetry.TelemetryClient.Tests;

public class ExceptionTelemetryClientHttpMockTests : AbstractTelemetryClientHttpMockTest
{
    [Fact]
    public async Task TrackException()
    {
        void ExceptionConsumer(TelemetryClient telemetryClient) =>
            telemetryClient.TrackException(new InvalidOperationException("Something went wrong"));

        await VerifyTrackMethod(ExceptionConsumer, "exception/expected-exception.json", IdShouldBeProvidedInExceptions);
    }

    [Fact]
    public async Task TrackExceptionWithNullException()
    {
        Exception? noException = null;

        void ExceptionConsumer(TelemetryClient telemetryClient) =>
            telemetryClient.TrackException(noException);

        await VerifyTrackMethod(ExceptionConsumer, "exception/expected-exception-with-null-exception.json",
            IdShouldBeProvidedInExceptions);
    }

    [Fact]
    public async Task TrackExceptionWithProperties()
    {
        var properties = new Dictionary<string, string> { { "Key1", "Value1" }, { "Key2", "Value2" } };

        void ExceptionConsumer(TelemetryClient telemetryClient) =>
            telemetryClient.TrackException(new InvalidOperationException("Something went wrong"), properties);

        await VerifyTrackMethod(ExceptionConsumer, "exception/expected-exception-with-properties.json");
    }

    private static void IdShouldBeProvidedInExceptions(JObject currentJson)
    {
        var data = currentJson["data"] as JObject;

        if (data == null)
            Assert.Fail("Should have data property.");

        var baseData = data["baseData"];

        if (baseData == null)
            Assert.Fail("Should have baseData property.");

        var exceptions = baseData["exceptions"];

        if (exceptions == null)
            Assert.Fail("Should have exceptions property.");

        Assert.Equal(1, exceptions?.Count() ?? 0);

        var exception = exceptions?[0];

        Assert.False(string.IsNullOrEmpty(exception?["id"]?.ToString()),
            "exceptions should contain id");
    }
}
