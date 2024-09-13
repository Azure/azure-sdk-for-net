// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading;

namespace System.ClientModel.Primitives;

#pragma warning disable CS1591 // public XML comments
public abstract class AsyncCollectionResult : ClientResult, IAsyncEnumerable<object>
{
    protected AsyncCollectionResult() : base()
    {
    }

    protected AsyncCollectionResult(PipelineResponse response) : base(response)
    {
    }

    public abstract ContinuationToken? ContinuationToken { get; protected set; }

    public abstract IAsyncEnumerable<BinaryData> AsRawValues();

    IAsyncEnumerator<object> IAsyncEnumerable<object>.GetAsyncEnumerator(CancellationToken cancellationToken)
        => AsRawValues().GetAsyncEnumerator(cancellationToken);
}
#pragma warning restore CS1591 // public XML comments
