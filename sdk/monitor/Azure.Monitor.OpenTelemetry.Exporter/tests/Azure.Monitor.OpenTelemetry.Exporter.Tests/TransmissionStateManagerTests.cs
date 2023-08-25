// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;
using Azure.Monitor.OpenTelemetry.Exporter.Internals;
using Xunit;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests
{
    public class TransmissionStateManagerTests
    {
        [Fact]
        public void EnableBackOffSetsStateToOpen()
        {
            var transmissionStateManager = new TransmissionStateManager();
            MockResponse mockResponse = new MockResponse(500, "Internal Server Error");
            transmissionStateManager.EnableBackOff(mockResponse);

            Assert.Equal(TransmissionState.Open, transmissionStateManager.State);
        }

        [Fact]
        public void EnableBackOffSetsStateToOpenUsingRetryAfterHeaderInResponse()
        {
            System.Timers.Timer backOffIntervalTimer = new();
            var transmissionStateManager = new TransmissionStateManager(
                random: new(),
                minIntervalToUpdateConsecutiveErrors: TimeSpan.FromSeconds(20),
                nextMinTimeToUpdateConsecutiveErrors: DateTimeOffset.MinValue,
                backOffIntervalTimer: backOffIntervalTimer,
                TransmissionState.Closed
                );

            MockResponse mockResponse = new MockResponse(429, "Internal Server Error");
            mockResponse.AddHeader("Retry-After", "20");
            transmissionStateManager.EnableBackOff(mockResponse);

            Assert.Equal(20000, backOffIntervalTimer.Interval);
            Assert.Equal(TransmissionState.Open, transmissionStateManager.State);
        }
    }
}
