// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using Azure.AI.AgentServer.Core;
using Azure.AI.AgentServer.Responses.Internal.Resilience;
using Azure.AI.AgentServer.Responses.Models;

namespace Azure.AI.AgentServer.Responses.Internal;

/// <summary>
/// Writes <see cref="ResponseStreamEvent"/> objects to a stream as SSE
/// with <c>event:</c> + <c>data:</c> lines. Writes are serialized through a
/// shared <see cref="SseKeepAliveSession"/> so that periodic keep-alive
/// comments emitted by the session's timer never interleave with event
/// frames.
/// </summary>
[System.Diagnostics.CodeAnalysis.Experimental("AAIP002")]
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
    /// Serializes a response event into the SSE frame fields the wire carries: the SSE event name
    /// (<c>event:</c>) and the JSON payload (<c>data:</c>) with the SDK-assigned
    /// <paramref name="sequenceNumber"/> injected and internal metadata stripped. This is the single
    /// point of client-facing event serialization, shared by the live writer
    /// (<see cref="WriteEventAsync"/>) and the Core event-stream codec (<see cref="ResponseWireStreamCodec"/>)
    /// so replayed and live frames are byte-identical.
    /// </summary>
    /// <param name="evt">The event to serialize.</param>
    /// <param name="sequenceNumber">The sequence number to inject into the payload.</param>
    /// <param name="jsonOptions">JSON serializer options for event data.</param>
    /// <returns>The SSE event name (may be <see langword="null"/>) and the JSON data payload.</returns>
    public static (string? EventType, string Data) SerializeEvent(
        ResponseStreamEvent evt, long sequenceNumber, JsonSerializerOptions jsonOptions)
    {
        var eventType = evt.Kind.ToString();
        var json = JsonSerializer.Serialize(evt, evt.GetType(), jsonOptions);

        // Inject the SDK-assigned sequence number into the serialized JSON and strip internal metadata
        // so the client never observes server-internal fields.
        var node = JsonNode.Parse(json)!;
        InternalMetadataEgress.Strip(node);
        node["sequence_number"] = sequenceNumber;
        return (eventType, node.ToJsonString(jsonOptions));
    }

    /// <summary>
    /// Writes a pre-serialized SSE event frame (<c>event:</c> + <c>data:</c>) directly to the stream.
    /// Used to relay a frame already produced by <see cref="SerializeEvent"/> (e.g., replayed from the
    /// Core event stream) without re-serializing, so a frame that never round-trips through a model is
    /// forwarded verbatim.
    /// </summary>
    /// <param name="eventType">The SSE event name, or <see langword="null"/>.</param>
    /// <param name="data">The already-serialized JSON data payload.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    public async Task WriteRawEventAsync(string? eventType, string data, CancellationToken cancellationToken)
    {
        var sseBlock = $"event: {eventType}\ndata: {data}\n\n";
        var bytes = Encoding.UTF8.GetBytes(sseBlock);

        await _session.Stream.WriteAsync(bytes, cancellationToken).ConfigureAwait(false);
        await _session.Stream.FlushAsync(cancellationToken).ConfigureAwait(false);
    }

    /// <summary>
    /// Writes a single SSE event with <c>event:</c> and <c>data:</c> lines,
    /// injecting the given <paramref name="sequenceNumber"/> into the JSON payload.
    /// </summary>
    /// <param name="evt">The event to write.</param>
    /// <param name="sequenceNumber">The sequence number to inject.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    public Task WriteEventAsync(ResponseStreamEvent evt, long sequenceNumber, CancellationToken cancellationToken)
    {
        var (eventType, data) = SerializeEvent(evt, sequenceNumber, _jsonOptions);
        return WriteRawEventAsync(eventType, data, cancellationToken);
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
