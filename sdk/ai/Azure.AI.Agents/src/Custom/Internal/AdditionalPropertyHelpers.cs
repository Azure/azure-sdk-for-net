// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Reflection;

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
        BinaryData writtenBinaryData = value switch
        {
            BinaryData binaryDataObject => binaryDataObject,
            string stringObject => BinaryData.FromString(stringObject),
            _ => ModelReaderWriter.Write(value, ModelSerializationExtensions.WireOptions, AzureAIAgentsContext.Default),
        };
        additionalData[key] = writtenBinaryData;
        additionalDataProperty.SetValue(instance, additionalData);
    }

    internal static U GetAdditionalProperty<T, U>(this T instance, string key)
    {
        PropertyInfo additionalDataProperty = instance.GetType().GetProperty("SerializedAdditionalRawData", BindingFlags.Instance | BindingFlags.NonPublic);
        object existingSerializedAdditionalRawData = additionalDataProperty.GetValue(instance);

        IDictionary<string, BinaryData> additionalData = (IDictionary<string, BinaryData>)existingSerializedAdditionalRawData;
        if (additionalData?.TryGetValue(key, out BinaryData valueBytes) != true)
        {
            return default(U);
        }

        if (typeof(U)  == typeof(string))
        {
            return (U)(object)valueBytes.ToString();
        }
        else
        {
            throw new NotImplementedException();
        }
    }
}
