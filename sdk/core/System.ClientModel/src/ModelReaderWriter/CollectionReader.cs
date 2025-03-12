// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace System.ClientModel.Primitives;

internal abstract class CollectionReader
{
    internal static CollectionReader GetCollectionReader(CollectionWrapper builder, ModelReaderWriterOptions options)
    {
        //For info on the different formats see the comments in ModelReaderWriterOptions.cs
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
            var element = builder.CreateElement();
            if (element is not IPersistableModel<object> persistableModel)
            {
                throw new InvalidOperationException($"'{element?.GetType().Name}' must implement IPersistableModel");
            }
            var wireFormat = persistableModel.GetFormatFromOptions(options);
            if (wireFormat == "J" && persistableModel is IJsonModel<object>)
            {
                return new JsonCollectionReader();
            }
            throw new InvalidOperationException($"{persistableModel.GetType().Name} has a wire format of '{wireFormat}' it must be 'J' to be read as a collection");
        }
    }

    internal abstract object Read(CollectionWrapper builder, BinaryData data, ModelReaderWriterContext context, ModelReaderWriterOptions options);
}
