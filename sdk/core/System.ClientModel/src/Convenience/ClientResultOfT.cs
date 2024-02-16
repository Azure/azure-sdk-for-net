// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;

namespace System.ClientModel;

/// <summary>
/// Represents the result of a cloud service operation, and provides a
/// strongly-typed representation of the service response value.
/// </summary>
/// <typeparam name="T"></typeparam>
public class ClientResult<T> : ClientResult
{
    /// <summary>
    /// Creates a new instance of <see cref="ClientResult{T}"/> that holds the
    /// provided model value and <see cref="PipelineResponse"/> received from
    /// the service.
    /// </summary>
    /// <param name="value">The strongly-typed representation of the service
    /// response payload value.</param>
    /// <param name="response">The response received from the service.</param>
    protected internal ClientResult(T value, PipelineResponse response)
        : base(response)
    {
        Value = value;
    }

    /// <summary>
    /// Gets the value received from the service.
    /// </summary>
    public virtual T Value { get; }
}
