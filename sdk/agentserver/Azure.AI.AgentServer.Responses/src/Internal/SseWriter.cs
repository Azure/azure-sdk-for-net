// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using Azure.AI.AgentServer.Core;
using Azure.AI.AgentServer.Responses.Models;

#pragma warning disable AZC0100 // ConfigureAwait(false) must be used.

namespace Azure.AI.AgentServer.Responses.Internal;

/// <summary>
/// Writes <see cref="ResponseStreamEvent"/> objects to a stream as SSE
/// with <c>event:</c> + <c>data:</c> lines. Writes are serialized through a
/// shared <see cref="SseKeepAliveSession"/> so that periodic keep-alive
/// comments emitted by the session's timer never interleave with event
/// frames.
/// </summary>
internal sealed class SseWriter
{
    private readonly SseKeepAliveSession _session;
    private readonly JsonSerializerOptions _jsonOptions;

    /// <summary>
    /// Initializes a new instance of <see cref="SseWriter"/>.
    /// </summary>
    /// <param name="session">The keep-alive session whose synchronized stream this writer uses.</param>
    /// <param name="jsonOptions">JSON serializer options for event data.</param>
    public SseWriter(SseKeepAliveSession session, JsonSerializerOptions jsonOptions)
    {
        _session = session;
        _jsonOptions = jsonOptions;
    }

    /// <summary>
    /// Writes a single SSE event with <c>event:</c> and <c>data:</c> lines,
    /// injecting the given <paramref name="sequenceNumber"/> into the JSON payload.
    /// </summary>
    /// <param name="evt">The event to write.</param>
    /// <param name="sequenceNumber">The sequence number to inject.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    public async Task WriteEventAsync(ResponseStreamEvent evt, long sequenceNumber, CancellationToken cancellationToken)
    {
        var eventType = evt.EventType.ToString();
        var json = JsonSerializer.Serialize(evt, evt.GetType(), _jsonOptions);

        // Inject the SDK-assigned sequence number into the serialized JSON
        var node = JsonNode.Parse(json)!;
        node["sequence_number"] = sequenceNumber;
        json = node.ToJsonString(_jsonOptions);

        var sseBlock = $"event: {eventType}\ndata: {json}\n\n";
        var bytes = Encoding.UTF8.GetBytes(sseBlock);

        await _session.Stream.WriteAsync(bytes, cancellationToken).ConfigureAwait(false);
        await _session.Stream.FlushAsync(cancellationToken).ConfigureAwait(false);
    }

    /// <summary>
    /// Writes a standalone SSE error event (not a <c>response.*</c> lifecycle event).
    /// Used for pre-<c>response.created</c> bad handler errors.
    /// </summary>
    /// <param name="errorEvent">The error event to write.</param>
    public async Task WriteErrorEventAsync(ResponseErrorEvent errorEvent)
    {
        var errorJson = JsonSerializer.Serialize(errorEvent, _jsonOptions);

        var sseBlock = $"event: error\ndata: {errorJson}\n\n";
        var bytes = Encoding.UTF8.GetBytes(sseBlock);

        await _session.Stream.WriteAsync(bytes, CancellationToken.None).ConfigureAwait(false);
        await _session.Stream.FlushAsync(CancellationToken.None).ConfigureAwait(false);
    }
}

#pragma warning restore AZC0100
