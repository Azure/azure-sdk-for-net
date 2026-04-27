// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Responses.Models;

namespace Azure.AI.AgentServer.Responses.Internal;

/// <summary>
/// Adapter that exposes the streaming capabilities of <see cref="InMemoryResponsesProvider"/>
/// as a <see cref="ResponsesStreamProvider"/>.
/// </summary>
internal sealed class InMemoryStreamProvider : ResponsesStreamProvider
{
    private readonly InMemoryResponsesProvider _provider;

    public InMemoryStreamProvider(InMemoryResponsesProvider provider)
    {
        _provider = provider;
    }

    /// <inheritdoc/>
    public override Task<IAsyncObserver<ResponseStreamEvent>> CreateEventPublisherAsync(
        string responseId, CancellationToken cancellationToken = default)
        => _provider.CreateEventPublisherAsync(responseId, cancellationToken);

    /// <inheritdoc/>
    public override Task<IAsyncDisposable> SubscribeToEventsAsync(
        string responseId,
        IAsyncObserver<ResponseStreamEvent> observer,
        long? cursor = null,
        CancellationToken cancellationToken = default)
        => _provider.SubscribeToEventsAsync(responseId, observer, cursor, cancellationToken);

    /// <inheritdoc/>
    public override Task DeleteEventStreamAsync(
        string responseId,
        CancellationToken cancellationToken = default)
        => _provider.DeleteEventStreamAsync(responseId);
}
