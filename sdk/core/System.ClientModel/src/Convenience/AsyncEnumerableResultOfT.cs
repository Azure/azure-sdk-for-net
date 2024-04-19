// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Threading;

namespace System.ClientModel;

#pragma warning disable CS1591 // public XML comments
public abstract class AsyncEnumerableResult<T> : ClientResult, IAsyncEnumerable<T>
{
    protected internal AsyncEnumerableResult(PipelineResponse response) : base(response)
    {
    }

    public abstract IAsyncEnumerator<T> GetAsyncEnumerator(CancellationToken cancellationToken = default);
}
#pragma warning restore CS1591 // public XML comments
