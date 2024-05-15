// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Generic;

namespace System.ClientModel;

#pragma warning disable CS1591 // public XML comments
public class ResultPage<T> : ResultCollection<T>
{
    private readonly IEnumerable<T> _values;

    // This one only has a constructor that takes a response, because we only
    // have a ResultPage<T> if we have a response
    public ResultPage(IEnumerable<T> values, string? continuationToken, PipelineResponse response)
        : base(response)
    {
        _values = values;
        ContinuationToken = continuationToken;
    }

    public string? ContinuationToken { get; }

    public override IEnumerator<T> GetEnumerator()
        => _values.GetEnumerator();
}
#pragma warning restore CS1591 // public XML comments
