// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Threading;

namespace System.ClientModel;

#pragma warning disable CS1591 // public XML comments
public abstract class AsyncResultCollection<T> : ClientResult, IAsyncEnumerable<T>
{
    // Overload for  lazily sending request
    protected internal AsyncResultCollection() : base(default)
    {
    }

    protected internal AsyncResultCollection(PipelineResponse response) : base(response)
    {
    }

    public abstract IAsyncEnumerator<T> GetAsyncEnumerator(CancellationToken cancellationToken = default);

    // TODO: take CancellationToken -- question -- does the cancellation token go here or to the enumerator?
    //public static ClientResultCollection<T> Create<TValue>(PipelineResponse response) where TValue : IJsonModel<T>
    public static AsyncResultCollection<TValue> Create<TValue>(PipelineResponse response, CancellationToken cancellationToken = default)
        where TValue : IJsonModel<TValue>
    {
        return StreamingClientResult<TValue>.CreateStreaming<TValue>(response, cancellationToken);
    }

    // TODO: Next - add this!
    //public static AsyncResultCollection<BinaryData> Create(PipelineResponse response)
    //{
    //    return StreamingClientResult<TValue>.Create<TValue>(response);
    //}
}
#pragma warning restore CS1591 // public XML comments
