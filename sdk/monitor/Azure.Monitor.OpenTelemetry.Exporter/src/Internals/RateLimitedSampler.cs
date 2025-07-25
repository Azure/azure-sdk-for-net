// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using OpenTelemetry.Trace;
using System.Diagnostics;
using System.Linq;
using System.Collections.Concurrent;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals
{
    internal class RateLimitedSampler : Sampler
    {
        private static readonly SamplingResult RecordOnlySamplingResult = new(SamplingDecision.RecordOnly);
        private readonly RateLimitedSamplingPercentage _samplingPercentage;

        public RateLimitedSampler(double targetSpansPerSecondLimit)
        {
            _samplingPercentage = new RateLimitedSamplingPercentage(targetSpansPerSecondLimit);
        }

        public override SamplingResult ShouldSample(in SamplingParameters samplingParameters)
        {
            // 1. Respect the sampling decision of the local parent span

            // get the span context of the parent span
            var parentContext = samplingParameters.ParentContext;

            // grab the parent sampling rate if it exists
            var parentAttributes = Activity.Current?.TagObjects;
            object? parentSampleRate = parentAttributes?.FirstOrDefault(kv => kv.Key == "microsoft.sample_rate").Value;

            SamplingResult? samplingResult = useLocalParentDecisionIfPossible(parentContext, parentSampleRate) ;
            if (samplingResult != null)
            {
                return samplingResult.Value;
            }

            // 2. Obtain a sampling percentage (this is a number from 0 to 100)
            double samplingPercentage = _samplingPercentage.Get();

            // 3. Use the sampling percentage to make a sampling decision
            if (samplingPercentage == 0)
            {
                // optimization, no need to calculate sample score in this case
                return RecordOnlySamplingResult;
            }

            if (samplingPercentage == 100)
            {
                // optimization, no need to calculate sample score in this case
                var attributes = new List<KeyValuePair<string, object>>();
                attributes.Add(new KeyValuePair<string, object>("microsoft.sample_rate", samplingPercentage));
                return new SamplingResult(SamplingDecision.RecordAndSample,
                    attributes);
            }

            // the sampling score is between 0 and 1, for correct comparison with samplingPercentage, we multiply by 100
            double sampleScore = 100 * SamplerUtils.DJB2SampleScore(samplingParameters.TraceId.ToHexString().ToUpperInvariant());
            if (sampleScore < samplingPercentage)
            {
                var attributes = new List<KeyValuePair<string, object>>();
                attributes.Add(new KeyValuePair<string, object>("microsoft.sample_rate", samplingPercentage));
                return new SamplingResult(SamplingDecision.RecordAndSample, attributes);
            }
            else
            {
                return RecordOnlySamplingResult;
            }
        }

        // this method is meant to honor the sampling decision of the local parent span if possible.
        // motivated from: https://github.com/microsoft/ApplicationInsights-Java/blob/3a5ab3354775f6454c74da837379afa66ae523e3/agent/agent-tooling/src/main/java/com/microsoft/applicationinsights/agent/internal/sampling/AiSampler.java#L93
        private SamplingResult? useLocalParentDecisionIfPossible(ActivityContext parentActivityContext, object? parentSampleRate)
        {
            // remote parent-based sampling messes up item counts since item count is not propagated in
            // tracestate (yet), but local parent-based sampling doesn't have this issue since we are
            // propagating item count locally
            if (!IsValid(parentActivityContext) || parentActivityContext.IsRemote)
            {
                return null;
            }

            bool isSampled = (parentActivityContext.TraceFlags & ActivityTraceFlags.Recorded) != 0;
            if (!isSampled)
            {
                // record only if parent is not sampled
                return RecordOnlySamplingResult;
            }

            // this is a span that has a local parent span that is sampled. Sample it in and include the sample rate from the parent.
            if (parentSampleRate != null)
            {
                var attributes = new List<KeyValuePair<string, object>>();
                attributes.Add(new KeyValuePair<string, object>("microsoft.sample_rate", parentSampleRate));
                return new SamplingResult(SamplingDecision.RecordAndSample, attributes);
            }

            // if we reach here, it means the parent span is sampled but does not have a sample rate set. The child should be sampled, we just
            // won't be able to propagate the sample rate. Technically we should not reach here.
            return new SamplingResult(SamplingDecision.RecordAndSample);
        }

        private bool IsValid(ActivityContext context)
        {
            // defining this manually as some dotnet versions do not have ActivityContext.IsValid
            // .NET 5 and earlier (.NET Core 3.1, .NET Standard 2.1, etc.) don't have it
            return context.TraceId != default && context.SpanId != default;
        }
    }
}
