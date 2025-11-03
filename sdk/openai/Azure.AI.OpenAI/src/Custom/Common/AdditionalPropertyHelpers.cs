// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using Azure.AI.OpenAI.Chat;

namespace Azure.AI.OpenAI.Internal;

#pragma warning disable AOAI001
#pragma warning disable SCME0001

internal static class AdditionalPropertyHelpers
{
    private static string SARD_EMPTY_SENTINEL = "__EMPTY__";

    private static T GetAdditionalProperty<T>(IDictionary<string, BinaryData> additionalProperties, string additionalPropertyKey, Func<JsonElement, ModelReaderWriterOptions, T> deserializeFunction) where T : class, IJsonModel<T>
    {
        if (additionalProperties?.TryGetValue(additionalPropertyKey, out BinaryData additionalPropertyValue) != true)
        {
            return null;
        }

        using JsonDocument document = JsonDocument.Parse(additionalPropertyValue);
        return deserializeFunction(document.RootElement, ModelSerializationExtensions.WireOptions);
    }

    private static IList<T> GetAdditionalPropertyAsList<T>(IDictionary<string, BinaryData> additionalProperties, string additionalPropertyKey, Func<JsonElement, ModelReaderWriterOptions, T> deserializeFunction) where T : class, IJsonModel<T>
    {
        if (additionalProperties?.TryGetValue(additionalPropertyKey, out BinaryData additionalPropertyValue) != true)
        {
            return null;
        }

        List<T> items = [];
        using JsonDocument document = JsonDocument.Parse(additionalPropertyValue);

        foreach (JsonElement element in document.RootElement.EnumerateArray())
        {
            items.Add(deserializeFunction(element, ModelSerializationExtensions.WireOptions));
        }

        return items;
    }

    internal static ResponseContentFilterResult GetAdditionalPropertyAsResponseContentFilterResult(IDictionary<string, BinaryData> additionalProperties, string additionalPropertyKey)
    {
        return GetAdditionalProperty(additionalProperties, additionalPropertyKey, ResponseContentFilterResult.DeserializeResponseContentFilterResult);
    }

    internal static ChatMessageContext GetAdditionalPropertyAsChatMessageContext(IDictionary<string, BinaryData> additionalProperties, string additionalPropertyKey)
    {
        return GetAdditionalProperty(additionalProperties, additionalPropertyKey, ChatMessageContext.DeserializeChatMessageContext);
    }

    internal static RequestImageContentFilterResult GetAdditionalPropertyAsRequestImageContentFilterResult(IDictionary<string, BinaryData> additionalProperties, string additionalPropertyKey)
    {
        return GetAdditionalProperty(additionalProperties, additionalPropertyKey, RequestImageContentFilterResult.DeserializeRequestImageContentFilterResult);
    }

    internal static ResponseImageContentFilterResult GetAdditionalPropertyAsResponseImageContentFilterResult(IDictionary<string, BinaryData> additionalProperties, string additionalPropertyKey)
    {
        return GetAdditionalProperty(additionalProperties, additionalPropertyKey, ResponseImageContentFilterResult.DeserializeResponseImageContentFilterResult);
    }

    internal static IList<ChatDataSource> GetAdditionalPropertyAsListOfChatDataSource(IDictionary<string, BinaryData> additionalProperties, string additionalPropertyKey)
    {
        return GetAdditionalPropertyAsList(additionalProperties, additionalPropertyKey, ChatDataSource.DeserializeChatDataSource);
    }

    internal static IList<RequestContentFilterResult> GetAdditionalPropertyAsListOfRequestContentFilterResult(IDictionary<string, BinaryData> additionalProperties, string additionalPropertyKey)
    {
        return GetAdditionalPropertyAsList(additionalProperties, additionalPropertyKey, RequestContentFilterResult.DeserializeRequestContentFilterResult);
    }

    internal static UserSecurityContext GetAdditionalPropertyAsUserSecurityContext(IDictionary<string, BinaryData> additionalProperties, string additionalPropertyKey)
    {
        return GetAdditionalProperty(additionalProperties, additionalPropertyKey, UserSecurityContext.DeserializeUserSecurityContext);
    }

    internal static void SetAdditionalProperty<T>(IDictionary<string, BinaryData> additionalProperties, string key, T value)
    {
        using MemoryStream stream = new();
        using (Utf8JsonWriter writer = new(stream))
        {
            writer.WriteObjectValue(value);
        }
        stream.Position = 0;
        BinaryData binaryValue = BinaryData.FromStream(stream);
        additionalProperties[key] = binaryValue;
    }

    internal static void SetEmptySentinelValue(IDictionary<string, BinaryData> additionalProperties, string key)
    {
        Argument.AssertNotNull(additionalProperties, nameof(additionalProperties));

        using MemoryStream stream = new();
        using Utf8JsonWriter writer = new(stream);

        writer.WriteStringValue(SARD_EMPTY_SENTINEL);
        writer.Flush();

        additionalProperties[key] = BinaryData.FromBytes(stream.ToArray());
    }

    internal static void SetEmptySentinelValue(ref JsonPatch patch, ReadOnlySpan<byte> path)
    {
        patch.Set(path, SARD_EMPTY_SENTINEL);
    }

    internal static bool GetIsEmptySentinelValue(JsonPatch patch, ReadOnlySpan<byte> path)
    {
        if (patch.Contains(path) && patch.TryGetValue(path, out string val))
        {
            return string.Equals(val, SARD_EMPTY_SENTINEL);
        }
        return false;
    }

    internal static bool GetIsEmptySentinelValue(IDictionary<string, BinaryData> additionalProperties, string key)
    {
        return additionalProperties is not null
            && additionalProperties.TryGetValue(key, out BinaryData existingValue)
            && StringComparer.OrdinalIgnoreCase.Equals(existingValue.ToString(), $@"""{SARD_EMPTY_SENTINEL}""");
    }
}
#pragma warning restore AOAI001
