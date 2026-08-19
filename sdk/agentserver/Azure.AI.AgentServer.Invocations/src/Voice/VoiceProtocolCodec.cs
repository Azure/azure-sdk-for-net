// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Buffers;
using System.Globalization;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace Azure.AI.AgentServer.Invocations.Voice;

internal sealed class VoiceProtocolException : Exception
{
    internal VoiceProtocolException(string message, int closeCode = 1002, Exception? innerException = null)
        : base(message, innerException)
    {
        CloseCode = closeCode;
    }

    internal int CloseCode { get; }
}

internal static partial class VoiceProtocolCodec
{
    internal const int MaxFrameBytes = 1024 * 1024;
    internal const int MaxJsonDepth = 256;
    private const int MaxAdmissionTimeoutMs = 60000;

    private static readonly HashSet<string> KnownExcludedInbound = new(StringComparer.Ordinal)
    {
        "conversation.item.create",
        "conversation.item.delete",
        "dtmf",
        "dtmf.collect.cancelled",
        "dtmf.collect.rejected",
        "handoff.failed",
        "conversation.item.created",
        "conversation.item.deleted",
        "conversation.item.failed",
        "handoff",
        "dtmf.collect",
        "dtmf.collect.cancel",
    };

    private static readonly HashSet<string> OutboundTypes = new(StringComparer.Ordinal)
    {
        "end_call",
        "error",
        "response.cancel",
        "response.created",
        "response.done",
        "response.none",
        "response.output_text.delta",
        "response.output_text.done",
        "session.ready",
        "session.rejected",
    };

    private static readonly HashSet<string> VoiceTypes = new(StringComparer.Ordinal)
    {
        "openai",
        "azure-standard",
        "azure-custom",
        "azure-personal",
        "avatar-voice-sync",
        "azure-realtime-native",
    };

    internal static VoiceInboundMessage? Decode(ReadOnlyMemory<byte> frame)
    {
        if (frame.Length > MaxFrameBytes)
        {
            throw new VoiceProtocolException("Voice frame exceeds the maximum size.", 1009);
        }

        JsonDocument document;
        try
        {
            document = JsonDocument.Parse(frame, new JsonDocumentOptions
            {
                AllowTrailingCommas = false,
                CommentHandling = JsonCommentHandling.Disallow,
                MaxDepth = MaxJsonDepth,
            });
        }
        catch (Exception exception) when (exception is JsonException or ArgumentException)
        {
            throw new VoiceProtocolException("Voice frame is not valid JSON.", innerException: exception);
        }

        using (document)
        {
            var root = document.RootElement;
            if (root.ValueKind != JsonValueKind.Object)
            {
                throw new VoiceProtocolException("Voice frame must be a JSON object.");
            }

            ValidateJsonTree(root);
            var type = RequiredString(root, "type", nonEmpty: true);
            var id = Identifier(root, "id");
            var timestamp = Timestamp(root, "ts");

            if (KnownExcludedInbound.Contains(type))
            {
                throw new VoiceProtocolException("Voice message type is not supported by Protocol 1.0.", 1003);
            }
            if (OutboundTypes.Contains(type))
            {
                throw new VoiceProtocolException("Agent-to-Bridge message received in the inbound direction.");
            }

            return type switch
            {
                "session.start" => ParseSessionStart(root, id, timestamp),
                "user.message" => ParseUserMessage(root, id, timestamp),
                "user.no_input" => new VoiceUserNoInputEvent(
                    id,
                    timestamp,
                    PrefixedIdentifier(root, "item_id", "in_"),
                    PositiveInteger(root, "count")),
                "user.speech_started" => new VoiceUserSpeechStartedEvent(id, timestamp),
                "barge_in" => new VoiceBargeInEvent(
                    id,
                    timestamp,
                    PrefixedIdentifier(root, "response_id", "r_"),
                    RequiredString(root, "heard_text"),
                    OptionalPrefixedIdentifier(root, "item_id", "it_")),
                "response.accepted" => new VoiceResponseAcceptedEvent(
                    id,
                    timestamp,
                    PrefixedIdentifier(root, "response_id", "r_")),
                "response.dropped" => new VoiceResponseDroppedEvent(
                    id,
                    timestamp,
                    PrefixedIdentifier(root, "response_id", "r_"),
                    RequiredString(root, "reason", nonEmpty: true)),
                "response.cancelled" => new VoiceResponseCancelledEvent(
                    id,
                    timestamp,
                    PrefixedIdentifier(root, "response_id", "r_"),
                    RequiredString(root, "heard_text"),
                    OptionalPrefixedIdentifier(root, "item_id", "it_")),
                "response.timeout" => ParseResponseTimeout(root, id, timestamp),
                "session.end" => new VoiceSessionEndEvent(
                    id,
                    timestamp,
                    RequiredString(root, "reason", nonEmpty: true)),
                _ => null,
            };
        }
    }

