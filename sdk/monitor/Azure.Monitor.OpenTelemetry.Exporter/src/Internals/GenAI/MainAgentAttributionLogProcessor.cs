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
            // Checking Name and Id suffices because any conforming GenAI
            // span will always carry at least the agent name attribute.
            if (activity.GetTagItem(MainAgentName) == null &&
                activity.GetTagItem(MainAgentId) == null)
            {
                return;
            }

            // Build a set of keys already present on the log record to avoid
            // adding duplicate attributes.
            var existingAttributes = logRecord.Attributes;
            HashSet<string>? existingKeys = null;
            if (existingAttributes != null && existingAttributes.Count > 0)
            {
                existingKeys = new HashSet<string>();
                foreach (var kvp in existingAttributes)
                {
                    existingKeys.Add(kvp.Key);
                }
            }

            // Collect values into a fixed-size buffer so we can check count
            // before allocating the merged list.
            var values = new KeyValuePair<string, object?>[s_mainAgentAttributes.Length];
            int count = 0;

            foreach (var attributeKey in s_mainAgentAttributes)
            {
                // Skip if the log record already carries this attribute.
                if (existingKeys != null && existingKeys.Contains(attributeKey))
                {
                    continue;
                }

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
