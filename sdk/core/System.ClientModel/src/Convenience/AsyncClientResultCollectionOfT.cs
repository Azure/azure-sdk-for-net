// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Threading;

namespace System.ClientModel;

#pragma warning disable CS1591 // public XML comments
public abstract class AsyncClientResultCollection<T> : ClientResult, IAsyncEnumerable<T>
{
    protected internal AsyncClientResultCollection(PipelineResponse response) : base(response)
    {
    }

    public abstract IAsyncEnumerator<T> GetAsyncEnumerator(CancellationToken cancellationToken = default);

    // TODO: take CancellationToken?
    //public static ClientResultCollection<T> Create<TValue>(PipelineResponse response) where TValue : IJsonModel<T>
    public static AsyncClientResultCollection<TValue> Create<TValue>(PipelineResponse response) where TValue : IJsonModel<TValue>
    {
        return StreamingClientResult<TValue>.Create<TValue>(response);
    }
}
#pragma warning restore CS1591 // public XML comments