    internal static ReadOnlyMemory<byte> Encode(VoiceOutboundMessage message)
    {
        ArgumentNullException.ThrowIfNull(message);
        using var output = new LimitedWriteStream(MaxFrameBytes);
        try
        {
            using (var writer = new Utf8JsonWriter(output, new JsonWriterOptions
            {
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            }))
            {
                writer.WriteStartObject();
                writer.WriteString("type", message.MessageType);
                writer.WriteString("id", ValidateIdentifier(message.Id, nameof(message.Id)));
                writer.WriteString(
                    "ts",
                    message.Timestamp.UtcDateTime.ToString(
                        "yyyy-MM-dd'T'HH:mm:ss.fffffff'Z'",
                        CultureInfo.InvariantCulture));
                WriteMessageFields(writer, message);
                writer.WriteEndObject();
            }
        }
        catch (FrameLimitExceededException)
        {
            throw new ArgumentOutOfRangeException(
                nameof(message),
            "Voice message exceeds the maximum encoded frame size.");
        }
        catch (JsonException exception)
        {
            throw new ArgumentException("Voice message contains invalid JSON.", nameof(message), exception);
        }

        return output.WrittenMemory;
    }

    private static VoiceSessionStartEvent ParseSessionStart(
        JsonElement root,
        string id,
        DateTimeOffset timestamp)
    {
        var reconnect = RequiredBoolean(root, "reconnect");
        string? greeting = null;
        if (root.TryGetProperty("greeting", out var greetingElement))
        {
            if (reconnect)
            {
                throw new VoiceProtocolException("session.start greeting must be absent on reconnect.");
            }
            greeting = ElementString(greetingElement, "greeting");
        }

        var timeoutElement = RequiredObject(root, "response_timeouts");
        var noInputTimeoutMs = root.TryGetProperty("no_input_timeout_ms", out _)
            ? PositiveInteger(root, "no_input_timeout_ms")
            : (int?)null;
        BinaryData? caller = null;
        if (root.TryGetProperty("caller", out var callerElement))
        {
            if (callerElement.ValueKind != JsonValueKind.Object)
            {
                throw new VoiceProtocolException("caller must be an object.");
            }
            ValidateCallerKnownFields(callerElement);
            RejectCredentialFields(callerElement);
            caller = BinaryData.FromString(callerElement.GetRawText());
        }

        return new VoiceSessionStartEvent(
            id,
            timestamp,
            RequiredString(root, "protocol_version", nonEmpty: true),
            reconnect,
            new VoiceResponseTimeouts(
                PositiveInteger(timeoutElement, "first_output_ms"),
                PositiveInteger(timeoutElement, "idle_ms"),
                PositiveInteger(timeoutElement, "max_duration_ms")),
            greeting,
            noInputTimeoutMs,
            caller);
    }

