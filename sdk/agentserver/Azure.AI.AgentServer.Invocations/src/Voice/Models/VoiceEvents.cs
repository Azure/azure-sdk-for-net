// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.AgentServer.Invocations.Voice;

/// <summary>
/// One ordered content part of a completed user turn.
/// </summary>
public abstract class VoiceContentPart
{
    private protected VoiceContentPart()
    {
    }
}

/// <summary>
/// A transcript or typed text content part.
/// </summary>
public sealed class InputTextPart : VoiceContentPart
{
    internal InputTextPart(string text)
    {
        Text = text;
    }

    /// <summary>Gets the recognized text for this part.</summary>
    public string Text { get; }
}

/// <summary>
/// A caller-supplied image content part, delivered by reference.
/// </summary>
public sealed class InputImagePart : VoiceContentPart
{
    internal InputImagePart(string imageRef, string mimeType, string? alt)
    {
        ImageRef = imageRef;
        MimeType = mimeType;
        Alt = alt;
    }

    /// <summary>Gets the opaque reference to the image bytes, which the library never fetches.</summary>
    public string ImageRef { get; }

    /// <summary>Gets the declared MIME type.</summary>
    public string MimeType { get; }

    /// <summary>Gets the optional alternative text, or <see langword="null"/>.</summary>
    public string? Alt { get; }
}

/// <summary>
/// Effective first-output, idle, and maximum-duration response deadlines
/// carried by <c>session.start</c>.
/// </summary>
public sealed class ResponseTimeouts
{
    internal ResponseTimeouts(int firstOutputMs, int idleMs, int maxDurationMs)
    {
        FirstOutputMs = firstOutputMs;
        IdleMs = idleMs;
        MaxDurationMs = maxDurationMs;
    }

    /// <summary>Gets the first-output deadline in milliseconds.</summary>
    public int FirstOutputMs { get; }

    /// <summary>Gets the idle-progress deadline in milliseconds.</summary>
    public int IdleMs { get; }

    /// <summary>Gets the absolute maximum-duration deadline in milliseconds.</summary>
    public int MaxDurationMs { get; }
}

/// <summary>
/// The immutable <c>session.start</c> event delivered once per activation.
/// </summary>
public sealed class SessionStartEvent
{
    internal SessionStartEvent(
        bool reconnect,
        ResponseTimeouts responseTimeouts,
        string? greeting,
        int? noInputTimeoutMs,
        IReadOnlyDictionary<string, object?>? caller)
    {
        Reconnect = reconnect;
        ResponseTimeouts = responseTimeouts;
        Greeting = greeting;
        NoInputTimeoutMs = noInputTimeoutMs;
        Caller = caller;
    }

    /// <summary>Gets the exact protocol version, which is <c>1.0</c> in this preview.</summary>
    public string ProtocolVersion => VoiceProtocolConstants.ProtocolVersion;

    /// <summary>Gets a value indicating whether this activation reattaches an existing session.</summary>
    public bool Reconnect { get; }

    /// <summary>Gets the effective response deadlines.</summary>
    public ResponseTimeouts ResponseTimeouts { get; }

    /// <summary>Gets the optional configured greeting, which is absent on reconnect.</summary>
    public string? Greeting { get; }

    /// <summary>Gets the optional no-input timeout in milliseconds.</summary>
    public int? NoInputTimeoutMs { get; }

    /// <summary>Gets the optional, untrusted caller or channel metadata. This is never an authorization identity.</summary>
    public IReadOnlyDictionary<string, object?>? Caller { get; }
}

/// <summary>
/// A completed user turn (<c>user.message</c>) with an ordered content list.
/// </summary>
public sealed class UserMessageEvent
{
    internal UserMessageEvent(string itemId, IReadOnlyList<VoiceContentPart> content)
    {
        ItemId = itemId;
        Content = content;
    }

    /// <summary>Gets the bridge-allocated input item ID with the <c>in_</c> prefix.</summary>
    public string ItemId { get; }

    /// <summary>Gets the ordered content parts.</summary>
    public IReadOnlyList<VoiceContentPart> Content { get; }

