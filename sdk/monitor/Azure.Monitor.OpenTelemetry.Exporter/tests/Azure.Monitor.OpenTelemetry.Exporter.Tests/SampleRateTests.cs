// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Azure.Monitor.OpenTelemetry.Exporter.Internals;
using Azure.Monitor.OpenTelemetry.Exporter.Models;
using Azure.Monitor.OpenTelemetry.Exporter.Tests.CommonTestFramework;
using OpenTelemetry;
using OpenTelemetry.Extensions.AzureMonitor;
using OpenTelemetry.Trace;
using Xunit;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests
{
    public class SampleRateTests
    {
        private const string ActivitySourceName = "SampleRateTests";
        private const string ActivityName = "TestActivity";

        static SampleRateTests()
        {
            Activity.DefaultIdFormat = ActivityIdFormat.W3C;
            Activity.ForceDefaultIdFormat = true;

            var listener = new ActivityListener
            {
                ShouldListenTo = _ => true,
                Sample = (ref ActivityCreationOptions<ActivityContext> options) => ActivitySamplingResult.AllData,
            };

            ActivitySource.AddActivityListener(listener);
        }

        [Theory]
        [InlineData(50.0F)]
        [InlineData("somestring")]
        [InlineData(null)]
        [InlineData("")]
        public void ValidateSampleRateForEventException(object SampleRate)
        {
            using ActivitySource activitySource = new ActivitySource(ActivitySourceName);

            // Valid SampleRate.
            using var activity = activitySource.StartActivity(
                ActivityName,
                ActivityKind.Client,
                parentContext: default,
                startTime: DateTime.UtcNow,
                tags: new Dictionary<string, object?>() { ["sampleRate"] = SampleRate });

            Assert.NotNull(activity);
            var activityTagsProcessor = TraceHelper.EnumerateActivityTags(activity);
            var telemetryItem = new TelemetryItem(activity, ref activityTagsProcessor, null, "00000000-0000-0000-0000-000000000000");
            var expTelemetryItem = new TelemetryItem("Exception", telemetryItem, default, default, default);

            if (SampleRate is float)
            {
                Assert.Equal(SampleRate, expTelemetryItem.SampleRate);
            }
            else
            {
                Assert.Null(expTelemetryItem.SampleRate);
            }
        }

        [Theory]
        [InlineData(50.0F)]
        [InlineData("somestring")]
        [InlineData(null)]
        [InlineData("")]
        public void ValidateSampleRateInTelemetry(object SampleRate)
        {
            using ActivitySource activitySource = new ActivitySource(ActivitySourceName);

            // Valid SampleRate.
            using var activity = activitySource.StartActivity(
                ActivityName,
                ActivityKind.Client,
                parentContext: default,
                startTime: DateTime.UtcNow,
                tags: new Dictionary<string, object?>() { ["sampleRate"] = SampleRate });

            Assert.NotNull(activity);
            var activityTagsProcessor = TraceHelper.EnumerateActivityTags(activity);
            var telemetryItem = new TelemetryItem(activity, ref activityTagsProcessor, null, "00000000-0000-0000-0000-000000000000");

            if (SampleRate is float)
            {
                Assert.Equal(SampleRate, telemetryItem.SampleRate);
            }
            else
            {
                Assert.Null(telemetryItem.SampleRate);
            }
        }

        [Fact]
        public void SampleRateE2ETest()
        {
            using var activitySource = new ActivitySource(ActivitySourceName);
            using var tracerProvider = Sdk.CreateTracerProviderBuilder()
                .AddSource(ActivitySourceName)
                .SetSampler(new ApplicationInsightsSampler(new ApplicationInsightsSamplerOptions() { SamplingRatio = 1.0F }))
                .AddAzureMonitorTraceExporterForTest(out List<TelemetryItem> telemetryItems)
                .Build();

            using (var activity = activitySource.StartActivity("SayHello"))
            {
            }

            tracerProvider?.ForceFlush();

            Assert.NotEmpty(telemetryItems);
            Assert.Equal(100F, telemetryItems.Last()!.SampleRate);
        }

        [Fact]
        public void NoTelemetryCreatedOnZeroSampleRate()
        {
            using var activitySource = new ActivitySource(ActivitySourceName);
            using var tracerProvider = Sdk.CreateTracerProviderBuilder()
                .AddSource(ActivitySourceName)
                .SetSampler(new ApplicationInsightsSampler(new ApplicationInsightsSamplerOptions() { SamplingRatio = 0.0F }))
                .AddAzureMonitorTraceExporterForTest(out List<TelemetryItem> telemetryItems)
                .Build();

            using (var activity = activitySource.StartActivity("SayHello"))
            {
            }

            tracerProvider?.ForceFlush();

            Assert.Empty(telemetryItems);
        }
    }
}
