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
        : base(pageToken, nextPageToken, response)
    {
        Values = values;
    }

    // The values in the page
    public IReadOnlyList<T> Values { get; }
}

#pragma warning restore CS1591
