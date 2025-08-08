// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using OpenTelemetry.Trace;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals;

/// <summary>
/// Rate limited sampler for OpenTelemetry exporters.
/// This sampler allows a specified number of traces per second to be sampled.
/// </summary>
internal sealed class RateLimitedSampler : Sampler
{
    private readonly double targetTracesPerSecondLimit;

    /// <summary>
    /// Initializes a new instance of the <see cref="RateLimitedSampler"/> class.
    /// </summary>
    /// <param name="targetTracesPerSecondLimit">
    /// The target number of traces per second that should be sampled.
    /// For example, specifying 0.5 means one request every two seconds.
    /// </param>
    public RateLimitedSampler(double targetTracesPerSecondLimit)
    {
        if (targetTracesPerSecondLimit < 0.0)
        {
            throw new ArgumentOutOfRangeException(nameof(targetTracesPerSecondLimit), "Target traces per second limit must be non-negative.");
        }

        this.targetTracesPerSecondLimit = targetTracesPerSecondLimit;
        Description = "RateLimitedSampler{" + targetTracesPerSecondLimit + "}";
    }

    /// <summary>
    /// Decides whether to sample a given telemetry item based on the rate limit.
    /// </summary>
    /// <param name="samplingParameters">Parameters of telemetry item used to make sampling decision.</param>
    /// <returns>Returns whether or not we should sample telemetry in the form of a <see cref="SamplingResult"/> class.</returns>
    public override SamplingResult ShouldSample(in SamplingParameters samplingParameters)
    {
        throw new NotImplementedException();
    }
}
