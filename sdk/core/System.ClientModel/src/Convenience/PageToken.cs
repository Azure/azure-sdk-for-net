// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;

namespace System.ClientModel;

#pragma warning disable CS1591
public abstract class PageToken : IPersistableModel<PageToken>
{
    protected PageToken(PageToken firstPageToken)
    {
        FirstCollectionPage = firstPageToken;
    }

    // The first page of the collection the page that this page token represents
    // is in.  Essentially, the rehydration token for the collection.
    public PageToken FirstCollectionPage { get; }

    public abstract BinaryData Write(ModelReaderWriterOptions options);
    public abstract PageToken Create(BinaryData data, ModelReaderWriterOptions options);
    public abstract string GetFormatFromOptions(ModelReaderWriterOptions options);
}
#pragma warning restore CS1591
