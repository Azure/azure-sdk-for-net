// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;

namespace System.ClientModel;

public abstract class OptionalOutputMessage<T> : OutputMessage
{
    private readonly T? _value;

    protected OptionalOutputMessage(T? value, PipelineResponse response) : base(response)
        => _value = value;

    public virtual T? Value => _value;

    public virtual bool HasValue => _value != null;
}
