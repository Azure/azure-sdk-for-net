// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Globalization;
using System.Net.ServerSentEvents;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading;
using Azure.AI.AgentServer.Responses.Models;

namespace Azure.AI.AgentServer.Responses.Internal;

/// <summary>
/// Bridges <see cref="ResponseStreamEvent"/> objects and the Core event-stream wire item
/// (<see cref="SseItem{T}"/> of <see cref="string"/>). The Core event stream carries already-serialized,
/// client-ready SSE frames: the <c>data:</c> payload in <see cref="SseItem{T}.Data"/>, the SSE event name
/// (<c>event:</c>) in <see cref="SseItem{T}.EventType"/>, and the monotonic
/// <see cref="ResponseStreamEvent.SequenceNumber"/> in <see cref="SseItem{T}.EventId"/> (the
/// replay/reconnect token).
/// </summary>
/// <remarks>
/// The frame is produced once at emit time via <see cref="SseWriter.SerializeEvent"/> — the same
/// serialization the live writer uses — so a replayed or relayed frame is byte-identical to the live
/// one and is forwarded to the client verbatim (via <see cref="SseWriter.WriteRawEventAsync"/>) without a
/// model round-trip. This mirrors the reference implementation, whose streams carry SSE text rather than
/// event objects, and preserves the prior behavior in which a malformed handler event (e.g. one with no
/// discriminator) was serialized once and never deserialized.
/// </remarks>
[System.Diagnostics.CodeAnalysis.Experimental("AAIP002")]
internal static class ResponseWireStreamCodec
{
    /// <summary>Serializes a response event into a client-ready Core event-stream wire item.</summary>
    /// <param name="value">The event to serialize; its <see cref="ResponseStreamEvent.SequenceNumber"/> must already be assigned.</param>
    /// <param name="jsonOptions">JSON serializer options for event data.</param>
    /// <returns>The wire item carrying the serialized frame, its SSE event name, and its sequence-number id.</returns>
    public static SseItem<string> ToWireItem(ResponseStreamEvent value, JsonSerializerOptions jsonOptions)
    {
        var (eventType, data) = SseWriter.SerializeEvent(value, value.SequenceNumber, jsonOptions);
        return new SseItem<string>(data, eventType)
        {
            EventId = value.SequenceNumber.ToString(CultureInfo.InvariantCulture),
        };
    }

    /// <summary>
    /// Projects a stream of response events into client-ready wire items so a live-yielding source can be
    /// relayed through the same raw SSE writer as replayed frames.
    /// </summary>
    /// <param name="events">The source events.</param>
    /// <param name="jsonOptions">JSON serializer options for event data.</param>
    /// <param name="cancellationToken">A token to stop projecting.</param>
    /// <returns>The projected wire items.</returns>
    public static async IAsyncEnumerable<SseItem<string>> ToWireItems(
        IAsyncEnumerable<ResponseStreamEvent> events,
        JsonSerializerOptions jsonOptions,
        [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        await foreach (var evt in events.WithCancellation(cancellationToken).ConfigureAwait(false))
        {
            yield return ToWireItem(evt, jsonOptions);
        }
    }

    /// <summary>
    /// Deserializes a Core event-stream wire item back into a response event. Used by tests that inspect
    /// the events published onto the stream; the client egress paths forward the frame verbatim and never
    /// deserialize.
    /// </summary>
    /// <param name="item">The wire item whose <see cref="SseItem{T}.Data"/> holds the serialized event.</param>
    /// <returns>The deserialized event, with <see cref="ResponseStreamEvent.SequenceNumber"/> restored.</returns>
    public static ResponseStreamEvent FromWireItem(SseItem<string> item)
        => ModelReaderWriter.Read<ResponseStreamEvent>(
            BinaryData.FromString(item.Data),
            ModelReaderWriterOptions.Json,
            AzureAIAgentServerResponsesContext.Default)!;
}
