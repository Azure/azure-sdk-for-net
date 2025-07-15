// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using OpenTelemetry.Trace;
using System.Diagnostics;

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
            Console.WriteLine("TraceState of parent activity:{0}", samplingParameters.ParentContext.TraceState);
            Console.WriteLine("TraceId of current span :{0}", samplingParameters.TraceId);
            Console.WriteLine("SpanId of current span :{0}", Activity.Current?.SpanId);
            // get the span context of the parent span
            var parentContext = samplingParameters.ParentContext;
            SamplingResult? samplingResult = useLocalParentDecisionIfPossible(parentContext);
            if (samplingResult != null)
            {
                return samplingResult.Value;
            }

            // 2. Obtain a sampling percentage (this is a number from 0 to 100)
            double samplingPercentage = _samplingPercentage.Get();
            Console.WriteLine("Sampling percentage: {0}", samplingPercentage);

            // 3. Use the sampling percentage to make a sampling decision
            if (samplingPercentage == 0)
            {
                // optimization, no need to calculate sample score in this case
                return RecordOnlySamplingResult;
            }

            if (samplingPercentage == 100)
            {
                // optimization, no need to calculate sample score in this case
                return new SamplingResult(SamplingDecision.RecordAndSample,
                    new List<KeyValuePair<string, object>> { new KeyValuePair<string, object>("microsoft.sample_rate", samplingPercentage) },
                    "microsoft.sample_rate=" + samplingPercentage.ToString("F2"));
            }

            // the sampling score is between 0 and 1, for correct comparison with samplingPercentage, we multiply by 100
            double sampleScore = 100 * SamplerUtils.DJB2SampleScore(samplingParameters.TraceId.ToHexString().ToUpperInvariant());
            Console.WriteLine("Sample score: {0}", sampleScore);
            if (sampleScore < samplingPercentage)
            {
                IEnumerable<KeyValuePair<string, object>> attributes = new List<KeyValuePair<string, object>>
                {
                    new KeyValuePair<string, object>("microsoft.sample_rate", samplingPercentage)
                };
                string traceState = "microsoft.sample_rate=" + samplingPercentage.ToString("F2");
                Console.WriteLine("TraceState: {0}", traceState);
                return new SamplingResult(SamplingDecision.RecordAndSample, attributes, traceState);
            }
            else
            {
                return RecordOnlySamplingResult;
            }
        }

        // this method is meant to honor the sampling decision of the local parent span if possible.
        // motivated from: https://github.com/microsoft/ApplicationInsights-Java/blob/3a5ab3354775f6454c74da837379afa66ae523e3/agent/agent-tooling/src/main/java/com/microsoft/applicationinsights/agent/internal/sampling/AiSampler.java#L93
        private SamplingResult? useLocalParentDecisionIfPossible(ActivityContext parentActivityContext)
        {
            // remote parent-based sampling messes up item counts since item count is not propagated in
            // tracestate (yet), but local parent-based sampling doesn't have this issue since we are
            // propagating item count locally
            Console.WriteLine("TraceState of parent activity:{0}", parentActivityContext.TraceState);
            Console.WriteLine("IsValid parentActivityContext:{0}", IsValid(parentActivityContext));
            Console.WriteLine("IsRemote parentActivityContext:{0}", parentActivityContext.IsRemote);
            Console.WriteLine("SpanId of parent activity:{0}", parentActivityContext.SpanId);
            if (!IsValid(parentActivityContext) || parentActivityContext.IsRemote)
            {
                return null;
            }

            bool isSampled = (parentActivityContext.TraceFlags & ActivityTraceFlags.Recorded) != 0;
            Console.WriteLine("IsSampled parentActivityContext:{0}", isSampled);
            if (!isSampled)
            {
                // record if parent is recorded but not sampled
                return RecordOnlySamplingResult;
            }

            if (parentActivityContext.TraceState == null)
            {
                // if we can't fetch the sampling rate of the parent from the tracestate, we can't honor the parent sampling decision
                return null;
            }

            // this is a span that has a local parent span that is sampled. Sample it in and include the sample rate from the parent.
            var attributes = new List<KeyValuePair<string, object>>();
            double? sampleRate = parseSampleRateFromTraceState(parentActivityContext.TraceState);
            Console.WriteLine("Parsed sample rate from trace state: {0}", sampleRate);
            if (sampleRate != null)
            {
                attributes.Add(new KeyValuePair<string, object>("microsoft.sample_rate", sampleRate));
            }
            return new SamplingResult(SamplingDecision.RecordAndSample, attributes, parentActivityContext.TraceState);
        }
        private double? parseSampleRateFromTraceState(string traceState)
        {
            if (string.IsNullOrEmpty(traceState))
            {
                return null;
            }

            string[] parts = traceState.Split('=');
            if (parts.Length != 2 || !double.TryParse(parts[1], out double sampleRate))
            {
                return null;
            }
            return sampleRate;
        }

        private bool IsValid(ActivityContext context)
        {
            // defining this manually as some dotnet versions do not have ActivityContext.IsValid
            // .NET 5 and earlier (.NET Core 3.1, .NET Standard 2.1, etc.) don't have it
            return context.TraceId != default && context.SpanId != default;
        }
    }
}
