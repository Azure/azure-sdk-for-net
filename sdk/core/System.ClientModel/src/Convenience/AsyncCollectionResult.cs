// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace System.ClientModel.Primitives;

#pragma warning disable CS1591 // public XML comments
public abstract class AsyncCollectionResult : ClientResult
{
    protected AsyncCollectionResult() : base()
    {
    }

    protected AsyncCollectionResult(PipelineResponse response) : base(response)
    {
    }

    public abstract ContinuationToken? ContinuationToken { get; protected set; }

    public abstract IAsyncEnumerable<BinaryData> AsRawValues();

    public abstract IAsyncEnumerable<ClientResult> AsRawResponses();
}
#pragma warning restore CS1591 // public XML comments
