// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Generic;

namespace System.ClientModel;

#pragma warning disable CS1591 // public XML comments
public abstract class ResultPage<T> : ResultCollection<T>
{
    // This one only has a constructor that takes a response, because we only
    // have a ResultPage<T> if we have a response
    protected ResultPage(PipelineResponse response) : base(response)
    {
    }

    public static ResultPage<T> Create(IEnumerable<T> values, string? continuationToken, PipelineResponse response)
        => new EnumerablePage(values, continuationToken, response);

    public string? ContinuationToken { get; protected set; }

    private class EnumerablePage : ResultPage<T>
    {
        private readonly IEnumerable<T> _values;

        public EnumerablePage(IEnumerable<T> values, string? continuationToken, PipelineResponse response)
            : base(response)
        {
            _values = values;
            ContinuationToken = continuationToken;
        }

        public override IEnumerator<T> GetEnumerator()
            => _values.GetEnumerator();
    }
}
#pragma warning restore CS1591 // public XML comments
