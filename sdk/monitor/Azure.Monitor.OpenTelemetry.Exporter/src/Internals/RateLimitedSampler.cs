// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using OpenTelemetry.Trace;
using System.Diagnostics;
using System.Linq;

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

            SamplingResult? samplingResult = useLocalParentDecisionIfPossible(parentContext);
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
                Console.WriteLine("Sampling percentage is 0, returning RecordOnlySamplingResult.");
                return RecordOnlySamplingResult;
            }
            if (samplingPercentage == 100)
            {
                // optimization, no need to calculate sample score in this case
                var attributes = new List<KeyValuePair<string, object>>();
                // assuming that ingestion sampling applies at 100, so setting it to 99.99 so ingestion sampling does not apply
                attributes.Add(new KeyValuePair<string, object>("microsoft.sample_rate", 99.99));
                //string tracestate = "microsoft.sample_rate=99.99";
                Console.WriteLine("Sampling percentage is 100, returning RecordAndSample with sample rate 99.99.");
                //Activity.Current?.SetTag("microsoft.sample_rate", 99.99);
                return new SamplingResult(SamplingDecision.RecordAndSample,
                    attributes/*, tracestate*/);
            }

            // the sampling score is between 0 and 1, for correct comparison with samplingPercentage, we multiply by 100
            double sampleScore = 100 * SamplerUtils.DJB2SampleScore(samplingParameters.TraceId.ToHexString().ToUpperInvariant());
            if (sampleScore < samplingPercentage)
            {
                var attributes = new List<KeyValuePair<string, object>>();
                attributes.Add(new KeyValuePair<string, object>("microsoft.sample_rate", samplingPercentage));
                //Activity.Current?.SetTag("microsoft.sample_rate", samplingPercentage);
                //string tracestate = "microsoft.sample_rate=" + samplingPercentage.ToString("F2");
                Console.WriteLine($"Sampled with score {sampleScore} and sampling percentage {samplingPercentage}.");
                return new SamplingResult(SamplingDecision.RecordAndSample, attributes/*, tracestate*/);
            }
            else
            {
                Console.WriteLine($"Not sampled with score {sampleScore} and sampling percentage {samplingPercentage}.");
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
            if (!IsValid(parentActivityContext) || parentActivityContext.IsRemote)
            {
                Console.WriteLine($"Parent Activity Context is invalid or remote. Parent Activity Context Trace/Span Ids: {parentActivityContext.TraceId}, {parentActivityContext.SpanId}");
                return null;
            }

            bool isSampled = (parentActivityContext.TraceFlags & ActivityTraceFlags.Recorded) != 0;
            if (!isSampled)
            {
                // record only if parent is not sampled
                Console.WriteLine($"Parent Activity Context is not sampled. Parent Activity Context TraceFlag: {parentActivityContext.TraceFlags}");
                Console.WriteLine($"Activity.Current SpanId: {Activity.Current?.SpanId} and traceflags: {Activity.Current?.ActivityTraceFlags}");
                return RecordOnlySamplingResult;
            }

            // fetch the sampling rate from the parent span attributes
            Console.WriteLine($"Activity.Current TraceId: {Activity.Current?.TraceId}, SpanId: {Activity.Current?.SpanId}");
            var parentAttributes = Activity.Current?.Tags;
            string? parentSampleRate = parentAttributes?.FirstOrDefault(kv => kv.Key == "microsoft.sample_rate").Value;

            //double? parentSampleRate = parseSampleRateFromTraceState(parentActivityContext.TraceState ?? string.Empty);
            // this is a span that has a local parent span that is sampled. Sample it in and include the sample rate from the parent.
            if (parentSampleRate != null)
            {
                Console.WriteLine($"Parent Sample Rate: {parentSampleRate}");
                var attributes = new List<KeyValuePair<string, object>>();
                attributes.Add(new KeyValuePair<string, object>("microsoft.sample_rate", parentSampleRate));
                return new SamplingResult(SamplingDecision.RecordAndSample, attributes/*, parentActivityContext.TraceState*/);
            }

            // if we reach here, it means the parent span is sampled but does not have a sample rate set. The child should be sampled, we just
            // won't be able to propagate the sample rate.
            Console.WriteLine("Parent Activity Context is sampled but does not have a sample rate set.");
            return new SamplingResult(SamplingDecision.RecordAndSample);
        }

        private bool IsValid(ActivityContext context)
        {
            // defining this manually as some dotnet versions do not have ActivityContext.IsValid
            // .NET 5 and earlier (.NET Core 3.1, .NET Standard 2.1, etc.) don't have it
            return context.TraceId != default && context.SpanId != default;
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
    }
}
