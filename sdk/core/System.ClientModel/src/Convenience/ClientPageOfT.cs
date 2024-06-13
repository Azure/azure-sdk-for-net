// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

// Lives in .Primitives because it's intended to be inherited from to create
// a service-specific instance.
namespace System.ClientModel.Primitives;

#pragma warning disable CS1591
public class ClientPage<TValue, TPageToken> : ClientResult
    where TPageToken : IPersistableModel<TPageToken>
{
    protected ClientPage(IReadOnlyList<TValue> values,
        TPageToken pageToken,
        TPageToken? nextPageToken,
        PipelineResponse response) : base(response)
    {
        Values = values;
        PageToken = pageToken;
        NextPageToken = nextPageToken;
    }

    // The values in the page
    public IReadOnlyList<TValue> Values { get; }

    // The token used to retrieve this page -- can uniquely request
    // the page AND uniquely rehydrate a page collection that this is
    // a page in (first, page 5, whatever).
    // i.e. it completely describes a collection where this is a page
    // in it.
    // This is useful because I can cache this and retrive both the
    // full collection this page is in and/or the current page.
    public TPageToken PageToken { get; }

    // If this is null, the current page is the last page in a collection.
    public TPageToken? NextPageToken { get; }
}
#pragma warning restore CS1591
