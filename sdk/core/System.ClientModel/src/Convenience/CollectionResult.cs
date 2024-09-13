// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections;
using System.Collections.Generic;

namespace System.ClientModel.Primitives;

#pragma warning disable CS1591 // public XML comments
public abstract class CollectionResult : ClientResult, IEnumerable
{
    protected CollectionResult() : base()
    {
    }

    protected CollectionResult(PipelineResponse response) : base(response)
    {
    }

    public abstract ContinuationToken? ContinuationToken { get; protected set; }

    public abstract IEnumerable<BinaryData> AsRawValues();

    IEnumerator IEnumerable.GetEnumerator() => AsRawValues().GetEnumerator();
}
#pragma warning restore CS1591 // public XML comments
