// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Buffers;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace Azure.AI.AgentServer.Invocations.Voice.Internal;

/// <summary>
/// Internal codec for Voice Live Bridge Protocol 1.0 frames.
/// Validates the common envelope and parses inbound messages into immutable
/// event models. Customer code cannot construct outbound frames directly;
/// the runtime owns wire framing.
/// </summary>
internal static class VoiceProtocolCodec
{
    private static readonly Regex Rfc3339Timestamp = new(
        @"^\d{4}-\d{2}-\d{2}T(?:[01]\d|2[0-3]):[0-5]\d:[0-5]\d(?:\.\d{1,9})?(?:Z|[+-](?:[01]\d|2[0-3]):[0-5]\d)$",
        RegexOptions.CultureInvariant);

    /// <summary>
    /// Decodes one JSON object frame and validates its common envelope
    /// (<c>type</c>, <c>id</c>, <c>ts</c>).
    /// </summary>
    /// <param name="frame">The UTF-8 text frame.</param>
    /// <returns>The parsed root element.</returns>
    /// <exception cref="VoiceBridgeProtocolException">If the frame is not a valid enveloped JSON object.</exception>
    public static JsonElement DecodeFrame(string frame)
    {
        ArgumentNullException.ThrowIfNull(frame);

        ValidateStrictJson(frame);

        JsonDocument document;
        try
        {
            document = JsonDocument.Parse(frame);
        }
        catch (JsonException)
        {
            throw new VoiceBridgeProtocolException("Bridge frame is not valid JSON.", VoiceProtocolConstants.CloseProtocolError);
        }

        using (document)
        {
            var root = document.RootElement;
            if (root.ValueKind != JsonValueKind.Object)
            {
                throw new VoiceBridgeProtocolException("Bridge frame must be a JSON object.");
            }

            RequireNonEmptyString(root, "type");
            RequireNonEmptyString(root, "id");
            ValidateTimestamp(root);
            return root.Clone();
        }
    }

    /// <summary>Returns the required message <c>type</c> discriminator.</summary>
    public static string GetMessageType(JsonElement root) =>
        root.GetProperty("type").GetString()!;

    /// <summary>
    /// Computes a key-order-independent digest of the complete decoded payload.
    /// Unknown fields participate in the digest.
    /// </summary>
    public static string ComputeCanonicalDigest(JsonElement root)
    {
        var buffer = new ArrayBufferWriter<byte>();
        using (var writer = new Utf8JsonWriter(buffer, new JsonWriterOptions { Indented = false }))
        {
            WriteCanonical(writer, root);
        }

        return Convert.ToHexString(SHA256.HashData(buffer.WrittenSpan));
    }

    /// <summary>Parses and validates a <c>session.start</c> frame.</summary>
    public static SessionStartEvent ParseSessionStart(JsonElement root)
    {
        var version = root.TryGetProperty("protocol_version", out var versionElement) &&
            versionElement.ValueKind == JsonValueKind.String
                ? versionElement.GetString()
                : null;
        if (version != VoiceProtocolConstants.ProtocolVersion)
        {
            throw new VoiceBridgeProtocolException("Unsupported bridge protocol version.");
        }

        if (!root.TryGetProperty("reconnect", out var reconnectElement) ||
            (reconnectElement.ValueKind != JsonValueKind.True && reconnectElement.ValueKind != JsonValueKind.False))
        {
            throw new VoiceBridgeProtocolException("session.start reconnect must be a Boolean.");
        }

        var reconnect = reconnectElement.GetBoolean();

        if (!root.TryGetProperty("response_timeouts", out var responseTimeouts) || responseTimeouts.ValueKind != JsonValueKind.Object)
        {
            throw new VoiceBridgeProtocolException("session.start response_timeouts must be an object.");
        }

        var timeouts = new ResponseTimeouts(
            RequirePositiveInt(responseTimeouts, "first_output_ms"),
            RequirePositiveInt(responseTimeouts, "idle_ms"),
            RequirePositiveInt(responseTimeouts, "max_duration_ms"));

        var greeting = OptionalString(root, "greeting");
        if (reconnect && greeting is not null)
        {
            throw new VoiceBridgeProtocolException("session.start greeting must be absent on reconnect.");
        }

        int? noInputTimeoutMs = null;
        if (root.TryGetProperty("no_input_timeout_ms", out var noInputTimeout) && noInputTimeout.ValueKind != JsonValueKind.Null)
        {
            noInputTimeoutMs = RequirePositiveInt(root, "no_input_timeout_ms");
        }

        IReadOnlyDictionary<string, object?>? caller = null;
        if (root.TryGetProperty("caller", out var callerElement) && callerElement.ValueKind != JsonValueKind.Null)
        {
            if (callerElement.ValueKind != JsonValueKind.Object)
            {
                throw new VoiceBridgeProtocolException("session.start caller must be an object.");
            }

            caller = FreezeObject(callerElement);
        }

        return new SessionStartEvent(reconnect, timeouts, greeting, noInputTimeoutMs, caller);
    }

