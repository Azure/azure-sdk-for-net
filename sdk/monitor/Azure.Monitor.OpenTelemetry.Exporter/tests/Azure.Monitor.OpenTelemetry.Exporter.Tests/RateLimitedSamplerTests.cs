// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using Azure.Monitor.OpenTelemetry.Exporter.Internals;
using OpenTelemetry;
using OpenTelemetry.Trace;
using Xunit;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests;

public class RateLimitedSamplerTests
{
    [Fact]
    public void RespectLocalParentDecision()
    {
        var sampler = new RateLimitedSampler(1000);
        // ensure when sampler sees first trace, it will think rate is <= 1/100
        System.Threading.Thread.Sleep(10);
        var parentActivity = new Activity("ParentActivity");
        parentActivity.Start();

        var parentSamplingParams = new SamplingParameters(default(ActivityContext), parentActivity.TraceId, parentActivity.OperationName, ActivityKind.Internal);
        var parentResult = sampler.ShouldSample(parentSamplingParams);

        // Assert parent span is sampled and has correct attribute
        Assert.Equal(SamplingDecision.RecordAndSample, parentResult.Decision);
        var parentSampleRateAttr = Assert.Single(parentResult.Attributes, kvp => kvp.Key == "microsoft.sample_rate");
        Assert.IsType<double>(parentSampleRateAttr.Value);
        double parentSampleRate = (double)parentSampleRateAttr.Value;
        Assert.True(parentSampleRate > 0);

        var parentActivityContext = new ActivityContext(
            parentActivity.TraceId,
            parentActivity.SpanId,
            ActivityTraceFlags.Recorded,
            null,
            isRemote: false
        );
        Console.WriteLine($"Parent trace ID: {parentActivity.TraceId}, spanid: {parentActivity.SpanId}");
        Console.WriteLine($"Parent Activity Context: {parentActivityContext.TraceId}, {parentActivityContext.SpanId}");

        for (int i = 0; i < 100; i++) {
             // Create a child activity with the parent as its context
            var childActivity = new Activity($"ChildActivity_{i}");
            childActivity.SetParentId(parentActivity.TraceId, parentActivity.SpanId, parentActivity.ActivityTraceFlags);
            childActivity.Start();

            var childSamplingParams = new SamplingParameters(parentActivityContext, parentActivity.TraceId, childActivity.OperationName, ActivityKind.Internal);
            var childResult = sampler.ShouldSample(childSamplingParams);

            // Assert child span is sampled and has same attribute
            Assert.Equal(SamplingDecision.RecordAndSample, childResult.Decision);
            var childSampleRateAttr = Assert.Single(childResult.Attributes, kvp => kvp.Key == "microsoft.sample_rate");
            Assert.IsType<double>(childSampleRateAttr.Value);
            double childSampleRate = (double)childSampleRateAttr.Value;
            Assert.Equal(parentSampleRate, childSampleRate);

            childActivity.Stop();
        }

        parentActivity.Stop();
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
        // Simulate 1000 spans being created in just over 1 second.
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
        Console.WriteLine($"Elapsed: {elapsed.TotalSeconds} s");
        Console.WriteLine($"Sampled in {sampledin} spans out of 100 attempts.");
        Assert.InRange(sampledin, 25, 50 * elapsed.TotalSeconds);
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
            System.Threading.Thread.Sleep(2); // 0.2 seconds
        }

        // We would expect all spans to be sampled in.
        Console.WriteLine($"Sampled in {sampledin} spans out of 1000 attempts.");
        Assert.True(sampledin == 50, $"Expected 50 spans to be sampled in, but got {sampledin}.");
    }
}
