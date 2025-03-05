﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.Json;

namespace System.ClientModel.Primitives;

internal class JsonCollectionReader : CollectionReader
{
    internal override object Read(Type returnType, CollectionBuilder builder, BinaryData data, ModelReaderWriterContext context, ModelReaderWriterOptions options)
    {
        Utf8JsonReader reader = new Utf8JsonReader(data);
        reader.Read();
        var genericType = returnType.IsGenericType ? returnType.GetGenericTypeDefinition() : null;
        if (genericType?.Equals(typeof(Dictionary<,>)) == true)
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
        ReadJsonCollection(ref reader, builder, options, context);
        return builder.ToObject();
    }

    private void ReadJsonCollection(
        ref Utf8JsonReader reader,
        CollectionBuilder collectionBuilder,
        ModelReaderWriterOptions options,
        ModelReaderWriterContext context)
    {
        object collection = collectionBuilder.GetBuilder();
        int argNumber = collection is IDictionary ? 1 : 0;
        Type elementType = collection.GetType().GetGenericArguments()[argNumber];

        bool isInnerCollection = false;
        bool isElementDictionary = false;
        IJsonModel<object>? jsonModel = null;
        string? propertyName = null;

        var elementInfo = context.GetModelInfoInternal(elementType);
        var element = elementInfo.CreateObject();
        if (element is CollectionBuilder elementBuilder)
        {
            isInnerCollection = true;
            isElementDictionary = elementBuilder.GetBuilder() is IDictionary;
        }
        else if (element is IJsonModel<object> iJsonModel)
        {
            jsonModel = iJsonModel;
        }
        else
        {
            throw new InvalidOperationException($"Element type {elementType.Name} must implement IJsonModel or CollectionBuilder");
        }

        while (reader.Read())
        {
            switch (reader.TokenType)
            {
                case JsonTokenType.StartObject:
                    if (isInnerCollection)
                    {
                        if (isElementDictionary)
                        {
                            var dictionaryBuilder = elementInfo.CreateObject() as CollectionBuilder;
                            Debug.Assert(dictionaryBuilder != null);
                            ReadJsonCollection(ref reader, dictionaryBuilder!, options, context);
                            collectionBuilder.AddItem(dictionaryBuilder!.ToObject(), propertyName);
                        }
                        else
                        {
                            throw new FormatException("Unexpected StartObject found.");
                        }
                    }
                    else
                    {
                        Debug.Assert(jsonModel != null);
                        collectionBuilder.AddItem(jsonModel!.Create(ref reader, options), propertyName);
                    }
                    break;
                case JsonTokenType.StartArray:
                    if (!isInnerCollection || isElementDictionary)
                    {
                        throw new FormatException("Unexpected StartArray found.");
                    }

                    var listBuilder = elementInfo.CreateObject() as CollectionBuilder;
                    Debug.Assert(listBuilder != null);
                    ReadJsonCollection(ref reader, listBuilder!, options, context);
                    collectionBuilder.AddItem(listBuilder!.ToObject(), propertyName);
                    break;
                case JsonTokenType.EndArray:
                    return;
                case JsonTokenType.PropertyName:
                    propertyName = reader.GetString();
                    break;
                case JsonTokenType.EndObject:
                    return;
                default:
                    throw new FormatException($"Unexpected token {reader.TokenType}.");
            }
        }
    }
}
