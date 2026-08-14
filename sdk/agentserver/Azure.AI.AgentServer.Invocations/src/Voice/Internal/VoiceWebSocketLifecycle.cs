// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using System.Net.WebSockets;
using Azure.AI.AgentServer.Invocations.Internal;
using Microsoft.AspNetCore.Http;

namespace Azure.AI.AgentServer.Invocations.Voice;

internal sealed class VoiceWebSocketLifecycle : IInvocationsWebSocketEndpointLifecycle
{
    private readonly VoiceHandler _handler;
    private readonly VoiceConnectionTelemetry _telemetry;

    private VoiceWebSocketLifecycle(
        VoiceHandler handler,
        VoiceConnectionTelemetry telemetry)
    {
        _handler = handler;
        _telemetry = telemetry;
    }

    internal static VoiceWebSocketLifecycle Start(
        VoiceHandler handler,
        IHeaderDictionary headers) =>
        new(handler, VoiceConnectionTelemetry.Start(headers));

    internal static async Task<InvocationsWebSocketCloseResult?> HandleAsync(
        VoiceHandler handler,
        WebSocket webSocket,
        InvocationContext context,
        ActivityContext connectionContext,
        CancellationToken cancellationToken)
    {
        var connection = new InvocationsWebSocketConnection(webSocket);
        var outcome = await handler.HandleWebSocketConnectionAsync(
            connection,
            context,
            connectionContext,
            cancellationToken).ConfigureAwait(false);
        var closeException = await connection.CloseAsync(outcome.Status, outcome.Reason).ConfigureAwait(false);
        return outcome with { CloseException = closeException };
    }

    public bool TryMarkAcceptCancellation(
        OperationCanceledException exception,
        CancellationToken requestCancellation) =>
        _telemetry.TryMarkRequestCancellation(exception, requestCancellation);

    public async Task<InvocationsWebSocketCloseResult?> HandleWebSocketWithOutcomeAsync(
        WebSocket webSocket,
        InvocationContext context,
        CancellationToken cancellationToken)
    {
        var outcome = await HandleAsync(
            _handler,
            webSocket,
            context,
            _telemetry.Context,
            cancellationToken).ConfigureAwait(false);
        if (outcome is { } value)
        {
            _telemetry.ObserveHandlerOutcome(value, cancellationToken);
        }
        return outcome;
    }

    public void MarkRequestCancelled() => _telemetry.MarkRequestCancelled();

    public async Task FinalizeAsync(
        Func<Task> finalizeConnection,
        Action emitCloseEvent,
        WebSocketEndpointCompletion completion)
    {
        try
        {
            await finalizeConnection().ConfigureAwait(false);
            _telemetry.EmitStructuredLog(emitCloseEvent);
        }
        finally
        {
            _telemetry.Complete(
                completion.SessionId,
                completion.CloseCode,
                completion.ErrorCode,
                completion.HandlerOutcome,
                completion.GetFinalDurationMs());
        }
    }
}
