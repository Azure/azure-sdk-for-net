// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;

namespace System.ClientModel;

public class OptionalClientResult<T> : ClientResult
{
    private readonly T? _value;

    protected internal OptionalClientResult(T? value, PipelineResponse response) : base(response)
        => _value = value;

    /// <summary>
    /// Gets the value returned by the service. Accessing this property will throw if <see cref="HasValue"/> is false.
    /// </summary>
    public virtual T? Value => _value;

    /// <summary>
    /// Gets a value indicating whether the current instance has a non-null value.
    /// </summary>
    public virtual bool HasValue => _value != null;
}
