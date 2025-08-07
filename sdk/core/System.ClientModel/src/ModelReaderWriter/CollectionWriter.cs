// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using System.Collections;

namespace System.ClientModel.Primitives;

internal abstract class CollectionWriter
{
    internal static CollectionWriter GetCollectionWriter(IEnumerable enumerable, ModelReaderWriterOptions options)
    {
        //For info on the different formats see the comments in ModelReaderWriterOptions.cs
        if (options.Format != "J" && options.Format != "W")
        {
            throw new InvalidOperationException($"Format '{options.Format}' is not supported.  Only 'J' or 'W' format can be written as collections");
        }

        if (options.Format == "J")
        {
            return new JsonCollectionWriter();
        }
        else // W format
        {
            var persistableModel = GetIPersistableModel(enumerable);
            var wireFormat = persistableModel.GetFormatFromOptions(options);
            if (wireFormat == "J" && persistableModel is IJsonModel<object>)
            {
                return new JsonCollectionWriter();
            }
            throw new InvalidOperationException($"{persistableModel.GetType().ToFriendlyName()} has a wire format of '{wireFormat}'.  It must be 'J' to be written as a collection");
        }
    }

    private static IPersistableModel<object> GetIPersistableModel(IEnumerable enumerable)
    {
        object first = GetFirstObject(enumerable);
        if (first is IEnumerable nextEnumerable)
        {
            return GetIPersistableModel(nextEnumerable);
        }
        else if (first is IPersistableModel<object> persistableModel)
        {
            return persistableModel;
        }
        else
        {
            throw new InvalidOperationException($"Unable to write {enumerable.GetType().ToFriendlyName()}.  Only collections of 'IPersistableModel' can be written.");
        }
    }

    private static object GetFirstObject(IEnumerable enumerable)
    {
        if (enumerable is IDictionary dictionary)
        {
            foreach (var key in dictionary.Keys)
            {
                var value = dictionary[key];
                if (value is not null)
                {
                    return value;
                }
            }
            throw new InvalidOperationException($"Can't use format 'W' format on an empty collection.  Please specify a concrete format");
        }

        var enumerator = enumerable.GetEnumerator();
        if (enumerator.MoveNext())
        {
            return enumerator.Current;
        }

        throw new InvalidOperationException($"Can't use format 'W' format on an empty collection.  Please specify a concrete format");
    }

    internal abstract BinaryData Write(IEnumerable enumerable, ModelReaderWriterOptions options);
}
