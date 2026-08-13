// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Core;
using Azure.AI.AgentServer.Invocations.Internal;
using Microsoft.Extensions.Primitives;

namespace Azure.AI.AgentServer.Invocations.Voice;

/// <summary>Send-only context for one accepted Voice WebSocket connection.</summary>
public class VoiceSession
{
    private readonly InvocationsWebSocketConnection? _connection;

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

    internal VoiceSession(InvocationsWebSocketConnection connection, InvocationContext invocationContext)
    {
        _connection = connection;
        InvocationContext = invocationContext;
    }

    /// <summary>Gets the explicit per-connection Invocations context.</summary>
    public virtual InvocationContext InvocationContext { get; }

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
