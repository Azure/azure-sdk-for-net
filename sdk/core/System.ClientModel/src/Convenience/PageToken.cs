// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace System.ClientModel.Primitives;

#pragma warning disable CS1591
public abstract class PageToken : IPersistableModel<PageToken>
{
    protected PageToken()
    {
    }

    // The first page of the collection the page that this page token represents
    // is in.  Essentially, the rehydration token for the collection.
    // Having this property lets any token for a page in the collection rehydrate
    // the collection with full context about how to retrieve the first page of
    // the collection and then also the current page within it.
    protected abstract PageToken FirstPageToken { get; }

    protected abstract BinaryData WriteCore(ModelReaderWriterOptions options);
    protected abstract PageToken CreateCore(BinaryData data, ModelReaderWriterOptions options);
    protected abstract string GetFormatFromOptionsCore(ModelReaderWriterOptions options);

    BinaryData IPersistableModel<PageToken>.Write(ModelReaderWriterOptions options)
        => WriteCore(options);

    PageToken IPersistableModel<PageToken>.Create(BinaryData data, ModelReaderWriterOptions options)
        => CreateCore(data, options);

    string IPersistableModel<PageToken>.GetFormatFromOptions(ModelReaderWriterOptions options)
        => GetFormatFromOptionsCore(options);
}
#pragma warning restore CS1591
