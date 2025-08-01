// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using Azure.Monitor.OpenTelemetry.Exporter.Internals;
using OpenTelemetry;
using OpenTelemetry.Trace;
using OpenTelemetry.Exporter;
using Xunit;
using System.Collections.Generic;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests;

public class RateLimitedSamplerTests
{
    [Fact]
    public void RespectLocalParentDecision()
    {
        ActivitySource MyActivitySource = new("MyCompany.MyProduct.MyLibrary");

        var exportedItems = new List<Activity>();
        using var tracerProvider = Sdk.CreateTracerProviderBuilder()
        .AddSource("MyCompany.MyProduct.MyLibrary")
        .SetSampler(new RateLimitedSampler(1000)) // 1000 traces per second
        .AddInMemoryExporter(exportedItems)
        .Build();

        System.Threading.Thread.Sleep(50); // Allow for adaptation time
        using (var activity = MyActivitySource.StartActivity("ParentActivity"))
        {
            for (int i = 0; i < 100; i++)
            {
                // Start 100 child activities
                using (var childActivity = MyActivitySource.StartActivity($"MyChildActivity_{i}"))
                {
                    Assert.NotNull(childActivity);
                }
            }
        }

        Assert.NotEmpty(exportedItems);
        Assert.Equal(101, exportedItems.Count);

        var exportedParentActivity = exportedItems[100];
        Assert.Equal("ParentActivity", exportedParentActivity.DisplayName);
        var parentSampleRate = exportedParentActivity.GetTagItem("microsoft.sample_rate");

        for (int i = 1; i < exportedItems.Count; i++) // looking at child activities
        {
            var exportedActivity = exportedItems[i - 1];
            var sampleRate = exportedActivity.GetTagItem("microsoft.sample_rate");
            Assert.Equal(parentSampleRate, sampleRate);
        }
    }

    [Fact]
    public void ZeroRateForZeroTracesPerSecond()
    {
        RateLimitedSamplingPercentage samplingPercentage = new RateLimitedSamplingPercentage(0);
        double percentage = samplingPercentage.Get();
        Assert.Equal(0, percentage);
    }

    [Fact]
    public void PercentageBetween0and100()
    {
        RateLimitedSamplingPercentage samplingPercentage = new RateLimitedSamplingPercentage(1);
        double percentage = samplingPercentage.Get();
        Assert.InRange(percentage, 0, 100);
    }

    [Fact]
    public void NearZeroRateForVeryLowTracesPerSecond()
    {
        RateLimitedSamplingPercentage samplingPercentage = new RateLimitedSamplingPercentage(0.00001);
        double percentage = samplingPercentage.Get();
        Assert.InRange(percentage, 0, 1);
    }

    [Fact]
    public void Percent100ForVeryHighTracesPerSecondAfterAdaptation()
    {
        RateLimitedSamplingPercentage samplingPercentage = new RateLimitedSamplingPercentage(1e9);
        System.Threading.Thread.Sleep(20);
        double percentage = samplingPercentage.Get();
        System.Threading.Thread.Sleep(20);
        percentage = samplingPercentage.Get();

        Assert.Equal(100, percentage);
    }

    [Fact]
    public void ReturnsRecordAndSampledWhenSampleRateIs100()
    {
        var sampler = new RateLimitedSampler(10000);
        var parentContext = default(ActivityContext); // No parent
        var traceId = ActivityTraceId.CreateRandom();
        var samplingParams = new SamplingParameters(
            parentContext,
            traceId,
            "span",
            ActivityKind.Internal
        );
        System.Threading.Thread.Sleep(100); // Allow for adaptation time
        var result = sampler.ShouldSample(samplingParams);

        Assert.Equal(SamplingDecision.RecordAndSample, result.Decision);
    }

    [Fact]
    public void ReturnsRecordOnlyWhenTracesPerSecondIsZero()
    {
        var sampler = new RateLimitedSampler(0);
        var parentContext = default(ActivityContext); // No parent
        var traceId = ActivityTraceId.CreateRandom();
        var samplingParams = new SamplingParameters(
            parentContext,
            traceId,
            "span",
            ActivityKind.Internal
        );
        System.Threading.Thread.Sleep(100); // Allow for adaptation time
        var result = sampler.ShouldSample(samplingParams);

        Assert.Equal(SamplingDecision.RecordOnly, result.Decision);
    }

    [Fact]
    public void AddsSampleRateAttrToSampledInSpan()
    {
        var sampler = new RateLimitedSampler(100);
        // sleeping to allow for the sampler to adapt. If we send the first span before the adaptation time has passed,
        // the span will not be sampled.
        System.Threading.Thread.Sleep(50);
        var parentContext = default(ActivityContext); // No parent
        var traceId = ActivityTraceId.CreateRandom();
        var samplingParams = new SamplingParameters(
            parentContext,
            traceId,
            "span",
            ActivityKind.Internal
        );
        var result = sampler.ShouldSample(samplingParams);

        Assert.Contains(result.Attributes, kvp => kvp.Key == "microsoft.sample_rate");
        var sampleRateAttr = Assert.Single(result.Attributes, kvp => kvp.Key == "microsoft.sample_rate");
        double sampleRate = (double)sampleRateAttr.Value;
        Assert.True(sampleRate == 100);
    }

    [Fact]
    public void SpansOverRateLimit()
    {
        var sampler = new RateLimitedSampler(50);
        int sampledin = 0;
        var parentContext = default(ActivityContext);
        System.Threading.Thread.Sleep(50); // Allow for adaptation time

        DateTime start = DateTime.UtcNow;
        for (int i = 0; i < 100; i++)
        {
            var traceId = ActivityTraceId.CreateRandom();
            var samplingParams = new SamplingParameters(parentContext, traceId, $"TestActivity_{i}", ActivityKind.Internal);
            var result = sampler.ShouldSample(samplingParams);
            if (result.Decision == SamplingDecision.RecordAndSample)
            {
                sampledin++;
            }
            System.Threading.Thread.Sleep(2);
        }
        // We would expect 50 to be sampled in, but there may be some variance based on sleep scheduling/elapsed time.
        DateTime end = DateTime.UtcNow;
        TimeSpan elapsed = end - start;
        if (elapsed.TotalSeconds < 1)
        {
            Assert.True(sampledin <= 50, $"Expected at most 50 spans to be sampled in, but got {sampledin}.");
        }
        else
        {
            Assert.True(sampledin <= 50 * elapsed.TotalSeconds, $"Expected less than {50 * elapsed.TotalSeconds} spans to be sampled in, but got {sampledin}.");
        }
    }

    [Fact]
    public void SpansUnderRateLimit()
    {
        var sampler = new RateLimitedSampler(1000);
        int sampledin = 0;
        var parentContext = default(ActivityContext);

        System.Threading.Thread.Sleep(50); // Allow for adaptation time

        // Simulate 50 spans being created in just over 1 second.
        for (int i = 0; i < 50; i++)
        {
            var traceId = ActivityTraceId.CreateRandom();
            var samplingParams = new SamplingParameters(parentContext, traceId, $"TestActivity_{i}", ActivityKind.Internal);
            var result = sampler.ShouldSample(samplingParams);
            if (result.Decision == SamplingDecision.RecordAndSample)
            {
                sampledin++;
            }
            System.Threading.Thread.Sleep(2);
        }

        // We would expect all spans to be sampled in.
        Assert.True(sampledin == 50, $"Expected 50 spans to be sampled in, but got {sampledin}.");
    }
}
