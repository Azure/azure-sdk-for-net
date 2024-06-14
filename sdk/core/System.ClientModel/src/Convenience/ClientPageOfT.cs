// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Generic;

// Lives in .Primitives because it's intended to be inherited from to create
// a service-specific instance.
namespace System.ClientModel;

#pragma warning disable CS1591
public class ClientPage<T> : ClientResult
{
    private ClientPage(IReadOnlyList<T> values,
        BinaryData pageToken,
        BinaryData? nextPageToken,
        PipelineResponse response) : base(response)
    {
        Values = values;
        PageToken = pageToken;
        NextPageToken = nextPageToken;
    }

    // The values in the page
    public IReadOnlyList<T> Values { get; }

    // The token used to retrieve this page -- can uniquely request
    // the page AND uniquely rehydrate a page collection that this is
    // a page in (first, page 5, whatever).
    // i.e. it completely describes a collection where this is a page
    // in it.
    // This is useful because I can cache this and retrive both the
    // full collection this page is in and/or the current page.
    public BinaryData PageToken { get; }

    // If this is null, the current page is the last page in a collection.
    public BinaryData? NextPageToken { get; }

    public static  ClientPage<T> Create(IReadOnlyList<T> values, BinaryData pageToken, BinaryData? nextPageToken, PipelineResponse response)
        => new(values, pageToken, nextPageToken, response);
}
#pragma warning restore CS1591
