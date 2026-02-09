// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.AI.OpenAI.Internal;

#pragma warning disable AOAI001
internal static class AdditionalPropertyHelpers
{
    private static T GetAdditionalProperty<T>(IDictionary<string, BinaryData> additionalProperties, string additionalPropertyKey, Func<JsonElement, ModelReaderWriterOptions, T> deserializeFunction) where T : class, IJsonModel<T>
    {
        if (additionalProperties?.TryGetValue(additionalPropertyKey, out BinaryData additionalPropertyValue) != true)
        {
            return null;
        }

        using JsonDocument document = JsonDocument.Parse(additionalPropertyValue);
        return deserializeFunction(document.RootElement, ModelSerializationExtensions.WireOptions);
    }

    internal static RequestImageContentFilterResult GetAdditionalPropertyAsRequestImageContentFilterResult(IDictionary<string, BinaryData> additionalProperties, string additionalPropertyKey)
    {
        return GetAdditionalProperty(additionalProperties, additionalPropertyKey, RequestImageContentFilterResult.DeserializeRequestImageContentFilterResult);
    }

    internal static ResponseImageContentFilterResult GetAdditionalPropertyAsResponseImageContentFilterResult(IDictionary<string, BinaryData> additionalProperties, string additionalPropertyKey)
    {
        return GetAdditionalProperty(additionalProperties, additionalPropertyKey, ResponseImageContentFilterResult.DeserializeResponseImageContentFilterResult);
    }
}
#pragma warning restore AOAI001
