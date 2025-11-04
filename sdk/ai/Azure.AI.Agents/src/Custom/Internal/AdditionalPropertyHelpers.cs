// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Reflection;
using System.Text.Json.Nodes;

#pragma warning disable OPENAI001

namespace Azure.AI.Agents;

internal static partial class AdditionalPropertyHelpers
{
    internal static void SetAdditionalProperty<T, U>(this T instance, string key, U value)
        where T : IJsonModel<T>
    {
        PropertyInfo additionalDataProperty = instance.GetType().GetProperty("SerializedAdditionalRawData", BindingFlags.Instance | BindingFlags.NonPublic);
        object existingSerializedAdditionalRawData = additionalDataProperty.GetValue(instance);

        IDictionary<string, BinaryData> additionalData = (IDictionary<string, BinaryData>)existingSerializedAdditionalRawData ?? new Dictionary<string, BinaryData>();
        additionalData[key] = GetBinaryData(value);
        additionalDataProperty.SetValue(instance, additionalData);
    }

    internal static bool TryGetAdditionalProperty<T, U>(this T instance, string key, out U value)
        where T : IJsonModel<T>
    {
        PropertyInfo additionalDataProperty = instance.GetType().GetProperty("SerializedAdditionalRawData", BindingFlags.Instance | BindingFlags.NonPublic);
        object existingSerializedAdditionalRawData = additionalDataProperty.GetValue(instance);

        if (instance.GetAdditionalProperty(key) is BinaryData valueBytes)
        {
            if (typeof(U) == typeof(string))
            {
                value = (U)(object)valueBytes.ToString();
                return true;
            }
            else if (typeof(U) == typeof(IDictionary<string, BinaryData>)
                && JsonNode.Parse(valueBytes.ToString()) is JsonObject dictionaryValueObject)
            {
                IDictionary<string, BinaryData> valueDictionary = new ChangeTrackingDictionary<string, BinaryData>();
                foreach (KeyValuePair<string, JsonNode> dictionaryPair in dictionaryValueObject)
                {
                    valueDictionary.Add(dictionaryPair.Key, BinaryData.FromString(dictionaryPair.Value.ToString()));
                }
                value = (U)(object)valueDictionary;
                return true;
            }
        }
        value = default;
        return false;
    }

    private static BinaryData GetBinaryData<T>(T input)
    {
        if (input is BinaryData passthroughBinaryData)
        {
            return passthroughBinaryData;
        }
        else if (input is string stringData)
        {
            return BinaryData.FromString(stringData);
        }
        else if (input is IPersistableModel<T>)
        {
            return ModelReaderWriter.Write(input, ModelSerializationExtensions.WireOptions, AzureAIAgentsContext.Default);
        }
        else if (input is IDictionary<string, BinaryData> binaryDataDictionary)
        {
            JsonObject dictionaryObject = new();
            foreach (KeyValuePair<string, BinaryData> dictionaryPair in binaryDataDictionary)
            {
                dictionaryObject[dictionaryPair.Key] = JsonNode.Parse(dictionaryPair.Value.ToString());
            }
            return BinaryData.FromString(dictionaryObject.ToString());
        }
        return null;
    }

    private static IDictionary<string, BinaryData> GetAdditionalProperties<T>(this T instance)
        where T : IJsonModel<T>
    {
        PropertyInfo additionalDataProperty = instance
            .GetType()
            .GetProperty(
                "SerializedAdditionalRawData",
                BindingFlags.Instance | BindingFlags.NonPublic);
        return additionalDataProperty.GetValue(instance) as IDictionary<string, BinaryData>;
    }

    private static BinaryData GetAdditionalProperty<T>(this T instance, string key)
        where T : IJsonModel<T>
    {
        if (instance.GetAdditionalProperties()?.TryGetValue(key, out BinaryData value) == true)
        {
            return value;
        }
        return null;
    }
}