    private static VoiceInboundMessage? ParseUserMessage(
        JsonElement root,
        string id,
        DateTimeOffset timestamp)
    {
        if (!root.TryGetProperty("content", out var contentElement) ||
            contentElement.ValueKind != JsonValueKind.Array ||
            contentElement.GetArrayLength() == 0)
        {
            throw new VoiceProtocolException("user.message content must be a non-empty array.");
        }

        var content = new List<VoiceInputTextPart>();
        foreach (var part in contentElement.EnumerateArray())
        {
            if (part.ValueKind != JsonValueKind.Object)
            {
                throw new VoiceProtocolException("user.message content parts must be objects.");
            }

            var partType = RequiredString(part, "type", nonEmpty: true);
            if (partType == "input_text")
            {
                content.Add(new VoiceInputTextPart(RequiredString(part, "text")));
            }
            else if (partType == "input_image")
            {
                throw new VoiceProtocolException("Image content is not supported by Protocol 1.0.", 1003);
            }
        }

        return content.Count == 0
            ? null
            : new VoiceUserMessageEvent(
                id,
                timestamp,
                PrefixedIdentifier(root, "item_id", "in_"),
                content);
    }

    private static VoiceResponseTimeoutEvent ParseResponseTimeout(
        JsonElement root,
        string id,
        DateTimeOffset timestamp)
    {
        var hasResponseId = root.TryGetProperty("response_id", out _);
        var hasItemIds = root.TryGetProperty("item_ids", out var itemIdsElement);
        if (hasResponseId == hasItemIds)
        {
            throw new VoiceProtocolException("response.timeout requires exactly one target.");
        }

        if (hasResponseId)
        {
            return new VoiceResponseTimeoutEvent(
                id,
                timestamp,
                RequiredString(root, "stage", nonEmpty: true),
                responseId: PrefixedIdentifier(root, "response_id", "r_"));
        }

        if (itemIdsElement.ValueKind != JsonValueKind.Array || itemIdsElement.GetArrayLength() == 0)
        {
            throw new VoiceProtocolException("response.timeout item_ids must be a non-empty array.");
        }

        var itemIds = itemIdsElement.EnumerateArray()
            .Select(item => ValidateInboundPrefixedIdentifier(ElementString(item, "item_ids"), "item_ids", "in_"))
            .ToArray();
        if (itemIds.Distinct(StringComparer.Ordinal).Count() != itemIds.Length)
        {
            throw new VoiceProtocolException("response.timeout item_ids must be unique.");
        }
        return new VoiceResponseTimeoutEvent(
            id,
            timestamp,
            RequiredString(root, "stage", nonEmpty: true),
            itemIds: itemIds);
    }

