// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using OpenTelemetry;
using OpenTelemetry.Logs;

namespace Azure.AI.AgentServer.Hosting.Internal;

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

        var baggage = activity.Baggage;
        var attributes = new List<KeyValuePair<string, object?>>();

        foreach (var item in baggage)
        {
            if (item.Value is not null)
            {
                attributes.Add(new KeyValuePair<string, object?>(item.Key, item.Value));
            }
        }

        if (attributes.Count > 0)
        {
            data.Attributes = attributes;
        }
    }
}
