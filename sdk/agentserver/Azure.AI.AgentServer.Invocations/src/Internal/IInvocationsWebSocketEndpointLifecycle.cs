// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net.WebSockets;

namespace Azure.AI.AgentServer.Invocations.Internal;

internal interface IInvocationsWebSocketEndpointLifecycle
{
    bool TryMarkAcceptCancellation(
        OperationCanceledException exception,
        CancellationToken requestCancellation);

    Task<InvocationsWebSocketCloseResult?> HandleWebSocketWithOutcomeAsync(
        WebSocket webSocket,
        InvocationContext context,
        CancellationToken cancellationToken);

    void MarkRequestCancelled();

    Task FinalizeAsync(
        Func<Task> finalizeConnection,
        Action emitCloseEvent,
        WebSocketEndpointCompletion completion);
}

internal readonly record struct WebSocketEndpointCompletion(
    string SessionId,
    int CloseCode,
    string? ErrorCode,
    InvocationsWebSocketCloseResult? HandlerOutcome,
    Func<long> GetFinalDurationMs);

internal sealed class DefaultInvocationsWebSocketEndpointLifecycle : IInvocationsWebSocketEndpointLifecycle
{
    private readonly InvocationWebSocketHandler _handler;

    internal DefaultInvocationsWebSocketEndpointLifecycle(InvocationWebSocketHandler handler) =>
        _handler = handler;

    public bool TryMarkAcceptCancellation(
        OperationCanceledException exception,
        CancellationToken requestCancellation) => false;

    public Task<InvocationsWebSocketCloseResult?> HandleWebSocketWithOutcomeAsync(
        WebSocket webSocket,
        InvocationContext context,
        CancellationToken cancellationToken) =>
        _handler.HandleWebSocketWithOutcomeAsync(webSocket, context, cancellationToken);

    public void MarkRequestCancelled()
    {
    }

    public async Task FinalizeAsync(
        Func<Task> finalizeConnection,
        Action emitCloseEvent,
        WebSocketEndpointCompletion completion)
    {
        await finalizeConnection().ConfigureAwait(false);
        emitCloseEvent();
    }
}
