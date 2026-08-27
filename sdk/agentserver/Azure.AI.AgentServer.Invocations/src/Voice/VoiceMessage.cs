// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.AgentServer.Invocations.Voice;

/// <summary>Base type for one immutable Bridge-to-agent Voice event.</summary>
public abstract class VoiceInboundMessage
{
    private protected VoiceInboundMessage(string messageType, string id, DateTimeOffset timestamp)
    {
        MessageType = messageType;
        Id = id;
        Timestamp = timestamp;
    }

    /// <summary>Gets the wire message type.</summary>
    public string MessageType { get; }

    /// <summary>Gets the wire message identifier.</summary>
    public string Id { get; }

    /// <summary>Gets the sender timestamp.</summary>
    public DateTimeOffset Timestamp { get; }

    /// <inheritdoc />
    public override string ToString() =>
        $"{GetType().Name} {{ MessageType = {MessageType}, Id = {Id}, Timestamp = {Timestamp:O} }}";
}

/// <summary>Base type for one immutable agent-to-Bridge Voice message.</summary>
public abstract class VoiceOutboundMessage
{
    private protected VoiceOutboundMessage(
        string messageType,
        string? id = null,
        DateTimeOffset? timestamp = null)
    {
        MessageType = messageType;
        Id = id ?? VoiceIds.CreateMessageId();
        Timestamp = timestamp ?? DateTimeOffset.UtcNow;
    }

    /// <summary>Gets the wire message type.</summary>
    public string MessageType { get; }

    /// <summary>Gets the wire message identifier.</summary>
    public string Id { get; }

    /// <summary>Gets the sender timestamp.</summary>
    public DateTimeOffset Timestamp { get; }

    /// <inheritdoc />
    public override string ToString() =>
        $"{GetType().Name} {{ MessageType = {MessageType}, Id = {Id}, Timestamp = {Timestamp:O} }}";
}

/// <summary>Stateless factories for agent-owned Voice protocol identifiers.</summary>
public static class VoiceIds
{
    /// <summary>Creates a new <c>m_</c> message identifier.</summary>
    public static string CreateMessageId() => $"m_{Guid.NewGuid():N}";

    /// <summary>Creates a new <c>r_</c> response identifier.</summary>
    public static string CreateResponseId() => $"r_{Guid.NewGuid():N}";

    /// <summary>Creates a new <c>it_</c> output-item identifier.</summary>
    public static string CreateItemId() => $"it_{Guid.NewGuid():N}";
}

internal static class VoiceModelHelpers
{
    internal static IReadOnlyList<string> CopyStrings(IEnumerable<string> values, string parameterName)
    {
        ArgumentNullException.ThrowIfNull(values, parameterName);
        return Array.AsReadOnly(values.ToArray());
    }

    internal static BinaryData? CopyBinaryData(BinaryData? value) =>
        value is null ? null : BinaryData.FromBytes(value.ToArray());
}

/// <summary>Response deadlines supplied by the Bridge for one connection.</summary>
public sealed class VoiceResponseTimeouts
{
    /// <summary>Initializes response deadlines.</summary>
    public VoiceResponseTimeouts(int firstOutputMs, int idleMs, int maxDurationMs)
    {
        FirstOutputMs = firstOutputMs;
        IdleMs = idleMs;
        MaxDurationMs = maxDurationMs;
    }

    /// <summary>Gets the first-output deadline in milliseconds.</summary>
    public int FirstOutputMs { get; }

    /// <summary>Gets the idle-progress deadline in milliseconds.</summary>
    public int IdleMs { get; }

    /// <summary>Gets the absolute response deadline in milliseconds.</summary>
    public int MaxDurationMs { get; }
}

/// <summary>The Bridge application-start event.</summary>
public sealed class VoiceSessionStartEvent : VoiceInboundMessage
{
    /// <summary>Initializes a Bridge application-start event.</summary>
    public VoiceSessionStartEvent(
        string id,
        DateTimeOffset timestamp,
        string protocolVersion,
        bool reconnect,
        VoiceResponseTimeouts responseTimeouts,
        string? greeting,
        int? noInputTimeoutMs,
        BinaryData? caller)
        : base("session.start", id, timestamp)
    {
        ProtocolVersion = protocolVersion;
        Reconnect = reconnect;
        ResponseTimeouts = responseTimeouts;
        Greeting = greeting;
        NoInputTimeoutMs = noInputTimeoutMs;
        Caller = VoiceModelHelpers.CopyBinaryData(caller);
    }

    /// <summary>Gets the exact selected Bridge protocol version.</summary>
    public string ProtocolVersion { get; }

    /// <summary>Gets whether this connection reattaches an existing logical session.</summary>
    public bool Reconnect { get; }

    /// <summary>Gets the effective response deadlines.</summary>
    public VoiceResponseTimeouts ResponseTimeouts { get; }

    /// <summary>Gets the optional Bridge-owned greeting.</summary>
    public string? Greeting { get; }

    /// <summary>Gets the optional no-input deadline.</summary>
    public int? NoInputTimeoutMs { get; }

    /// <summary>Gets the optional open caller context as immutable JSON.</summary>
    public BinaryData? Caller { get; }
}

/// <summary>An explicit positive application-readiness acknowledgement.</summary>
public sealed class VoiceSessionReadyMessage : VoiceOutboundMessage
{
    /// <summary>Initializes a readiness acknowledgement.</summary>
    public VoiceSessionReadyMessage(string? id = null, DateTimeOffset? timestamp = null)
        : base("session.ready", id, timestamp)
    {
    }
}
