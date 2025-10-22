// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using System.Collections;
using System.Text.Encodings.Web;
using System.Text.Json;

namespace System.ClientModel.Primitives;

internal class JsonCollectionWriter : CollectionWriter
{
    internal override BinaryData Write(IEnumerable enumerable, ModelReaderWriterOptions options)
    {
        using UnsafeBufferSequence sequenceWriter = new();
        using Utf8JsonWriter writer = new(sequenceWriter, new JsonWriterOptions { Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping });
        WriteEnumerable(enumerable, writer, options);
        writer.Flush();
        return sequenceWriter.ExtractReader().ToBinaryData();
    }

    private static void WriteJson(object model, Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        if (model is null)
        {
            writer.WriteNullValue();
        }
        else if (model is IJsonModel<object> jsonModel)
        {
            jsonModel.Write(writer, options);
        }
        else if (model is IEnumerable enumerable)
        {
            WriteEnumerable(enumerable, writer, options);
        }
        else
        {
            throw new InvalidOperationException($"{model.GetType().ToFriendlyName()} does not implement IJsonModel or IEnumerable<IJsonModel>");
        }
    }

    private static void WriteEnumerable(IEnumerable enumerable, Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        var enumerableType = enumerable.GetType();

        if (enumerableType.IsArray &&
            enumerableType.GetArrayRank() > 1 &&
            enumerableType.GetElementType()?.IsArray == false) //multi-dimensional array
        {
            Array array = (Array)enumerable;
            WriteMultiDimensionalArray(array, new int[array.Rank], 0, options, writer);
        }
        else
        {
            if (enumerable is IDictionary dictionary)
            {
                writer.WriteStartObject();
                foreach (var key in dictionary.Keys)
                {
                    writer.WritePropertyName(key.ToString()!);
                    WriteJson(dictionary[key]!, writer, options);
                }
                writer.WriteEndObject();
            }
            else
            {
                writer.WriteStartArray();
                foreach (var item in enumerable)
                {
                    WriteJson(item, writer, options);
                }
                writer.WriteEndArray();
            }
        }
    }

    private static void WriteMultiDimensionalArray(Array array, int[] indices, int currentDimension, ModelReaderWriterOptions options, Utf8JsonWriter writer)
    {
        // If we've reached the innermost dimension, print the value at the collected indices
        if (currentDimension == array.Rank)
        {
            WriteJson(array.GetValue(indices)!, writer, options);
            return;
        }

        writer.WriteStartArray();
        // Recursively iterate through each level
        for (int i = 0; i < array.GetLength(currentDimension); i++)
        {
            indices[currentDimension] = i;
            WriteMultiDimensionalArray(array, indices, currentDimension + 1, options, writer);
        }
        writer.WriteEndArray();
    }
}