    /// <summary>Parses and validates a <c>user.message</c> frame.</summary>
    public static UserMessageEvent ParseUserMessage(JsonElement root)
    {
        var itemId = RequirePrefixedId(root, "item_id", VoiceProtocolConstants.InputItemPrefix);
        var parts = ParseContentParts(root, "user.message");
        return new UserMessageEvent(itemId, parts);
    }

    /// <summary>Parses and validates a <c>user.no_input</c> turn.</summary>
    public static UserNoInputEvent ParseUserNoInput(JsonElement root) =>
        new(
            RequirePrefixedId(root, "item_id", VoiceProtocolConstants.InputItemPrefix),
            RequirePositiveInt(root, "count"));

    /// <summary>Parses and validates a <c>conversation.item.create</c> mutation.</summary>
    public static ConversationItemCreateEvent ParseConversationItemCreate(JsonElement root)
    {
        var requestId = RequireNonEmptyStringValue(root, "id");
        if (!root.TryGetProperty("item", out var item) || item.ValueKind != JsonValueKind.Object)
        {
            throw new VoiceBridgeProtocolException("conversation.item.create item must be an object.");
        }

        var itemId = RequirePrefixedId(item, "id", VoiceProtocolConstants.HistoryItemPrefix);
        if (RequireString(item, "role") != "user")
        {
            throw new VoiceBridgeProtocolException(
                "conversation.item.create role must be user.",
                VoiceProtocolConstants.ClosePolicyViolation);
        }

        var previousItemId = OptionalString(root, "previous_item_id");
        if (previousItemId is not null &&
            previousItemId != "root" &&
            !HasPrefix(previousItemId, VoiceProtocolConstants.InputItemPrefix) &&
            !HasPrefix(previousItemId, VoiceProtocolConstants.HistoryItemPrefix) &&
            !HasPrefix(previousItemId, VoiceProtocolConstants.OutputItemPrefix))
        {
            throw new VoiceBridgeProtocolException(
                "previous_item_id must be root or start with in_, hi_, or it_.",
                VoiceProtocolConstants.ClosePolicyViolation);
        }

        var content = ParseContentParts(item, "conversation.item.create");
        if (content.Count == 0)
        {
            throw new VoiceBridgeProtocolException("conversation.item.create contains no supported content parts.");
        }

        return new ConversationItemCreateEvent(
            requestId,
            new ConversationHistoryItem(itemId, content),
            previousItemId);
    }

