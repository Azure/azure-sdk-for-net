// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals
{
    internal static class SamplerUtils
    {
        public static double DJB2SampleScore(string traceIdHex)
        {
            // Calculate DJB2 hash code from hex-converted TraceId
            int hash = 5381;

            for (int i = 0; i < traceIdHex.Length; i++)
            {
                unchecked
                {
                    hash = (hash << 5) + hash + (int)traceIdHex[i];
                }
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
