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
    // Constructor overload for collection implementations that postpone
    // sending a request until GetAsyncEnumerator is called. This will typically
    // be used by collections returned from client convenience methods.
    protected internal AsyncResultCollection() : base(default)
    {
    }

    // Constructor overload for collection implementations where the service
    // has returned a response.  This will typically be used by collections
    // created from the return result of a client's protocol method.
    protected internal AsyncResultCollection(PipelineResponse response) : base(response)
    {
    }

    public static AsyncResultCollection<BinaryData> Create(PipelineResponse response, string terminalEvent)
    {
        Argument.AssertNotNull(response, nameof(response));

        if (response.ContentStream is null)
        {
            throw new ArgumentException("Unable to create result collection from PipelineResponse with null ContentStream", nameof(response));
        }

        return new AsyncSseDataEventCollection(response, terminalEvent);
    }

    public abstract IAsyncEnumerator<T> GetAsyncEnumerator(CancellationToken cancellationToken = default);

    // TODO: what input does it take?
    //public virtual bool CloseStream() { }
}
#pragma warning restore CS1591 // public XML comments