    /// <summary>Parses and validates a <c>conversation.item.delete</c> mutation.</summary>
    public static ConversationItemDeleteEvent ParseConversationItemDelete(JsonElement root)
    {
        var itemId = RequireNonEmptyStringValue(root, "item_id");
        if (!HasPrefix(itemId, VoiceProtocolConstants.HistoryItemPrefix) &&
            !HasPrefix(itemId, VoiceProtocolConstants.OutputItemPrefix))
        {
            throw new VoiceBridgeProtocolException(
                "conversation.item.delete item_id must start with hi_ or it_.",
                VoiceProtocolConstants.ClosePolicyViolation);
        }

        return new ConversationItemDeleteEvent(
            RequireNonEmptyStringValue(root, "id"),
            itemId);
    }

    /// <summary>Parses a raw-key or collected-result <c>dtmf</c> event.</summary>
    public static object ParseDtmf(JsonElement root)
    {
        var digits = RequireString(root, "digits");
        var hasCollection = root.TryGetProperty("collection_id", out _);
        var hasItem = root.TryGetProperty("item_id", out _);
        var hasReason = root.TryGetProperty("completion_reason", out _);
        if (!hasCollection && !hasItem && !hasReason)
        {
            if (digits.Length != 1 || !IsDtmfKey(digits[0]))
            {
                throw new VoiceBridgeProtocolException("Raw dtmf digits must contain exactly one DTMF key.");
            }

            return new DtmfKeyEvent(digits);
        }

        if (!hasCollection || !hasItem || !hasReason)
        {
            throw new VoiceBridgeProtocolException(
                "Collected dtmf requires collection_id, item_id, and completion_reason.");
        }

        if (digits.Any(character => !IsDtmfKey(character)))
        {
            throw new VoiceBridgeProtocolException("Collected dtmf digits contain an invalid key.");
        }

        return new DtmfCollectedEvent(
            RequirePrefixedId(root, "item_id", VoiceProtocolConstants.InputItemPrefix),
            RequirePrefixedId(root, "collection_id", VoiceProtocolConstants.DtmfCollectionPrefix),
            digits,
            RequireNonEmptyStringValue(root, "completion_reason"));
    }

    /// <summary>Parses a <c>dtmf.collect.rejected</c> event.</summary>
    public static DtmfCollectionRejectedEvent ParseDtmfCollectionRejected(JsonElement root) =>
        new(
            RequirePrefixedId(root, "collection_id", VoiceProtocolConstants.DtmfCollectionPrefix),
            RequireNonEmptyStringValue(root, "reason"));

    /// <summary>Parses a <c>dtmf.collect.cancelled</c> event.</summary>
    public static DtmfCollectionCancelledEvent ParseDtmfCollectionCancelled(JsonElement root) =>
        new(
            RequirePrefixedId(root, "collection_id", VoiceProtocolConstants.DtmfCollectionPrefix),
            RequireNonEmptyStringValue(root, "reason"));

    /// <summary>Parses a bridge-generated <c>handoff.failed</c> recovery turn.</summary>
    public static HandoffFailedEvent ParseHandoffFailed(JsonElement root) =>
        new(
            RequirePrefixedId(root, "item_id", VoiceProtocolConstants.InputItemPrefix),
            RequireNonEmptyStringValue(root, "target"),
            RequireNonEmptyStringValue(root, "code"),
            OptionalString(root, "message"));

    /// <summary>Parses a caller <c>barge_in</c> playback terminal.</summary>
    public static BargeInEvent ParseBargeIn(JsonElement root)
    {
        var itemId = OptionalString(root, "item_id");
        if (itemId is not null && !HasPrefix(itemId, VoiceProtocolConstants.OutputItemPrefix))
        {
            throw new VoiceBridgeProtocolException(
                "barge_in item_id must start with it_.",
                VoiceProtocolConstants.ClosePolicyViolation);
        }

        return new BargeInEvent(
            RequirePrefixedId(root, "response_id", VoiceProtocolConstants.ResponsePrefix),
            RequireString(root, "heard_text"),
            itemId);
    }

