// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;

namespace System.ClientModel;

/// <summary>
/// Represents the result of a cloud service operation, and provides a
/// strongly-typed representation of the service response value.
/// </summary>
/// <typeparam name="T">The type of the value returned in the service response.
/// </typeparam>
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

    /// <summary>
    /// Returns the value of this <see cref="ClientResult{T}"/> object.
    /// </summary>
    /// <param name="result">The <see cref="ClientResult{T}"/> instance.</param>
    public static implicit operator T(ClientResult<T> result)
    {
        if (result == null)
        {
#pragma warning disable CA1065 // Don't throw from cast operators
            throw new ArgumentNullException(nameof(result), $"The implicit cast from ClientResult<{typeof(T)}> to {typeof(T)} failed because the ClientResult<{typeof(T)}> was null.");
#pragma warning restore CA1065
        }

        return result.Value!;
    }
}
