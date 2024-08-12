// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Azure.Monitor.OpenTelemetry.Exporter.Internals;
using Azure.Monitor.OpenTelemetry.Exporter.Models;
using Azure.Monitor.OpenTelemetry.Exporter.Tests.CommonTestFramework;
using OpenTelemetry;
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
        public void ValidateSampleRateForEventException(float sampleRate)
        {
            using ActivitySource activitySource = new ActivitySource(ActivitySourceName);

            using var activity = activitySource.StartActivity(
                ActivityName,
                ActivityKind.Client,
                parentContext: default,
                startTime: DateTime.UtcNow);

            Assert.NotNull(activity);
            var activityTagsProcessor = TraceHelper.EnumerateActivityTags(activity);
            var telemetryItem = new TelemetryItem(activity, ref activityTagsProcessor, null, "00000000-0000-0000-0000-000000000000", sampleRate);
            var expTelemetryItem = new TelemetryItem("Exception", telemetryItem, default, default, default);
            Assert.Equal(sampleRate, expTelemetryItem.SampleRate);
        }

        [Theory]
        [InlineData(50.0F)]
        public void ValidateSampleRateInTelemetry(float sampleRate)
        {
            using ActivitySource activitySource = new ActivitySource(ActivitySourceName);

            using var activity = activitySource.StartActivity(
                ActivityName,
                ActivityKind.Client,
                parentContext: default,
                startTime: DateTime.UtcNow);

            Assert.NotNull(activity);
            var activityTagsProcessor = TraceHelper.EnumerateActivityTags(activity);
            var telemetryItem = new TelemetryItem(activity, ref activityTagsProcessor, null, "00000000-0000-0000-0000-000000000000", sampleRate);

            Assert.Equal(sampleRate, telemetryItem.SampleRate);
        }

        [Fact]
        public void SampleRateE2ETest()
        {
            using var activitySource = new ActivitySource(ActivitySourceName);
            using var tracerProvider = Sdk.CreateTracerProviderBuilder()
                .AddSource(ActivitySourceName)
                .AddAzureMonitorTraceExporterForTest(out List<TelemetryItem> telemetryItems, options => options.SamplingRatio = 1.0F)
                .Build();

            using (var activity = activitySource.StartActivity("SayHello"))
            {
            }

            tracerProvider?.ForceFlush();

            Assert.NotEmpty(telemetryItems);
            Assert.Null(telemetryItems.Last()!.SampleRate);
        }

        [Fact]
        public void NoTelemetryCreatedOnZeroSampleRate()
        {
            using var activitySource = new ActivitySource(ActivitySourceName);
            using var tracerProvider = Sdk.CreateTracerProviderBuilder()
                .AddSource(ActivitySourceName)
                .AddAzureMonitorTraceExporterForTest(out List<TelemetryItem> telemetryItems, options => options.SamplingRatio = 0.0F)
                .Build();

            using (var activity = activitySource.StartActivity("SayHello"))
            {
            }

            tracerProvider?.ForceFlush();

            Assert.Empty(telemetryItems);
        }
    }
}