    /// <summary>
    /// Gets the concatenated text of all <see cref="InputTextPart"/> parts, preserving order.
    /// Non-text parts are ignored; ordered <see cref="Content"/> remains authoritative.
    /// </summary>
    public string Text =>
        string.Join(" ", Content.OfType<InputTextPart>().Select(p => p.Text));
}

/// <summary>
/// One caller-app supplied user-role conversation history item.
/// </summary>
public sealed class ConversationHistoryItem
{
    internal ConversationHistoryItem(string itemId, IReadOnlyList<VoiceContentPart> content)
    {
        ItemId = itemId;
        Content = content;
    }

    /// <summary>Gets the caller or bridge-allocated item ID with the <c>hi_</c> prefix.</summary>
    public string ItemId { get; }

    /// <summary>Gets the closed role value, which is <c>user</c> in protocol 1.0.</summary>
    public string Role => "user";

    /// <summary>Gets the ordered content parts to persist.</summary>
    public IReadOnlyList<VoiceContentPart> Content { get; }
}

/// <summary>
/// A non-response-producing request to persist one conversation history item.
/// </summary>
public sealed class ConversationItemCreateEvent
{
    internal ConversationItemCreateEvent(string requestId, ConversationHistoryItem item, string? previousItemId)
    {
        RequestId = requestId;
        Item = item;
        PreviousItemId = previousItemId;
    }

    /// <summary>Gets the inbound envelope ID used to correlate the mutation result.</summary>
    public string RequestId { get; }

    /// <summary>Gets the item to persist.</summary>
    public ConversationHistoryItem Item { get; }

    /// <summary>Gets the insertion predecessor, <c>root</c>, or <see langword="null"/> to append.</summary>
    public string? PreviousItemId { get; }
}

/// <summary>
/// A non-response-producing request to delete one conversation history item.
/// </summary>
public sealed class ConversationItemDeleteEvent
{
    internal ConversationItemDeleteEvent(string requestId, string itemId)
    {
        RequestId = requestId;
        ItemId = itemId;
    }

    /// <summary>Gets the inbound envelope ID used to correlate the mutation result.</summary>
    public string RequestId { get; }

    /// <summary>Gets the history or output item ID to delete.</summary>
    public string ItemId { get; }
}

/// <summary>
/// A bridge-generated silence turn.
/// </summary>
public sealed class UserNoInputEvent
{
    internal UserNoInputEvent(string itemId, int count)
    {
        ItemId = itemId;
        Count = count;
    }

    /// <summary>Gets the bridge-allocated input item ID.</summary>
    public string ItemId { get; }

    /// <summary>Gets the consecutive no-input count.</summary>
    public int Count { get; }
}

/// <summary>
/// Advisory notification that caller speech began while no response was open.
/// </summary>
public sealed class UserSpeechStartedEvent
{
    internal UserSpeechStartedEvent()
    {
    }
}

/// <summary>
/// One raw, session-scoped DTMF key.
/// </summary>
public sealed class DtmfKeyEvent
{
    internal DtmfKeyEvent(string digit)
    {
        Digit = digit;
    }

    /// <summary>Gets the single DTMF key.</summary>
    public string Digit { get; }
}

/// <summary>
/// A completed DTMF collection delivered as a response-producing turn.
/// </summary>
public sealed class DtmfCollectedEvent
{
    internal DtmfCollectedEvent(string itemId, string collectionId, string digits, string completionReason)
    {
        ItemId = itemId;
        CollectionId = collectionId;
        Digits = digits;
        CompletionReason = completionReason;
    }

    /// <summary>Gets the bridge-allocated input item ID.</summary>
    public string ItemId { get; }

    /// <summary>Gets the SDK-allocated collection ID.</summary>
    public string CollectionId { get; }

    /// <summary>Gets the collected digits, excluding the terminator.</summary>
    public string Digits { get; }

    /// <summary>Gets the open-enum completion reason.</summary>
    public string CompletionReason { get; }
}