    private static void WriteMessageFields(Utf8JsonWriter writer, VoiceOutboundMessage message)
    {
        switch (message)
        {
            case VoiceSessionReadyMessage:
                return;
            case VoiceSessionRejectedMessage rejected:
                writer.WriteString("code", ValidateString(rejected.Code, nameof(rejected.Code), nonEmpty: true));
                writer.WriteBoolean("retriable", rejected.Retriable);
                WriteOptionalString(writer, "message", rejected.Message);
                return;
            case VoiceResponseCreatedMessage created:
                writer.WriteString(
                    "response_id",
                    ValidatePrefixedIdentifier(created.ResponseId, nameof(created.ResponseId), "r_"));
                if (created.InReplyTo is not null)
                {
                    if (created.AdmissionTimeoutMs is not null || created.SupersedeKey is not null)
                    {
                        throw new ArgumentException(
                            "A reply response.created cannot contain proactive admission controls.",
                            nameof(message));
                    }
                    WriteInputPrefix(writer, created.InReplyTo);
                }
                else
                {
                    if (created.AdmissionTimeoutMs is not null)
                    {
                        if (created.AdmissionTimeoutMs is <= 0 or > MaxAdmissionTimeoutMs)
                        {
                            throw new ArgumentOutOfRangeException(
                                nameof(created.AdmissionTimeoutMs),
                                $"admission_timeout_ms must be between 1 and {MaxAdmissionTimeoutMs}.");
                        }
                        writer.WriteNumber("admission_timeout_ms", created.AdmissionTimeoutMs.Value);
                    }
                    WriteOptionalString(writer, "supersede_key", created.SupersedeKey, nonEmpty: true);
                }
                return;
            case VoiceResponseNoneMessage none:
                WriteInputPrefix(writer, none.InReplyTo);
                WriteOptionalString(writer, "reason", none.Reason);
                return;
            case VoiceResponseOutputTextDeltaMessage delta:
                WriteResponseItem(writer, delta.ResponseId, delta.ItemId);
                writer.WriteString("delta", ValidateString(delta.Delta, nameof(delta.Delta), nonEmpty: true));
                WriteVoice(writer, delta.Voice);
                return;
            case VoiceResponseOutputTextDoneMessage done:
                WriteResponseItem(writer, done.ResponseId, done.ItemId);
                writer.WriteString("text", ValidateString(done.Text, nameof(done.Text)));
                WriteVoice(writer, done.Voice);
                return;
            case VoiceResponseDoneMessage responseDone:
                writer.WriteString(
                    "response_id",
                    ValidatePrefixedIdentifier(responseDone.ResponseId, nameof(responseDone.ResponseId), "r_"));
                return;
            case VoiceResponseCancelMessage cancel:
                writer.WriteString(
                    "response_id",
                    ValidatePrefixedIdentifier(cancel.ResponseId, nameof(cancel.ResponseId), "r_"));
                WriteOptionalString(writer, "reason", cancel.Reason);
                return;
            case VoiceEndCallMessage endCall:
                writer.WriteString("reason", ValidateString(endCall.Reason, nameof(endCall.Reason), nonEmpty: true));
                writer.WriteString("mode", endCall.Mode switch
                {
                    VoiceEndCallMode.Drain => "drain",
                    VoiceEndCallMode.Immediate => "immediate",
                    _ => throw new ArgumentOutOfRangeException(nameof(endCall.Mode)),
                });
                return;
            case VoiceErrorMessage error:
                writer.WriteString("code", ValidateString(error.Code, nameof(error.Code), nonEmpty: true));
                writer.WriteString("message", ValidateString(error.Message, nameof(error.Message)));
                if (error.ResponseId is not null)
                {
                    writer.WriteString(
                        "response_id",
                        ValidatePrefixedIdentifier(error.ResponseId, nameof(error.ResponseId), "r_"));
                }
                if (error.ItemId is not null)
                {
                    if (error.ResponseId is null)
                    {
                        throw new ArgumentException("item_id requires response_id.", nameof(message));
                    }
                    writer.WriteString(
                        "item_id",
                        ValidatePrefixedIdentifier(error.ItemId, nameof(error.ItemId), "it_"));
                }
                return;
            default:
                throw new ArgumentException("message must be a selected outbound Voice message.", nameof(message));
        }
    }

    private static void WriteInputPrefix(Utf8JsonWriter writer, IReadOnlyList<string> inputIds)
    {
        if (inputIds.Count == 0)
        {
            throw new ArgumentException("in_reply_to must be non-empty.", nameof(inputIds));
        }

        var unique = new HashSet<string>(StringComparer.Ordinal);
        writer.WriteStartArray("in_reply_to");
        foreach (var inputId in inputIds)
        {
            var validated = ValidatePrefixedIdentifier(inputId, "in_reply_to", "in_");
            if (!unique.Add(validated))
            {
                throw new ArgumentException("in_reply_to must contain unique identifiers.", nameof(inputIds));
            }
            writer.WriteStringValue(validated);
        }
        writer.WriteEndArray();
    }

    private static void WriteResponseItem(Utf8JsonWriter writer, string responseId, string itemId)
    {
        writer.WriteString("response_id", ValidatePrefixedIdentifier(responseId, nameof(responseId), "r_"));
        writer.WriteString("item_id", ValidatePrefixedIdentifier(itemId, nameof(itemId), "it_"));
    }

