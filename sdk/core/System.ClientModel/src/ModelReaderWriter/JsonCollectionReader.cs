// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using System.Collections;
using System.Diagnostics;
using System.Text.Json;

namespace System.ClientModel.Primitives;

internal class JsonCollectionReader : CollectionReader
{
    internal override object Read(
        ModelReaderWriterTypeBuilder.CollectionWrapper collectionWrapper,
        BinaryData data,
        ModelReaderWriterTypeBuilder builder,
        ModelReaderWriterContext context,
        ModelReaderWriterOptions options)
    {
        Utf8JsonReader reader = new(data);
        reader.Read();
        if (collectionWrapper.Builder is IDictionary)
        {
            if (reader.TokenType != JsonTokenType.StartObject)
            {
                throw new FormatException("Expected start of dictionary.");
            }
        }
        else if (reader.TokenType != JsonTokenType.StartArray)
        {
            throw new FormatException("Expected start of array.");
        }
        ReadJsonCollection(ref reader, collectionWrapper, builder, options, context);
        return collectionWrapper.ToCollection();
    }

    private static void ReadJsonCollection(
        ref Utf8JsonReader reader,
        ModelReaderWriterTypeBuilder.CollectionWrapper collectionWrapper,
        ModelReaderWriterTypeBuilder builder,
        ModelReaderWriterOptions options,
        ModelReaderWriterContext context)
    {
        object collection = collectionWrapper.Builder;

        Debug.Assert(builder.GetItemType() is not null);

        bool isElementDictionary = false;
        IJsonModel<object>? jsonModel = null;
        string? propertyName = null;

        var itemBuilder = context.GetTypeBuilder(builder.GetItemType()!);
        var itemInstance = itemBuilder.CreateObject();
        if (itemInstance is ModelReaderWriterTypeBuilder.CollectionWrapper itemCollectionWrapper)
        {
            isElementDictionary = itemCollectionWrapper.Builder is IDictionary;
        }
        else if (itemInstance is IJsonModel<object> iJsonModel)
        {
            jsonModel = iJsonModel;
        }
        else
        {
            throw new InvalidOperationException($"Item type '{builder.GetItemType()?.ToFriendlyName()}' must implement IJsonModel");
        }

        while (reader.Read())
        {
            switch (reader.TokenType)
            {
                case JsonTokenType.StartObject:
                    if (isElementDictionary)
                    {
                        var dictionaryWrapper = itemBuilder.CreateObject() as ModelReaderWriterTypeBuilder.CollectionWrapper;
                        Debug.Assert(dictionaryWrapper != null);
                        ReadJsonCollection(ref reader, dictionaryWrapper!, itemBuilder, options, context);
                        collectionWrapper.AddItem(dictionaryWrapper!.ToCollection(), propertyName);
                    }
                    else if (jsonModel is not null)
                    {
                        collectionWrapper.AddItem(jsonModel!.Create(ref reader, options), propertyName);
                    }
                    else
                    {
                        throw new FormatException("Unexpected JsonTokenType.StartObject found.");
                    }
                    break;
                case JsonTokenType.StartArray:
                    if (isElementDictionary)
                    {
                        throw new FormatException("Unexpected JsonTokenType.StartArray found.");
                    }

                    var listWrapper = itemBuilder.CreateObject() as ModelReaderWriterTypeBuilder.CollectionWrapper;
                    if (listWrapper is not null)
                    {
                        ReadJsonCollection(ref reader, listWrapper!, itemBuilder, options, context);
                        collectionWrapper.AddItem(listWrapper!.ToCollection(), propertyName);
                    }
                    else
                    {
                        Debug.Assert(jsonModel != null);
                        collectionWrapper.AddItem(jsonModel!.Create(ref reader, options), propertyName);
                    }
                    break;
                case JsonTokenType.EndArray:
                    return;
                case JsonTokenType.PropertyName:
                    propertyName = reader.GetString();
                    break;
                case JsonTokenType.EndObject:
                    return;
                case JsonTokenType.Null:
                    collectionWrapper.AddItem(null, propertyName);
                    break;
                default:
                    throw new FormatException($"Unexpected token {reader.TokenType}.");
            }
        }
    }
}
