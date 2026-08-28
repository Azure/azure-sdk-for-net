// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using System.Net.WebSockets;
using Azure.AI.AgentServer.Invocations.Internal;
using Microsoft.AspNetCore.Http;

#pragma warning disable AAAS001 // Internal implementation of the experimental Voice relay.

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
        IHeaderDictionary headers,
        InvocationCorrelationBaggage correlationBaggage = default) =>
        new(handler, VoiceConnectionTelemetry.Start(headers, correlationBaggage));

    internal static async Task<InvocationsWebSocketCloseResult?> HandleAsync(
        VoiceHandler handler,
        WebSocket webSocket,
        InvocationContext context,
        VoiceTraceContext traceContext,
        CancellationToken cancellationToken)
    {
        var connection = new InvocationsWebSocketConnection(webSocket);
        var outcome = await handler.HandleWebSocketConnectionAsync(
            connection,
            context,
            traceContext,
            cancellationToken).ConfigureAwait(false);
        var closeException = await connection.CloseAsync(outcome.Status, outcome.Reason).ConfigureAwait(false);
        return outcome with { CloseException = closeException };
    }

    public bool TryMarkAcceptCancellation(CancellationToken requestCancellation) =>
        _telemetry.TryMarkRequestCancellation(requestCancellation);

    public async Task<InvocationsWebSocketCloseResult?> HandleWebSocketWithOutcomeAsync(
        WebSocket webSocket,
        InvocationContext context,
        CancellationToken cancellationToken)
    {
        try
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
        catch (OperationCanceledException exception)
            when (exception.CancellationToken == cancellationToken &&
                  cancellationToken.IsCancellationRequested)
        {
            _telemetry.MarkRequestCancelled();
            throw;
        }
    }

    public async Task FinalizeAsync(
        Func<Task> finalizeConnection,
        Action<long> emitCloseEvent,
        WebSocketEndpointCompletion completion)
    {
        long durationMs;
        try
        {
            await finalizeConnection().ConfigureAwait(false);
        }
        finally
        {
            durationMs = completion.GetFinalDurationMs();
            _telemetry.Complete(
                completion.SessionId,
                completion.CloseCode,
                completion.ErrorCode,
                completion.HandlerOutcome,
                durationMs);
        }

        _telemetry.EmitStructuredLog(() => emitCloseEvent(durationMs));
    }
}

#pragma warning restore AAAS001
