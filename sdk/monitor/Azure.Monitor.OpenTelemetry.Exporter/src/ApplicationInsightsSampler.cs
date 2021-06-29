// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

using OpenTelemetry;
using OpenTelemetry.Trace;

namespace Azure.Monitor.OpenTelemetry.Exporter
{
    public class ApplicationInsightsSampler : Sampler
    {
        private readonly float samplingRatio;

        public ApplicationInsightsSampler(float samplingRatio)
        {
            // Ensure passed ratio is between 0 and 1, inclusive
            if (samplingRatio < 0 || samplingRatio > 1)
            {
                throw new ArgumentOutOfRangeException(nameof(samplingRatio), "Ratio must be between 0 and 1, inclusive.");
            }
            this.samplingRatio = samplingRatio;
            Description = "ApplicationInsightsSampler{" + samplingRatio + "}";
        }

        public override SamplingResult ShouldSample(in SamplingParameters samplingParameters)
        {
            double sampleScore = DJB2SampleScore(samplingParameters.TraceId.ToHexString().ToLowerInvariant());
            return new SamplingResult(sampleScore < samplingRatio);
        }

        private static double DJB2SampleScore(string traceIdHex)
        {
            // Calculate DJB2 hash code from hex-converted TraceId
            int hash = 5381;

            for (int i = 0; i < traceIdHex.Length; i++)
            {
                hash = ((hash << 5) + hash) + (int)traceIdHex[i];
            }

            // Take the absolute value of the hash
            if (hash == int.MinValue)
            {
                hash = int.MaxValue;
            }
            else
            {
                hash = Math.Abs(hash);
            }

            // Divide by MaxValue for value between 0 and 1 for sampling score
            double samplingScore = (double)hash / int.MaxValue;
            return samplingScore;
        }
    }
}
