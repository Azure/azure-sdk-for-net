// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.AgentServer.Responses.Tests.Helpers;

/// <summary>
/// Represents a single parsed SSE event from a raw byte stream.
/// </summary>
/// <param name="EventType">The value of the "event:" line.</param>
/// <param name="Data">The value of the "data:" line (raw JSON string).</param>
public record SseEvent(string EventType, string Data);

/// <summary>
/// Minimal SSE parser for protocol conformance tests.
/// Parses raw SSE text into <see cref="SseEvent"/> records.
/// </summary>
public static class SseParser
{
    /// <summary>
    /// Parses raw SSE body text into a list of events.
    /// Ignores SSE comments (lines starting with ":") and blank lines.
    /// </summary>
    /// <param name="rawBody">The raw response body as a string.</param>
    /// <returns>A list of parsed SSE events.</returns>
    public static List<SseEvent> Parse(string rawBody)
    {
        var events = new List<SseEvent>();
        var blocks = rawBody.Split("\n\n", StringSplitOptions.RemoveEmptyEntries);

        foreach (var block in blocks)
        {
            string? eventType = null;
            string? data = null;

            foreach (var line in block.Split('\n'))
            {
                if (line.StartsWith("event: "))
                    eventType = line["event: ".Length..];
                else if (line.StartsWith("data: "))
                    data = line["data: ".Length..];
                // Lines starting with ":" are comments (keep-alive) — skip
            }

            if (eventType is not null && data is not null)
                events.Add(new SseEvent(eventType, data));
        }

        return events;
    }
}
