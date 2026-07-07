// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;

namespace Azure.AI.AgentServer.Responses.Models;

/// <summary>
/// Extension methods for creating immutable snapshots of <see cref="ResponseObject"/> objects.
/// </summary>
public static class ResponseSnapshotExtensions
{
    /// <summary>
    /// Creates an immutable deep copy of the <see cref="ResponseObject"/> via
    /// <see cref="ModelReaderWriter"/> round-trip serialization.
    /// </summary>
    /// <param name="response">The source response to snapshot.</param>
    /// <returns>
    /// A new <see cref="ResponseObject"/> instance that is fully independent of the original.
    /// Mutations to the original do not affect the snapshot and vice versa.
    /// </returns>
    /// <remarks>
    /// Uses <see cref="ModelReaderWriter.Write(object, ModelReaderWriterOptions, ModelReaderWriterContext)"/> and
    /// <see cref="ModelReaderWriter.Read{T}(BinaryData, ModelReaderWriterOptions, ModelReaderWriterContext)"/>
    /// which leverage the TypeSpec-generated <see cref="IPersistableModel{T}"/> implementation.
    /// This guarantees all properties — including polymorphic <see cref="OutputItem"/> subtypes,
    /// <see cref="BinaryData"/> union fields, and additional binary data properties — are
    /// fully serialized and deserialized into an independent object graph.
    /// </remarks>
    public static ResponseObject Snapshot(this ResponseObject response)
    {
        BinaryData data = ModelReaderWriter.Write(response, ModelReaderWriterOptions.Json, AzureAIAgentServerResponsesContext.Default);
        return ModelReaderWriter.Read<ResponseObject>(data, ModelReaderWriterOptions.Json, AzureAIAgentServerResponsesContext.Default)
            ?? throw new InvalidOperationException($"Failed to deserialize snapshot of {nameof(ResponseObject)}.");
    }

    /// <summary>
    /// If the event is a lifecycle event that embeds a <see cref="ResponseObject"/> reference,
    /// replaces it with an immutable snapshot of the given <paramref name="accumulator"/>.
    /// Non-lifecycle events are left unchanged.
    /// </summary>
    /// <param name="evt">The event whose embedded Response to replace.</param>
    /// <param name="accumulator">
    /// The mutable accumulator <see cref="ResponseObject"/> that has been updated by
    /// <c>UpdateFromEvent</c>. A snapshot of this is set on the event.
    /// </param>
    /// <remarks>
    /// The handler's local Response object may not have accumulated output items.
    /// The SDK's accumulator (<c>execution.Response</c>) is the authoritative state.
    /// Snapshotting the accumulator onto the event ensures the buffered event's payload
    /// reflects the full accumulated state at emission time.
    /// </remarks>
    public static void SnapshotEmbeddedResponse(this ResponseStreamEvent evt, ResponseObject accumulator)
    {
        switch (evt)
        {
            case ResponseCreatedEvent e:
                e.Response = accumulator.Snapshot();
                break;
            case ResponseInProgressEvent e:
                e.Response = accumulator.Snapshot();
                break;
            case ResponseCompletedEvent e:
                e.Response = accumulator.Snapshot();
                break;
            case ResponseFailedEvent e:
                e.Response = accumulator.Snapshot();
                break;
            case ResponseIncompleteEvent e:
                e.Response = accumulator.Snapshot();
                break;
            case ResponseQueuedEvent e:
                e.Response = accumulator.Snapshot();
                break;
        }
    }
}
