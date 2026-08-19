// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.AgentServer.Invocations.Voice;

/// <summary>Closed call-ending mode.</summary>
public enum VoiceEndCallMode
{
    /// <summary>Play already queued audio before ending the call.</summary>
    Drain,

    /// <summary>End immediately and cut queued audio.</summary>
    Immediate,
}

/// <summary>An explicit negative application-readiness acknowledgement.</summary>
public sealed class VoiceSessionRejectedMessage : VoiceOutboundMessage
{
    /// <summary>Initializes a readiness rejection.</summary>
    public VoiceSessionRejectedMessage(
        string code,
        bool retriable,
        string? message = null,
        string? id = null,
        DateTimeOffset? timestamp = null)
        : base("session.rejected", id, timestamp)
    {
        Code = code;
        Retriable = retriable;
        Message = message;
    }

    /// <summary>Gets the open-enum rejection code.</summary>
    public string Code { get; }

    /// <summary>Gets whether retry may succeed without deployment changes.</summary>
    public bool Retriable { get; }

    /// <summary>Gets optional sanitized diagnostic detail.</summary>
    public string? Message { get; }
}

/// <summary>Opens a reply response or requests proactive admission.</summary>
public sealed class VoiceResponseCreatedMessage : VoiceOutboundMessage
{
    /// <summary>Initializes a response-created message.</summary>
    public VoiceResponseCreatedMessage(
        string responseId,
        IEnumerable<string>? inReplyTo = null,
        int? admissionTimeoutMs = null,
        string? supersedeKey = null,
        string? id = null,
        DateTimeOffset? timestamp = null)
        : base("response.created", id, timestamp)
    {
        ResponseId = responseId;
        InReplyTo = inReplyTo is null ? null : VoiceModelHelpers.CopyStrings(inReplyTo, nameof(inReplyTo));
        AdmissionTimeoutMs = admissionTimeoutMs;
        SupersedeKey = supersedeKey;
    }

    /// <summary>Gets the agent-allocated response identifier.</summary>
    public string ResponseId { get; }

    /// <summary>Gets the ordered input prefix for a reply, or null for proactive admission.</summary>
    public IReadOnlyList<string>? InReplyTo { get; }

    /// <summary>Gets the optional proactive admission timeout.</summary>
    public int? AdmissionTimeoutMs { get; }

    /// <summary>Gets the optional proactive supersession key.</summary>
    public string? SupersedeKey { get; }
}

/// <summary>Explicitly declines an ordered pending-input prefix.</summary>
public sealed class VoiceResponseNoneMessage : VoiceOutboundMessage
{
    /// <summary>Initializes a response-none message.</summary>
    public VoiceResponseNoneMessage(
        IEnumerable<string> inReplyTo,
        string? reason = null,
        string? id = null,
        DateTimeOffset? timestamp = null)
        : base("response.none", id, timestamp)
    {
        InReplyTo = VoiceModelHelpers.CopyStrings(inReplyTo, nameof(inReplyTo));
        Reason = reason;
    }

    /// <summary>Gets the ordered input prefix being declined.</summary>
    public IReadOnlyList<string> InReplyTo { get; }

    /// <summary>Gets the optional open-enum decline reason.</summary>
    public string? Reason { get; }
}

/// <summary>Streams one text increment for an output item.</summary>
public sealed class VoiceResponseOutputTextDeltaMessage : VoiceOutboundMessage
{
    /// <summary>Initializes an output-text delta.</summary>
    public VoiceResponseOutputTextDeltaMessage(
        string responseId,
        string itemId,
        string delta,
        BinaryData? voice = null,
        string? id = null,
        DateTimeOffset? timestamp = null)
        : base("response.output_text.delta", id, timestamp)
    {
        ResponseId = responseId;
        ItemId = itemId;
        Delta = delta;
        Voice = VoiceModelHelpers.CopyBinaryData(voice);
    }

    /// <summary>Gets the owning response identifier.</summary>
    public string ResponseId { get; }

    /// <summary>Gets the output item identifier.</summary>
    public string ItemId { get; }

