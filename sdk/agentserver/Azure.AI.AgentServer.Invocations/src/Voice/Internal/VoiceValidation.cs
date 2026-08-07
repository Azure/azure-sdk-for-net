// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using System.Text.RegularExpressions;

namespace Azure.AI.AgentServer.Invocations.Voice.Internal;

internal static partial class VoiceValidation
{
    private const int MaxErrorMessageLength = 1024;
    private static readonly HashSet<string> SupportedVoiceFields = new(StringComparer.Ordinal)
    {
        "type",
        "name",
        "endpoint_id",
        "model",
        "temperature",
        "locale",
        "style",
        "pitch",
        "rate",
        "volume",
        "custom_lexicon_url",
        "custom_text_normalization_url",
        "prefer_locales",
        "multi_talker_speaker_name",
    };

    private static readonly HashSet<string> RequiredStringVoiceFields = new(StringComparer.Ordinal)
    {
        "name",
        "endpoint_id",
        "model",
    };

    private static readonly HashSet<string> NullableStringVoiceFields = new(StringComparer.Ordinal)
    {
        "locale",
        "style",
        "pitch",
        "rate",
        "volume",
        "custom_lexicon_url",
        "custom_text_normalization_url",
        "multi_talker_speaker_name",
    };

    private static readonly IReadOnlyDictionary<string, HashSet<string>> VoiceVariantFields =
        new Dictionary<string, HashSet<string>>(StringComparer.Ordinal)
        {
            ["openai"] = new(StringComparer.Ordinal) { "type", "name" },
            ["azure-realtime-native"] = new(StringComparer.Ordinal) { "type", "name" },
            ["azure-standard"] = AzureFields("type", "name", "multi_talker_speaker_name"),
            ["azure-custom"] = AzureFields("type", "name", "endpoint_id"),
            ["azure-personal"] = AzureFields("type", "name", "model"),
            ["avatar-voice-sync"] = AzureFields("type", "model"),
        };

    public static string SafeCode(string? value, string fallback) =>
        value is not null && SafeCodeExpression().IsMatch(value) ? value : fallback;

    public static string SafeMessage(string? value, string fallback)
    {
        if (value is null)
        {
            return fallback;
        }

        return value.Length <= MaxErrorMessageLength
            ? value
            : value[..MaxErrorMessageLength];
    }

    public static bool IsDtmfKey(char value) =>
        (value >= '0' && value <= '9') || value is '*' or '#';

