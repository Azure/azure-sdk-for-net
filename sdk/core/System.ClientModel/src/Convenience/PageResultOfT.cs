// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Generic;

namespace System.ClientModel;

#pragma warning disable CS1591

public abstract class PageResult<T> : PageResult
{
    protected PageResult(IReadOnlyList<T> values,
        ContinuationToken pageToken,
        ContinuationToken? nextPageToken,
        PipelineResponse response)
        : base(nextPageToken is not null, response)
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
    public ContinuationToken PageToken { get; }

    // If this is null, the current page is the last page in a collection.
    public ContinuationToken? NextPageToken { get; }
}

#pragma warning restore CS1591
