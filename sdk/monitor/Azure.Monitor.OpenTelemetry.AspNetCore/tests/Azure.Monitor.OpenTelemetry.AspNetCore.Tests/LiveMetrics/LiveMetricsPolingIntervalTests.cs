﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
using Azure.Monitor.OpenTelemetry.AspNetCore.Internals.LiveMetrics;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Platform;
using Xunit;

namespace Azure.Monitor.OpenTelemetry.AspNetCore.Tests.LiveMetrics
{
    public class LiveMetricsPolingIntervalTests
    {
        [Fact]
        public void VerifyLiveMetricsReadsPolingIntervalHeader()
        {
            var mockTransport = new MockTransport(_ => new MockResponse(200).AddHeader("x-ms-qps-service-polling-interval-hint", "123"));

            AzureMonitorOptions options = new AzureMonitorOptions
            {
                ConnectionString = "InstrumentationKey=00000000-0000-0000-0000-000000000000",
                EnableLiveMetrics = false, // set to false to prevent the manager from starting.
                Transport = mockTransport
            };

            var manager = new Manager(options, new DefaultPlatform());

            Assert.Empty(mockTransport.Requests);
            Assert.Null(manager._pingPeriodFromService);

            manager.OnPing();

            Assert.Single(mockTransport.Requests);
            Assert.Equal(123, manager._pingPeriodFromService!.Value.TotalMilliseconds);
        }
    }
}
