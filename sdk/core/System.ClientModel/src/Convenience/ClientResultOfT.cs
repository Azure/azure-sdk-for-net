// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;

namespace System.ClientModel;

public class ClientResult<T> : ClientResult
{
    protected internal ClientResult(T value, PipelineResponse response)
        : base(response)
    {
        Value = value;
    }

    public virtual T Value { get; }
}
