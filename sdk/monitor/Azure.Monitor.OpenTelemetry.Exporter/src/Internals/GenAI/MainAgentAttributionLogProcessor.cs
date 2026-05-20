// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Diagnostics;
using OpenTelemetry;
using OpenTelemetry.Logs;

using static Azure.Monitor.OpenTelemetry.Exporter.Internals.GenAI.MainAgentAttributeConstants;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals.GenAI
{
    /// <summary>
    /// A log processor that copies main-agent attributes from the current span
    /// onto emitted log records so that logs are attributed to the user-facing agent.
    /// </summary>
    internal sealed class MainAgentAttributionLogProcessor : BaseProcessor<LogRecord>
    {
        private static readonly string[] s_mainAgentAttributes = new[]
        {
            MainAgentName,
            MainAgentId,
            MainAgentVersion,
            MainAgentConversationId,
        };

        public override void OnEnd(LogRecord logRecord)
        {
            var activity = Activity.Current;
            if (activity == null)
            {
                return;
            }

            // Quick check: skip if current span has no main agent attributes.
            if (activity.GetTagItem(MainAgentName) == null &&
                activity.GetTagItem(MainAgentId) == null)
            {
                return;
            }

            // Collect values into a stack-friendly fixed-size buffer to avoid
            // unnecessary List allocations on every log record.
            var values = new KeyValuePair<string, object?>[s_mainAgentAttributes.Length];
            int count = 0;

            foreach (var attributeKey in s_mainAgentAttributes)
            {
                var value = activity.GetTagItem(attributeKey);
                if (value != null)
                {
                    values[count++] = new KeyValuePair<string, object?>(attributeKey, value);
                }
            }

            if (count == 0)
            {
                return;
            }

            var existingAttributes = logRecord.Attributes;
            var merged = new List<KeyValuePair<string, object?>>(
                (existingAttributes?.Count ?? 0) + count);

            if (existingAttributes != null)
            {
                merged.AddRange(existingAttributes);
            }

            for (int i = 0; i < count; i++)
            {
                merged.Add(values[i]);
            }

            logRecord.Attributes = merged;
        }
    }
}
