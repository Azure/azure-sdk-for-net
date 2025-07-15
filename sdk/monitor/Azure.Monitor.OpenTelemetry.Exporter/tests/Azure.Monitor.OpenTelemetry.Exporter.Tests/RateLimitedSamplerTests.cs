// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using Azure.Monitor.OpenTelemetry.Exporter.Internals;
using OpenTelemetry.Trace;
using Xunit;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests;

public class RateLimitedSamplerTests
{
    /*[Fact]
    public void SampleInSpanUnderLimit()
    {
        var sampler = new RateLimitedSampler(5);
        var parentContext = default(ActivityContext);
        var traceId = ActivityTraceId.CreateRandom();
        var samplingParams = new SamplingParameters(parentContext, traceId, "TestActivity", ActivityKind.Internal);
        var result = sampler.ShouldSample(samplingParams);

        // Assert SamplingDecision
        Assert.Equal(SamplingDecision.RecordAndSample, result.Decision);

        // Assert attribute exists and is non-zero
        var sampleRateAttr = Assert.Single(result.Attributes, kvp => kvp.Key == "microsoft.sample_rate");
        Assert.IsType<double>(sampleRateAttr.Value);
        double sampleRate = (double)sampleRateAttr.Value;
        Assert.True(sampleRate > 0);

        // Assert tracestate matches
        // string expectedTraceState = "microsoft.sample_rate=" + sampleRate.ToString("F2");
        // Assert.Equal(expectedTraceState, result.TraceState);
    }

    [Fact]
    public void ZeroTracesPerSecondDontSample()
    {
        var sampler = new RateLimitedSampler(0);
        var parentContext = default(ActivityContext);
        var traceId1 = ActivityTraceId.CreateRandom();
        var traceId2 = ActivityTraceId.CreateRandom();
        var samplingParams1 = new SamplingParameters(parentContext, traceId1, "TestActivity1", ActivityKind.Internal);
        var samplingParams2 = new SamplingParameters(parentContext, traceId2, "TestActivity2", ActivityKind.Internal);

        var result1 = sampler.ShouldSample(samplingParams1);
        var result2 = sampler.ShouldSample(samplingParams2);

        int sampledCount = 0;
        if (result1.Decision == SamplingDecision.RecordAndSample) sampledCount++;
        if (result2.Decision == SamplingDecision.RecordAndSample) sampledCount++;

        Assert.Equal(0, sampledCount);
    }

    [Fact]
    public void SampleSpanAtLimit()
    {
        var sampler = new RateLimitedSampler(1); // Only 1 span per second allowed
        var parentContext = default(ActivityContext);
        var traceId = ActivityTraceId.CreateRandom();
        var samplingParams = new SamplingParameters(parentContext, traceId, "TestActivity", ActivityKind.Internal);
        var result = sampler.ShouldSample(samplingParams);

        Assert.Equal(SamplingDecision.RecordAndSample, result.Decision);
    }

    [Fact]
    public void RespectLocalParentDecision()
    {
        var sampler = new RateLimitedSampler(5);
        // Create a local parent span
        var parentTraceId = ActivityTraceId.CreateRandom();
        var parentSpanId = ActivitySpanId.CreateRandom();
        var parentContext = new ActivityContext(parentTraceId, parentSpanId, ActivityTraceFlags.None, traceState: null, isRemote: false);
        var parentSamplingParams = new SamplingParameters(parentContext, parentTraceId, "ParentActivity", ActivityKind.Internal);
        var parentResult = sampler.ShouldSample(parentSamplingParams);

        // Assert parent span is sampled and has correct attribute and tracestate
        Assert.Equal(SamplingDecision.RecordAndSample, parentResult.Decision);
        var parentSampleRateAttr = Assert.Single(parentResult.Attributes, kvp => kvp.Key == "microsoft.sample_rate");
        Assert.IsType<double>(parentSampleRateAttr.Value);
        double parentSampleRate = (double)parentSampleRateAttr.Value;
        Assert.True(parentSampleRate > 0);
        string expectedTraceState = "microsoft.sample_rate=" + parentSampleRate.ToString("F2");
        //Assert.Equal(expectedTraceState, parentResult.TraceState);

        // Create a child span with the parent context
        var childSpanId = ActivitySpanId.CreateRandom();
        var childContext = new ActivityContext(parentTraceId, childSpanId, ActivityTraceFlags.None, traceState: expectedTraceState, isRemote: false);
        var childSamplingParams = new SamplingParameters(childContext, parentTraceId, "ChildActivity", ActivityKind.Internal);
        var childResult = sampler.ShouldSample(childSamplingParams);

        // Assert child span is sampled and has same attribute and tracestate
        Assert.Equal(SamplingDecision.RecordAndSample, childResult.Decision);
        var childSampleRateAttr = Assert.Single(childResult.Attributes, kvp => kvp.Key == "microsoft.sample_rate");
        Assert.IsType<double>(childSampleRateAttr.Value);
        double childSampleRate = (double)childSampleRateAttr.Value;
        //Assert.Equal(parentSampleRate, childSampleRate);
        //Assert.Equal(expectedTraceState, childResult.TraceState);
    }*/

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
        var result = sampler.ShouldSample(samplingParams);

        Assert.Equal(SamplingDecision.RecordOnly, result.Decision);
    }

    [Fact]
    public void AddsSampleRateAttrToSampledInSpan()
    {
        var sampler = new RateLimitedSampler(1);
        // sleeping to allow for the sampler to adapt. If we send the first span before the adaptation time has passed,
        // the span will not be sampled.
        System.Threading.Thread.Sleep(1000);
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

        // Simulate 1000 spans being created in just over 1 second.
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 200; j++)
            {
                var traceId = ActivityTraceId.CreateRandom();
                var samplingParams = new SamplingParameters(parentContext, traceId, $"TestActivity_{i}_{j}", ActivityKind.Internal);
                var result = sampler.ShouldSample(samplingParams);
                if (result.Decision == SamplingDecision.RecordAndSample)
                {
                    sampledin++;
                }
            }
            System.Threading.Thread.Sleep(200); // 0.2 seconds
        }

        // We would expect close to 50 be sampled in, but there may be some variance based on timing.
        Console.WriteLine($"Sampled in {sampledin} spans out of 1000 attempts.");
        Assert.InRange(sampledin, 50, 100);
    }

    [Fact]
    public void SpansUnderRateLimit()   
    {
        var sampler = new RateLimitedSampler(1000);
        int sampledin = 0;
        var parentContext = default(ActivityContext);

        // Simulate 50 spans being created in just over 1 second.
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                var traceId = ActivityTraceId.CreateRandom();
                var samplingParams = new SamplingParameters(parentContext, traceId, $"TestActivity_{i}_{j}", ActivityKind.Internal);
                var result = sampler.ShouldSample(samplingParams);
                if (result.Decision == SamplingDecision.RecordAndSample)
                {
                    sampledin++;
                }
            }
            System.Threading.Thread.Sleep(200); // 0.2 seconds
        }

        // We would expect close to 10 be sampled in, but there may be some variance based on timing.
        Console.WriteLine($"Sampled in {sampledin} spans out of 1000 attempts.");
        // assert that all of then spans were sampled in
        Assert.True(sampledin == 50, $"Expected 50 spans to be sampled in, but got {sampledin}.");
    }
}