    private static void WriteVoice(Utf8JsonWriter writer, BinaryData? voice)
    {
        if (voice is null)
        {
            return;
        }

        using var document = JsonDocument.Parse(voice);
        var root = document.RootElement;
        if (root.ValueKind != JsonValueKind.Object || !root.EnumerateObject().Any())
        {
            throw new ArgumentException("voice must be a non-empty JSON object.", nameof(voice));
        }
        ValidateJsonTree(root, outbound: true);

        writer.WriteStartObject("voice");
        foreach (var property in root.EnumerateObject())
        {
            ValidateVoiceKnownField(property);
            if (property.NameEquals("type"))
            {
                var voiceType = ElementString(property.Value, "voice.type");
                voiceType = voiceType switch
                {
                    "azure-platform" => "azure-standard",
                    "custom" => "azure-custom",
                    _ => voiceType,
                };
                if (!VoiceTypes.Contains(voiceType))
                {
                    throw new ArgumentException("voice.type is not supported.", nameof(voice));
                }
                writer.WriteString("type", voiceType);
            }
            else
            {
                property.WriteTo(writer);
            }
        }
        writer.WriteEndObject();
    }

    private static void ValidateCallerKnownFields(JsonElement caller)
    {
        foreach (var property in caller.EnumerateObject())
        {
            switch (property.Name)
            {
                case "channel":
                case "ani":
                case "dnis":
                case "customer_id":
                    _ = ElementString(property.Value, $"caller.{property.Name}");
                    break;
                case "custom_parameters" when property.Value.ValueKind != JsonValueKind.Object:
                    throw new VoiceProtocolException("caller.custom_parameters must be an object.");
            }
        }
    }

    private static void ValidateVoiceKnownField(JsonProperty property)
    {
        switch (property.Name)
        {
            case "type":
                ValidateOutboundJsonString(property.Value, "voice.type", nullable: false);
                break;
            case "name":
            case "endpoint_id":
            case "model":
                ValidateOutboundJsonString(property.Value, $"voice.{property.Name}", nullable: false);
                break;
            case "locale":
            case "style":
            case "pitch":
            case "rate":
            case "volume":
                ValidateOutboundJsonString(property.Value, $"voice.{property.Name}", nullable: true);
                break;
            case "custom_lexicon_url":
            case "custom_text_normalization_url":
                ValidateOutboundUri(property.Value, $"voice.{property.Name}");
                break;
            case "multi_talker_speaker_name":
                ValidateOutboundJsonString(property.Value, $"voice.{property.Name}", nullable: true);
                break;
            case "temperature":
                if (property.Value.ValueKind == JsonValueKind.Null)
                {
                    break;
                }
                if (property.Value.ValueKind != JsonValueKind.Number ||
                    !property.Value.TryGetDouble(out var temperature) ||
                    !double.IsFinite(temperature) ||
                    temperature is < 0 or > 1)
                {
                    throw new ArgumentOutOfRangeException(
                        "voice.temperature",
                        "voice.temperature must be null or between 0.0 and 1.0.");
                }
                break;
            case "prefer_locales":
                if (property.Value.ValueKind == JsonValueKind.Null)
                {
                    break;
                }
                if (property.Value.ValueKind != JsonValueKind.Array)
                {
                    throw new ArgumentException("voice.prefer_locales must be null or an array of strings.");
                }
                foreach (var locale in property.Value.EnumerateArray())
                {
                    ValidateOutboundJsonString(locale, "voice.prefer_locales", nullable: false);
                }
                break;
            case "avatar_character":
            case "avatar_style":
                throw new ArgumentException($"voice.{property.Name} is server-owned and cannot be sent.");
        }
    }

    private static void ValidateOutboundJsonString(JsonElement value, string name, bool nullable)
    {
        if (nullable && value.ValueKind == JsonValueKind.Null)
        {
            return;
        }
        if (value.ValueKind != JsonValueKind.String || string.IsNullOrEmpty(value.GetString()))
        {
            throw new ArgumentException($"{name} must be a non-empty string{(nullable ? " or null" : string.Empty)}.");
        }
    }

