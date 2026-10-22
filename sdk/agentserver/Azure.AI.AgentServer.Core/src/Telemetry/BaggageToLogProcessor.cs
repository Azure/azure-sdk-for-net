// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using OpenTelemetry;
using OpenTelemetry.Logs;

namespace Azure.AI.AgentServer.Core.Internal;

/// <summary>
/// OpenTelemetry log processor that stamps the Foundry marker and copies W3C Baggage key-value pairs from
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
        var merged = new List<KeyValuePair<string, object?>>();
        var existingKeys = new HashSet<string>(StringComparer.Ordinal)
        {
            AgentHostTelemetry.FoundryAttributeName
        };

        if (data.Attributes is not null)
        {
            foreach (var attribute in data.Attributes)
            {
                if (attribute.Key != AgentHostTelemetry.FoundryAttributeName)
                {
                    merged.Add(attribute);
                    existingKeys.Add(attribute.Key);
                }
            }
        }

        // Preserve call-site attributes, except for the authoritative Foundry marker.
        var activity = Activity.Current;
        if (activity is not null)
        {
            foreach (var item in activity.Baggage)
            {
                if (item.Value is not null && existingKeys.Add(item.Key))
                {
                    merged.Add(new KeyValuePair<string, object?>(item.Key, item.Value));
                }
            }
        }

        merged.Add(new KeyValuePair<string, object?>(
            AgentHostTelemetry.FoundryAttributeName, AgentHostTelemetry.FoundryAttributeValue));
        data.Attributes = merged;
    }
}
