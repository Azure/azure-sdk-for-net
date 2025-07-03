using System;
using System.Collections.Generic;
using OpenTelemetry.Trace;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals
{
    internal class RateLimitedSampler : Sampler
    {
        private static readonly SamplingResult RecordOnlySamplingResult = new(SamplingDecision.RecordOnly);
        private static readonly SamplingResult RecordAndSampleSamplingResult = new(SamplingDecision.RecordAndSample);
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
            var parentActivityContext = parentContext.ActivityContext;

            // TODO: respect the sampling decision of the parent span if available


            // 2. Obtain a sampling percentage (this is a number from 0 to 100)
            double samplingPercentage = _samplingPercentage.Get();

            // 3. Use the sampling percentage to make a sampling decision
            double sampleScore = 100 * SamplerUtils.DJB2SampleScore(samplingParameters.TraceId.ToHexString().ToUpperInvariant());
            if (sampleScore < samplingPercentage)
            {
                attributes.Add(new KeyValuePair<string, object>("microsoft.sample_rate", samplingPercentage));
                return RecordAndSampleSamplingResult;
            }
            else
            {
                return RecordOnlySamplingResult;
            }
        }

        private SamplingResult useLocalParentDecisionIfPossible(ActivityContext parentActivityContext)
        {
            if (!parentActivityContext.IsValid && parentActivityContext.IsRemote)
            {
                // If the parent span is sampled, we should sample this span as well
                return null;
            }
            if (!parentActivityContext.IsSampled())
            {
                return RecordOnlySamplingResult;
            }
        }


    }
}
