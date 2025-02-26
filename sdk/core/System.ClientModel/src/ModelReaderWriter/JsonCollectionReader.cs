// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections;
using System.Collections.Generic;
using System.Text.Json;

namespace System.ClientModel.Primitives;

internal class JsonCollectionReader : CollectionReader
{
    private string _paramName;

    internal JsonCollectionReader(string paramName)
    {
        _paramName = paramName;
    }

    internal override object Read(Type returnType, BinaryData data, IActivatorFactory activatorFactory, ModelReaderWriterOptions options)
    {
        object collection = activatorFactory.CreateObject(returnType);
        Utf8JsonReader reader = new Utf8JsonReader(data);
        reader.Read();
        var genericType = returnType.GetGenericTypeDefinition();
        if (genericType.Equals(typeof(Dictionary<,>)))
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
        ReadJsonCollection(ref reader, collection, options, activatorFactory);
        return collection;
    }

    private void ReadJsonCollection(
        ref Utf8JsonReader reader,
        object collection,
        ModelReaderWriterOptions options,
        IActivatorFactory activatorFactory)
    {
        int argNumber = collection is IDictionary ? 1 : 0;
        Type elementType = collection.GetType().GetGenericArguments()[argNumber];
        if (elementType.IsArray)
        {
            throw new ArgumentException("Arrays are not supported. Use List<> instead.");
        }
        Type? elementGenericType = elementType.IsGenericType ? elementType.GetGenericTypeDefinition() : null;
        if (elementGenericType is not null && !ModelReaderWriter.s_supportedCollectionTypes.Contains(elementGenericType))
        {
            throw new ArgumentException($"Collection Type {elementGenericType.FullName} is not supported.", _paramName);
        }

        bool isElementDictionary = elementGenericType is not null && elementGenericType.Equals(typeof(Dictionary<,>));

        IJsonModel<object>? iJsonModel = elementGenericType is null
            ? ModelReaderWriter.GetInstance(elementType, activatorFactory) as IJsonModel<object>
            : activatorFactory.CreateObject(elementType) as IJsonModel<object>;
        if (elementGenericType is null && iJsonModel is null)
        {
            throw new InvalidOperationException($"Element type {elementType.FullName} must implement IJsonModel");
        }
        bool isInnerCollection = iJsonModel is null;
        string? propertyName = null;

        while (reader.Read())
        {
            switch (reader.TokenType)
            {
                case JsonTokenType.StartObject:
                    if (isInnerCollection)
                    {
                        if (isElementDictionary)
                        {
                            var innerDictionary = activatorFactory.CreateObject(elementType);
                            AddItemToCollection(collection, propertyName, innerDictionary);
                            ReadJsonCollection(ref reader, innerDictionary, options, activatorFactory);
                        }
                        else
                        {
                            throw new FormatException("Unexpected StartObject found.");
                        }
                    }
                    else
                    {
                        AddItemToCollection(collection, propertyName, iJsonModel!.Create(ref reader, options));
                    }
                    break;
                case JsonTokenType.StartArray:
                    if (!isInnerCollection || isElementDictionary)
                    {
                        throw new FormatException("Unexpected StartArray found.");
                    }

                    object innerList = activatorFactory.CreateObject(elementType);
                    AddItemToCollection(collection, propertyName, innerList);
                    ReadJsonCollection(ref reader, innerList, options, activatorFactory);
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