    private static void ValidateOutboundUri(JsonElement value, string name)
    {
        if (value.ValueKind == JsonValueKind.Null)
        {
            return;
        }
        if (value.ValueKind != JsonValueKind.String ||
            !Uri.TryCreate(value.GetString(), UriKind.Absolute, out _))
        {
            throw new ArgumentException($"{name} must be an absolute URI or null.");
        }
    }

    private static void WriteOptionalString(
        Utf8JsonWriter writer,
        string name,
        string? value,
        bool nonEmpty = false)
    {
        if (value is not null)
        {
            writer.WriteString(name, ValidateString(value, name, nonEmpty));
        }
    }

    private static void ValidateJsonTree(JsonElement root, bool outbound = false)
    {
        try
        {
            ValidateJsonTreeCore(root, outbound);
        }
        catch (InvalidOperationException exception)
        {
            if (outbound)
            {
                throw new ArgumentException("Voice JSON contains invalid Unicode.", exception);
            }
            throw new VoiceProtocolException(
                "Voice frame contains invalid Unicode.",
                innerException: exception);
        }
    }

    private static void ValidateJsonTreeCore(JsonElement root, bool outbound)
    {
        var pending = new Stack<JsonElement>();
        pending.Push(root);
        while (pending.Count > 0)
        {
            var value = pending.Pop();

            switch (value.ValueKind)
            {
                case JsonValueKind.Object:
                    var names = new HashSet<string>(StringComparer.Ordinal);
                    foreach (var property in value.EnumerateObject())
                    {
                        ValidateUnicode(property.Name, "JSON object key", outbound);
                        if (!names.Add(property.Name))
                        {
                            ThrowJsonValidation("Voice frame contains a duplicate JSON object key.", outbound);
                        }
                        pending.Push(property.Value);
                    }
                    break;
                case JsonValueKind.Array:
                    foreach (var item in value.EnumerateArray())
                    {
                        pending.Push(item);
                    }
                    break;
                case JsonValueKind.String:
                    ValidateUnicode(value.GetString()!, "JSON string", outbound);
                    break;
            }
        }
    }

    private static void ThrowJsonValidation(string message, bool outbound)
    {
        if (outbound)
        {
            throw new ArgumentException(message);
        }
        throw new VoiceProtocolException(message);
    }

    private static void ValidateUnicode(string value, string name, bool outbound)
    {
        try
        {
            _ = new UTF8Encoding(false, true).GetByteCount(value);
        }
        catch (EncoderFallbackException exception)
        {
            if (outbound)
            {
                throw new ArgumentException($"{name} contains invalid Unicode.", exception);
            }
            throw new VoiceProtocolException($"{name} contains invalid Unicode.", innerException: exception);
        }
    }

    private static void RejectCredentialFields(JsonElement caller)
    {
        var pending = new Stack<JsonElement>();
        pending.Push(caller);
        while (pending.Count > 0)
        {
            var current = pending.Pop();
            if (current.ValueKind == JsonValueKind.Object)
            {
                foreach (var property in current.EnumerateObject())
                {
                    var normalized = NormalizeFieldName(property.Name);
                    var collapsed = normalized.Replace("_", string.Empty, StringComparison.Ordinal);
                    if (CredentialFieldExpression().IsMatch(normalized) ||
                        CollapsedCredentialFields.Contains(collapsed))
                    {
                        throw new VoiceProtocolException("session.start caller must not contain credentials.");
                    }
                    pending.Push(property.Value);
                }
            }
            else if (current.ValueKind == JsonValueKind.Array)
            {
                foreach (var item in current.EnumerateArray())
                {
                    pending.Push(item);
                }
            }
        }
    }

