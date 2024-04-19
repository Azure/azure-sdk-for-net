// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections;
using System.Collections.Generic;

namespace System.ClientModel;

#pragma warning disable CS1591 // public XML comments
public abstract class EnumerableClientResult<T> : ClientResult, IEnumerable<T>
{
    protected internal EnumerableClientResult(PipelineResponse response) : base(response)
    {
    }

    public abstract IEnumerator<T> GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
#pragma warning restore CS1591 // public XML comments
