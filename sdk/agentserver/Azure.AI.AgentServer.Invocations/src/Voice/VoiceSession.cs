// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using Azure.AI.AgentServer.Core;
using Azure.AI.AgentServer.Invocations.Internal;
using Microsoft.Extensions.Primitives;

namespace Azure.AI.AgentServer.Invocations.Voice;

/// <summary>Send-only context for one accepted Voice WebSocket connection.</summary>
[Experimental("AAAS001")]
public class VoiceSession
{
    private readonly InvocationsWebSocketConnection? _connection;
    private readonly VoiceTraceContext _traceContext;

    /// <summary>Initializes a mockable Voice session.</summary>
    protected VoiceSession()
        : this(new InvocationContext(
            invocationId: "invocation_mock",
            sessionId: "session_mock",
            clientHeaders: new Dictionary<string, string>(),
            queryParameters: new Dictionary<string, StringValues>(),
            platformContext: PlatformContext.Empty))
    {
    }

    /// <summary>Initializes a mock Voice session with an explicit invocation context.</summary>
    protected VoiceSession(InvocationContext invocationContext)
    {
        InvocationContext = invocationContext ?? throw new ArgumentNullException(nameof(invocationContext));
    }

    internal VoiceSession(InvocationContext invocationContext, ActivityContext connectionContext)
        : this(invocationContext)
    {
        _traceContext = new VoiceTraceContext(connectionContext, default);
    }

    internal VoiceSession(
        InvocationsWebSocketConnection connection,
        InvocationContext invocationContext,
        ActivityContext connectionContext = default)
        : this(
            connection,
            invocationContext,
            new VoiceTraceContext(connectionContext, default))
    {
    }

    internal VoiceSession(
        InvocationsWebSocketConnection connection,
        InvocationContext invocationContext,
        VoiceTraceContext traceContext)
    {
        _connection = connection;
        InvocationContext = invocationContext;
        _traceContext = traceContext;
    }

    /// <summary>Gets the explicit per-connection Invocations context.</summary>
    public virtual InvocationContext InvocationContext { get; }

    /// <summary>Starts an application-owned target-agent decision trace.</summary>
    /// <param name="origin">The decision origin.</param>
    /// <param name="inputCount">The number of inputs consumed by this decision.</param>
    /// <returns>A mockable handle that the application activates and completes explicitly.</returns>
    public virtual VoiceTurnTrace StartTurn(VoiceTurnOrigin origin, int inputCount) =>
        VoiceTurnTrace.Start(_traceContext, origin, inputCount);

    /// <summary>
    /// Encodes and sends one explicit agent-to-Bridge message. Concurrent sends are serialized;
    /// sends fail after connection termination begins.
    /// </summary>
    public virtual Task SendAsync(
        VoiceOutboundMessage message,
        CancellationToken cancellationToken = default)
    {
        if (_connection is null)
        {
            throw new InvalidOperationException("The mock Voice session has no transport.");
        }

        return _connection.SendTextAsync(VoiceProtocolCodec.Encode(message), cancellationToken);
    }
}