    public static IReadOnlyDictionary<string, object?>? NormalizeVoice(
        IReadOnlyDictionary<string, object?>? voice)
    {
        if (voice is null)
        {
            return null;
        }

        if (voice.Count == 0)
        {
            throw new ArgumentException("The voice merge patch must be non-empty.", nameof(voice));
        }

        var normalized = new Dictionary<string, object?>(StringComparer.Ordinal);
        foreach (var field in voice)
        {
            if (SupportedVoiceFields.Contains(field.Key))
            {
                normalized[field.Key] = NormalizeJsonElement(field.Value);
            }
        }

        if (normalized.Count == 0)
        {
            throw new ArgumentException("The voice merge patch must contain a supported field.", nameof(voice));
        }

        string? voiceType = null;
        if (normalized.TryGetValue("type", out var typeValue))
        {
            voiceType = typeValue as string
                ?? throw new ArgumentException("voice.type must be a string.", nameof(voice));
            voiceType = voiceType switch
            {
                "azure-platform" => "azure-standard",
                "custom" => "azure-custom",
                _ => voiceType,
            };
            if (!VoiceVariantFields.ContainsKey(voiceType))
            {
                throw new ArgumentException("voice.type is not a supported Voice Live variant.", nameof(voice));
            }

            normalized["type"] = voiceType;
        }

        foreach (var fieldName in RequiredStringVoiceFields)
        {
            if (normalized.TryGetValue(fieldName, out var fieldValue) &&
                (fieldValue is not string text || text.Length == 0))
            {
                throw new ArgumentException($"voice.{fieldName} must be a non-empty string.", nameof(voice));
            }
        }

        foreach (var fieldName in NullableStringVoiceFields)
        {
            if (normalized.TryGetValue(fieldName, out var fieldValue) &&
                fieldValue is not null &&
                (fieldValue is not string text || text.Length == 0))
            {
                throw new ArgumentException($"voice.{fieldName} must be a non-empty string or null.", nameof(voice));
            }
        }

        if (normalized.TryGetValue("temperature", out var temperature) && temperature is not null)
        {
            var numericTemperature = temperature switch
            {
                byte value => value,
                sbyte value => value,
                short value => value,
                ushort value => value,
                int value => value,
                uint value => value,
                long value => value,
                ulong value => value,
                float value => value,
                double value => value,
                decimal value => (double)value,
                _ => throw new ArgumentException("voice.temperature must be a number or null.", nameof(voice)),
            };

            if (!double.IsFinite(numericTemperature) || numericTemperature is < 0 or > 1)
            {
                throw new ArgumentOutOfRangeException(nameof(voice), "voice.temperature must be between 0.0 and 1.0.");
            }

            // Write back one canonical CLR number so every accepted input
            // serializes as a JSON number.
            normalized["temperature"] = numericTemperature;
        }

        if (normalized.TryGetValue("prefer_locales", out var locales) && locales is not null)
        {
            if (locales is string || locales is not System.Collections.IEnumerable localeValues)
            {
                throw new ArgumentException("voice.prefer_locales must contain non-empty strings or be null.", nameof(voice));
            }

            var materializedLocales = new List<string>();
            foreach (var value in localeValues)
            {
                if (value is not string locale || locale.Length == 0)
                {
                    throw new ArgumentException("voice.prefer_locales must contain non-empty strings or be null.", nameof(voice));
                }

                materializedLocales.Add(locale);
            }

            normalized["prefer_locales"] = materializedLocales.ToArray();
        }

        if (voiceType is not null)
        {
            foreach (var fieldName in normalized.Keys)
            {
                if (!VoiceVariantFields[voiceType].Contains(fieldName))
                {
                    throw new ArgumentException($"voice.{fieldName} is not valid for {voiceType}.", nameof(voice));
                }
            }
        }

        try
        {
            VoiceSendTransaction.ValidateJsonValue(normalized);
        }
        catch (Exception exception) when (exception is JsonException or NotSupportedException)
        {
            throw new ArgumentException("The voice merge patch must contain JSON-compatible values.", nameof(voice), exception);
        }

        return normalized;
    }

    private static object? NormalizeJsonElement(object? value)
    {
        if (value is not JsonElement element)
        {
            return value;
        }

        return element.ValueKind switch
        {
            JsonValueKind.String => element.GetString(),
            JsonValueKind.Number when element.TryGetInt64(out var integer) => integer,
            JsonValueKind.Number when element.TryGetDecimal(out var decimalValue) => decimalValue,
            JsonValueKind.Number => element.GetDouble(),
            JsonValueKind.True => true,
            JsonValueKind.False => false,
            JsonValueKind.Null => null,
            JsonValueKind.Array => element.EnumerateArray()
                .Select(item => NormalizeJsonElement(item))
                .ToArray(),
            _ => element.Clone(),
        };
    }

    private static HashSet<string> AzureFields(params string[] required)
    {
        var fields = new HashSet<string>(required, StringComparer.Ordinal)
        {
            "temperature",
            "custom_lexicon_url",
            "custom_text_normalization_url",
            "prefer_locales",
            "locale",
            "style",
            "pitch",
            "rate",
            "volume",
        };
        return fields;
    }

    [GeneratedRegex("^[A-Za-z0-9._-]{1,64}$", RegexOptions.CultureInvariant)]
    private static partial Regex SafeCodeExpression();
}
