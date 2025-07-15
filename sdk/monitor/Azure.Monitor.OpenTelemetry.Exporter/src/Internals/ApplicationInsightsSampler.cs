// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using OpenTelemetry.Trace;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals;

/// <summary>
/// Sample configurable for OpenTelemetry exporters for compatibility
/// with Application Insight SDKs.
/// </summary>
internal sealed class ApplicationInsightsSampler : Sampler
{
    private static readonly SamplingResult RecordOnlySamplingResult = new(SamplingDecision.RecordOnly);
    private static readonly SamplingResult RecordAndSampleSamplingResult = new(SamplingDecision.RecordAndSample);
    private readonly float samplingRatio;

    /// <summary>
    /// Initializes a new instance of the <see cref="ApplicationInsightsSampler"/> class.
    /// </summary>
    /// <param name="samplingRatio">
    /// Ratio of telemetry that should be sampled.
    /// For example; Specifying 0.4F means 40% of traces are sampled and 60% are dropped.
    /// </param>
    public ApplicationInsightsSampler(float samplingRatio)
    {
        // Ensure passed ratio is between 0 and 1, inclusive
        if (samplingRatio < 0.0F || samplingRatio > 1.0F)
        {
            throw new ArgumentOutOfRangeException(nameof(samplingRatio), "Sampling ratio must be between 0.0 and 1.0 (inclusive).");
        }

        this.samplingRatio = samplingRatio;
        Description = "ApplicationInsightsSampler{" + samplingRatio + "}";
    }

    /// <summary>
    /// Computational method using the DJB2 Hash algorithm to decide whether to sample
    /// a given telemetry item, based on its Trace Id.
    /// </summary>
    /// <param name="samplingParameters">Parameters of telemetry item used to make sampling decision.</param>
    /// <returns>Returns whether or not we should sample telemetry in the form of a <see cref="SamplingResult"/> class.</returns>
    public override SamplingResult ShouldSample(in SamplingParameters samplingParameters)
    {
        if (samplingRatio == 1)
        {
            return RecordAndSampleSamplingResult;
        }

        if (samplingRatio == 0)
        {
            return RecordOnlySamplingResult;
        }

        double sampleScore = SamplerUtils.DJB2SampleScore(samplingParameters.TraceId.ToHexString().ToUpperInvariant());

        if (sampleScore < samplingRatio)
        {
            return RecordAndSampleSamplingResult;
        }
        else
        {
            return RecordOnlySamplingResult;
        }
    }
}
