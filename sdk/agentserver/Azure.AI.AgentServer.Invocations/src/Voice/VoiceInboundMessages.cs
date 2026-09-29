// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.CodeAnalysis;

namespace Azure.AI.AgentServer.Invocations.Voice;

/// <summary>One supported text part in a completed user turn.</summary>
[Experimental("AAAS001")]
public sealed class VoiceInputTextPart
{
    /// <summary>Initializes a text content part.</summary>
    public VoiceInputTextPart(string text)
    {
        Text = text;
    }

    /// <summary>Gets the final recognized or application-supplied text.</summary>
    public string Text { get; }

    /// <inheritdoc />
    public override string ToString() => nameof(VoiceInputTextPart);
}

/// <summary>A completed user text turn.</summary>
[Experimental("AAAS001")]
public sealed class VoiceUserMessageEvent : VoiceInboundMessage
{
    /// <summary>Initializes a completed user turn.</summary>
    public VoiceUserMessageEvent(
        string id,
        DateTimeOffset timestamp,
        string itemId,
        IEnumerable<VoiceInputTextPart> content)
        : base("user.message", id, timestamp)
    {
        ItemId = itemId;
        ArgumentNullException.ThrowIfNull(content);
        Content = Array.AsReadOnly(content.ToArray());
    }

    /// <summary>Gets the Bridge-allocated input item identifier.</summary>
    public string ItemId { get; }

    /// <summary>Gets supported content parts in wire order.</summary>
    public IReadOnlyList<VoiceInputTextPart> Content { get; }
}

/// <summary>A Bridge-generated no-input turn.</summary>
[Experimental("AAAS001")]
public sealed class VoiceUserNoInputEvent : VoiceInboundMessage
{
    /// <summary>Initializes a no-input event.</summary>
    public VoiceUserNoInputEvent(string id, DateTimeOffset timestamp, string itemId, int count)
        : base("user.no_input", id, timestamp)
    {
        ItemId = itemId;
        Count = count;
    }

    /// <summary>Gets the Bridge-allocated input item identifier.</summary>
    public string ItemId { get; }

    /// <summary>Gets the consecutive no-input count.</summary>
    public int Count { get; }
}

/// <summary>Advises that caller speech began while no response was open.</summary>
[Experimental("AAAS001")]
public sealed class VoiceUserSpeechStartedEvent : VoiceInboundMessage
{
    /// <summary>Initializes a speech-start event.</summary>
    public VoiceUserSpeechStartedEvent(string id, DateTimeOffset timestamp)
        : base("user.speech_started", id, timestamp)
    {
    }
}

/// <summary>Reports caller interruption and the played-text snapshot.</summary>
[Experimental("AAAS001")]
public sealed class VoiceBargeInEvent : VoiceInboundMessage
{
    /// <summary>Initializes a barge-in event.</summary>
    public VoiceBargeInEvent(
        string id,
        DateTimeOffset timestamp,
        string responseId,
        string heardText,
        string? itemId = null)
        : base("barge_in", id, timestamp)
    {
        ResponseId = responseId;
        HeardText = heardText;
        ItemId = itemId;
    }

    /// <summary>Gets the interrupted response identifier.</summary>
    public string ResponseId { get; }

    /// <summary>Gets the text played before interruption.</summary>
    public string HeardText { get; }

    /// <summary>Gets the playing output item identifier, when available.</summary>
    public string? ItemId { get; }
}

/// <summary>Reports acceptance of a proactive response request.</summary>
[Experimental("AAAS001")]
public sealed class VoiceResponseAcceptedEvent : VoiceInboundMessage
{
    /// <summary>Initializes a proactive acceptance event.</summary>
    public VoiceResponseAcceptedEvent(string id, DateTimeOffset timestamp, string responseId)
        : base("response.accepted", id, timestamp)
    {
        ResponseId = responseId;
    }

    /// <summary>Gets the accepted response identifier.</summary>
    public string ResponseId { get; }
}

/// <summary>Reports that a proactive response request was dropped.</summary>
[Experimental("AAAS001")]
public sealed class VoiceResponseDroppedEvent : VoiceInboundMessage
{
    /// <summary>Initializes a proactive drop event.</summary>
    public VoiceResponseDroppedEvent(string id, DateTimeOffset timestamp, string responseId, string reason)
        : base("response.dropped", id, timestamp)
    {
        ResponseId = responseId;
        Reason = reason;
    }

    /// <summary>Gets the dropped response identifier.</summary>
    public string ResponseId { get; }

    /// <summary>Gets the open-enum drop reason.</summary>
    public string Reason { get; }
}

/// <summary>Reports the winning self-cancel playback outcome.</summary>
[Experimental("AAAS001")]
public sealed class VoiceResponseCancelledEvent : VoiceInboundMessage
{
    /// <summary>Initializes a response-cancelled event.</summary>
    public VoiceResponseCancelledEvent(
        string id,
        DateTimeOffset timestamp,
        string responseId,
        string heardText,
        string? itemId = null)
        : base("response.cancelled", id, timestamp)
    {
        ResponseId = responseId;
        HeardText = heardText;
        ItemId = itemId;
    }

    /// <summary>Gets the cancelled response identifier.</summary>
    public string ResponseId { get; }

    /// <summary>Gets the text played before cancellation completed.</summary>
    public string HeardText { get; }

    /// <summary>Gets the playing output item identifier, when available.</summary>
    public string? ItemId { get; }
}

/// <summary>Reports a response or pending-input timeout.</summary>
[Experimental("AAAS001")]
public sealed class VoiceResponseTimeoutEvent : VoiceInboundMessage
{
    /// <summary>Initializes a timeout event.</summary>
    public VoiceResponseTimeoutEvent(
        string id,
        DateTimeOffset timestamp,
        string stage,
        string? responseId = null,
        IEnumerable<string>? itemIds = null)
        : base("response.timeout", id, timestamp)
    {
        Stage = stage;
        ResponseId = responseId;
        ItemIds = itemIds is null ? null : VoiceModelHelpers.CopyStrings(itemIds, nameof(itemIds));
    }

    /// <summary>Gets the open-enum timeout stage.</summary>
    public string Stage { get; }

    /// <summary>Gets the timed-out response identifier, when a response was open.</summary>
    public string? ResponseId { get; }

    /// <summary>Gets timed-out pending input identifiers before response creation.</summary>
    public IReadOnlyList<string>? ItemIds { get; }
}

/// <summary>Reports Bridge-initiated session termination.</summary>
[Experimental("AAAS001")]
public sealed class VoiceSessionEndEvent : VoiceInboundMessage
{
    /// <summary>Initializes a session-end event.</summary>
    public VoiceSessionEndEvent(string id, DateTimeOffset timestamp, string reason)
        : base("session.end", id, timestamp)
    {
        Reason = reason;
    }

    /// <summary>Gets the open-enum termination reason.</summary>
    public string Reason { get; }
}
