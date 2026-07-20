// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Responses.Models;

namespace Azure.AI.AgentServer.Responses;

/// <summary>
/// Provides event streaming infrastructure for Server-Sent Events (SSE) delivery.
/// Extend this class to back SSE streaming with a custom transport
/// (e.g., Redis Streams, Kafka, Azure Service Bus).
/// </summary>
/// <remarks>
/// <para>
/// Event streaming uses <see cref="IAsyncObserver{T}"/>. Observer methods return
/// <see cref="ValueTask"/> and do not accept <see cref="CancellationToken"/>
/// — subscription cancellation is handled via <see cref="IAsyncDisposable"/>.
/// </para>
/// <para>
/// When no custom implementation is registered, the SDK provides an
/// in-memory default that is automatically registered by
/// <c>AddResponsesServer()</c>.
/// </para>
/// </remarks>
public abstract class ResponsesStreamProvider
{
    /// <summary>
    /// Creates an event publisher for the specified response.
    /// The SDK pushes SSE events through the returned observer.
    /// </summary>
    /// <param name="responseId">The unique response identifier.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>
    /// An <see cref="IAsyncObserver{T}"/> that the SDK calls
    /// <c>OnNextAsync</c> on to push events. The implementation assigns
    /// sequence numbers (via <see cref="ResponseStreamEvent.SequenceNumber"/>)
    /// before storing. The SDK calls <c>OnCompletedAsync</c> when the
    /// event stream ends.
    /// </returns>
    public abstract Task<IAsyncObserver<ResponseStreamEvent>> CreateEventPublisherAsync(
        string responseId,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Subscribes to events for the specified response.
    /// </summary>
    /// <param name="responseId">The unique response identifier.</param>
    /// <param name="observer">
    /// An SDK-provided observer that the implementation calls
    /// <c>OnNextAsync</c> on to deliver events. Events are delivered with
    /// <see cref="ResponseStreamEvent.SequenceNumber"/> already set.
    /// </param>
    /// <param name="cursor">
    /// An optional sequence number. When provided, only events after this
    /// cursor are delivered, then live events continue. When <c>null</c>,
    /// all available events are delivered from the beginning.
    /// </param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>
    /// A disposable resource that the SDK releases on SSE client disconnect.
    /// The implementation should clean up its subscription state when disposed.
    /// </returns>
    public abstract Task<IAsyncDisposable> SubscribeToEventsAsync(
        string responseId,
        IAsyncObserver<ResponseStreamEvent> observer,
        long? cursor = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes the event stream for the specified response, removing all buffered events.
    /// Called when a response is deleted or when a non-background/non-streaming response
    /// completes (its event stream is not eligible for SSE replay per B2).
    /// </summary>
    /// <param name="responseId">The unique response identifier.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    public virtual Task DeleteEventStreamAsync(
        string responseId,
        CancellationToken cancellationToken = default)
        => Task.CompletedTask;
}
