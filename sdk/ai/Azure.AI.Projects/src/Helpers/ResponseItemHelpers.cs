// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.AI.Projects.OpenAI;
using OpenAI.Responses;
using OpenAI;
using System.Runtime.CompilerServices;

namespace Azure.AI.Projects;

#pragma warning disable SCME0001

internal static partial class ResponseItemHelpers
{
    internal static void DeserializeItemsValue(JsonProperty property, ref IList<AgentResponseItem> items)
    {
        if (property.Value.ValueKind == JsonValueKind.Array)
        {
            List<AgentResponseItem> deserializedItems = [];
            foreach (JsonElement serializedResponseItemElement in property.Value.EnumerateArray())
            {
                AgentResponseItem deserializedItem
                    = CustomSerializationHelpers.DeserializeProjectOpenAIType<AgentResponseItem>(
                        serializedResponseItemElement,
                        ModelSerializationExtensions.WireOptions);
                deserializedItems.Add(deserializedItem);
            }
            items = deserializedItems;
        }
    }

    internal static ChangeTrackingList<ResponseItem> GetPublicItemsFromInternalParams(IList<InternalItemParam> internalItems)
    {
        ChangeTrackingList<ResponseItem> result = new();
        foreach (InternalItemParam internalItem in internalItems ?? [])
        {
            BinaryData serializedInternalItem = ModelReaderWriter.Write(internalItem, ModelSerializationExtensions.WireOptions, AzureAIProjectsContext.Default);
            ResponseItem deserializedItem = ModelReaderWriter.Read<ResponseItem>(serializedInternalItem, ModelSerializationExtensions.WireOptions, OpenAIContext.Default);
            result.Add(deserializedItem);
        }
        return result;
    }

    private static Dictionary<Type, ModelReaderWriterContext> s_contextMap;

    internal static ChangeTrackingList<T> ConvertItemsTo<T, U>(IEnumerable<U> sourceItems)
    {
        s_contextMap ??= new()
        {
            [typeof(ResponseItem)] = OpenAIContext.Default,
            [typeof(InternalItemParam)] = AzureAIProjectsContext.Default,
        };
        if (!s_contextMap.ContainsKey(typeof(T)) || !s_contextMap.ContainsKey(typeof(U)))
        {
            throw new NotImplementedException();
        }

        ChangeTrackingList<T> values = new();

        foreach (U sourceItem in sourceItems ??= [])
        {
            BinaryData serializedItem = ModelReaderWriter.Write(sourceItem, ModelSerializationExtensions.WireOptions, s_contextMap[typeof(U)]);
            T deserializedTargetItem = ModelReaderWriter.Read<T>(serializedItem, ModelSerializationExtensions.WireOptions, s_contextMap[typeof(T)]);
            values.Add(deserializedTargetItem);
        }

        return values;
    }
}