    private static string NormalizeFieldName(string value)
    {
        var builder = new StringBuilder(value.Length);
        foreach (var character in value)
        {
            if (char.IsUpper(character) && builder.Length > 0 && char.IsLetterOrDigit(builder[^1]))
            {
                builder.Append('_');
            }
            builder.Append(char.IsLetterOrDigit(character) ? char.ToLowerInvariant(character) : '_');
        }
        return builder.ToString().Trim('_');
    }

    private static readonly HashSet<string> CollapsedCredentialFields = new(StringComparer.Ordinal)
    {
        "authorization",
        "authorizationheader",
        "credential",
        "credentials",
        "password",
        "passwd",
        "pwd",
        "secret",
        "secretvalue",
        "apikey",
        "apitoken",
        "authtoken",
        "bearertoken",
        "accesskey",
        "accesstoken",
        "refreshtoken",
        "idtoken",
        "clientassertion",
        "clientsecret",
        "privatekey",
        "connectionstring",
        "sastoken",
        "sasurl",
        "accountkey",
        "subscriptionkey",
        "sharedaccesskey",
        "sharedaccesssignature",
    };

    private static JsonElement RequiredObject(JsonElement value, string name)
    {
        if (!value.TryGetProperty(name, out var property) || property.ValueKind != JsonValueKind.Object)
        {
            throw new VoiceProtocolException($"{name} must be an object.");
        }
        return property;
    }

    private static string RequiredString(JsonElement value, string name, bool nonEmpty = false)
    {
        if (!value.TryGetProperty(name, out var property))
        {
            throw new VoiceProtocolException($"{name} is required.");
        }
        return ElementString(property, name, nonEmpty);
    }

    private static string ElementString(JsonElement value, string name, bool nonEmpty = false)
    {
        if (value.ValueKind != JsonValueKind.String)
        {
            throw new VoiceProtocolException($"{name} must be a string.");
        }
        var text = value.GetString()!;
        if (nonEmpty && text.Length == 0)
        {
            throw new VoiceProtocolException($"{name} must be non-empty.");
        }
        return text;
    }

    private static bool RequiredBoolean(JsonElement value, string name)
    {
        if (!value.TryGetProperty(name, out var property) ||
            property.ValueKind is not (JsonValueKind.True or JsonValueKind.False))
        {
            throw new VoiceProtocolException($"{name} must be a boolean.");
        }
        return property.GetBoolean();
    }

    private static int PositiveInteger(JsonElement value, string name)
    {
        if (!value.TryGetProperty(name, out var property) ||
            !property.TryGetInt32(out var number) ||
            number <= 0)
        {
            throw new VoiceProtocolException($"{name} must be a positive integer.");
        }
        return number;
    }

    private static string Identifier(JsonElement value, string name) =>
        ValidateInboundIdentifier(RequiredString(value, name, nonEmpty: true), name);

    private static string PrefixedIdentifier(JsonElement value, string name, string prefix) =>
        ValidateInboundPrefixedIdentifier(Identifier(value, name), name, prefix);

    private static string? OptionalPrefixedIdentifier(JsonElement value, string name, string prefix) =>
        value.TryGetProperty(name, out _) ? PrefixedIdentifier(value, name, prefix) : null;

    private static string ValidateInboundIdentifier(string value, string name)
        => value;

    private static string ValidateInboundPrefixedIdentifier(string value, string name, string prefix)
    {
        if (!value.StartsWith(prefix, StringComparison.Ordinal) || value.Length == prefix.Length)
        {
            throw new VoiceProtocolException($"{name} must start with {prefix}.");
        }
        return value;
    }

    private static DateTimeOffset Timestamp(JsonElement value, string name)
    {
        var text = RequiredString(value, name, nonEmpty: true);
        var parseText = NormalizeTimestampPrecision(text);
        if (!Rfc3339Expression().IsMatch(text) ||
            !DateTimeOffset.TryParse(
                parseText,
                CultureInfo.InvariantCulture,
                DateTimeStyles.AssumeUniversal | DateTimeStyles.AllowWhiteSpaces,
                out var timestamp))
        {
            throw new VoiceProtocolException("ts must match the RFC 3339 profile.");
        }
        return timestamp;
    }

