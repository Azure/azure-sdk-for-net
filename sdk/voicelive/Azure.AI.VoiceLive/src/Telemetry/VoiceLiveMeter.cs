// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.Metrics;

namespace Azure.AI.VoiceLive.Telemetry
{
    internal static class VoiceLiveMeter
    {
        private static readonly Meter s_meter = new Meter("Azure.AI.VoiceLive", "1.1.0");

        /// <summary>Duration of a VoiceLive session in seconds (gen_ai.client.operation.duration).</summary>
        internal static readonly Histogram<double> OperationDuration = s_meter.CreateHistogram<double>(
            "gen_ai.client.operation.duration", "s", "Duration of the VoiceLive session.");

        /// <summary>Token counts per turn (gen_ai.client.token.usage). Dimension gen_ai.token.type = input|output.</summary>
        internal static readonly Histogram<long> TokenUsage = s_meter.CreateHistogram<long>(
            "gen_ai.client.token.usage", "{token}", "Number of input and output tokens consumed.");
    }
}
