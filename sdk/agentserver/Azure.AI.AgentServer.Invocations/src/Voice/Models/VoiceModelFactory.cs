// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections;
using System.Collections.ObjectModel;
using System.Text.Json;

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

    /// <summary>Creates a bridge-generated no-input turn.</summary>
    public static UserNoInputEvent UserNoInputEvent(
        string itemId = "in_test",
        int count = 1) => new(itemId, count);

    /// <summary>Creates an advisory speech-started callback model.</summary>
    public static UserSpeechStartedEvent UserSpeechStartedEvent() => new();

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

    private static object? FreezeValue(object? value)
    {
        if (value is null or string or bool)
        {
            return value;
        }

        if (value is JsonElement jsonElement)
        {
            return FreezeJsonElement(jsonElement);
        }

        if (value is IDictionary dictionary)
        {
            return FreezeUntypedDictionary(dictionary);
        }

        var dictionaryInterfaces = value.GetType()
            .GetInterfaces()
            .Append(value.GetType())
            .Where(type => type.IsGenericType &&
                type.GetGenericTypeDefinition() is var definition &&
                (definition == typeof(IDictionary<,>) || definition == typeof(IReadOnlyDictionary<,>)))
            .ToArray();
        if (dictionaryInterfaces.Length > 0)
        {
            if (dictionaryInterfaces.Any(type => type.GetGenericArguments()[0] != typeof(string)))
            {
                throw new ArgumentException("Caller metadata dictionaries must use string keys.", nameof(value));
            }

            return FreezeGenericDictionary((IEnumerable)value);
        }

        if (value is IEnumerable sequence)
        {
            return Array.AsReadOnly(sequence.Cast<object?>().Select(FreezeValue).ToArray());
        }

        if (value is byte or sbyte or short or ushort or int or uint or long or ulong or float or double or decimal)
        {
            if (value is double doubleValue && !double.IsFinite(doubleValue) ||
                value is float floatValue && !float.IsFinite(floatValue))
            {
                throw new ArgumentException("Caller metadata numbers must be finite.", nameof(value));
            }

            return value;
        }

        throw new ArgumentException("Caller metadata must contain JSON-compatible values.", nameof(value));
    }

    private static IReadOnlyDictionary<string, object?> FreezeUntypedDictionary(IDictionary dictionary)
    {
        var map = new Dictionary<string, object?>(StringComparer.Ordinal);
        foreach (DictionaryEntry entry in dictionary)
        {
            if (entry.Key is not string key)
            {
                throw new ArgumentException("Caller metadata dictionaries must use string keys.", nameof(dictionary));
            }

            map[key] = FreezeValue(entry.Value);
        }

        return new ReadOnlyDictionary<string, object?>(map);
    }

    private static IReadOnlyDictionary<string, object?> FreezeGenericDictionary(IEnumerable dictionary)
    {
        var map = new Dictionary<string, object?>(StringComparer.Ordinal);
        foreach (var entry in dictionary)
        {
            var entryType = entry?.GetType()
                ?? throw new ArgumentException("Caller metadata dictionary entries cannot be null.", nameof(dictionary));
            var key = entryType.GetProperty("Key")?.GetValue(entry) as string
                ?? throw new ArgumentException("Caller metadata dictionaries must use string keys.", nameof(dictionary));
            var item = entryType.GetProperty("Value")?.GetValue(entry);
            map.Add(key, FreezeValue(item));
        }

        return new ReadOnlyDictionary<string, object?>(map);
    }

    private static object? FreezeJsonElement(JsonElement value) => value.ValueKind switch
    {
        JsonValueKind.Object => new ReadOnlyDictionary<string, object?>(
            value.EnumerateObject().ToDictionary(
                property => property.Name,
                property => FreezeJsonElement(property.Value),
                StringComparer.Ordinal)),
        JsonValueKind.Array => Array.AsReadOnly(value.EnumerateArray().Select(FreezeJsonElement).ToArray()),
        JsonValueKind.String => value.GetString(),
        JsonValueKind.Number when value.TryGetInt64(out var integer) => integer,
        JsonValueKind.Number when value.TryGetDecimal(out var decimalValue) => decimalValue,
        JsonValueKind.Number => FreezeJsonNumber(value),
        JsonValueKind.True => true,
        JsonValueKind.False => false,
        JsonValueKind.Null => null,
        _ => throw new ArgumentException("Caller metadata contains an unsupported JSON value.", nameof(value)),
    };

    private static JsonElement FreezeJsonNumber(JsonElement value)
    {
        var number = value.GetDouble();
        if (!double.IsFinite(number))
        {
            throw new ArgumentException("Caller metadata numbers must be finite.", nameof(value));
        }

        return value.Clone();
    }
}
