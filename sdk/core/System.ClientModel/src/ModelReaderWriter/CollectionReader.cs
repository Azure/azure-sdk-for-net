// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections;

namespace System.ClientModel.Primitives;

internal abstract class CollectionReader
{
    internal static CollectionReader GetCollectionReader(Type returnType, BinaryData data, IActivatorFactory activatorFactory, ModelReaderWriterOptions options)
    {
        if (options.Format != "J" && options.Format != "W")
        {
            throw new InvalidOperationException($"Format '{options.Format}' is not supported only 'J' or 'W' format can be read as collections");
        }

        if (options.Format == "J")
        {
            return new JsonCollectionReader();
        }
        else // W format
        {
            var persistableModel = GetPersistableModel(returnType, activatorFactory);
            var wireFormat = persistableModel.GetFormatFromOptions(options);
            if (wireFormat == "J" && persistableModel is IJsonModel<object>)
            {
                return new JsonCollectionReader();
            }
            throw new InvalidOperationException($"{persistableModel.GetType().FullName} has a wire format of '{wireFormat}' it must be 'J' to be read as a collection");
        }
    }

    private static IPersistableModel<object> GetPersistableModel(Type returnType, IActivatorFactory activatorFactory)
    {
        var obj = activatorFactory.GetModelInfo(returnType).CreateObject();
        if (obj is IPersistableModel<object> persistableModel)
        {
            return persistableModel;
        }
        else if (obj is CollectionBuilder builder)
        {
            return GetPersistableModelFromEnumerable((IEnumerable)builder.GetBuilder(), activatorFactory);
        }
        throw new InvalidOperationException($"Unable to read type {returnType.FullName} can only read collections of IPersistableModel");
    }

    private static IPersistableModel<object> GetPersistableModelFromEnumerable(IEnumerable enumerable, IActivatorFactory activatorFactory)
    {
        var genericArguments = enumerable.GetType().GetGenericArguments();
        var elementType = enumerable is IDictionary ? genericArguments[1] : genericArguments[0];
        var element = activatorFactory.GetModelInfo(elementType).CreateObject();
        if (element is IPersistableModel<object> persistableModel)
        {
            return persistableModel;
        }
        else if (element is CollectionBuilder builder)
        {
            return GetPersistableModelFromEnumerable((IEnumerable)builder.GetBuilder(), activatorFactory);
        }

        throw new InvalidOperationException($"Unable to read type {enumerable.GetType().FullName} can only read collections of IPersistableModel");
    }

    internal abstract object Read(Type returnType, BinaryData data, IActivatorFactory activatorFactory, ModelReaderWriterOptions options);
}
