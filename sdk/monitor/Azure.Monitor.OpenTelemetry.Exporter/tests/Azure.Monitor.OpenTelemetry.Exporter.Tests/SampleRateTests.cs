// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
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

        [Fact]
        public void SpanSampleRateIsWrittenToEnvelopeAndNotToProperties()
        {
            var telemetryItems = ExportOneServerSpan(new StampingSampler(25.0), options => { });

            var telemetryItem = Assert.Single(telemetryItems, item => item.Name == "Request");
            Assert.Equal(25f, telemetryItem.SampleRate);
            Assert.DoesNotContain(SemanticConventions.AttributeMicrosoftSampleRate, ((RequestData)telemetryItem.Data.BaseData).Properties.Keys);
        }

        /// <summary>
        /// Rate-limited sampling takes precedence over SamplingRatio. The ratio must not be reported
        /// for spans the rate-limited sampler kept in full.
        /// </summary>
        [Fact]
        public void SpanSampleRateTakesPrecedenceOverConfiguredSamplingRatio()
        {
            var telemetryItems = ExportOneServerSpan(new StampingSampler(100.0), options =>
            {
                options.SamplingRatio = 0.5F;
                options.TracesPerSecond = 5;
            });

            Assert.Null(Assert.Single(telemetryItems, item => item.Name == "Request").SampleRate);
        }

        [Fact]
        public void RateLimitedSamplerKeepingEverySpanDoesNotReportSamplingRatio()
        {
            var options = new AzureMonitorExporterOptions { SamplingRatio = 0.5F, TracesPerSecond = 1_000_000_000 };

            // Lets the rate-limited sampler's window open, so the first span is sampled at 100%.
            var sampler = SamplerFactory.Create(options, multiEndpointEnabled: false);
            Thread.Sleep(10);

            var telemetryItems = ExportOneServerSpan(sampler, o =>
            {
                o.SamplingRatio = options.SamplingRatio;
                o.TracesPerSecond = options.TracesPerSecond;
            });

            Assert.Null(Assert.Single(telemetryItems, item => item.Name == "Request").SampleRate);
        }

        [Fact]
        public void FixedRateSamplerSampleRateIsReadFromSpan()
        {
            using var activitySource = new ActivitySource(ActivitySourceName);

            // TracesPerSecond keeps its default, so the configured ratio is not used as a fallback;
            // the rate can only come from the attribute the sampler stamps.
            using var tracerProvider = Sdk.CreateTracerProviderBuilder()
                .AddSource(ActivitySourceName)
                .AddAzureMonitorTraceExporterForTest(out List<TelemetryItem> telemetryItems, options => options.SamplingRatio = 0.5F)
                .Build();

            for (int i = 0; i < 50; i++)
            {
                using var activity = activitySource.StartActivity("SayHello", ActivityKind.Server);
            }

            tracerProvider?.ForceFlush();

            var requests = telemetryItems.Where(item => item.Name == "Request").ToList();
            Assert.NotEmpty(requests);
            Assert.All(requests, item => Assert.Equal(50f, item.SampleRate));
        }

        [Fact]
        public void SpanWithoutSampleRateFallsBackToSamplingRatioUnderFixedRateConfiguration()
        {
            var telemetryItems = ExportOneServerSpan(new AlwaysOnSampler(), options =>
            {
                options.SamplingRatio = 0.5F;
                options.TracesPerSecond = null;
            });

            Assert.Equal(50f, Assert.Single(telemetryItems, item => item.Name == "Request").SampleRate);
        }

        [Fact]
        public void SpanWithoutSampleRateReportsNoSampleRateUnderRateLimitedConfiguration()
        {
            var telemetryItems = ExportOneServerSpan(new AlwaysOnSampler(), options =>
            {
                options.SamplingRatio = 0.5F;
                options.TracesPerSecond = 5;
            });

            Assert.Null(Assert.Single(telemetryItems, item => item.Name == "Request").SampleRate);
        }

        [Theory]
        [InlineData(25)]
        [InlineData(25L)]
        [InlineData(25F)]
        [InlineData(25.0)]
        [InlineData("25")]
        public void SpanSampleRateAcceptsNumericValues(object sampleRate)
        {
            var telemetryItems = ExportOneServerSpan(new StampingSampler(sampleRate), options => { });

            Assert.Equal(25f, Assert.Single(telemetryItems, item => item.Name == "Request").SampleRate);
        }

        [Theory]
        [InlineData("abc")]
        [InlineData(double.NaN)]
        [InlineData(double.PositiveInfinity)]
        [InlineData(0.0)]
        [InlineData(-1.0)]
        [InlineData(150.0)]
        [InlineData(true)]
        public void InvalidSpanSampleRateFallsBack(object sampleRate)
        {
            var telemetryItems = ExportOneServerSpan(new StampingSampler(sampleRate), options =>
            {
                options.SamplingRatio = 0.5F;
                options.TracesPerSecond = null;
            });

            var telemetryItem = Assert.Single(telemetryItems, item => item.Name == "Request");
            Assert.Equal(50f, telemetryItem.SampleRate);
            Assert.DoesNotContain(SemanticConventions.AttributeMicrosoftSampleRate, ((RequestData)telemetryItem.Data.BaseData).Properties.Keys);
        }

        [Fact]
        public void ExceptionEventInheritsSpanSampleRate()
        {
            using var activitySource = new ActivitySource(ActivitySourceName);
            using var tracerProvider = Sdk.CreateTracerProviderBuilder()
                .AddSource(ActivitySourceName)
                .AddAzureMonitorTraceExporterForTest(out List<TelemetryItem> telemetryItems, sampler: new StampingSampler(25.0))
                .Build();

            using (var activity = activitySource.StartActivity("SayHello", ActivityKind.Server))
            {
                activity!.AddEvent(new ActivityEvent("exception", tags: new ActivityTagsCollection
                {
                    { "exception.type", "System.InvalidOperationException" },
                    { "exception.message", "boom" },
                }));
            }

            tracerProvider?.ForceFlush();

            Assert.Equal(25f, Assert.Single(telemetryItems, item => item.Name == "Exception").SampleRate);
            Assert.Equal(25f, Assert.Single(telemetryItems, item => item.Name == "Request").SampleRate);
        }

        private static List<TelemetryItem> ExportOneServerSpan(Sampler sampler, Action<AzureMonitorExporterOptions> configure)
        {
            using var activitySource = new ActivitySource(ActivitySourceName);
            using var tracerProvider = Sdk.CreateTracerProviderBuilder()
                .AddSource(ActivitySourceName)
                .AddAzureMonitorTraceExporterForTest(out List<TelemetryItem> telemetryItems, configure, sampler)
                .Build();

            using (var activity = activitySource.StartActivity("SayHello", ActivityKind.Server))
            {
            }

            tracerProvider?.ForceFlush();

            return telemetryItems;
        }

        /// <summary>Stamps a fixed <c>microsoft.sample_rate</c>, as the Azure Monitor samplers do.</summary>
        private sealed class StampingSampler : Sampler
        {
            private readonly object _sampleRate;

            public StampingSampler(object sampleRate) => _sampleRate = sampleRate;

            public override SamplingResult ShouldSample(in SamplingParameters samplingParameters)
                => new(SamplingDecision.RecordAndSample, new[] { new KeyValuePair<string, object>(SemanticConventions.AttributeMicrosoftSampleRate, _sampleRate) });
        }
    }
}
