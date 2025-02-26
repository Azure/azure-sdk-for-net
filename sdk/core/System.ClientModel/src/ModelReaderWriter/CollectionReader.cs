// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace System.ClientModel.Primitives;

internal abstract class CollectionReader
{
    internal static CollectionReader GetCollectionReader(Type returnType, BinaryData data, IActivatorFactory activatorFactory, string paramName, ModelReaderWriterOptions options)
    {
        if (options.Format != "J" && options.Format != "W")
        {
            throw new InvalidOperationException($"Format '{options.Format}' is not supported only 'J' or 'W' format can be read as collections");
        }

        if (options.Format == "J")
        {
            return new JsonCollectionReader(paramName);
        }
        else // W format
        {
            var persistableModel = GetPersistableModel(returnType, activatorFactory);
            var wireFormat = persistableModel.GetFormatFromOptions(options);
            if (wireFormat == "J" && persistableModel is IJsonModel<object>)
            {
                return new JsonCollectionReader(paramName);
            }
            throw new InvalidOperationException($"{persistableModel.GetType().FullName} has a wire format of '{wireFormat}' it must be 'J' to be read as a collection");
        }
    }

    private static IPersistableModel<object> GetPersistableModel(Type returnType, IActivatorFactory activatorFactory)
    {
        var obj = activatorFactory.CreateObject(returnType);
        if (obj is IPersistableModel<object> persistableModel)
        {
            return persistableModel;
        }
        else if (obj is IEnumerable enumerable)
        {
            return GetPersistableModelFromEnumerable(enumerable, activatorFactory);
        }
        throw new InvalidOperationException($"Unable to read type {returnType.FullName} can only read collections of IPersistableModel");
    }

    private static IPersistableModel<object> GetPersistableModelFromEnumerable(IEnumerable enumerable, IActivatorFactory activatorFactory)
    {
        var genericArguments = enumerable.GetType().GetGenericArguments();
        var elementType = enumerable is IDictionary ? genericArguments[1] : genericArguments[0];
        var element = activatorFactory.CreateObject(elementType);
        if (element is IPersistableModel<object> persistableModel)
        {
            return persistableModel;
        }
        else if (element is IEnumerable enumerableElement)
        {
            return GetPersistableModelFromEnumerable(enumerableElement, activatorFactory);
        }

        throw new InvalidOperationException($"Unable to read type {enumerable.GetType().FullName} can only read collections of IPersistableModel");
    }

    internal abstract object Read(Type returnType, BinaryData data, IActivatorFactory activatorFactory, ModelReaderWriterOptions options);

    protected static void AddItemToCollection(object collection, string? key, object item)
    {
        if (collection is IDictionary dictionary)
        {
            if (key is null)
            {
                //we should never get here because System.Text.Json will throw JsonReaderException if there was no property name
                throw new FormatException("Null key found for dictionary entry.");
            }
            dictionary.Add(key, item);
        }
        else if (collection is IList list)
        {
            list.Add(item);
        }
        else
        {
            //we should never be able to get here since we check for supported collection types in ReadCollection
            throw new InvalidOperationException($"Collection type {collection.GetType().Name} is not supported.");
        }
    }
}
