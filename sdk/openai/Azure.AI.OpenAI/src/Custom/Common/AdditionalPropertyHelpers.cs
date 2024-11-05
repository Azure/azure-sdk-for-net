// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.AI.OpenAI.Internal;

internal static class AdditionalPropertyHelpers
{
    private static string SARD_EMPTY_SENTINEL = "__EMPTY__";

    internal static T GetAdditionalProperty<T>(IDictionary<string, BinaryData> additionalProperties, string key)
        where T : class, IJsonModel<T>
    {
        if (additionalProperties?.TryGetValue(key, out BinaryData binaryProperty) != true)
        {
            return null;
        }
        return (T)ModelReaderWriter.Read(binaryProperty, typeof(T));
    }

    internal static IList<T> GetAdditionalListProperty<T>(IDictionary<string, BinaryData> additionalProperties, string key)
        where T : class, IJsonModel<T>
    {
        if (additionalProperties?.TryGetValue(key, out BinaryData binaryProperty) != true)
        {
            return null;
        }
        List<T> items = [];
        using JsonDocument document = JsonDocument.Parse(binaryProperty);
        foreach (JsonElement element in document.RootElement.EnumerateArray())
        {
            items.Add((T)ModelReaderWriter.Read(BinaryData.FromObjectAsJson(element), typeof(T)));
        }
        return items;
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
        additionalProperties[key] = BinaryData.FromObjectAsJson(SARD_EMPTY_SENTINEL);
    }

    internal static bool GetIsEmptySentinelValue(IDictionary<string, BinaryData> additionalProperties, string key)
    {
        return additionalProperties is not null
            && additionalProperties.TryGetValue(key, out BinaryData existingValue)
            && StringComparer.OrdinalIgnoreCase.Equals(existingValue.ToString(), $@"""{SARD_EMPTY_SENTINEL}""");
    }
}