    /// <summary>Parses a <c>response.cancelled</c> playback terminal.</summary>
    public static ResponseCancellationOutcome ParseResponseCancelled(JsonElement root)
    {
        var itemId = OptionalString(root, "item_id");
        if (itemId is not null && !HasPrefix(itemId, VoiceProtocolConstants.OutputItemPrefix))
        {
            throw new VoiceBridgeProtocolException(
                "response.cancelled item_id must start with it_.",
                VoiceProtocolConstants.ClosePolicyViolation);
        }

        return new ResponseCancellationOutcome(
            RequirePrefixedId(root, "response_id", VoiceProtocolConstants.ResponsePrefix),
            "cancelled",
            RequireString(root, "heard_text"),
            itemId);
    }

    /// <summary>Parses the exclusive response/input-batch forms of <c>response.timeout</c>.</summary>
    public static ResponseTimeoutEvent ParseResponseTimeout(JsonElement root)
    {
        var stage = RequireNonEmptyStringValue(root, "stage");
        var hasResponseId = root.TryGetProperty("response_id", out _);
        var hasItemIds = root.TryGetProperty("item_ids", out _);
        if (hasResponseId == hasItemIds)
        {
            throw new VoiceBridgeProtocolException(
                "response.timeout requires exactly one of response_id or item_ids.");
        }

        if (hasResponseId)
        {
            return new ResponseTimeoutEvent(
                stage,
                RequirePrefixedId(root, "response_id", VoiceProtocolConstants.ResponsePrefix),
                itemIds: null);
        }

        var itemIdsElement = root.GetProperty("item_ids");
        if (itemIdsElement.ValueKind != JsonValueKind.Array || itemIdsElement.GetArrayLength() == 0)
        {
            throw new VoiceBridgeProtocolException("response.timeout item_ids must be a non-empty array.");
        }

        var itemIds = new List<string>();
        var uniqueItemIds = new HashSet<string>(StringComparer.Ordinal);
        foreach (var itemIdElement in itemIdsElement.EnumerateArray())
        {
            if (itemIdElement.ValueKind != JsonValueKind.String)
            {
                throw new VoiceBridgeProtocolException("response.timeout item_ids must contain in_ identifiers.");
            }

            var itemId = itemIdElement.GetString()!;
            if (!HasPrefix(itemId, VoiceProtocolConstants.InputItemPrefix))
            {
                throw new VoiceBridgeProtocolException("response.timeout item_ids must contain in_ identifiers.");
            }

            if (!uniqueItemIds.Add(itemId))
            {
                throw new VoiceBridgeProtocolException("response.timeout item_ids must not contain duplicates.");
            }

            itemIds.Add(itemId);
        }

        return new ResponseTimeoutEvent(stage, responseId: null, itemIds.AsReadOnly());
    }

    /// <summary>Parses a bridge-initiated <c>session.end</c> event.</summary>
    public static SessionEndEvent ParseSessionEnd(JsonElement root) =>
        new(RequireNonEmptyStringValue(root, "reason"));

    /// <summary>Returns one required response ID.</summary>
    public static string ParseResponseId(JsonElement root) =>
        RequirePrefixedId(root, "response_id", VoiceProtocolConstants.ResponsePrefix);

    /// <summary>Returns one required collection ID.</summary>
    public static string ParseCollectionId(JsonElement root) =>
        RequirePrefixedId(root, "collection_id", VoiceProtocolConstants.DtmfCollectionPrefix);

    /// <summary>Returns one required non-empty open-enum reason.</summary>
    public static string ParseReason(JsonElement root) => RequireNonEmptyStringValue(root, "reason");

