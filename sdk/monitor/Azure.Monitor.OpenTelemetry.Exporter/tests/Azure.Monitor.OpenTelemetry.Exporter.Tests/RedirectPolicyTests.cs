// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
using Azure.Core.Pipeline;
using Azure.Monitor.OpenTelemetry.Exporter.Internals;
using Azure.Monitor.OpenTelemetry.Exporter.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using Xunit;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests
{
    public class RedirectPolicyTests
    {
        private static readonly ActivitySource activitySource = new ActivitySource("OTel.RedirectPolicy");

        private const string testIkey = "test_ikey";
        private const string testEndpoint = "http://localhost:5050";

        static RedirectPolicyTests()
        {
            Activity.DefaultIdFormat = ActivityIdFormat.W3C;
            Activity.ForceDefaultIdFormat = true;

            var listener = new ActivityListener
            {
                ShouldListenTo = _ => true,
                Sample = (ref ActivityCreationOptions<ActivityContext> options) => ActivitySamplingResult.AllData,
            };

            ActivitySource.AddActivityListener(listener);

            HttpPipelineHelper.MinimumRetryInterval = 6000;
        }

        [Fact]
        public void UsesLocationResponseHeaderAsNewRequestUri()
        {
            using var activity = CreateActivity("TestActivity");
            var telemetryItem = CreateTelemetryItem(activity);
            List<TelemetryItem> telemetryItems = new List<TelemetryItem>();
            telemetryItems.Add(telemetryItem);

            // Transmit
            var fistResponse = new MockResponse(307).AddHeader("Location", "http://new.host/");
            var transmitter = GetTransmitter(fistResponse);
            transmitter.TrackAsync(telemetryItems, false, CancellationToken.None).EnsureCompleted();
        }

        private static AzureMonitorTransmitter GetTransmitter(MockResponse mockResponse)
        {
            // MockTransport mockTransport = new MockTransport(mockResponse, new MockResponse(200));
            var mockTransport = new MockTransport(_ =>
               new MockResponse(307).AddHeader("Location", "http://new.host/"));
            AzureMonitorExporterOptions options = new AzureMonitorExporterOptions();
            options.ConnectionString = $"InstrumentationKey={testIkey};IngestionEndpoint={testEndpoint}";
            options.Transport = mockTransport;
            AzureMonitorTransmitter transmitter = new AzureMonitorTransmitter(options);

            return transmitter;
        }

        private static Activity CreateActivity(string activityName)
        {
            ActivitySource activitySource = new ActivitySource("OTel.RedirectPolicy");
            var activity = activitySource.StartActivity(
                activityName,
                ActivityKind.Client,
                parentContext: default,
                startTime: DateTime.UtcNow);

            return activity;
        }

        private static TelemetryItem CreateTelemetryItem(Activity activity)
        {
            var monitorTags = TraceHelper.EnumerateActivityTags(activity);
            return new TelemetryItem(activity, ref monitorTags, null, null, null);
        }
    }
}
