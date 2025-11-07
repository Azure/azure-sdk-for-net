// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using OpenTelemetry;
using OpenTelemetry.Logs;

namespace Azure.AI.AgentServer.Core.Telemetry
{
    /// <summary>
    /// Processor that enriches log records with baggage information.
    /// </summary>
    public class LogEnrichmentProcessor : BaseProcessor<LogRecord>
    {
        /// <summary>
        /// Called when a log record ends, enriches it with current baggage data.
        /// </summary>
        /// <param name="data">The log record to enrich.</param>
        public override void OnEnd(LogRecord data)
        {
            var currentBaggage = Baggage.Current.GetBaggage().ToDictionary();
            data.Attributes = MergeAttributes(data.Attributes, currentBaggage);
            base.OnEnd(data);
        }

        private List<KeyValuePair<string, object?>> MergeAttributes(
            IEnumerable<KeyValuePair<string, object?>>? original, Dictionary<string, string>? additional)
        {
            var dict = original?.ToDictionary(kv => kv.Key, kv => kv.Value) ?? new Dictionary<string, object?>();
            if (additional != null)
            {
                foreach (var kv in additional)
                {
                    dict[kv.Key] = kv.Value;
                }
            }

            return dict.ToList();
        }
    }
}
