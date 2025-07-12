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
    [Fact]
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
        string expectedTraceState = "microsoft.sample_rate=" + sampleRate.ToString("F2");
        Assert.Equal(expectedTraceState, result.TraceState);
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

        // Only one should be sampled in, the other should be dropped
        int sampledCount = 0;
        if (result1.Decision == SamplingDecision.RecordAndSample) sampledCount++;
        if (result2.Decision == SamplingDecision.RecordAndSample) sampledCount++;

        Assert.Equal(1, sampledCount);
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
        Assert.Equal(expectedTraceState, parentResult.TraceState);

        // Create a child span with the parent context
        var childSpanId = ActivitySpanId.CreateRandom();
        var childContext = new ActivityContext(parentTraceId, childSpanId, ActivityTraceFlags.None, traceState: parentResult.TraceState, isRemote: false);
        var childSamplingParams = new SamplingParameters(childContext, parentTraceId, "ChildActivity", ActivityKind.Internal);
        var childResult = sampler.ShouldSample(childSamplingParams);

        // Assert child span is sampled and has same attribute and tracestate
        Assert.Equal(SamplingDecision.RecordAndSample, childResult.Decision);
        var childSampleRateAttr = Assert.Single(childResult.Attributes, kvp => kvp.Key == "microsoft.sample_rate");
        Assert.IsType<double>(childSampleRateAttr.Value);
        double childSampleRate = (double)childSampleRateAttr.Value;
        Assert.Equal(parentSampleRate, childSampleRate);
        Assert.Equal(expectedTraceState, childResult.TraceState);
    }
}
