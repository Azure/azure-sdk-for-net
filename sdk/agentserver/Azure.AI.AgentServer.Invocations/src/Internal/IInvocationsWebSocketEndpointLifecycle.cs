// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net.WebSockets;

namespace Azure.AI.AgentServer.Invocations.Internal;

internal interface IInvocationsWebSocketEndpointLifecycle
{
    bool TryMarkAcceptCancellation(CancellationToken requestCancellation);

    Task<InvocationsWebSocketCloseResult?> HandleWebSocketWithOutcomeAsync(
        WebSocket webSocket,
        InvocationContext context,
        CancellationToken cancellationToken);

    Task FinalizeAsync(
        Func<Task> finalizeConnection,
        Action<long> emitCloseEvent,
        WebSocketEndpointCompletion completion);
}

internal readonly record struct WebSocketEndpointCompletion(
    string SessionId,
    int CloseCode,
    string? ErrorCode,
    InvocationsWebSocketCloseResult? HandlerOutcome,
    Func<long> GetFinalDurationMs);
