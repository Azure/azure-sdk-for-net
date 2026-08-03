// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections;
using System.Collections.ObjectModel;

namespace Azure.AI.AgentServer.Invocations.Voice;

/// <summary>
/// Creates immutable Voice Live Bridge callback models for testing and mocking.
/// </summary>
public static class VoiceModelFactory
{
    /// <summary>Creates one input text content part.</summary>
    public static InputTextPart InputTextPart(string text = "") => new(text);

    /// <summary>Creates one reference-only input image content part.</summary>
    public static InputImagePart InputImagePart(
        string imageRef = "https://example.invalid/image",
        string mimeType = "image/png",
        string? alt = null) => new(imageRef, mimeType, alt);

    /// <summary>Creates effective response deadlines.</summary>
    public static ResponseTimeouts ResponseTimeouts(
        int firstOutputMs = 15000,
        int idleMs = 30000,
        int maxDurationMs = 120000) => new(firstOutputMs, idleMs, maxDurationMs);

    /// <summary>Creates a validated session-start callback model.</summary>
    public static SessionStartEvent SessionStartEvent(
        bool reconnect = false,
        ResponseTimeouts? responseTimeouts = null,
        string? greeting = null,
        int? noInputTimeoutMs = null,
        IReadOnlyDictionary<string, object?>? caller = null) =>
        new(
            reconnect,
            responseTimeouts ?? ResponseTimeouts(),
            greeting,
            noInputTimeoutMs,
            FreezeDictionary(caller));

    /// <summary>Creates a completed user-message callback model.</summary>
    public static UserMessageEvent UserMessageEvent(
        string itemId = "in_test",
        IEnumerable<VoiceContentPart>? content = null) =>
        new(itemId, FreezeList(content ?? new[] { InputTextPart() }));

    /// <summary>Creates one user-role conversation history item.</summary>
    public static ConversationHistoryItem ConversationHistoryItem(
        string itemId = "hi_test",
        IEnumerable<VoiceContentPart>? content = null) =>
        new(itemId, FreezeList(content ?? new[] { InputTextPart() }));

    /// <summary>Creates a history-item create callback model.</summary>
    public static ConversationItemCreateEvent ConversationItemCreateEvent(
        string requestId = "m_test",
        ConversationHistoryItem? item = null,
        string? previousItemId = null) =>
        new(requestId, item ?? ConversationHistoryItem(), previousItemId);

    /// <summary>Creates a history-item delete callback model.</summary>
    public static ConversationItemDeleteEvent ConversationItemDeleteEvent(
        string requestId = "m_test",
        string itemId = "hi_test") => new(requestId, itemId);

    /// <summary>Creates a bridge-generated no-input turn.</summary>
    public static UserNoInputEvent UserNoInputEvent(
        string itemId = "in_test",
        int count = 1) => new(itemId, count);

    /// <summary>Creates an advisory speech-started callback model.</summary>
    public static UserSpeechStartedEvent UserSpeechStartedEvent() => new();

    /// <summary>Creates one raw DTMF key callback model.</summary>
    public static DtmfKeyEvent DtmfKeyEvent(string digit = "1") => new(digit);

    /// <summary>Creates one completed DTMF collection turn.</summary>
    public static DtmfCollectedEvent DtmfCollectedEvent(
        string itemId = "in_test",
        string collectionId = "dc_test",
        string digits = "",
        string completionReason = "max_digits") =>
        new(itemId, collectionId, digits, completionReason);

    /// <summary>Creates one DTMF collection rejection callback model.</summary>
    public static DtmfCollectionRejectedEvent DtmfCollectionRejectedEvent(
        string collectionId = "dc_test",
        string reason = "invalid_configuration") => new(collectionId, reason);

    /// <summary>Creates one DTMF collection cancellation callback model.</summary>
    public static DtmfCollectionCancelledEvent DtmfCollectionCancelledEvent(
        string collectionId = "dc_test",
        string reason = "cancelled_by_agent") => new(collectionId, reason);

    /// <summary>Creates one handoff failure recovery turn.</summary>
    public static HandoffFailedEvent HandoffFailedEvent(
        string itemId = "in_test",
        string target = "target-agent",
        string code = "target_unavailable",
        string? message = null) => new(itemId, target, code, message);

    /// <summary>Creates one caller barge-in callback model.</summary>
    public static BargeInEvent BargeInEvent(
        string responseId = "r_test",
        string heardText = "",
        string? itemId = null) => new(responseId, heardText, itemId);

    /// <summary>Creates one response-timeout callback model.</summary>
    public static ResponseTimeoutEvent ResponseTimeoutEvent(
        string stage = "first_output",
        string responseId = "r_test") => new(stage, responseId, itemIds: null);

    /// <summary>Creates one pre-response input-batch timeout callback model.</summary>
    public static ResponseTimeoutEvent ResponseTimeoutEventForItems(
        IEnumerable<string> itemIds,
        string stage = "first_output") => new(stage, responseId: null, FreezeList(itemIds));

    /// <summary>Creates one self-cancel playback outcome.</summary>
    public static ResponseCancellationOutcome ResponseCancellationOutcome(
        string responseId = "r_test",
        string kind = "cancelled",
        string heardText = "",
        string? itemId = null) => new(responseId, kind, heardText, itemId);

    /// <summary>Creates one bridge-initiated session-end callback model.</summary>
    public static SessionEndEvent SessionEndEvent(string reason = "caller_hangup") => new(reason);

    private static IReadOnlyList<T> FreezeList<T>(IEnumerable<T> values) =>
        Array.AsReadOnly(values.ToArray());

    private static IReadOnlyDictionary<string, object?>? FreezeDictionary(
        IReadOnlyDictionary<string, object?>? values)
    {
        if (values is null)
        {
            return null;
        }

        return new ReadOnlyDictionary<string, object?>(
            values.ToDictionary(pair => pair.Key, pair => FreezeValue(pair.Value), StringComparer.Ordinal));
    }

    private static object? FreezeValue(object? value) => value switch
    {
        IReadOnlyDictionary<string, object?> dictionary => FreezeDictionary(dictionary),
        IDictionary<string, object?> dictionary => FreezeDictionary(
            new ReadOnlyDictionary<string, object?>(new Dictionary<string, object?>(dictionary, StringComparer.Ordinal))),
        IEnumerable sequence when value is not string => Array.AsReadOnly(sequence.Cast<object?>().Select(FreezeValue).ToArray()),
        _ => value,
    };
}