    private static IReadOnlyList<VoiceContentPart> ParseContentParts(JsonElement root, string messageName)
    {
        if (!root.TryGetProperty("content", out var content) ||
            content.ValueKind != JsonValueKind.Array ||
            content.GetArrayLength() == 0)
        {
            throw new VoiceBridgeProtocolException($"{messageName} content must be a non-empty array.");
        }

        var parts = new List<VoiceContentPart>();
        foreach (var part in content.EnumerateArray())
        {
            if (part.ValueKind != JsonValueKind.Object ||
                !part.TryGetProperty("type", out var typeElement) ||
                typeElement.ValueKind != JsonValueKind.String)
            {
                throw new VoiceBridgeProtocolException($"{messageName} content parts must have a string type.");
            }

            var type = typeElement.GetString();
            switch (type)
            {
                case "input_text":
                    parts.Add(new InputTextPart(RequireString(part, "text")));
                    break;
                case "input_image":
                    parts.Add(new InputImagePart(
                        RequireNonEmptyStringValue(part, "image_ref"),
                        RequireNonEmptyStringValue(part, "mime_type"),
                        OptionalString(part, "alt")));
                    break;
                default:
                    // Unknown open-enum content parts are ignored for forward compatibility.
                    break;
            }
        }

        return parts.AsReadOnly();
    }

    private static void ValidateStrictJson(string frame)
    {
        try
        {
            var reader = new Utf8JsonReader(Encoding.UTF8.GetBytes(frame));
            var objectProperties = new Stack<HashSet<string>>();
            while (reader.Read())
            {
                switch (reader.TokenType)
                {
                    case JsonTokenType.StartObject:
                        objectProperties.Push(new HashSet<string>(StringComparer.Ordinal));
                        break;
                    case JsonTokenType.EndObject:
                        objectProperties.Pop();
                        break;
                    case JsonTokenType.PropertyName:
                        var propertyName = reader.GetString()!;
                        if (objectProperties.Count == 0 || !objectProperties.Peek().Add(propertyName))
                        {
                            throw new VoiceBridgeProtocolException("Bridge frame contains a duplicate object key.");
                        }

                        break;
                    case JsonTokenType.Number:
                        if (reader.TryGetDouble(out var value) && !double.IsFinite(value))
                        {
                            throw new VoiceBridgeProtocolException("Bridge frame contains a non-finite number.");
                        }

                        break;
                }
            }
        }
        catch (JsonException)
        {
            throw new VoiceBridgeProtocolException("Bridge frame is not valid JSON.", VoiceProtocolConstants.CloseProtocolError);
        }
    }

    private static void WriteCanonical(Utf8JsonWriter writer, JsonElement element)
    {
        switch (element.ValueKind)
        {
            case JsonValueKind.Object:
                writer.WriteStartObject();
                foreach (var property in element.EnumerateObject().OrderBy(property => property.Name, StringComparer.Ordinal))
                {
                    writer.WritePropertyName(property.Name);
                    WriteCanonical(writer, property.Value);
                }

                writer.WriteEndObject();
                break;
            case JsonValueKind.Array:
                writer.WriteStartArray();
                foreach (var item in element.EnumerateArray())
                {
                    WriteCanonical(writer, item);
                }

                writer.WriteEndArray();
                break;
            case JsonValueKind.String:
                writer.WriteStringValue(element.GetString());
                break;
            case JsonValueKind.Number:
                writer.WriteRawValue(element.GetRawText(), skipInputValidation: false);
                break;
            case JsonValueKind.True:
                writer.WriteBooleanValue(true);
                break;
            case JsonValueKind.False:
                writer.WriteBooleanValue(false);
                break;
            case JsonValueKind.Null:
                writer.WriteNullValue();
                break;
            default:
                throw new VoiceBridgeProtocolException("Bridge frame contains an unsupported JSON value.");
        }
    }

    private static IReadOnlyDictionary<string, object?> FreezeObject(JsonElement element)
    {
        var map = new Dictionary<string, object?>(StringComparer.Ordinal);
        foreach (var property in element.EnumerateObject())
        {
            map[property.Name] = FreezeJsonValue(property.Value);
        }

        return new ReadOnlyDictionary<string, object?>(map);
    }

