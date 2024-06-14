// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace System.ClientModel.Primitives;

#pragma warning disable CS1591
public abstract class PageToken : IPersistableModel<PageToken>
{
    protected PageToken(bool hasResponseValues)
    {
        HasResponseValues = hasResponseValues;
    }

    // Indicates whether or not the page token contains values from a service
    // response that would cause the next page request to be created
    // differently.
    public bool HasResponseValues { get; protected set; }

    // TODO: should this enforce that we can rehydrate the token?

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
