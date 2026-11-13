// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.AgentServer.Responses.Internal;

/// <summary>
/// Adapter that exposes the cancellation capabilities of <see cref="InMemoryResponsesProvider"/>
/// as a <see cref="ResponsesCancellationSignalProvider"/>.
/// </summary>
internal sealed class InMemoryCancellationSignalProvider : ResponsesCancellationSignalProvider
{
    private readonly InMemoryResponsesProvider _provider;

    public InMemoryCancellationSignalProvider(InMemoryResponsesProvider provider)
    {
        _provider = provider;
    }

    /// <inheritdoc/>
    public override Task CancelResponseAsync(string responseId, CancellationToken cancellationToken = default)
        => _provider.CancelResponseAsync(responseId, cancellationToken);

    /// <inheritdoc/>
    public override Task<CancellationToken> GetResponseCancellationTokenAsync(string responseId, CancellationToken cancellationToken = default)
        => _provider.GetResponseCancellationTokenAsync(responseId, cancellationToken);
}