    /// <summary>Gets the non-empty text increment.</summary>
    public string Delta { get; }

    /// <summary>Gets an optional Voice Live synthesis merge patch.</summary>
    public BinaryData? Voice { get; }
}

/// <summary>Completes one streamed or non-streamed output item.</summary>
public sealed class VoiceResponseOutputTextDoneMessage : VoiceOutboundMessage
{
    /// <summary>Initializes a completed output item.</summary>
    public VoiceResponseOutputTextDoneMessage(
        string responseId,
        string itemId,
        string text,
        BinaryData? voice = null,
        string? id = null,
        DateTimeOffset? timestamp = null)
        : base("response.output_text.done", id, timestamp)
    {
        ResponseId = responseId;
        ItemId = itemId;
        Text = text;
        Voice = VoiceModelHelpers.CopyBinaryData(voice);
    }

    /// <summary>Gets the owning response identifier.</summary>
    public string ResponseId { get; }

    /// <summary>Gets the completed output item identifier.</summary>
    public string ItemId { get; }

    /// <summary>Gets the complete item text.</summary>
    public string Text { get; }

    /// <summary>Gets an optional Voice Live synthesis merge patch.</summary>
    public BinaryData? Voice { get; }
}

/// <summary>Explicitly completes normal response generation.</summary>
public sealed class VoiceResponseDoneMessage : VoiceOutboundMessage
{
    /// <summary>Initializes a response-done message.</summary>
    public VoiceResponseDoneMessage(
        string responseId,
        string? id = null,
        DateTimeOffset? timestamp = null)
        : base("response.done", id, timestamp)
    {
        ResponseId = responseId;
    }

    /// <summary>Gets the completed response identifier.</summary>
    public string ResponseId { get; }
}

/// <summary>Requests cancellation of an open or pending proactive response.</summary>
public sealed class VoiceResponseCancelMessage : VoiceOutboundMessage
{
    /// <summary>Initializes a response-cancel request.</summary>
    public VoiceResponseCancelMessage(
        string responseId,
        string? reason = null,
        string? id = null,
        DateTimeOffset? timestamp = null)
        : base("response.cancel", id, timestamp)
    {
        ResponseId = responseId;
        Reason = reason;
    }

    /// <summary>Gets the response identifier.</summary>
    public string ResponseId { get; }

    /// <summary>Gets the optional open-enum cancellation reason.</summary>
    public string? Reason { get; }
}

/// <summary>Asks the Bridge to end the call.</summary>
public sealed class VoiceEndCallMessage : VoiceOutboundMessage
{
    /// <summary>Initializes an end-call request.</summary>
    public VoiceEndCallMessage(
        string reason,
        VoiceEndCallMode mode = VoiceEndCallMode.Drain,
        string? id = null,
        DateTimeOffset? timestamp = null)
        : base("end_call", id, timestamp)
    {
        Reason = reason;
        Mode = mode;
    }

    /// <summary>Gets the open-enum call-ending reason.</summary>
    public string Reason { get; }

    /// <summary>Gets the closed call-ending mode.</summary>
    public VoiceEndCallMode Mode { get; }
}

/// <summary>Reports an explicit response- or session-scoped agent failure.</summary>
public sealed class VoiceErrorMessage : VoiceOutboundMessage
{
    /// <summary>Initializes an agent error.</summary>
    public VoiceErrorMessage(
        string code,
        string message,
        string? responseId = null,
        string? itemId = null,
        string? id = null,
        DateTimeOffset? timestamp = null)
        : base("error", id, timestamp)
    {
        Code = code;
        Message = message;
        ResponseId = responseId;
        ItemId = itemId;
    }

    /// <summary>Gets the open-enum error code.</summary>
    public string Code { get; }

    /// <summary>Gets sanitized diagnostic detail.</summary>
    public string Message { get; }

    /// <summary>Gets the related response identifier, when response-scoped.</summary>
    public string? ResponseId { get; }

    /// <summary>Gets the related output item identifier, when available.</summary>
    public string? ItemId { get; }
}