    private static object? FreezeJsonValue(JsonElement value) => value.ValueKind switch
    {
        JsonValueKind.Object => FreezeObject(value),
        JsonValueKind.Array => Array.AsReadOnly(value.EnumerateArray().Select(FreezeJsonValue).ToArray()),
        JsonValueKind.String => value.GetString(),
        JsonValueKind.Number when value.TryGetInt64(out var integer) => integer,
        JsonValueKind.Number when value.TryGetDecimal(out var decimalValue) => decimalValue,
        JsonValueKind.Number => value.Clone(),
        JsonValueKind.True => true,
        JsonValueKind.False => false,
        JsonValueKind.Null => null,
        _ => throw new VoiceBridgeProtocolException("Caller metadata contains an unsupported JSON value."),
    };

    private static void RequireNonEmptyString(JsonElement root, string name)
    {
        if (!root.TryGetProperty(name, out var element) || element.ValueKind != JsonValueKind.String ||
            string.IsNullOrEmpty(element.GetString()))
        {
            throw new VoiceBridgeProtocolException($"Envelope field '{name}' must be a non-empty string.");
        }
    }

    private static string RequireString(JsonElement root, string name)
    {
        if (!root.TryGetProperty(name, out var element) || element.ValueKind != JsonValueKind.String)
        {
            throw new VoiceBridgeProtocolException($"Field '{name}' must be a string.");
        }

        return element.GetString()!;
    }

    private static string RequireNonEmptyStringValue(JsonElement root, string name)
    {
        var value = RequireString(root, name);
        if (value.Length == 0)
        {
            throw new VoiceBridgeProtocolException($"Field '{name}' must be a non-empty string.");
        }

        return value;
    }

    private static string? OptionalString(JsonElement root, string name)
    {
        if (!root.TryGetProperty(name, out var element) || element.ValueKind == JsonValueKind.Null)
        {
            return null;
        }

        if (element.ValueKind != JsonValueKind.String)
        {
            throw new VoiceBridgeProtocolException($"Field '{name}' must be a string.");
        }

        return element.GetString();
    }

    private static string RequirePrefixedId(JsonElement root, string name, string prefix)
    {
        if (!root.TryGetProperty(name, out var element) || element.ValueKind != JsonValueKind.String)
        {
            throw new VoiceBridgeProtocolException($"Field '{name}' must be a string.", VoiceProtocolConstants.ClosePolicyViolation);
        }

        var value = element.GetString()!;
        var marker = prefix + "_";
        if (!value.StartsWith(marker, StringComparison.Ordinal) || value.Length <= marker.Length)
        {
            throw new VoiceBridgeProtocolException($"Field '{name}' must start with {marker}.", VoiceProtocolConstants.ClosePolicyViolation);
        }

        return value;
    }

    private static bool HasPrefix(string value, string prefix)
    {
        var marker = prefix + "_";
        return value.StartsWith(marker, StringComparison.Ordinal) && value.Length > marker.Length;
    }

    private static bool IsDtmfKey(char value) =>
        (value >= '0' && value <= '9') || value is '*' or '#';

    private static int RequirePositiveInt(JsonElement root, string name)
    {
        if (!root.TryGetProperty(name, out var element) || element.ValueKind != JsonValueKind.Number ||
            !element.TryGetInt32(out var value) || value <= 0)
        {
            throw new VoiceBridgeProtocolException($"Field '{name}' must be a positive integer.");
        }

        return value;
    }

    private static void ValidateTimestamp(JsonElement root)
    {
        var timestamp = root.TryGetProperty("ts", out var element) && element.ValueKind == JsonValueKind.String
            ? element.GetString()
            : null;
        if (timestamp is null ||
            !Rfc3339Timestamp.IsMatch(timestamp) ||
            !DateTimeOffset.TryParse(
                timestamp,
                CultureInfo.InvariantCulture,
                DateTimeStyles.RoundtripKind,
                out _))
        {
            throw new VoiceBridgeProtocolException("ts must match the RFC 3339 profile.");
        }
    }
}
