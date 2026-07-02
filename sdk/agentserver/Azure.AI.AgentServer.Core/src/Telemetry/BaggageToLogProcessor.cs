// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using OpenTelemetry;
using OpenTelemetry.Logs;

namespace Azure.AI.AgentServer.Core.Internal;

/// <summary>
/// OpenTelemetry log processor that copies W3C Baggage key-value pairs from
/// <see cref="Activity.Current"/> into every log record as attributes.
/// This ensures baggage values (e.g., <c>response_id</c>, <c>invocation_id</c>,
/// <c>x-request-id</c>) appear in log records even when the call site does not
/// explicitly include them.
/// </summary>
internal sealed class BaggageToLogProcessor : BaseProcessor<LogRecord>
{
    /// <inheritdoc />
    public override void OnEnd(LogRecord data)
    {
        var activity = Activity.Current;
        if (activity is null)
        {
            return;
        }

        // Merge baggage into existing attributes without overwriting any
        // attributes already set by the call-site or earlier processors.
        var existing = data.Attributes;
        HashSet<string>? existingKeys = null;
        List<KeyValuePair<string, object?>>? merged = null;

        foreach (var item in activity.Baggage)
        {
            if (item.Value is null)
            {
                continue;
            }

            // Lazily build the set of existing keys on first baggage hit.
            if (existingKeys is null && existing is not null)
            {
                existingKeys = new HashSet<string>(StringComparer.Ordinal);
                foreach (var attr in existing)
                {
                    existingKeys.Add(attr.Key);
                }
            }

            // Skip baggage entries whose key already exists in the log record.
            if (existingKeys is not null && existingKeys.Contains(item.Key))
            {
                continue;
            }

            merged ??= existing is not null
                ? new List<KeyValuePair<string, object?>>(existing)
                : new List<KeyValuePair<string, object?>>();
            merged.Add(new KeyValuePair<string, object?>(item.Key, item.Value));
        }

        if (merged is not null)
        {
            data.Attributes = merged;
        }
    }
}