    private static string NormalizeTimestampPrecision(string value)
    {
        var decimalIndex = value.IndexOf('.', StringComparison.Ordinal);
        if (decimalIndex < 0)
        {
            return value;
        }

        var zoneIndex = value.IndexOfAny(['Z', '+', '-'], decimalIndex + 1);
        var fractionLength = zoneIndex - decimalIndex - 1;
        return fractionLength <= 7
            ? value
            : value.Remove(decimalIndex + 8, fractionLength - 7);
    }

    private static string ValidateString(string? value, string name, bool nonEmpty = false)
    {
        ArgumentNullException.ThrowIfNull(value, name);
        ValidateUnicode(value, name, outbound: true);
        if (nonEmpty && value.Length == 0)
        {
            throw new ArgumentException($"{name} must be non-empty.", name);
        }
        return value;
    }

    private static string ValidateIdentifier(string? value, string name)
        => ValidateString(value, name, nonEmpty: true);

    private static string ValidatePrefixedIdentifier(string? value, string name, string prefix)
    {
        var identifier = ValidateIdentifier(value, name);
        if (!identifier.StartsWith(prefix, StringComparison.Ordinal) || identifier.Length == prefix.Length)
        {
            throw new ArgumentException($"{name} must start with {prefix}.", name);
        }
        return identifier;
    }

    [GeneratedRegex(
        "(?:^|_)(?:authorization(?:_header)?|credentials?|password|passwd|pwd|secret(?:_value)?|api_(?:key|token)|auth_token|bearer_token|access_(?:key|token)|refresh_token|id_token|client_(?:assertion|secret)|private_key|connection_string|sas(?:_token|_url)?|account_key|subscription_key|shared_access_(?:key|signature))(?:_|$)",
        RegexOptions.CultureInvariant)]
    private static partial Regex CredentialFieldExpression();

    [GeneratedRegex(
        "^[0-9]{4}-[0-9]{2}-[0-9]{2}T(?:[01][0-9]|2[0-3]):[0-5][0-9]:[0-5][0-9](?:\\.[0-9]+)?(?:Z|[+-](?:[01][0-9]|2[0-3]):[0-5][0-9])$",
        RegexOptions.CultureInvariant)]
    private static partial Regex Rfc3339Expression();

    private sealed class LimitedWriteStream : Stream
    {
        private readonly ArrayBufferWriter<byte> _buffer = new();
        private readonly int _maximum;

        internal LimitedWriteStream(int maximum) => _maximum = maximum;

        internal ReadOnlyMemory<byte> WrittenMemory => _buffer.WrittenMemory;

        public override bool CanRead => false;

        public override bool CanSeek => false;

        public override bool CanWrite => true;

        public override long Length => _buffer.WrittenCount;

        public override long Position
        {
            get => _buffer.WrittenCount;
            set => throw new NotSupportedException();
        }

        public override void Flush()
        {
        }

        public override int Read(byte[] buffer, int offset, int count) => throw new NotSupportedException();

        public override long Seek(long offset, SeekOrigin origin) => throw new NotSupportedException();

        public override void SetLength(long value) => throw new NotSupportedException();

        public override void Write(byte[] buffer, int offset, int count) =>
            Write(buffer.AsSpan(offset, count));

        public override void Write(ReadOnlySpan<byte> buffer)
        {
            if (_buffer.WrittenCount > _maximum - buffer.Length)
            {
                throw new FrameLimitExceededException();
            }
            var destination = _buffer.GetSpan(buffer.Length);
            buffer.CopyTo(destination);
            _buffer.Advance(buffer.Length);
        }

        public override ValueTask WriteAsync(
            ReadOnlyMemory<byte> buffer,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            Write(buffer.Span);
            return ValueTask.CompletedTask;
        }
    }

    private sealed class FrameLimitExceededException : Exception;
}
