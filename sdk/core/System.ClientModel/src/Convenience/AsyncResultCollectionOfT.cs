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
    // TODO: Consider signature: `public static ClientResultCollection<T> Create<TValue>(PipelineResponse response) where TValue : IJsonModel<T>` ?
    // TODO: terminal event can be a model type as well ... are we happy using string for now and adding an overload if needed later?
    public static AsyncResultCollection<TValue> Create<TValue>(PipelineResponse response, CancellationToken cancellationToken = default)
        where TValue : IJsonModel<TValue>
    {
        Argument.AssertNotNull(response, nameof(response));

        if (response.ContentStream is null)
        {
            throw new ArgumentException("Unable to create result from response with null ContentStream", nameof(response));
        }

        // TODO: correct pattern for cancellation token
        return new AsyncSseValueResultCollection<TValue>(response);
    }

    public static AsyncResultCollection<BinaryData> Create(PipelineResponse response, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNull(response, nameof(response));

        if (response.ContentStream is null)
        {
            throw new ArgumentException("Unable to create result from response with null ContentStream", nameof(response));
        }

        // TODO: correct pattern for cancellation token
        return new AsyncSseDataResultCollection(response);
    }
}
#pragma warning restore CS1591 // public XML comments