/// <summary>
/// A DTMF collection request that the bridge did not start.
/// </summary>
public sealed class DtmfCollectionRejectedEvent
{
    internal DtmfCollectionRejectedEvent(string collectionId, string reason)
    {
        CollectionId = collectionId;
        Reason = reason;
    }

    /// <summary>Gets the rejected collection ID.</summary>
    public string CollectionId { get; }

    /// <summary>Gets the open-enum rejection reason.</summary>
    public string Reason { get; }
}

/// <summary>
/// A pending or active DTMF collection that ended without a collected turn.
/// </summary>
public sealed class DtmfCollectionCancelledEvent
{
    internal DtmfCollectionCancelledEvent(string collectionId, string reason)
    {
        CollectionId = collectionId;
        Reason = reason;
    }

    /// <summary>Gets the cancelled collection ID.</summary>
    public string CollectionId { get; }

    /// <summary>Gets the open-enum cancellation reason.</summary>
    public string Reason { get; }
}

/// <summary>
/// A bridge-generated recovery turn after target activation failed.
/// </summary>
public sealed class HandoffFailedEvent
{
    internal HandoffFailedEvent(string itemId, string target, string code, string? message)
    {
        ItemId = itemId;
        Target = target;
        Code = code;
        Message = message;
    }

    /// <summary>Gets the bridge-allocated recovery input item ID.</summary>
    public string ItemId { get; }

    /// <summary>Gets the stable same-project target agent name.</summary>
    public string Target { get; }

    /// <summary>Gets the open-enum handoff failure code.</summary>
    public string Code { get; }

    /// <summary>Gets optional sanitized diagnostic detail.</summary>
    public string? Message { get; }
}

/// <summary>
/// Caller interruption and the associated playback outcome.
/// </summary>
public sealed class BargeInEvent
{
    internal BargeInEvent(string responseId, string heardText, string? itemId)
    {
        ResponseId = responseId;
        HeardText = heardText;
        ItemId = itemId;
    }

    /// <summary>Gets the response that the caller interrupted.</summary>
    public string ResponseId { get; }

    /// <summary>Gets the approximate text played before the interruption.</summary>
    public string HeardText { get; }

    /// <summary>Gets the output item playing at the cut, when one existed.</summary>
    public string? ItemId { get; }
}

/// <summary>
/// A terminal response-deadline notification. Exactly one of
/// <see cref="ResponseId"/> and <see cref="ItemIds"/> is populated.
/// </summary>
public sealed class ResponseTimeoutEvent
{
    internal ResponseTimeoutEvent(string stage, string? responseId, IReadOnlyList<string>? itemIds)
    {
        Stage = stage;
        ResponseId = responseId;
        ItemIds = itemIds;
    }

    /// <summary>Gets the open-enum timeout stage.</summary>
    public string Stage { get; }

    /// <summary>Gets the open response that timed out, when one had been announced.</summary>
    public string? ResponseId { get; }

    /// <summary>Gets the ordered input batch that timed out before response creation.</summary>
    public IReadOnlyList<string>? ItemIds { get; }
}

/// <summary>
/// The winning playback outcome returned after an agent self-cancel request.
/// </summary>
public sealed class ResponseCancellationOutcome
{
    internal ResponseCancellationOutcome(string responseId, string kind, string heardText, string? itemId)
    {
        ResponseId = responseId;
        Kind = kind;
        HeardText = heardText;
        ItemId = itemId;
    }

    /// <summary>Gets the response whose cancellation was requested.</summary>
    public string ResponseId { get; }

    /// <summary>Gets <c>cancelled</c> or the racing <c>barge_in</c> terminal kind.</summary>
    public string Kind { get; }

    /// <summary>Gets the approximate text played before the winning terminal.</summary>
    public string HeardText { get; }

    /// <summary>Gets the output item playing at the terminal, when one existed.</summary>
    public string? ItemId { get; }
}

/// <summary>
/// Bridge-initiated session termination.
/// </summary>
public sealed class SessionEndEvent
{
    internal SessionEndEvent(string reason)
    {
        Reason = reason;
    }

    /// <summary>Gets the open-enum termination reason.</summary>
    public string Reason { get; }
}
