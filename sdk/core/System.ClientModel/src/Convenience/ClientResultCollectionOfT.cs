// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections;
using System.Collections.Generic;

namespace System.ClientModel;

#pragma warning disable CS1591 // public XML comments
public abstract class ClientResultCollection<T> : ClientResult, IEnumerable<T>
{
    // Constructor overload for collection implementations that postpone
    // sending a request until GetAsyncEnumerator is called. This will typically
    // be used by collections returned from client convenience methods.
    protected internal ClientResultCollection() : base()
    {
    }

    // Constructor overload for collection implementations where the service
    // has returned a response.  This will typically be used by collections
    // created from the return result of a client's protocol method.
    protected internal ClientResultCollection(PipelineResponse response) : base(response)
    {
    }

    public abstract IEnumerator<T> GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
#pragma warning restore CS1591 // public XML comments
